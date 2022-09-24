import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetOpportunityStageForViewDto, OpportunityStageDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewOpportunityStageModal',
    templateUrl: './view-opportunityStage-modal.component.html',
})
export class ViewOpportunityStageModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetOpportunityStageForViewDto;

    constructor(injector: Injector) {
        super(injector);
        this.item = new GetOpportunityStageForViewDto();
        this.item.opportunityStage = new OpportunityStageDto();
    }

    show(item: GetOpportunityStageForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
