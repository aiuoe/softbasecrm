import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetActivityForViewDto, ActivityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/**
 * Component for viewing an activity
 */
@Component({
    selector: 'viewActivityModal',
    templateUrl: './view-activity-modal.component.html'
})
export class ViewActivityModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetActivityForViewDto;

    /**
     * Constructor method
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetActivityForViewDto();
        this.item.activity = new ActivityDto();
    }

    /**
     * Show the modal dialog
     */
    show(item: GetActivityForViewDto): void {
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
