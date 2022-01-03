import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetCustomerAttachmentForViewDto, CustomerAttachmentDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewCustomerAttachmentModal',
    templateUrl: './view-customerAttachment-modal.component.html',
})
export class ViewCustomerAttachmentModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetCustomerAttachmentForViewDto;

    constructor(injector: Injector) {
        super(injector);
        this.item = new GetCustomerAttachmentForViewDto();
        this.item.customerAttachment = new CustomerAttachmentDto();
    }

    show(item: GetCustomerAttachmentForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
