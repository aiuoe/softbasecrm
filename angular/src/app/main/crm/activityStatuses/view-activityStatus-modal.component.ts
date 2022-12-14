import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetActivityStatusForViewDto, ActivityStatusDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/**
 * Component for viewing an activity status
 */
@Component({
    selector: 'viewActivityStatusModal',
    templateUrl: './view-activityStatus-modal.component.html',
})
export class ViewActivityStatusModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetActivityStatusForViewDto;

    /**
     * Constructor method
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetActivityStatusForViewDto();
        this.item.activityStatus = new ActivityStatusDto();
    }

    /**
     * Show the dialog
     */
    show(item: GetActivityStatusForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /**
     * Close the dialog
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
