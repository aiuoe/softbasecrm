﻿import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
    CustomerServiceProxy,
    AccountUserDto,
    GetCustomerForViewDto,
    CustomerAccountTypeLookupTableDto,
    AccountUserLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { AppConsts } from '@shared/AppConsts';
import { LocalStorageService } from '@shared/utils/local-storage.service';
import { last } from 'rxjs/internal/operators';
import { debounce } from 'lodash-es';

/***
 * Component to manage the customers/accounts summary grid
 */
@Component({
    templateUrl: './customers.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class CustomersComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    accountTypes: CustomerAccountTypeLookupTableDto[];
    selectedAccountType: CustomerAccountTypeLookupTableDto;
    selectedAccountTypes: CustomerAccountTypeLookupTableDto[];
    accountUsers: AccountUserDto[] = [];
    assignedUsersFilter: AccountUserLookupTableDto[] = [];
    allUsers: AccountUserLookupTableDto[];
    currentUserId : number;

    /**
     * Used to delay the search and wait for the user to finish typing.
     */
    delaySearchCustomers = debounce(this.getCustomer, AppConsts.SearchBarDelayMilliseconds);

    /***
     * Main constructor
     * @param injector
     * @param _customerServiceProxy
     * @param _notifyService
     * @param _tokenAuth
     * @param _activatedRoute
     * @param _fileDownloadService
     * @param _router
     * @param _dateTimeService
     * @param _localStorageService
     */
    constructor(
        injector: Injector,
        private _customerServiceProxy: CustomerServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _router: Router,
        private _dateTimeService: DateTimeService,
        private _localStorageService: LocalStorageService
    ) {
        super(injector);
    }

    /***
     * Initialize component
     */
    ngOnInit(): void {
        this._customerServiceProxy.getCurrentUserId()
            .subscribe((result: number) => {
                this.currentUserId = result
            });

        this._customerServiceProxy.getAllAccountTypeForTableDropdown()
            .subscribe((result: CustomerAccountTypeLookupTableDto[]) => {
                this.accountTypes = result;
            });

        this._customerServiceProxy.getAllUserForTableDropdown()
            .subscribe((result: AccountUserLookupTableDto[]) => {
                this.allUsers = result;
            });
    }

    /***
     * Verify if the user can't or not add an opportunity
     * on the account
     * @param customerDto
     */
     currentUserHasFreeAccessToAddOpportunity(customerDto : GetCustomerForViewDto) : boolean {
        if (this.permission.isGranted('Pages.Customer.HasFreeAccessToAddOpportunity__Dynamic')) {            
            return true;
        }
        else  
            return this.verifyUserIsAssingedToAccount(customerDto);        
    }
    
    /***
     * Verify if the user can't or not schedule a meeting
     * on the account
     * @param customerDto
     */
     currentUserHasFreeAccessToScheduleMeeting(customerDto : GetCustomerForViewDto) : boolean {
        if (this.permission.isGranted('Pages.Customer.HasFreeAccessToScheduleMeeting__Dynamic')) {
            return true;
        }
        else  
            return this.verifyUserIsAssingedToAccount(customerDto);        
    }
    
    /***
     * Verify if the user can't or not schedule a call
     * on the account
     * @param customerDto
     */
     currentUserHasFreeAccessToScheduleCall(customerDto : GetCustomerForViewDto) : boolean {
        if (this.permission.isGranted('Pages.Customer.HasFreeAccessToScheduleCall__Dynamic')) {
            return true;
        }
        else  
            return this.verifyUserIsAssingedToAccount(customerDto);        
    }
    
    /***
     * Verify if the user can't or not create an email reminder
     * on the account
     * @param customerDto
     */
     currentUserHasFreeAccessToEmailReminder(customerDto : GetCustomerForViewDto) : boolean {
        if (this.permission.isGranted('Pages.Customer.HasFreeAccessToEmailReminder__Dynamic')) {
            return true;
        }
        else  
            return this.verifyUserIsAssingedToAccount(customerDto);        
    }    

    /***
     * Verify if the user can't or not to create a to do reminder
     * on the account
     * @param customerDto
     */
     currentUserHasFreeAccessToDoReminder(customerDto : GetCustomerForViewDto) : boolean {
        if (this.permission.isGranted('Pages.Customer.HasFreeAccessToDoReminder__Dynamic')) {
            return true;
        }
        else  
            return this.verifyUserIsAssingedToAccount(customerDto);        
    }    
    

    /***
     * Verify if the user is or not assigned to this account
     * @param customerDto
     */
    verifyUserIsAssingedToAccount(customerDto : GetCustomerForViewDto) {

        let result = false;
        customerDto.customer.users?.forEach((user) => {
            if (user.id == this.currentUserId) {                
                result = true;
                return;
            }    
        });
        return result;
    }

    /***
     * Get customers
     * @param event
     */
    getCustomer(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._customerServiceProxy
            .getAll(
                this.filterText,
                this.selectedAccountTypes?.map(x => x.id),
                this.assignedUsersFilter?.map(x => x.id),
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .pipe(last())
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.setUsersProfilePictureUrl(this.primengTableHelper.records);
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    /***
     * Set user image profile reference
     * @param users
     */
    setUsersProfilePictureUrl(users: GetCustomerForViewDto[]): void {
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
     * Reload page
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /***
     * Go to create customer page
     */
    createCustomer(): void {
        this._router.navigate(['/app/main/business/accounts/createOrEdit']);
    }

    /***
     * Export to excel
     */
    exportToExcel(): void {
        this._customerServiceProxy
            .getCustomerToExcel(
                this.filterText,
                this.selectedAccountTypes?.map(x => x.id),
                this.assignedUsersFilter?.map(x => x.id)
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
}
