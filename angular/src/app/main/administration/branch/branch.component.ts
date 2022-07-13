import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil, finalize } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, BranchForEditDto, BranchListItemDto, CreateBranchCommand, GetBranchInitialDataDto,
    IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto, PagedResultDtoOfBranchListItemDto, PatchBranchCurrencyTypeCommand, ReadCommonShareServiceProxy, UpdateBranchCommand
} from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';

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
    actionButtons = BranchActionButtons;
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
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.initBranch();
        this._branchesService.getInitialData().pipe(takeUntil(this.destroy$)).subscribe((x: GetBranchInitialDataDto) => {
            this.initialDropdownData = x;
        });
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    isViewMode(): boolean {
        return this.activeCrudMode === this.branchCrudModes.View;
    }

    displayForm(): boolean {
        return [this.branchCrudModes.View, this.branchCrudModes.Add, this.branchCrudModes.Edit].includes(this.activeCrudMode);
    }

    displayButton(actionButton: BranchActionButtons): boolean {
        switch (actionButton) {
            case BranchActionButtons.Add:
                return this.activeCrudMode === this.branchCrudModes.List;
            case BranchActionButtons.Cancel:
            case BranchActionButtons.Save:
                return [this.branchCrudModes.Add, this.branchCrudModes.Edit].includes(this.activeCrudMode);
            case BranchActionButtons.Close:
                return this.activeCrudMode === this.branchCrudModes.View;
            case BranchActionButtons.Add:
                return this.activeCrudMode === this.branchCrudModes.Edit;
            default:
                return false;
        }
    }

    addOnClick(): void {
        this.initBranch();
        this.branchId = null;
        this.currencyTypeId = null;
        this.activeCrudMode = BranchCrudModes.Add;
    }

    cancelOnClick(): void {
        this.activeCrudMode = BranchCrudModes.List;
    }

    itemDeleteOnClick(): void {
        if (this.branchId) {
            this.deleteBranch(this.branchId, this.branchForEdit.name);
        }
    }

    saveOnClick(): void {
        if (this.branchId) {
            this.updateBranch();
        } else {
            this.addBranch();
        }
    }

    viewOnClick(branchId: number): void {
        this.branchId = branchId;
        this.getBranch(branchId);
        this.activeCrudMode = BranchCrudModes.View;
    }

    editOnClick(branchId: number): void {
        this.branchId = branchId;
        this.getBranch(branchId);
        this.activeCrudMode = BranchCrudModes.Edit;
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

    getBranch(branchId: number): void {
        this._branchesService.get(branchId).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.branchForEdit = x;
            this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime?.toJSDate();
        });
    }

    currencyTypeOnChange(): void {
        if (this.branchId && this.currencyTypeId) {
            this._branchesService.getBranchCurrencyType(this.branchId, this.currencyTypeId)
                .pipe(takeUntil(this.destroy$)).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    deleteBranchCurrencyType(): void {
        if (this.branchId && this.currencyTypeId) {
            this.branchCurrencyType = new BranchCurrencyTypeDto();
            const patchBranchCurrencyTypeCommand = new PatchBranchCurrencyTypeCommand();
            this._branchesService.patchBranchCurrencyType(this.branchId, this.currencyTypeId, patchBranchCurrencyTypeCommand)
                .pipe(takeUntil(this.destroy$)).subscribe((x: BranchCurrencyTypeDto) => {
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
                .pipe(takeUntil(this.destroy$)).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    acountsReceivableGLAccountNumberOnChange(): void {
        if (this.branchForEdit.receivable) {
            this._branchesService.getChartOfAccountDetails(this.branchForEdit.receivable)
                .pipe(takeUntil(this.destroy$)).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        }
    }

    zipCodeOnChange(): void {
        if (this.branchForEdit.zipCode) {
            this._branchesService.getZipCodeDetails(this.branchForEdit.zipCode).pipe(takeUntil(this.destroy$)).subscribe((x: IGetZipCodeDetailsDto) => {
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

    addBranch(): void {
        var requestBody = new CreateBranchCommand({ number: 1, ...this.branchForEdit });
        this._branchesService.create(requestBody).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.activeCrudMode = BranchCrudModes.List;
            this.paginator.changePage(this.paginator.getPage());
        });
    }

    updateBranch(): void {
        var requestBody = new UpdateBranchCommand({ id: 1, ...this.branchForEdit });
        this._branchesService.update(this.branchId, requestBody).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.branchForEdit = x;
            this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime?.toJSDate();
        });
    }

    deleteBranch(branchId: number, branchName: string): void {
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

    logoGraphicClear() {

    }

    private initBranch(): void {
        this.branchForEdit = new BranchForEditDto({
            number: null,
            name: null,
            subName: null,
            address: null,
            city: null,
            state: null,
            zipCode: null,
            countryId: null,
            phone: null,
            fax: null,
            receivable: null,
            financeCharge: null,
            financeRate: null,
            financeDays: null,
            stateTaxLabel: null,
            countyTaxLabel: null,
            showSplitSalesTax: null,
            cityTaxLabel: null,
            localTaxLabel: null,
            defaultWarehouseId: null,
            clarkPartsCode: null,
            clarkDealerAccessCode: null,
            useStateTaxCodeDescription: null,
            useCountyTaxCodeDescription: null,
            useCityTaxCodeDescription: null,
            useLocalTaxCodeDescription: null,
            rentalDeliveryDefaultTime: null,
            stateTaxCodeId: null,
            countyTaxCodeId: null,
            cityTaxCodeId: null,
            localTaxCodeId: null,
            taxCodeId: null,
            useAbsoluteTaxCodes: null,
            smallSubName: null,
            shopId: null,
            image: null,
            useImage: null,
            logoFile: null,
            vendorId: null,
            printFinalCc: null,
            printFinalBcc: null,
            storeName: null,
            creditCardAccountNo: null,
            tvhAccountNo: null,
            tvhKey: null,
            tvhCountryId: null,
            tvhWarehouseId: null,
            creatorUserName: null,
            creationTime: null,
            lastModifierUserName: null,
            lastModificationTime: null
        });
    }
}

export enum BranchCrudModes {
    List = 1,
    View,
    Add,
    Edit
}

export enum BranchActionButtons {
    Add = 1,
    Cancel,
    Close,
    Delete,
    Save
}