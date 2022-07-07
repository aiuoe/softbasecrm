import { Component, Injector, Input, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchesServiceProxy, BranchForEditDto, GetTaxTabInitialDataDto, TaxCodeInBranchDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchTaxSetup',
    templateUrl: './branch-tax-setup.component.html'
})

export class BranchTaxSetupComponent extends AppComponentBase implements OnChanges, OnDestroy {
    destroy$ = new Subject();
    @Input() taxCodes: TaxCodeInBranchDto[] = [];
    @Input() branchForEdit: BranchForEditDto;
    private hasInitialData = false;

    taxTabInitialData = new GetTaxTabInitialDataDto();

    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy
    ) {
        super(injector);
    }

    ngOnChanges(changes: SimpleChanges): void {
        if(changes.branchForEdit) {
            this.setTaxTabInitialData();
        }
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    useAbsoluteTaxCodesStatusOnChange(): void {
        this.setTaxTabInitialData();
    }

    private setTaxTabInitialData(): void {
        if (!this.hasInitialData) {
            this._branchesService.getTaxTabInitialData().pipe(takeUntil(this.destroy$)).subscribe(
                (x: GetTaxTabInitialDataDto) => {
                    this.taxTabInitialData = x;
                    this.hasInitialData = true;
                }
            );
        }
    }

}