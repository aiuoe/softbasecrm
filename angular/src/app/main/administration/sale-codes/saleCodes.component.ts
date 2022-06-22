import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ReplicateSaleCodesModalComponent } from './replicate/replicate-saleCodes-modal.component';
import { AddlDistSaleCodesModalComponent } from './addl-dist/addl-dist-saleCodes-modal.component';
import { EqGroupDistSaleCodesModalComponent } from './eq-group-dist/eq-group-dist-saleCodes-modal.component';
import { EqMakeDistSaleCodesModalComponent } from './eq-make-dist/eq-make-dist-saleCodes-modal.component';
import { CustomerSearchSaleCodesModalComponent } from './customer-search/customer-search-saleCodes-modal.component';

/***
 * Component to manage sale codes
 */
@Component({
    templateUrl: './saleCodes.component.html',
    styleUrls: ['./saleCodes.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class SaleCodesComponent extends AppComponentBase {
    @ViewChild('replicateSaleCodesModal', { static: true })
    replicateSaleCodesModal: ReplicateSaleCodesModalComponent;
    @ViewChild('addlDistSaleCodesModal', { static: true })
    addlDistSaleCodesModal: AddlDistSaleCodesModalComponent;
    @ViewChild('eqGroupDistSaleCodesModal', { static: true })
    eqGroupDistSaleCodesModal: EqGroupDistSaleCodesModalComponent;
    @ViewChild('eqMakeDistSaleCodesModal', { static: true })
    eqMakeDistSaleCodesModal: EqMakeDistSaleCodesModalComponent;
    @ViewChild('customerSearchSaleCodesModal', { static: true })
    customerSearchSaleCodesModal: CustomerSearchSaleCodesModalComponent;

    /***
     * Class constructor
     * @param injector
     */
    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    /***
     * Method that shows the replicate modal
     */
     replicateSaleCodes(): void {
        this.replicateSaleCodesModal.show();
    }

    /***
     * Method that shows the additional parts distribution modal
     */
     addlDistSaleCodes(): void {
        this.addlDistSaleCodesModal.show();
    }

    /***
     * Method that shows the equipment group distribution modal
     */
     eqGroupDistSaleCodes(): void {
        this.eqGroupDistSaleCodesModal.show();
    }
    /***
     * Method that shows the equipment make distribution modal
     */
     eqMakeDistSaleCodes(): void {
        this.eqMakeDistSaleCodesModal.show();
    }
    
    /***
     * Method that shows the customer search modal
     */
     customerSearchSaleCodes(): void {
      this.customerSearchSaleCodesModal.show();
  }
}
