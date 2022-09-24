import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { GlobalSearchComponent } from '@app/main/crm/globalSearch/global-search.component';

const routes: Routes = [
    {
        path: '',
        component: GlobalSearchComponent,
        pathMatch: 'full',
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class GlobalSearchRoutingModule {

}
