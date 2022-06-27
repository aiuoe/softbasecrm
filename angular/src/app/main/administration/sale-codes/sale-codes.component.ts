import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { SelectItem } from 'primeng/api';
import { ReplicateSaleCodesModalComponent } from './sale-codes-replicate/sale-codes-replicate-modal.component';
import { AddlDistSaleCodesModalComponent } from './sale-codes-additional-distribution/sale-codes-additional-distribution-modal.component';
import { EqGroupDistSaleCodesModalComponent } from './sale-codes-equipment-group-distribution/sale-codes-equipment-group-distribution-modal.component';
import { EqMakeDistSaleCodesModalComponent } from './sale-codes-equipment-make-distribution/sale-codes-equipment-make-distribution-modal.component';
import { CustomerSearchModalComponent } from '../../common/customer-search/customer-search-modal.component';

/***
 * Component to manage sale codes
 */
@Component({
    templateUrl: './sale-codes.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class SaleCodesComponent extends AppComponentBase {
    branchSelectItems: SelectItem[] = [
        { label: 'Branch 1', value: 'Branch 1' },
        { label: 'Branch 2', value: 'Branch 2' },
    ];
    departmentSelectItems: SelectItem[] = [
        { label: 'Department 1', value: 'Department 1' },
        { label: 'Department 2', value: 'Department 2' },
    ];
    saleCodeSelectItems: SelectItem[] = [
        { label: 'Code 1', value: 'Code 1' },
        { label: 'Code 2', value: 'Code 2' },
    ];
    laborRateSelectItems: SelectItem[] = [
        { label: 'Rate 1', value: 'Rate 1' },
        { label: 'Rate 2', value: 'Rate 2' },
    ];
    subTotalTypeSelectItems: SelectItem[] = [
        { label: 'Type 1', value: 'Type 1' },
        { label: 'Type 2', value: 'Type 2' },
    ];
    expenseBranchSelectItems: SelectItem[] = [
        { label: 'Branch 1', value: 'Branch 1' },
        { label: 'Branch 2', value: 'Branch 2' },
    ];
    expenseDepartmentSelectItems: SelectItem[] = [
        { label: 'Department 1', value: 'Department 1' },
        { label: 'Department 2', value: 'Department 2' },
    ];
    expenseCodeSelectItems: SelectItem[] = [
        { label: 'Code 1', value: 'Code 1' },
        { label: 'Code 2', value: 'Code 2' },
    ];

    @ViewChild('replicateSaleCodesModal', { static: true })
    replicateSaleCodesModal: ReplicateSaleCodesModalComponent;
    @ViewChild('addlDistSaleCodesModal', { static: true })
    addlDistSaleCodesModal: AddlDistSaleCodesModalComponent;
    @ViewChild('eqGroupDistSaleCodesModal', { static: true })
    eqGroupDistSaleCodesModal: EqGroupDistSaleCodesModalComponent;
    @ViewChild('eqMakeDistSaleCodesModal', { static: true })
    eqMakeDistSaleCodesModal: EqMakeDistSaleCodesModalComponent;
    @ViewChild('customerSearchModal', { static: true })
    customerSearchModal: CustomerSearchModalComponent;

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
     customerSearch(): void {
      this.customerSearchModal.show();
    }
}
