import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetCountryForViewDto, CountryDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component to manage the country view modal
 */
@Component({
    selector: 'viewCountryModal',
    templateUrl: './view-country-modal.component.html',
})
export class ViewCountryModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetCountryForViewDto;

    /***
     * Main constructor
     * @param injector
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetCountryForViewDto();
        this.item.country = new CountryDto();
    }

    /***
     * Initialize page
     * @param item
     */
    show(item: GetCountryForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /***
     * Close modal
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
