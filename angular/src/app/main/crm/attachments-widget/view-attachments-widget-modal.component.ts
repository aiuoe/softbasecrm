import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { IAttachment } from './attachment.model';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component to manage attachment view
 */
 @Component({
    selector: 'view-attachments-widget-modal',
    templateUrl: './view-attachments-widget-modal.component.html',
})
export class ViewAttachmentsWidgetModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: IAttachment;

    /**
     * Attachment view's constructor
     * @param injector 
     */
    constructor(injector: Injector) {
        super(injector);
        this.item = {} as IAttachment;
    }

    /**
     * Displays this component
     * @param item 
     */
    show(item: IAttachment): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    /**
     * Closes this component
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
