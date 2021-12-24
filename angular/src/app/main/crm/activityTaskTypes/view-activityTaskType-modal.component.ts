import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetActivityTaskTypeForViewDto, ActivityTaskTypeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewActivityTaskTypeModal',
    templateUrl: './view-activityTaskType-modal.component.html',
})
export class ViewActivityTaskTypeModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetActivityTaskTypeForViewDto;

    constructor(injector: Injector) {
        super(injector);
        this.item = new GetActivityTaskTypeForViewDto();
        this.item.activityTaskType = new ActivityTaskTypeDto();
    }

    /**
     * Show the dialog
     */
    show(item: GetActivityTaskTypeForViewDto): void {
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
