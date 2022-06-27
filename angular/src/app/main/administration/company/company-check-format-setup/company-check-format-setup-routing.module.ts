import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CheckFormatSetupCompanyComponent } from './company-check-format-setup.component';

const routes: Routes = [
    {
        path: '',
        component: CheckFormatSetupCompanyComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class CheckFormatSetupCompanyRoutingModule {}
