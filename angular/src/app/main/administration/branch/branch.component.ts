import { Component, Injector, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, BranchForEditDto, CreateBranchCommand, GetBranchInitialDataDto,
    IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto, PatchBranchCurrencyTypeCommand, ReadCommonShareServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase implements OnInit, OnDestroy {

    destroy$ = new Subject();
    loading: boolean = false;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];

    branchId: number;
    branchNumber: number;
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

    branchNumberOnChange(): void {
        this._branchesService.get(this.branchId).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.branchForEdit = x;
            this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime.toJSDate();
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
        if (this.branchForEdit.name) {
            var requestBody = new CreateBranchCommand({ number: 1, ...this.branchForEdit});
            this._branchesService.create(requestBody).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
                this.branchForEdit = x;
                this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime.toJSDate();

                //TODO: add new branch to dropdown
                //this.initialDropdownData.branches.push(new BranchLookupDto({id: 1, number: 1}));
            });
        }
    }

    updateBranch(): void {

    }

    deleteBranch(): void {
        if (this.branchId) {
            this.loading = true;
            this._branchesService.delete(this.branchId).subscribe(() => {
                this.initialDropdownData.branches = this.initialDropdownData.branches.filter(x => x.id !== this.branchId);
                this.branchCurrencyType = new BranchCurrencyTypeDto();
                this.branchForEdit = new BranchForEditDto();
                this.branchId = null;
                this.branchNumber = null;
                this.currencyTypeId = null;
            }, () => {

            }, () => {
                this.loading = false;
            });
        }
    }

    logoGraphicClear() {

    }

    private initBranch(): void {
        this.branchForEdit = new BranchForEditDto({
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
            tvhWarehouse: null,
            creatorUserName: null,
            creationTime: null,
            lastModifierUserName: null,
            lastModificationTime: null
          });
    }
}

