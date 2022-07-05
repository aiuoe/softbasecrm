import { Component, Injector, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto,
    BranchesServiceProxy, BranchForEditDto, IAccountReceivableInBranchDto, IBranchCurrencyTypeDto, IBranchLookupDto, ICurrencyTypeLookupDto,
    ICustomerCountryLookupTableDto, IGetBranchInitialDataDto, IPatchBranchCurrencyTypeCommand, ITaxCodeInBranchDto, IWarehouseLookupDto, PatchBranchCurrencyTypeCommand
} from '@shared/service-proxies/service-proxies';
import { Subject } from 'rxjs';

@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase implements OnInit {

    destroy$ = new Subject();
    saving: boolean = false;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];

    branchId: number;
    branchNumber: number;
    currencyTypeId: number;
    branchCurrencyType: IBranchCurrencyTypeDto = new BranchCurrencyTypeDto();
    branchForEdit: BranchForEditDto = new BranchForEditDto();
    branches: IBranchLookupDto[] = [];
    countries: ICustomerCountryLookupTableDto[] = [];
    accountsReceivables: IAccountReceivableInBranchDto[] = [];
    warehouses: IWarehouseLookupDto[] = [];
    currencyTypes: ICurrencyTypeLookupDto[] = [];
    taxCodes: ITaxCodeInBranchDto[] = [];

    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._branchesService.getInitialData().pipe(takeUntil(this.destroy$)).subscribe((x: IGetBranchInitialDataDto) => {
            this.branches = x.branches;
            this.accountsReceivables = x.accountsReceivables;
            this.warehouses = x.warehouses;
            this.currencyTypes = x.currencyTypes;
            this.taxCodes = x.taxCodes;
        });
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    branchNumberOnChange(): void {
        this._branchesService.get(this.branchId).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.branchForEdit = x;
        });
    }

    currencyTypeOnChange(): void {
        if (this.branchId && this.currencyTypeId) {
            this._branchesService.getBranchCurrencyType(this.branchId, this.currencyTypeId)
                .pipe(takeUntil(this.destroy$)).subscribe((x: IBranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    deleteBranchCurrencyType(): void {
        if (this.branchId && this.currencyTypeId) {
            this.branchCurrencyType = new BranchCurrencyTypeDto();
            const patchBranchCurrencyTypeCommand = new PatchBranchCurrencyTypeCommand();
            this._branchesService.patchBranchCurrencyType(this.branchId, this.currencyTypeId, patchBranchCurrencyTypeCommand)
                .pipe(takeUntil(this.destroy$)).subscribe((x: IBranchCurrencyTypeDto) => {
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
                .pipe(takeUntil(this.destroy$)).subscribe((x: IBranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    addBranch(): void {

    }

    updateBranch(): void {

    }

    deleteBranch(): void {

    }

    logoGraphicClear() {

    }
}