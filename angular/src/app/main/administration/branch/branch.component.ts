import { Component, Injector, OnDestroy, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, BranchForEditDto, GetBranchInitialDataDto, IBranchCurrencyTypeDto,
    IBranchForEditDto,
    IGetBranchInitialDataDto, IGetChartOfAccountDetailsDto, PatchBranchCurrencyTypeCommand, ReadCommonShareServiceProxy
} from '@shared/service-proxies/service-proxies';
import { Subject } from 'rxjs';
import { DatePipe } from '@angular/common';

@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase implements OnInit, OnDestroy {

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
    branchForEdit: IBranchForEditDto = new BranchForEditDto();
    initialDropdownData: IGetBranchInitialDataDto = new GetBranchInitialDataDto();
    isAccountNumberValid: boolean = true;

    selectedDate: Date = new Date();
    creationTime: Date = new Date();
    lastModificationTime: Date = new Date();

    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
        private _commonServiceProxy: ReadCommonShareServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._branchesService.getInitialData().pipe(takeUntil(this.destroy$)).subscribe((x: IGetBranchInitialDataDto) => {
            this.initialDropdownData = x;
        });
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    branchNumberOnChange(): void {
        this._branchesService.get(this.branchId).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.branchForEdit = x;
            this.branchForEdit.localTaxCodeId = -11;
            this.selectedDate = this.branchForEdit.rentalDeliveryDefaultTime.toJSDate();
            this.creationTime = this.branchForEdit.creationTime.toJSDate();
            this.lastModificationTime = this.branchForEdit.lastModificationTime.toJSDate();
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

    acountsReceivableGLAccountNumberOnKeyUp(): void {
        if (this.branchForEdit.receivable) {
            this._branchesService.getChartOfAccountDetails(this.branchForEdit.receivable)
                .pipe(takeUntil(this.destroy$)).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        }
    }

    branchAccountsReceivablesOnChange(e: any): void {
        if (e.value) {
            this.branchForEdit.receivable = this.initialDropdownData.accountsReceivables.find(x => x.id === e.value).accountReceivable;
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

