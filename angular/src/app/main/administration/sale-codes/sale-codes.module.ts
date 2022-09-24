import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { SaleCodesRoutingModule } from './sale-codes-routing.module';
import { SaleCodesComponent } from './sale-codes.component';
import { ReplicateSaleCodesModalComponent } from './sale-codes-replicate/sale-codes-replicate-modal.component';
import { AddlDistSaleCodesModalComponent } from './sale-codes-additional-distribution/sale-codes-additional-distribution-modal.component';
import { EqGroupDistSaleCodesModalComponent } from './sale-codes-equipment-group-distribution/sale-codes-equipment-group-distribution-modal.component';
import { EqMakeDistSaleCodesModalComponent } from './sale-codes-equipment-make-distribution/sale-codes-equipment-make-distribution-modal.component';
import { CustomerSearchModalComponent } from '../../common/customer-search/customer-search-modal.component';

@NgModule({
    declarations: [
        SaleCodesComponent,
        ReplicateSaleCodesModalComponent,
        AddlDistSaleCodesModalComponent,
        EqGroupDistSaleCodesModalComponent,
        EqMakeDistSaleCodesModalComponent,
        CustomerSearchModalComponent,
    ],
    imports: [
        AppSharedModule,
        SaleCodesRoutingModule,
        AdminSharedModule,
        CheckboxModule,
        RadioButtonModule,
    ],
})
export class SaleCodesModule {}
