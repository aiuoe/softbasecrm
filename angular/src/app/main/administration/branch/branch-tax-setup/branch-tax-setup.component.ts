import { Component, Injector, Input, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchesServiceProxy, CityTaxCodeInBranchDto, CountyTaxCodeInBranchDto, GetTaxTabInitialDataDto, LocalTaxCodeInBranchDto, StateTaxCodeInBranchDto, TaxCodeInBranchDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchTaxSetup',
    templateUrl: './branch-tax-setup.component.html'
})

export class BranchTaxSetupComponent extends AppComponentBase {

    @Input() standardTaxCodes: TaxCodeInBranchDto[] = [];
    stateTaxCodes: StateTaxCodeInBranchDto[] = [];
    countyTaxCodes: CountyTaxCodeInBranchDto[] = [];
    localTaxCodes: LocalTaxCodeInBranchDto[] = [];
    cityTaxCodes: CityTaxCodeInBranchDto[] = [];

    isUseAbsoluteTaxCodesChecked: boolean = false;
    hasDropDownData:boolean=false;

    constructor(
        injector: Injector,
        private branchesService: BranchesServiceProxy
    ) {
        super(injector);

    }

    /**
     * This method gets executed whenever user updates the UseAbsoluteTaxCodes checkbox.
     */
    onChangeUseAbsoluteTaxCodesStatus() {
        this.isUseAbsoluteTaxCodesChecked = !this.isUseAbsoluteTaxCodesChecked;
        this.hasDropDownData=true;
        //hasDropDownData flag lets the api called only once,no matter UseAbsoluteTaxCodes is checked or not
        if (this.hasDropDownData) {
            this.branchesService.getTaxTabInitialData().subscribe(
                (response: GetTaxTabInitialDataDto) => {
                    this.stateTaxCodes = response.stateTaxCodes;
                    this.countyTaxCodes = response.countyTaxCodes;
                    this.localTaxCodes = response.localTaxCodes;
                    this.cityTaxCodes = response.cityTaxCodes;
                }
            );
        }
    }

}