import { Component, Injector, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
    CustomerServiceProxy,
    AccountTypesServiceProxy,
    PagedResultDtoOfGetAccountTypeForViewDto,
    AccountTypeDto,
    AccountUserDto,
    UserListDto,
    GetCustomerForViewDto,
    AccountUserUserLookupTableDto,
    GetAccountUserForViewDto
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
import { CreateOrEditAssignedUserModalComponent } from '@app/main/crm/assigned-user/create-or-edit-assined-user-modal.component';

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
    @ViewChild('assignedUsersModal', { static: true }) assignedUsersModal: CreateOrEditAssignedUserModalComponent;

    advancedFiltersAreShown = false;
    filterText = '';
    accountTypes: AccountTypeDto[];
    selectedAccountType: AccountTypeDto;
    selectedAccountTypes: AccountTypeDto[];
    accountUsers: AccountUserDto[] = [];
    selectedAccountUsers: AccountUserDto[] = [];
    assignedUsersFilter: AccountUserUserLookupTableDto[] = [];

    /***
     * Main constructor
     * @param injector
     * @param _customerServiceProxy
     * @param _accountTypeServiceProxy
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
        private _accountTypeServiceProxy: AccountTypesServiceProxy,
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
        this._accountTypeServiceProxy.getAll('', '', 0, 100)
            .subscribe((result: PagedResultDtoOfGetAccountTypeForViewDto) => {
                this.accountTypes = result.items.map(x => x.accountType);
            });
    }

    /***
     * Get customers by text filter changed
     * @param event
     */
    getCustomerByTextFilter(event: KeyboardEvent) {
        const textFilterHasMoreThan2Characters = this.filterText && this.filterText?.trim().length >= 2;
        const keyDownIsBackspace = event && event.key === 'Backspace';
        if (textFilterHasMoreThan2Characters || keyDownIsBackspace) {
            this.getCustomer();
        }
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
                this.selectedAccountTypes?.map(x => x.id)
            )
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    /**
     * Handles the creating assigned user modal
     */
    createAccountUser(): void {
        this.assignedUsersModal.show();
    }

    /**
     * Method that receives the selected users from the Assigned Users component
     * @param selectedUsers
     * @returns
     */
    selectAssignedUsers(selectedUsers: AccountUserUserLookupTableDto[]) {
        this.assignedUsersFilter = selectedUsers ?? [];
        this.getCustomer();
    }

}
