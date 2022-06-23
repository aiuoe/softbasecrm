import {NgModule} from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import {AppSharedModule} from '@app/shared/app-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { MultiSelectModule } from 'primeng/multiselect';
import {BranchRoutingModule} from './branch-routing.module';
import { BranchComponent } from './branch.component';
import { EmailComponent } from './email/email.component';
import { FinanceComponent } from './finance/finance.component';
import { LogoGraphicComponent } from './logo-graphic/logo-graphic.component';
import { TaxSetupComponent } from './tax-setup/tax-setup.component';
import { TvhComponent } from './tvh/tvh.component';

@NgModule({
    declarations: [
        BranchComponent,
        TvhComponent,
        TaxSetupComponent,
        LogoGraphicComponent,
        FinanceComponent,
        EmailComponent
    ],
    imports: [
        AdminSharedModule,
        AppSharedModule, 
        BranchRoutingModule,
        CheckboxModule,
        MultiSelectModule
    ]
})
export class BranchModule {}