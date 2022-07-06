import { Component, Injector, OnDestroy, OnInit } from '@angular/core';
import { takeUntil, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, BranchForEditDto, GetBranchInitialDataDto, IBranchCurrencyTypeDto,
    IBranchForEditDto, IGetBranchInitialDataDto, IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto,
    PatchBranchCurrencyTypeCommand, ReadCommonShareServiceProxy
} from '@shared/service-proxies/service-proxies';
import { Subject } from 'rxjs';

@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase implements OnInit, OnDestroy {

    destroy$ = new Subject();
    debouncer: { [key: string]: Subject<any> } = {
        receivable: new Subject<string>(),
        zipCode: new Subject<string>(),
        addBranch: new Subject<number>(),
        updateBranch: new Subject<number>(),
        deleteBranch: new Subject<number>(),
    };
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
        this.setReceivableValidator$();
        this.getZipCodeDetails$();
        this.deleteBranch$();
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

    acountsReceivableGLAccountNumberOnKeyUp(): void {
        if (this.branchForEdit.receivable) {
            this.debouncer.receivable.next(this.branchForEdit.receivable);
        }
    }

    zipCodeOnKeyUp(): void {
        if (this.branchForEdit.zipCode) {
            this.debouncer.zipCode.next(this.branchForEdit.zipCode);
        }
    }

    addBranch(): void {

    }

    updateBranch(): void {

    }

    deleteBranch(): void {
        if (this.branchId) {
            this.debouncer.deleteBranch.next(this.branchId);
        }
    }

    logoGraphicClear() {

    }

    private setReceivableValidator$(): void {
        this.debouncer.receivable.pipe(debounceTime(400), distinctUntilChanged(), takeUntil(this.destroy$)).subscribe(() => {
            this._branchesService.getChartOfAccountDetails(this.branchForEdit.receivable)
                .pipe(takeUntil(this.destroy$)).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        });
    }

    private getZipCodeDetails$(): void {
        this.debouncer.zipCode.pipe(debounceTime(400), distinctUntilChanged(), takeUntil(this.destroy$)).subscribe(() => {
            this._branchesService.getZipCodeDetails(this.branchForEdit.zipCode).pipe(takeUntil(this.destroy$)).subscribe((x: IGetZipCodeDetailsDto) => {
                if (!_isEmpty(x)) {
                    this.branchForEdit.city = x.city;
                    this.branchForEdit.state = x.state;
                }
            });
        });
    }

    private deleteBranch$(): void {
        this.debouncer.deleteBranch.pipe(debounceTime(400), distinctUntilChanged(), takeUntil(this.destroy$)).subscribe(() => {
            this._branchesService.delete(this.branchId).subscribe(() => {
                this.initialDropdownData.branches = this.initialDropdownData.branches.filter(x => x.id !== this.branchId);
                this.branchCurrencyType = new BranchCurrencyTypeDto();
                this.branchForEdit = new BranchForEditDto();
                this.branchId = null;
                this.branchNumber = null;
                this.currencyTypeId = null;
            });
        });
    }
}