import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    CustomerAttachmentsServiceProxy,
    CreateOrEditCustomerAttachmentDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditCustomerAttachmentModal',
    templateUrl: './create-or-edit-customerAttachment-modal.component.html',
})
export class CreateOrEditCustomerAttachmentModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    customerAttachment: CreateOrEditCustomerAttachmentDto = new CreateOrEditCustomerAttachmentDto();

    constructor(
        injector: Injector,
        private _customerAttachmentsServiceProxy: CustomerAttachmentsServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    show(customerAttachmentId?: number): void {
        if (!customerAttachmentId) {
            this.customerAttachment = new CreateOrEditCustomerAttachmentDto();
            this.customerAttachment.id = customerAttachmentId;

            this.active = true;
            this.modal.show();
        } else {
            this._customerAttachmentsServiceProxy
                .getCustomerAttachmentForEdit(customerAttachmentId)
                .subscribe((result) => {
                    this.customerAttachment = result.customerAttachment;

                    this.active = true;
                    this.modal.show();
                });
        }
    }

    save(): void {
        this.saving = true;

        this._customerAttachmentsServiceProxy
            .createOrEdit(this.customerAttachment)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
