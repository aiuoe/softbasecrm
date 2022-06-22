import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { SaleCodesRoutingModule } from './saleCodes-routing.module';
import { SaleCodesComponent } from './saleCodes.component';
import { ReplicateSaleCodesModalComponent } from './replicate/replicate-saleCodes-modal.component';
import { AddlDistSaleCodesModalComponent } from './addl-dist/addl-dist-saleCodes-modal.component';
import { EqGroupDistSaleCodesModalComponent } from './eq-group-dist/eq-group-dist-saleCodes-modal.component';
import { EqMakeDistSaleCodesModalComponent } from './eq-make-dist/eq-make-dist-saleCodes-modal.component';
import { CustomerSearchSaleCodesModalComponent } from './customer-search/customer-search-saleCodes-modal.component';

@NgModule({
    declarations: [
        SaleCodesComponent,
        ReplicateSaleCodesModalComponent,
        AddlDistSaleCodesModalComponent,
        EqGroupDistSaleCodesModalComponent,
        EqMakeDistSaleCodesModalComponent,
        CustomerSearchSaleCodesModalComponent,
    ],
    imports: [AppSharedModule, SaleCodesRoutingModule, AdminSharedModule],
})
export class SaleCodesModule {}
