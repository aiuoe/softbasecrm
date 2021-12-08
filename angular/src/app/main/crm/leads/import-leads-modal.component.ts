import { TokenService } from 'abp-ng2-module';
import { Component, ElementRef, Injector, ViewChild } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ProfileServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { nextGuid } from '@shared/utils/global.utils';

@Component({
    selector: 'importLeadsModal',
    templateUrl: './import-leads-modal.component.html',
})
export class ImportLeadsModalComponent extends AppComponentBase {
    @ViewChild('importLeadsModal', { static: true }) modal: ModalDirective;
    @ViewChild('uploadFileImportInputLabel') uploadFileImportInputLabel: ElementRef;

    public active = false;
    public uploader: FileUploader;
    public saving = false;
    public maxExcelImportBytesUserFriendlyValue = 5;

    private _uploaderOptions: FileUploaderOptions = {};

    constructor(injector: Injector, private _profileService: ProfileServiceProxy, private _tokenService: TokenService) {
        super(injector);
    }

    initializeModal(): void {
        this.active = true;
        this.initFileUploader();
    }

    show(): void {
        this.initializeModal();
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.uploader.clearQueue();
        this.modal.hide();
    }

    fileChangeEvent(event: any): void {
        if (event.target.files[0].size > 5242880) {
            //5MB
            this.message.warn(this.l('ImportExcelFile_Warn_SizeLimit', this.maxExcelImportBytesUserFriendlyValue));
            return;
        }

        this.uploadFileImportInputLabel.nativeElement.innerText = event.target.files[0].name;
        this.uploader.clearQueue();
        this.uploader.addToQueue([event.target.files[0]]);
    }

    initFileUploader(): void {
        this.uploader = new FileUploader({ url: AppConsts.remoteServiceBaseUrl + '/LeadImport/UploadLeads' });
        this._uploaderOptions.autoUpload = false;
        this._uploaderOptions.authToken = 'Bearer ' + this._tokenService.getToken();
        this._uploaderOptions.removeAfterUpload = true;
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
        };

        this.uploader.onBuildItemForm = (fileItem: FileItem, form: any) => {
            form.append('FileType', fileItem.file.type);
            form.append('FileName', 'ExcelFile');
            form.append('FileToken', nextGuid);
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            this.message.success('Success');
            this.close();
        };

        this.uploader.setOptions(this._uploaderOptions);
    }

    save(): void {
        this.uploader.uploadAll();
    }
}
