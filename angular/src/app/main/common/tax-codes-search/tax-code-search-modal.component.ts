import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Table } from 'primeng/table';
import { AppComponentBase } from '@shared/common/app-component-base';
import { SelectItem } from 'primeng/api';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { ReadCommonShareServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

/***
 * Component for Tax Code Search
 */
@Component({
  selector: 'taxCodeSearchModal',
  templateUrl: './tax-code-search-modal.component.html',
})
export class TaxCodeSearchModalComponent extends AppComponentBase implements OnInit {
  @ViewChild('taxCodeSearchModal', { static: true }) modal: ModalDirective;
  @ViewChild('dataTable', { static: true }) dataTable: Table;

  exmTaxCodeTypesSelectItems: SelectItem[] = [
    { label: 'D-Digital', value: 'D' },
    { label: 'F-Freight', value: 'F' },
    { label: 'O-Other', value: 'O' },
];

filters: {
  taxCodeType: string;
  partialTaxCode: string;
  parentTaxCode: string;
  description: string;
} = <any>{};

  constructor(
    injector: Injector,
    private _taxCodesServiceProxy : ReadCommonShareServiceProxy,
) {
    super(injector);
}

  /***
     * Method that shows the modal
     */
   show(): void {
    this.modal.show();
}

/***
 * Method that closes the modal
 */
close(): void {
    this.modal.hide();
}

/***
 * This method search the Api using the GetTaxCodes to look for Avalara Tax Codes
 */
searchTaxCodes(){
  this.primengTableHelper.showLoadingIndicator();

  this._taxCodesServiceProxy.getTaxCodes(
  this.filters.taxCodeType != undefined && this.filters.taxCodeType.length > 0 ? this.filters.taxCodeType : " ",
  this.filters.partialTaxCode != undefined && this.filters.partialTaxCode.length > 0 ? this.filters.partialTaxCode : " ",
  this.filters.parentTaxCode != undefined && this.filters.parentTaxCode.length > 0 ? this.filters.parentTaxCode : " ",
  this.filters.description != undefined && this.filters.description.length > 0 ? this.filters.description : " ")
  .pipe(finalize(() => this.primengTableHelper.hideLoadingIndicator()))
  .subscribe((result) => {
      this.primengTableHelper.totalRecordsCount = result.length;
      this.primengTableHelper.records = result;
      this.primengTableHelper.hideLoadingIndicator();
  });
}

ngOnInit(): void {
    this.primengTableHelper.showLoadingIndicator();
    this.primengTableHelper.hideLoadingIndicator();
}

}
