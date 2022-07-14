import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil, finalize } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, BranchForEditDto, BranchListItemDto, CreateBranchCommand, GetBranchInitialDataDto,
    IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto, PagedResultDtoOfBranchListItemDto, PatchBranchCurrencyTypeCommand,
    ReadCommonShareServiceProxy, UpdateBranchCommand
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
    branchForEdit = new BranchForEditDto();
    initialDropdownData = new GetBranchInitialDataDto();
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
            this.deleteBranch(this.branchId, this.branchForEdit.name);
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
        if (this.branchForEdit.receivable) {
            this._branchesService.getChartOfAccountDetails(this.branchForEdit.receivable)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        }
    }

    zipCodeOnChange(): void {
        if (this.branchForEdit.zipCode) {
            this._branchesService.getZipCodeDetails(this.branchForEdit.zipCode)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: IGetZipCodeDetailsDto) => {
                    if (!_isEmpty(x)) {
                        this.branchForEdit.city = x.city;
                        this.branchForEdit.state = x.state;
                    }
                });
        }
    }

    branchAccountsReceivablesOnChange(e: any): void {
        if (e.value) {
            this.branchForEdit.receivable = this.initialDropdownData.accountsReceivables.find(x => x.id === e.value).accountReceivable;
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
            ).subscribe((x: BranchForEditDto) => {
                this.branchForEdit = x;
                this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime?.toJSDate();
            });
    }

    private addBranch(): void {
        var requestBody = new CreateBranchCommand({ number: 1, ...this.branchForEdit });
        this._branchesService.create(requestBody)
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: BranchForEditDto) => {
                this.activeCrudMode = BranchCrudModes.List;
                this.paginator.changePage(this.paginator.getPage());
                this.notifyService.success(this.l('SuccessfullyAdded'));
            });
    }

    private updateBranch(): void {
        var requestBody = new UpdateBranchCommand({ id: 1, ...this.branchForEdit });
        this._branchesService.update(this.branchId, requestBody)
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: BranchForEditDto) => {
                this.branchForEdit = x;
                this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime?.toJSDate();
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
                        this.branchForEdit = new BranchForEditDto();
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
        this.branchForEdit = new BranchForEditDto();
        this.branchForEdit.init({});
    }

    private initActionButtons(): void {
        this.actionButtons = [
            { name: this.l('Branch'), cssClass: 'btn-primary', iconClass: 'fa fa-plus', activeCrudModes: [BranchCrudModes.List], action: () => this.addOnClick() },
            { name: this.l('Save'), cssClass: 'btn-primary', iconClass: 'fa fa-save', activeCrudModes: [BranchCrudModes.Add, BranchCrudModes.Edit], action: () => this.saveOnClick() },
            { name: this.l('Delete'), cssClass: 'btn-danger', activeCrudModes: [BranchCrudModes.Edit], action: () => this.itemDeleteOnClick() },
            { name: this.l('Cancel'), cssClass: 'btn-secondary', activeCrudModes: [BranchCrudModes.Add, BranchCrudModes.Edit], action: () => this.cancelOnClick() },
            { name: this.l('Close'), cssClass: 'btn-secondary', activeCrudModes: [BranchCrudModes.List, BranchCrudModes.View], action: () => this.cancelOnClick() },
        ];
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
