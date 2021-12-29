﻿import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetLeadSourceForViewDto, LeadSourceDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewLeadSourceModal',
    templateUrl: './view-leadSource-modal.component.html',
})
export class ViewLeadSourceModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetLeadSourceForViewDto;

    /***
     * Class constructor
     * @param injector
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetLeadSourceForViewDto();
        this.item.leadSource = new LeadSourceDto();
    }

    /***
     * Method that show the view
     * @param opportunityStageId
     */
    show(item: GetLeadSourceForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /***
     * Method that close or hide the view 
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
