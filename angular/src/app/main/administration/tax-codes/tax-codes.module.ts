import {NgModule} from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import {AppSharedModule} from '@app/shared/app-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { MultiSelectModule } from 'primeng/multiselect';
import { TaxCodesComponent } from './tax-codes.component';
import { TaxCodesRoutingModule } from './tax-codes-routing.module';
import { TaxCodesStandardComponent } from './tax-codes-standard/tax-codes-standard.component';
import { TaxCodesStateGovComponent } from './tax-codes-state-gov/tax-codes-state-gov.component';
import { TaxCodesCountryProvComponent } from './tax-codes-country-prov/tax-codes-country-prov.component';
import { TaxCodesCityComponent } from './tax-codes-city/tax-codes-city.component';
import { TaxCodesLocalComponent } from './tax-codes-local/tax-codes-local.component';
import { TaxCodesSalesTaxComponent } from './tax-codes-sales-tax-integration/tax-codes-sales-tax.component';
import { TaxCodesDefaultTaxCodeComponent } from './tax-codes-default-tax-code/tax-codes-default-tax-code.component';

@NgModule({
    declarations: [
        TaxCodesComponent,
        TaxCodesStandardComponent,
        TaxCodesStateGovComponent,
        TaxCodesCountryProvComponent,
        TaxCodesCityComponent,
        TaxCodesLocalComponent,
        TaxCodesSalesTaxComponent,
        TaxCodesDefaultTaxCodeComponent
    ],
    imports: [
        AdminSharedModule,
        AppSharedModule, 
        TaxCodesRoutingModule,
        CheckboxModule,
        MultiSelectModule
    ]
})

// tax codes module
export class TaxCodesModule {}