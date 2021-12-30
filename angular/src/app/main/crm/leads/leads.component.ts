import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
    LeadsServiceProxy,
    LeadStatusesServiceProxy,
    LeadLeadSourceLookupTableDto,
    LeadStatusDto,
    PagedResultDtoOfGetLeadStatusForViewDto,
    ConvertLeadToAccountRequestDto,
    PriorityDto,
    PrioritiesServiceProxy,
    PagedResultDtoOfGetPriorityForViewDto,
    LeadLeadStatusLookupTableDto,
    LeadPriorityLookupTableDto,
    GetCustomerForViewDto,
    LeadUserUserLookupTableDto,
    GetLeadForViewDto
} from '@shared/service-proxies/service-proxies';
import { IAjaxResponse, NotifyService, TokenService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';

import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { HttpClient } from '@angular/common/http';
import { FileUploader, FileUploaderOptions } from 'ng2-file-upload';
import { ImportLeadsModalComponent } from '@app/main/crm/leads/import-leads-modal.component';
import { LocalStorageService } from '@shared/utils/local-storage.service';
import { AppConsts } from '@shared/AppConsts';
import { forkJoin, Observable } from 'rxjs';

/***
 * Component to manage the leads summary grid
 */
@Component({
    templateUrl: './leads.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class LeadsComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @ViewChild('importLeadsModalComponent', { static: true })

    importLeadsModalComponent: ImportLeadsModalComponent;
    leadStatuses: LeadLeadStatusLookupTableDto[];
    selectedLeadStatus: LeadStatusDto;
    selectedLeadStatuses: LeadStatusDto[];
    readOnlyStatus = [];
    allStatusesFilter : LeadLeadStatusLookupTableDto = new LeadLeadStatusLookupTableDto;     

    priorities: LeadPriorityLookupTableDto[];
    selectedPriority: LeadPriorityLookupTableDto;
    selectedPriorities: LeadPriorityLookupTableDto[];
    allPrioritiesFilter : LeadPriorityLookupTableDto = new LeadPriorityLookupTableDto;
    
    allUsers: LeadUserUserLookupTableDto[];   
    selectedUsers: LeadUserUserLookupTableDto[];
    noAssignedUsersOption: LeadUserUserLookupTableDto = new LeadUserUserLookupTableDto;

    advancedFiltersAreShown = false;
    filterText = '';
    companyOrContactNameFilter = '';
    contactNameFilter = '';
    contactPositionFilter = '';
    webSiteFilter = '';
    addressFilter = '';
    countryFilter = '';
    stateFilter = '';
    cityFilter = '';
    descriptionFilter = '';
    companyPhoneFilter = '';
    companyEmailFilter = '';
    poBoxFilter = '';
    zipCodeFilter = '';
    contactPhoneFilter = '';
    contactPhoneExtensionFilter = '';
    contactCellPhoneFilter = '';
    contactFaxNumberFilter = '';
    pagerNumberFilter = '';
    contactEmailFilter = '';
    leadSourceDescriptionFilter = '';
    leadStatusDescriptionFilter = '';
    priorityDescriptionFilter = ''; 

    allLeadSources: LeadLeadSourceLookupTableDto[];
    leadSourceDescription = '';
    leadSourceId: number;
    formData = new FormData();
    importFile: File;

    public uploader: FileUploader;
    private _uploaderOptions: FileUploaderOptions = {}
    public saving = false;


    /***
     * Main constructor
     * @param injector
     * @param _leadsServiceProxy
     * @param _leadStatusesServiceProxy
     * @param _notifyService
     * @param _tokenAuth
     * @param _activatedRoute
     * @param _fileDownloadService
     * @param _router
     * @param _dateTimeService
     * @param http
     * @param _tokenService
     * @param _localStorageService
     */
    constructor(
        injector: Injector,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _leadStatusesServiceProxy : LeadStatusesServiceProxy,
        private _prioritiesServiceProxy : PrioritiesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService,
        private http: HttpClient,
        private _tokenService: TokenService,
        private _localStorageService: LocalStorageService
    ) {
        super(injector);
    }

    /***
    * Initialize component
    */
    ngOnInit(){

        this._leadsServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
        });
        this._leadsServiceProxy.getAllLeadStatusForTableDropdown().subscribe((result) => {
            this.leadStatuses = result;
            this.leadStatuses.forEach( (leadStatus) => {
                if (!leadStatus.isLeadConversionValid)
                    this.readOnlyStatus.push(leadStatus.displayName);                        
            })
            this.allStatusesFilter.displayName = "All";
            this.leadStatuses.unshift(this.allStatusesFilter);  
        });
        this._leadsServiceProxy.getAllPriorityForTableDropdown().subscribe((result) => {
            this.priorities = result;
            this.allPrioritiesFilter.displayName = "All";
            this.priorities.unshift(this.allPrioritiesFilter);  
        });

        this._leadsServiceProxy.getAllUsersForTableDropdown().subscribe((result) => {
            this.allUsers = result;    
            this.noAssignedUsersOption.id = -1;
            this.noAssignedUsersOption.displayName = "None"   
            this.allUsers.unshift(this.noAssignedUsersOption);
        });
    }

    /***
     * Get leads by company or contact filter changed
     * @param event
     */
    getCustomerByCompanyOrContactNameFilter(event: KeyboardEvent) {
        const textFilterHasMoreThan1Characters = this.companyOrContactNameFilter && this.companyOrContactNameFilter?.trim().length >= 1;
        const keyDownIsBackspace = event && event.key === 'Backspace';
        if (textFilterHasMoreThan1Characters || keyDownIsBackspace) {
            this.getLeads();
        }
    }


    /***
    * Get leads on page load/filter changes
    * @param event
    */
    getLeads(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();          

        this._leadsServiceProxy
            .getAll(
                this.filterText,
                this.companyOrContactNameFilter,
                this.contactNameFilter,
                this.contactPositionFilter,
                this.webSiteFilter,
                this.addressFilter,
                this.countryFilter,
                this.stateFilter,
                this.cityFilter,
                this.descriptionFilter,
                this.companyPhoneFilter,
                this.companyEmailFilter,
                this.poBoxFilter,
                this.zipCodeFilter,
                this.contactPhoneFilter,
                this.contactPhoneExtensionFilter,
                this.contactCellPhoneFilter,
                this.contactFaxNumberFilter,
                this.pagerNumberFilter,
                this.contactEmailFilter,
                this.leadSourceDescriptionFilter,
                this.leadStatusDescriptionFilter,
                this.priorityDescriptionFilter,
                this.selectedLeadStatus?.id,
                this.selectedPriority?.id,
                this.selectedUsers?.map(x => x.id),
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.setUsersProfilePictureUrl(this.primengTableHelper.records);
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    /***
    * Verify if a lead on 'status' can be edited or converted
    */
    leadCanBeEdittedOrConverted(status: any) : boolean {
        return !(this.readOnlyStatus.includes(status));
    }


    /***
    * Reload page
    */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /***
    * Go to create lead page
    */
    createLead(): void {
        this._router.navigate(['/app/main/crm/leads/createOrEdit']);
    }

    /***
    * Export to excel
    */
    exportToExcel(): void {
        this._leadsServiceProxy
            .getLeadsToExcel(
                this.filterText,
                this.companyOrContactNameFilter,
                this.contactNameFilter,
                this.contactPositionFilter,
                this.webSiteFilter,
                this.addressFilter,
                this.countryFilter,
                this.stateFilter,
                this.cityFilter,
                this.descriptionFilter,
                this.companyPhoneFilter,
                this.companyEmailFilter,
                this.poBoxFilter,
                this.zipCodeFilter,
                this.contactPhoneFilter,
                this.contactPhoneExtensionFilter,
                this.contactCellPhoneFilter,
                this.contactFaxNumberFilter,
                this.pagerNumberFilter,
                this.contactEmailFilter,
                this.leadSourceDescriptionFilter,
                this.leadStatusDescriptionFilter,
                this.priorityDescriptionFilter,
                this.selectedLeadStatus?.id,
                this.selectedPriority?.id,
                this.selectedUsers?.map(x => x.id),
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    /*
    Below there are methods that act as placeholder for
    rows selections, currently there are not valid actions
    as 13/12/2021 - lead summary story
    */

    onTableHeaderCheckboxToggle(event: any) {
        console.log('Not implemented');
    }

    onRowSelect(event) {
        console.log('Not implemented');
    }

    onRowUnselect(event) {
        console.log('Not implemented');
    }

    showModalDialog() {
        this.importLeadsModalComponent.show();
    }

    /***
     * Set user image profile reference
     * @param users
     */
     setUsersProfilePictureUrl(users: GetLeadForViewDto[]): void {
        for (let i = 0; i < users.length; i++) {
            let user = users[i];
            if (user.firstUserAssignedId) {
                this._localStorageService.getItem(AppConsts.authorization.encrptedAuthTokenName, function(err, value) {
                    let profilePictureUrl =
                        AppConsts.remoteServiceBaseUrl +
                        '/Profile/GetProfilePictureByUser?userId=' +
                        user.firstUserAssignedId +
                        '&' +
                        AppConsts.authorization.encrptedAuthTokenName +
                        '=' +
                        encodeURIComponent(value.token);
                    (user as any).profilePictureUrl = profilePictureUrl;
                });
            }
        }
    }

    /***
     * Convert Lead to Account
     * @param leadId
     */
    convertToAccount(leadId: number) {
        const convertToAccountData = new ConvertLeadToAccountRequestDto();
        convertToAccountData.leadId = leadId;
        this.spinnerService.show();
        this._leadsServiceProxy.convertToAccount(convertToAccountData)
            .subscribe(_ => {
                this.spinnerService.hide();
                this.getLeads();
                this.message.success(this.l('LeadConversionSuccessful'));
            }, _ => {
                this.spinnerService.hide();
            });
    }
}
