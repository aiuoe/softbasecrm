import { Component, ViewChild, Injector, OnInit, EventEmitter, Output, ViewEncapsulation } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { ReadCommonShareServiceProxy, TaxCodeDto, TaxCodeTypeDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

/***
 * Component for Tax Code Search
 */
@Component({
    selector: 'taxCodeSearchModal',
    encapsulation: ViewEncapsulation.None,
    templateUrl: './tax-code-search-modal.component.html',
})
export class TaxCodeSearchModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('taxCodeSearchModal', { static: true }) modal: ModalDirective;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @Output() messageEvent = new EventEmitter<string>();
    selectedTaxCodeData: TaxCodeDto;
    taxCodeTypeItems: TaxCodeTypeDto[];
    taxCodeType: string;
    partialTaxCode: string;
    parentTaxCode: string;
    description: string;
    selected: boolean = false;

    constructor(
        injector: Injector,
        private _taxCodesServiceProxy: ReadCommonShareServiceProxy,
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

    /**
     * This methods gets the tax code types that Avalara has available
     */
    getTaxCodeTypes() {
        this._taxCodesServiceProxy.getTaxCodeTypes()
            .subscribe((result) => {
                this.taxCodeTypeItems = result;
            });
    }

    /***
     * This method search the Api using the GetTaxCodes to look for Avalara Tax Codes
     * searchTaxCodes
     * @param event
     */
    searchTaxCodes(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._taxCodesServiceProxy.getTaxCodes(
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.taxCodeType != undefined && this.taxCodeType != null ? this.taxCodeType.trim() : ' ',
            this.partialTaxCode != undefined && this.partialTaxCode != null ? this.partialTaxCode.trim() : ' ',
            this.parentTaxCode != undefined && this.parentTaxCode != null ? this.parentTaxCode.trim() : ' ',
            this.description != undefined && this.description != null ? this.description.trim() : ' ')
            .pipe(finalize(() => this.primengTableHelper.hideLoadingIndicator()))
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    //** Reload the page with the next set of rows */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    ngOnInit(): void {
        this.getTaxCodeTypes();
        this.primengTableHelper.showLoadingIndicator();
        this.primengTableHelper.hideLoadingIndicator();
    }

    //**Notifies that a tax code has been selected */
    onRowSelect(event) {
        this.selected = true;
    }

    //**Notifies when there is no tax code selected */
    onRowUnselect(event) {
        this.selected = false;
    }

    //** By clicking Okey Button notifies the parent of the tax code selected */
    taxCodeSelected(): void {
        this.messageEvent.emit(this.selectedTaxCodeData.taxCode);
        this.modal.hide();
    }


}
