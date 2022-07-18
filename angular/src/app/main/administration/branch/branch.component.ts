import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil, finalize } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, UpsertBranchDto, BranchListItemDto, GetBranchInitialDataDto,
    IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto, PagedResultDtoOfBranchListItemDto, PatchBranchCurrencyTypeCommand,
    ReadCommonShareServiceProxy
} from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { Router } from '@angular/router';

/**
 * Main component for branch
 */
@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase implements OnInit, OnDestroy {

    destroy$ = new Subject();
    loading: boolean = false;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];
    actionButtons: ActionButton[] = [];
    branchCrudModes = BranchCrudModes;
    activeCrudMode = BranchCrudModes.List;
    filters: { filterText: string } = { filterText: '' };
    branchId: number;
    currencyTypeId: number;
    branchCurrencyType = new BranchCurrencyTypeDto();
    upsertBranchDto = new UpsertBranchDto();
    initialDropdownData = new GetBranchInitialDataDto();
    logoFile: File = null;
    isAccountNumberValid: boolean = true;
    selectedDate = new Date();
    creationTime = new Date();
    lastModificationTime = new Date();

    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
        private _commonServiceProxy: ReadCommonShareServiceProxy,
        private _router: Router,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.initBranch();
        this.initActionButtons();
        this.setInitialDropdownData();
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    isViewMode(): boolean {
        return this.activeCrudMode === this.branchCrudModes.View;
    }

    addOnClick(): void {
        this.initBranch();
        this.branchId = null;
        this.currencyTypeId = null;
        this.activeCrudMode = BranchCrudModes.Add;
    }

    cancelOnClick(): void {
        if (this.activeCrudMode === BranchCrudModes.List) {
            this._router.navigate(['app', 'main', 'administration']);
        } else {
            this.paginator.changePage(this.paginator.getPage());
            this.activeCrudMode = BranchCrudModes.List;
        }
    }

    saveOnClick(): void {
        return this.branchId
            ? this.updateBranch()
            : this.addBranch();
    }

    viewOnClick(branchId: number): void {
        this.branchId = branchId;
        this.activeCrudMode = BranchCrudModes.View;
        this.getBranch(branchId);
    }

    editOnClick(branchId: number): void {
        this.branchId = branchId;
        this.activeCrudMode = BranchCrudModes.Edit;
        this.getBranch(branchId);
    }

    itemDeleteOnClick(): void {
        if (this.branchId) {
            this.deleteBranch(this.branchId, this.upsertBranchDto.name);
        }
    }

    rowDeleteOnClick(branch: BranchListItemDto): void {
        this.deleteBranch(branch.id, branch.name);
    }

    getBrances(event?: LazyLoadEvent): void {
        if (!this.dataTable || !this.paginator) {
            return;
        }
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }
        this.primengTableHelper.showLoadingIndicator();

        this._branchesService.getAllPaged(
            this.filters.filterText,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event)
        ).pipe(
            takeUntil(this.destroy$),
            finalize(() => this.primengTableHelper.hideLoadingIndicator())
        ).subscribe((x: PagedResultDtoOfBranchListItemDto) => {
            this.primengTableHelper.totalRecordsCount = x.totalCount;
            this.primengTableHelper.records = x.items;
        });
    }

    currencyTypeOnChange(): void {
        if (this.branchId && this.currencyTypeId) {
            this._branchesService.getBranchCurrencyType(this.branchId, this.currencyTypeId)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    deleteBranchCurrencyType(): void {
        if (this.branchId && this.currencyTypeId) {
            this.branchCurrencyType = new BranchCurrencyTypeDto();
            const patchBranchCurrencyTypeCommand = new PatchBranchCurrencyTypeCommand();
            this._branchesService.patchBranchCurrencyType(this.branchId, this.currencyTypeId, patchBranchCurrencyTypeCommand)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    updateBranchCurrencyType(): void {
        if (this.branchId && this.currencyTypeId) {
            const patchBranchCurrencyTypeCommand = new PatchBranchCurrencyTypeCommand({
                branchId: -1,
                currencyTypeId: -1,
                arAccountNo: this.branchCurrencyType.arAccountNo,
                debitAccount: this.branchCurrencyType.debitAccount,
                creditAccount: this.branchCurrencyType.creditAccount,
                debitAccountReevaluate: this.branchCurrencyType.debitAccountReevaluate,
                creditAccountReevaluate: this.branchCurrencyType.creditAccountReevaluate,
            });

            this._branchesService.patchBranchCurrencyType(this.branchId, this.currencyTypeId, patchBranchCurrencyTypeCommand)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    acountsReceivableGLAccountNumberOnChange(): void {
        if (this.upsertBranchDto.receivable) {
            this._branchesService.getChartOfAccountDetails(this.upsertBranchDto.receivable)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        }
    }

    zipCodeOnChange(): void {
        if (this.upsertBranchDto.zipCode) {
            this._branchesService.getZipCodeDetails(this.upsertBranchDto.zipCode)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: IGetZipCodeDetailsDto) => {
                    if (!_isEmpty(x)) {
                        this.upsertBranchDto.city = x.city;
                        this.upsertBranchDto.state = x.state;
                    }
                });
        }
    }

    branchAccountsReceivablesOnChange(e: any): void {
        if (e.value) {
            this.upsertBranchDto.receivable = this.initialDropdownData.accountsReceivables.find(x => x.id === e.value).accountReceivable;
        }
    }

    private setInitialDropdownData(): void {
        this._branchesService.getInitialData()
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: GetBranchInitialDataDto) => {
                this.initialDropdownData = x;
            });
    }

    private getBranch(branchId: number): void {
        this._branchesService.get(branchId)
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: UpsertBranchDto) => {
                this.upsertBranchDto = x;
                this.selectedDate = this.upsertBranchDto.rentalDeliveryDefaultTime?.toJSDate();
            });
    }

    private addBranch(): void {
        this._branchesService.create(this.upsertBranchDto, this.getFileParameterFromFile(this.logoFile))
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: UpsertBranchDto) => {
                this.activeCrudMode = BranchCrudModes.List;
                this.paginator.changePage(this.paginator.getPage());
                this.notifyService.success(this.l('SuccessfullyAdded'));
            });
    }

    private updateBranch(): void {
        this._branchesService.update(this.upsertBranchDto.id, this.upsertBranchDto, this.getFileParameterFromFile(this.logoFile))
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: UpsertBranchDto) => {
                this.upsertBranchDto = x;
                this.selectedDate = this.upsertBranchDto.rentalDeliveryDefaultTime?.toJSDate();
                this.notifyService.success(this.l('UpdateSuccessfully'));
            });
    }

    private deleteBranch(branchId: number, branchName: string): void {
        this.message.confirm(
            this.l('BranchDeleteWarningMessage', branchName),
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this.loading = true;
                    this._branchesService.delete(branchId).subscribe(() => {
                        this.branchCurrencyType = new BranchCurrencyTypeDto();
                        this.initBranch();
                        this.branchId = null;
                        this.currencyTypeId = null;
                        this.activeCrudMode = BranchCrudModes.List;
                        this.paginator.changePage(this.paginator.getPage());
                        this.notifyService.success(this.l('SuccessfullyDeleted'));
                    }, () => {

                    }, () => {
                        this.loading = false;
                    });
                }
            }
        );
    }

    private initBranch(): void {
        this.upsertBranchDto = new UpsertBranchDto();
        this.upsertBranchDto.init({});
    }

    private initActionButtons(): void {
        this.actionButtons = [
            { name: this.l('Cancel'), cssClass: 'btn-secondary', activeCrudModes: [BranchCrudModes.Add, BranchCrudModes.Edit], action: () => this.cancelOnClick() },
            { name: this.l('Close'), cssClass: 'btn-secondary', activeCrudModes: [BranchCrudModes.List, BranchCrudModes.View], action: () => this.cancelOnClick() },
            { name: this.l('Delete'), cssClass: 'btn-danger', activeCrudModes: [BranchCrudModes.Edit], action: () => this.itemDeleteOnClick() },
            { name: this.l('Branch'), cssClass: 'btn-primary', iconClass: 'fa fa-plus', activeCrudModes: [BranchCrudModes.List], action: () => this.addOnClick() },
            { name: this.l('Save'), cssClass: 'btn-primary', iconClass: 'fa fa-save', activeCrudModes: [BranchCrudModes.Add, BranchCrudModes.Edit], action: () => this.saveOnClick() },
        ];
    }

    onChangeFile(event: File) {
        this.logoFile = event;
    }
}

export class ActionButton {
    name: string;
    cssClass: string;
    iconClass?: string;
    activeCrudModes: BranchCrudModes[];
    action: (argument?: () => any) => void;
}

export enum BranchCrudModes {
    List = 1,
    View,
    Add,
    Edit
}
