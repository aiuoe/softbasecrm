import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TaxCodesComponent} from './tax-codes.component';

const routes: Routes = [{
    path: '',
    component: TaxCodesComponent,
    pathMatch: 'full'
}];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class TaxCodesRoutingModule {}