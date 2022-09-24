import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SaleCodesComponent } from './sale-codes.component';

const routes: Routes = [
    {
        path: '',
        component: SaleCodesComponent,
        pathMatch: 'full',
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class SaleCodesRoutingModule {}
