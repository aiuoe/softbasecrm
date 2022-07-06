import { Component, Injector, Input, OnDestroy } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchesServiceProxy, BranchForEditDto, IGetChartOfAccountDetailsDto } from '@shared/service-proxies/service-proxies';
import { Subject } from 'rxjs';

@Component({
    selector: 'branchFinance',
    templateUrl: './branch-finance.component.html'
})

export class BranchFinanceComponent extends AppComponentBase implements OnDestroy {
    destroy$ = new Subject();
    @Input() branchForEdit: BranchForEditDto;
    isAccountNumberValid: boolean = true;

    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
    ) {
        super(injector);
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    creditCardDebitAccountNoOnKeyUp(): void {
        if (this.branchForEdit.creditCardAccountNo) {
            this._branchesService.getChartOfAccountDetails(this.branchForEdit.creditCardAccountNo)
                .pipe(takeUntil(this.destroy$)).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        }
    }
}