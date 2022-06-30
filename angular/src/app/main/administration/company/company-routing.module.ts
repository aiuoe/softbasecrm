import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyComponent } from './company.component';

const routes: Routes = [
    {
        path: '',
        component: CompanyComponent,
        pathMatch: 'full',
    },
    {
        path: 'checkFormatSetup',
        loadChildren: () => import('./company-check-format-setup/company-check-format-setup.module').then(m => m.CheckFormatSetupCompanyModule),
        // data: { permission: 'Pages.ActivityStatuses' }
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CompanyRoutingModule {}
