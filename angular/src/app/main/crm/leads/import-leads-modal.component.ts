import { TokenService } from 'abp-ng2-module';
import { Component, ElementRef, EventEmitter, Injector, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountUsersServiceProxy, AccountUserUserLookupTableDto, LeadLeadSourceLookupTableDto, LeadsServiceProxy, ProfileServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { nextGuid } from '@shared/utils/global.utils';

@Component({
    selector: 'importLeadsModal',
    templateUrl: './import-leads-modal.component.html',
})
export class ImportLeadsModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('importLeadsModal', { static: true }) modal: ModalDirective;
    @ViewChild('uploadFileImportInputLabel') uploadFileImportInputLabel: ElementRef;

    @Output() modalUpload: EventEmitter<any> = new EventEmitter<any>();

    public active = false;
    public uploader: FileUploader;
    public saving = false;
    public maxExcelImportBytesUserFriendlyValue = 5;

    private _uploaderOptions: FileUploaderOptions = {};

    selectedUserId : number = 0;
    selectedLeadSourceId : number = 0;
    allLeadSources: LeadLeadSourceLookupTableDto[];
    allUsers: AccountUserUserLookupTableDto[];
    fileFlag = false;

    constructor(injector: Injector, private _profileService: ProfileServiceProxy, 
                private _tokenService: TokenService,
                private _leadsServiceProxy: LeadsServiceProxy,
                private _accountUsersServiceProxy: AccountUsersServiceProxy) {
        super(injector);
    }

    ngOnInit(){
        this._leadsServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
        });

        this._accountUsersServiceProxy.getAllUserForTableDropdown().subscribe(result => {						
            this.allUsers = result;                      
        });	
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
        this.selectedLeadSourceId = 0;
        this.selectedUserId = 0;
        this.fileFlag = false;
        this.uploader.clearQueue();
        this.modal.hide();
    }

    fileChangeEvent(event: any): void {
        if (event.target.files[0].size > 5242880) {
            //5MB
            this.message.warn(this.l('ImportExcelFile_Warn_SizeLimit', this.maxExcelImportBytesUserFriendlyValue));
            return;
        }

        this.fileFlag = true;
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
            form.append('SelectedLeadSource', this.selectedLeadSourceId);
            form.append('SelectedUser', this.selectedUserId);
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            this.message.success('Leads imported successfully');
            this.close();
        };

        this.uploader.setOptions(this._uploaderOptions);
    }

    save(): void {
        this.message.confirm('', 'Are you sure you want to upload this file?', (isConfirmed) => {
            if (isConfirmed) {                       
                this.uploader.uploadAll();
                this.modalUpload.emit(null);
                this.fileFlag = false;
            }
        });
    }

    validateUploadButton(): boolean{
        if(this.selectedLeadSourceId > 0 && this.fileFlag){
            return false;
        }
        return true;
    }
}
