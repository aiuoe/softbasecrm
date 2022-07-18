import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, UpsertBranchDto, GetBranchInitialDataDto,
    IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto, PatchBranchCurrencyTypeCommand,
    ReadCommonShareServiceProxy
} from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { BrowseMode, IActionButton } from '../branch.model';

/**
 * Main component for branch edit
 */
@Component({
    templateUrl: './branch-upsert.component.html',
    animations: [appModuleAnimation()],
})

export class BranchUpsertComponent extends AppComponentBase implements OnInit, OnDestroy {

    destroy$ = new Subject();
    loading: boolean = false;
    browseMode: BrowseMode;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];
    actionButtons: IActionButton[] = [];
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
        private _activatedRoute: ActivatedRoute,
        private _branchesService: BranchesServiceProxy,
        private _commonServiceProxy: ReadCommonShareServiceProxy,
        private _router: Router,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.browseMode = this._activatedRoute.snapshot.data.browseMode;
        if (this._activatedRoute.snapshot.params.id) {
            this.branchId = this._activatedRoute.snapshot.params.id;
            this.getBranch(this.branchId);
        }
        this.initBranch();
        this.initActionButtons();
        this.setInitialDropdownData();
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    isViewMode(): boolean {
        return this.browseMode === BrowseMode.View;
    }

    isBranchNumberFieldDisabled(): boolean {
        return [BrowseMode.View, BrowseMode.Edit].includes(this.browseMode);
    }

    onChangeFile(event: File) {
        this.logoFile = event;
    }

    cancelOnClick(): void {
        this._router.navigate(['app', 'main', 'administration', 'branch']);
    }

    saveOnClick(): void {
        return this.branchId
            ? this.updateBranch()
            : this.addBranch();
    }

    deleteOnClick(): void {
        if (this.branchId) {
            this.deleteBranch(this.branchId, this.upsertBranchDto.name);
        }
    }

    isButtonActive(button: string): boolean {
        switch (button) {
            case 'close':
                return true;
            case 'delete':
                return this.browseMode === BrowseMode.Edit;
            case 'save':
                return [BrowseMode.Add, BrowseMode.Edit].includes(this.browseMode);
            default:
                return false;
        }
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
                this.notifyService.success(this.l('SuccessfullyAdded'));
                this._router.navigate(['app', 'main', 'administration', 'branch']);
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
                        this.notifyService.success(this.l('SuccessfullyDeleted'));
                        this._router.navigate(['app', 'main', 'administration', 'branch']);
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
            { name: this.l('Close'), cssClass: 'btn-secondary', isActive: () => this.isButtonActive('close'), action: () => this.cancelOnClick() },
            { name: this.l('Delete'), cssClass: 'btn-danger', isActive: () => this.isButtonActive('delete'), action: () => this.deleteOnClick() },
            { name: this.l('Save'), cssClass: 'btn-primary', iconClass: 'fa fa-save', isActive: () => this.isButtonActive('save'), action: () => this.saveOnClick() },
        ];
    }
}


