import { TokenService } from 'abp-ng2-module';
import { Component, ElementRef, EventEmitter, Injector, Input, OnInit, Output, ViewChild } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountUsersServiceProxy, AccountUserUserLookupTableDto, CreateOrEditLeadDto, LeadDto, LeadLeadSourceLookupTableDto, LeadsServiceProxy, ProfileServiceProxy } from '@shared/service-proxies/service-proxies';
import { FileUploader, FileUploaderOptions, FileItem } from 'ng2-file-upload';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { nextGuid } from '@shared/utils/global.utils';
import { FileDownloadService } from '@shared/utils/file-download.service';

/***
 * Component to manage the import leads functionallity
 */
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
    duplicatedLeads: LeadDto[];

    selectedUserId : number = 0;
    selectedLeadSourceId : number = 0;
    allLeadSources: LeadLeadSourceLookupTableDto[];
    allUsers: AccountUserUserLookupTableDto[];
    fileFlag = false;

    constructor(injector: Injector, private _profileService: ProfileServiceProxy, 
                private _tokenService: TokenService,
                private _leadsServiceProxy: LeadsServiceProxy,
                private _accountUsersServiceProxy: AccountUsersServiceProxy,
                private _fileDownloadService: FileDownloadService) {
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

    /**
     * Shows the modal
     */
    show(): void {
        this.initializeModal();
        this.modal.show();
    }

    
    /**
     * Close the pop up
     */
    close(): void {
        this.active = false;
        this.selectedLeadSourceId = 0;
        this.selectedUserId = 0;
        this.fileFlag = false;
        this.uploader.clearQueue();
        this.modal.hide();
    }


    /**
     * Event triggered when the file input changes
     */
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

    /**
     * This method manages the upload of the excel file
     */
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
            var jsonResponde = JSON.parse(response);
            this.duplicatedLeads = jsonResponde.result.repeatedLeads;
            this.duplicatedLeads.forEach( item =>{
                item.id = 0;
            });

            if (this.duplicatedLeads.length > 0) {
                this.message.confirm(
                    this.duplicatedLeads.length + ' lead(s) was(were) not imported because of an existing lead with the same Company Name and Contact Name.  Download file to see details',
                    'Duplicated leads encountered',
                    (isConfirmed) => {
                        if (isConfirmed) {
                        this._leadsServiceProxy.getDuplicatedLeadsToExcel(this.duplicatedLeads)
                            .subscribe( response =>{
                                this._fileDownloadService.downloadTempFile(response);
                                this.close();
                            });
                        }
                        else{
                            this.close();
                        }
                    }
                );
            }
            else{
                this.message.success('Leads imported successfully');
                this.close();
            }
        };

        this.uploader.onErrorItem = () => {
            //TO DO: Manage errors an exceptions
        }

        this.uploader.setOptions(this._uploaderOptions);
    }

    /**
     * This method upload the file with a list of leads
     */
    save(): void {
        this.message.confirm('', 'Are you sure you want to upload this file?', (isConfirmed) => {
            if (isConfirmed) {                       
                this.uploader.uploadAll();
                this.modalUpload.emit(null);
                this.fileFlag = false;
            }
        });
    }


    /**
     * This method verify if the "Upload" button is available or not
     * @returns 
     */
    validateUploadButton(): boolean{
        if(this.selectedLeadSourceId > 0 && this.fileFlag){
            return false;
        }
        return true;
    }
}
