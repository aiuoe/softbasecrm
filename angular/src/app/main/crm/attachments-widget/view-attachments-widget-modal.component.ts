import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { IAttachment } from './attachment.model';
import { AppComponentBase } from '@shared/common/app-component-base';

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

    constructor(injector: Injector) {
        super(injector);
        this.item = {} as IAttachment;
    }

    show(item: IAttachment): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
