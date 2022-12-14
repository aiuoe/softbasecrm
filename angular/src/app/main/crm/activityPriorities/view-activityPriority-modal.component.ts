import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetActivityPriorityForViewDto, ActivityPriorityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/**
 * Component for viewing an activity priority
 */
@Component({
    selector: 'viewActivityPriorityModal',
    templateUrl: './view-activityPriority-modal.component.html',
})
export class ViewActivityPriorityModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetActivityPriorityForViewDto;

    /**
     * Constructor method
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetActivityPriorityForViewDto();
        this.item.activityPriority = new ActivityPriorityDto();
    }

    /**
     * Show the modal dialog
     */
    show(item: GetActivityPriorityForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /**
     * Close the modal dialog
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
