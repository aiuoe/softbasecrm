import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetLeadStatusForViewDto, LeadStatusDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component to view lead status
 */
@Component({
    selector: 'viewLeadStatusModal',
    templateUrl: './view-leadStatus-modal.component.html',
})
export class ViewLeadStatusModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetLeadStatusForViewDto;

    /***
     * Class constructor
     * @param injector
     * @param _activatedRoute
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetLeadStatusForViewDto();
        this.item.leadStatus = new LeadStatusDto();
    }

    /***
     * Method that show the view
     * @param leadStatusId
     */
    show(item: GetLeadStatusForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /***
     * Method that close the view 
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
