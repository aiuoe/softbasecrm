import { Component, Injector, Input, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchesServiceProxy, GetTaxTabInitialDataDto, TaxCodeInBranchDto, UpsertBranchDto } from '@shared/service-proxies/service-proxies';

/**
 * Sub component for branch tax setup tab
 */
@Component({
    selector: 'branchTaxSetup',
    templateUrl: './branch-tax-setup.component.html'
})

export class BranchTaxSetupComponent extends AppComponentBase implements OnChanges, OnDestroy {

    @Input() isViewMode: boolean;
    @Input() taxCodes: TaxCodeInBranchDto[] = [];
    @Input() upsertBranchDto: UpsertBranchDto;
    destroy$ = new Subject();
    private hasInitialData = false;
    taxTabInitialData = new GetTaxTabInitialDataDto();

    /**
     * constructor
     */
    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy
    ) {
        super(injector);
    }

    /**
     * OnChanges
     */
    ngOnChanges(changes: SimpleChanges): void {
        if (changes.upsertBranchDto) {
            this.setTaxTabInitialData();
        }
    }

    /**
     * OnDestroy
     */
    ngOnDestroy(): void {
        this.destroy$.next();
    }

    /**
     * use absolute tax codes status checkbox on change
     */
    useAbsoluteTaxCodesStatusOnChange(): void {
        this.setTaxTabInitialData();
    }

    /**
     * get tax tab dropdown values
     */
    private setTaxTabInitialData(): void {
        if (!this.hasInitialData) {
            this._branchesService.getTaxTabInitialData()
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: GetTaxTabInitialDataDto) => {
                    this.taxTabInitialData = x;
                    this.hasInitialData = true;
                });
        }
    }
}