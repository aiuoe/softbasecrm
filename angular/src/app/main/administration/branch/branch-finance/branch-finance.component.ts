import { Component, Injector, Input, OnDestroy } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchesServiceProxy, UpsertBranchDto, IGetChartOfAccountDetailsDto } from '@shared/service-proxies/service-proxies';
import { Subject } from 'rxjs';

/**
 * Sub component for branch finance tab
 */
@Component({
    selector: 'branchFinance',
    templateUrl: './branch-finance.component.html'
})

export class BranchFinanceComponent extends AppComponentBase implements OnDestroy {

    @Input() isViewMode: boolean;
    @Input() upsertBranchDto: UpsertBranchDto;
    destroy$ = new Subject();
    isAccountNumberValid: boolean = true;

    /**
     * constructor
     */
    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
    ) {
        super(injector);
    }

    /**
     * OnDestroy
     */
    ngOnDestroy(): void {
        this.destroy$.next();
    }

    /**
     * credit card debit account No on key up action
     */
    creditCardDebitAccountNoOnKeyUp(): void {
        if (this.upsertBranchDto.creditCardAccountNo) {
            this.updateAccountNumberValidity();
        }
    }

    /**
     * update account number validity
     */
    private updateAccountNumberValidity(): void {
        this._branchesService.getChartOfAccountDetails(this.upsertBranchDto.creditCardAccountNo)
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: IGetChartOfAccountDetailsDto) => {
                this.isAccountNumberValid = !!x.id;
            });
    }
}