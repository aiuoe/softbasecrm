import {NgModule} from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import {AppSharedModule} from '@app/shared/app-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { MultiSelectModule } from 'primeng/multiselect';
import {BranchRoutingModule} from './branch-routing.module';
import { BranchComponent } from './branch.component';
import { BranchEmailComponent } from './branch-email/branch-email.component';
import { BranchFinanceComponent } from './branch-finance/branch-finance.component';
import { BranchLogoGraphicComponent } from './branch-logo-graphic/branch-logo-graphic.component';
import { BranchTaxSetupComponent } from './branch-tax-setup/branch-tax-setup.component';
import { BranchTvhComponent } from './branch-tvh/branch-tvh.component';
import { CalendarModule } from 'primeng/calendar';

@NgModule({
    declarations: [
        BranchComponent,
        BranchTvhComponent,
        BranchTaxSetupComponent,
        BranchLogoGraphicComponent,
        BranchFinanceComponent,
        BranchEmailComponent
    ],
    imports: [
        AdminSharedModule,
        AppSharedModule, 
        BranchRoutingModule,
        CheckboxModule,
        MultiSelectModule,
        CalendarModule
    ]
})
export class BranchModule {}