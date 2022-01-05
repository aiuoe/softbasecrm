import { TokenService } from 'abp-ng2-module';
import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
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
    @ViewChild('uploadFileInputLabel') uploadFileInputLabel: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    public uploader: FileUploader;

    private _uploaderOptions: FileUploaderOptions = {};

    customerAttachment: CreateOrEditCustomerAttachmentDto = new CreateOrEditCustomerAttachmentDto();

    constructor(
        injector: Injector,
        private _tokenService: TokenService,
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
            this.initFileUploader();
            this.modal.show();
        } else {
            this._customerAttachmentsServiceProxy
                .getCustomerAttachmentForEdit(customerAttachmentId)
                .subscribe((result) => {
                    this.customerAttachment = result.customerAttachment;

                    this.active = true;
                    this.initFileUploader();
                    this.modal.show();
                });
        }
    }

    /**
     * This method manages the upload of the excel file
     */
     initFileUploader(): void {
        this.uploader = new FileUploader({url: AppConsts.remoteServiceBaseUrl + '/CustomerImport/UploadAttachments'});
        this._uploaderOptions.autoUpload = false;
        this._uploaderOptions.authToken = 'Bearer ' + this._tokenService.getToken();
        this._uploaderOptions.removeAfterUpload = true;
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
        };

        this.uploader.onBuildItemForm = (fileItem: FileItem, form: any) => {
            form.append('Id', this.customerAttachment.id);
            form.append('Name', this.customerAttachment.name);
            form.append('FilePath', this.customerAttachment.filePath);
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            this.message.success(this.l('CustomerAttachmentUploaded'));
            this.close();
        };

        this.uploader.onErrorItem = () => {
            //this.message.error(this.l('ErrorUploadingMessage'));
            this.close();
        };

        this.uploader.setOptions(this._uploaderOptions);

        this.uploader.response.subscribe(res => {
            this.modalSave.emit(null);
        });
    }

    save(): void {
        this.saving = true;

        this.message.confirm('', this.l('AreYouSureToUpload'), (isConfirmed) => {
            if (isConfirmed) {
                this.uploader.uploadAll();
                this.saving = false;
            }
        });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }

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

    ngOnInit(): void {}
}
