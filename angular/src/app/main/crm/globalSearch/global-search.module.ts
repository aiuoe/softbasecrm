import { NgModule } from '@angular/core';
import { GlobalSearchComponent } from '@app/main/crm/globalSearch/global-search.component';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { GlobalSearchRoutingModule } from '@app/main/crm/globalSearch/global-search-routing.module';

@NgModule({
    declarations: [GlobalSearchComponent],
    imports: [AppSharedModule, GlobalSearchRoutingModule, AdminSharedModule]
})
export class GlobalSearchModule { }
