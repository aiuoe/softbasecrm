import { TokenService } from 'abp-ng2-module';
import { Component, ViewChild, Injector, Output, Input, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { IAttachment, CustomerAttachment, LeadAttachment } from './attachment.model';
import {
    CustomerAttachmentsServiceProxy,
    ICustomerAttachmentDto,
    LeadAttachmentsServiceProxy
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/***
 * Component to manage creation and modification of an attachment.
 */
 @Component({
    selector: 'create-or-edit-attachments-widget-modal',
    templateUrl: './create-or-edit-attachments-widget-modal.component.html',
})
export class CreateOrEditAttachmentsWidgetModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('uploadFileInputLabel') uploadFileInputLabel: ElementRef;

    @Input() componentType = '';
    @Input() idToStore: any;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    public uploader: FileUploader;

    private _uploaderOptions: FileUploaderOptions = {};

    attachment: IAttachment = {} as IAttachment;

    constructor(
        injector: Injector,
        private _tokenService: TokenService,
        private _customerAttachmentsServiceProxy: CustomerAttachmentsServiceProxy,
        private _leadAttachmentsServiceProxy: LeadAttachmentsServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Displays this component
     * @param attachment    An attachment to modify, otherwise a null to create a new attachment.
     */
     show(attachment?: IAttachment): void {

        this.attachment = {} as IAttachment;

        switch (this.componentType) {
            case 'Account':
                if (attachment) {
                    this._customerAttachmentsServiceProxy
                        .getCustomerAttachmentForEdit(attachment.id)
                        .subscribe((result) => {
                            this.attachment = result.customerAttachment;

                            this.active = true;
                            this.initFileUploader();
                            this.modal.show();
                        });
                    return;
                }

                let customerAttachment = new CustomerAttachment();
                customerAttachment.customerNumber = this.idToStore;
                this.attachment = customerAttachment;

                break;

            case 'Lead':
                if (attachment) {
                    this._leadAttachmentsServiceProxy
                        .getLeadAttachmentForEdit(attachment.id)
                        .subscribe((result) => {
                            this.attachment = result.leadAttachment;

                            this.active = true;
                            this.initFileUploader();
                            this.modal.show();
                        });
                    return;
                }

                let leadAttachment = new LeadAttachment();
                leadAttachment.leadId = this.idToStore;
                this.attachment = leadAttachment;
                break;


            default:
                return;
        }
        this.active = true;
        this.initFileUploader();
        this.modal.show();
    }

    /**
     * Determines whether the attachment is a customer attachment.
     * @param attachment    An attachment to check.
     * @returns true    If the attachment is a customer attachment; false, otherwise.
     */
    isCustomer(attachment: IAttachment): attachment is CustomerAttachment {
        return (<CustomerAttachment>attachment).customerNumber !== undefined;
    }

    /**
     * This method manages the upload of the excel file
     */
     initFileUploader(): void {
        
        let url = AppConsts.remoteServiceBaseUrl;
        switch (this.componentType) {
            case 'Account':
                url += '/CustomerImport/UploadAttachments';

            case 'Lead':
                url += '/LeadImportAttachment/UploadAttachments';
                break;

            default:
                this.close();
                return;
        }

        this.uploader = new FileUploader({url});
        this._uploaderOptions.autoUpload = false;
        this._uploaderOptions.authToken = 'Bearer ' + this._tokenService.getToken();
        this._uploaderOptions.removeAfterUpload = true;
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
        };

        this.uploader.onBuildItemForm = (fileItem: FileItem, form: any) => {
            if(this.attachment.id !== undefined) {
                form.append('Id', this.attachment.id);
            }
            form.append('Name', this.attachment.name);
            if (this.isCustomer(this.attachment)) {
                form.append('CustomerNumber', (<CustomerAttachment>this.attachment).customerNumber);
            }
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            this.message.success(this.l('CustomerAttachmentUploaded'));
            this.close();
        };

        this.uploader.onErrorItem = () => {
            this.message.error(this.l('ErrorUploadingMessage'));
            this.close();
        };

        this.uploader.setOptions(this._uploaderOptions);

        this.uploader.response.subscribe(res => {
            this.modalSave.emit(null);
            this.saving = false;
        });
    }

    /**
     * Uploads the attachment
     */
    save(): void {
        this.saving = true;
        this.uploader.uploadAll();
    }

    /**
     * Closes this component
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }

    /**
     * An event trigged when an attachment had changed
     * @param event 
     * @returns 
     */
    fileChangeEvent(event: any): void {
        const validExtensions = ['jpg', 'jpeg', 'png', 'gif', 'doc', 'pdf'];
        const selectedFile = event.target.files[0];
        const filename: string = selectedFile.name;
        const fileExtension: string = filename.substring(filename.lastIndexOf('.') + 1, filename.length) || filename;

        if (!validExtensions.some((ext) => ext.toLowerCase() === fileExtension.toLowerCase())) {
            // Invalid file extension
            this.message.warn(this.l('CustomerAttachment_Warn_FileType'));
            return;
        }

        this.uploadFileInputLabel.nativeElement.innerText = filename;
        this.uploader.clearQueue();
        this.uploader.addToQueue([event.target.files[0]]);
    }

    /**
     * An init function
     */
    ngOnInit(): void {}
}
