import {TokenService} from 'abp-ng2-module';
import {Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild} from '@angular/core';
import {AppConsts} from '@shared/AppConsts';
import {AppComponentBase} from '@shared/common/app-component-base';
import {
    AccountUsersServiceProxy,
    AccountUserUserLookupTableDto,
    LeadDto,
    LeadLeadSourceLookupTableDto,
    LeadsServiceProxy,
    ProfileServiceProxy
} from '@shared/service-proxies/service-proxies';
import {FileUploader, FileUploaderOptions, FileItem} from 'ng2-file-upload';
import {ModalDirective} from 'ngx-bootstrap/modal';
import {nextGuid} from '@shared/utils/global.utils';
import {FileDownloadService} from '@shared/utils/file-download.service';

/***
 * Component to manage the import leads functionallity
 */
@Component({
    selector: 'importLeadsModal',
    templateUrl: './import-leads-modal.component.html',
})
export class ImportLeadsModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('importLeadsModal', {static: true}) modal: ModalDirective;
    @ViewChild('uploadFileImportInputLabel') uploadFileImportInputLabel: ElementRef;

    @Output() modalUpload: EventEmitter<any> = new EventEmitter<any>();

    public active = false;
    public uploader: FileUploader;
    public saving = false;
    public maxExcelImportBytesUserFriendlyValue = 5;

    private _uploaderOptions: FileUploaderOptions = {};
    duplicatedLeads: LeadDto[];

    selectedUserId = 0;
    selectedLeadSourceId = 0;
    allLeadSources: LeadLeadSourceLookupTableDto[];

    // List of users to show in dropdown
    allUsers: AccountUserUserLookupTableDto[];
    // Flag used to know if there's a change on the inout file
    fileFlag = false;

    /**
     * Constructor
     * @param injector
     * @param _profileService
     * @param _tokenService
     * @param _leadsServiceProxy
     * @param _accountUsersServiceProxy
     * @param _fileDownloadService
     */
    constructor(injector: Injector, private _profileService: ProfileServiceProxy,
                private _tokenService: TokenService,
                private _leadsServiceProxy: LeadsServiceProxy,
                private _accountUsersServiceProxy: AccountUsersServiceProxy,
                private _fileDownloadService: FileDownloadService) {
        super(injector);
    }

    ngOnInit() {

        // Get all the lead source to list on the dropdown
        this._leadsServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
        });

        // Gets all users to show on the User dropdown
        this._accountUsersServiceProxy.getAllUserForTableDropdown().subscribe(result => {
            this.allUsers = result;
        });
    }

    /**
     * Call the file uploader and intialize the data
     */
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
        this.uploader = new FileUploader({url: AppConsts.remoteServiceBaseUrl + '/LeadImport/UploadLeads'});
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
            const jsonResponde = JSON.parse(response);
            this.duplicatedLeads = jsonResponde.result.repeatedLeads;
            this.duplicatedLeads.forEach(item => {
                item.id = 0;
            });

            if (this.duplicatedLeads.length > 0) {
                this.message.confirm(
                    this.duplicatedLeads.length + ' ' + this.l('LeadsNotImportedDuplicated'),
                    this.l('DuplicatedLeads'),
                    (isConfirmed) => {
                        if (isConfirmed) {
                            this._leadsServiceProxy.getDuplicatedLeadsToExcel(this.duplicatedLeads)
                                .subscribe(response => {
                                    this._fileDownloadService.downloadTempFile(response);
                                    this.close();
                                });
                        } else {
                            this.close();
                        }
                    },
                    {
                        confirmButtonText: this.l('Download'),
                        cancelButtonText: this.l('Close'),      
                    }
                );
            } else {
                this.message.success(this.l('LeadsImportedSuccesfuly'));
                this.close();
            }
        };

        this.uploader.onErrorItem = () => {
            this.message.error(this.l('ErrorUploadingMessage'));
            this.close();
        };

        this.uploader.setOptions(this._uploaderOptions);

        this.uploader.response.subscribe(res => {
            this.modalUpload.emit(null);
        });
    }

    /**
     * This method upload the file with a list of leads
     */
    save(): void {
        this.message.confirm('', this.l('AreYouSureToUpload'), (isConfirmed) => {
            if (isConfirmed) {
                this.uploader.uploadAll();
                this.fileFlag = false;
            }
        });
    }


    /**
     * This method verify if the "Upload" button is available or not
     * @returns
     */
    validateUploadButton(): boolean {
        if (this.selectedLeadSourceId > 0 && this.fileFlag) {
            return false;
        }
        return true;
    }
}
