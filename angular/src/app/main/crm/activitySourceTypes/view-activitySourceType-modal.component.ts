import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetActivitySourceTypeForViewDto, ActivitySourceTypeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/**
 * Component for viewing an activity source type
 */
@Component({
    selector: 'viewActivitySourceTypeModal',
    templateUrl: './view-activitySourceType-modal.component.html',
})
export class ViewActivitySourceTypeModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetActivitySourceTypeForViewDto;

    /**
     * Constructor method
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetActivitySourceTypeForViewDto();
        this.item.activitySourceType = new ActivitySourceTypeDto();
    }

    /**
     * Show dialog
     */
    show(item: GetActivitySourceTypeForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /**
     * Close dialog
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
