import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetPriorityForViewDto, PriorityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

/**
 * Component that works as a view only page for priority
 */
@Component({
    selector: 'viewPriorityModal',
    templateUrl: './view-priority-modal.component.html',
})
export class ViewPriorityModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetPriorityForViewDto;

    /**
     * Manin constructor
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = new GetPriorityForViewDto();
        this.item.priority = new PriorityDto();
    }

    /**
     * Shows the selected priority
     * @param item priority
     */
    show(item: GetPriorityForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /**
     * Closes the modal
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
