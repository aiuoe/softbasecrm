import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetOpportunityForViewDto, OpportunityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewOpportunityModal',
    templateUrl: './view-opportunity-modal.component.html',
})
export class ViewOpportunityModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetOpportunityForViewDto;

    constructor(injector: Injector) {
        super(injector);
        this.item = new GetOpportunityForViewDto();
        this.item.opportunity = new OpportunityDto();
    }

    show(item: GetOpportunityForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
