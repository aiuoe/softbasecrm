﻿import {AppConsts} from "@shared/AppConsts";
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetOpportunityTypeForViewDto, OpportunityTypeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewOpportunityTypeModal',
    templateUrl: './view-opportunityType-modal.component.html'
})
export class ViewOpportunityTypeModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetOpportunityTypeForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetOpportunityTypeForViewDto();
        this.item.opportunityType = new OpportunityTypeDto();
    }

    show(item: GetOpportunityTypeForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
