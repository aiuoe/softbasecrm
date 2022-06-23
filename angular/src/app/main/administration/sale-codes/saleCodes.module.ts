import { NgModule } from '@angular/core';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { SaleCodesRoutingModule } from './saleCodes-routing.module';
import { SaleCodesComponent } from './saleCodes.component';
import { ReplicateSaleCodesModalComponent } from './replicate/replicate-saleCodes-modal.component';
import { AddlDistSaleCodesModalComponent } from './additional-distribution/additional-distribution-saleCodes-modal.component';
import { EqGroupDistSaleCodesModalComponent } from './equipment-group-distribution/equipment-group-distribution-saleCodes-modal.component';
import { EqMakeDistSaleCodesModalComponent } from './equipment-make-distribution/equipment-make-distribution-saleCodes-modal.component';
import { CustomerSearchSaleCodesModalComponent } from '../../common/customer-search/customer-search-saleCodes-modal.component';

@NgModule({
    declarations: [
        SaleCodesComponent,
        ReplicateSaleCodesModalComponent,
        AddlDistSaleCodesModalComponent,
        EqGroupDistSaleCodesModalComponent,
        EqMakeDistSaleCodesModalComponent,
        CustomerSearchSaleCodesModalComponent,
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
