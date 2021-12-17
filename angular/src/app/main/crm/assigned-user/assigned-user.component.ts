import { Component, Injector, ViewEncapsulation, ViewChild, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    AccountUsersServiceProxy,
    AccountUserDto,
    AccountUserUserLookupTableDto,
    CreateOrEditAccountUserDto,
    GetAccountUserForViewDto
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAssignedUserModalComponent } from './create-or-edit-assined-user-modal.component';

import { ViewAssignedUserModalComponent } from './view-assigned-user-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { finalize } from 'rxjs/operators';

/***
 * Component to manage the list of assigned users
 */
@Component({
    templateUrl: './assigned-user-component.html',
    selector: 'app-assigned-user',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})

export class AssignedUserComponent extends AppComponentBase {

    @ViewChild('createOrEditAssignedUserModal', { static: true }) createOrEditAssignedUserModal: CreateOrEditAssignedUserModalComponent;
    @ViewChild('viewAssignedUserModal', { static: true }) viewAssignedUserModal: ViewAssignedUserModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @Input() componentType = '';
    @Input() idToStore: any;

    advancedFiltersAreShown = false;
    filterText = '';
    userNameFilter = '';
    saving = false;
    assignedUsersExists: GetAccountUserForViewDto[];


    constructor(
        injector: Injector,
        private _accountUsersServiceProxy: AccountUsersServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     *
     * @param event Gets the list of users assigned to an Account/Lead/Opportunity
     * @returns
     */
    getAccountUsers(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._accountUsersServiceProxy.getAll(
            this.filterText,
            this.userNameFilter,
            this.idToStore,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.assignedUsersExists = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }


    /**
     * Refresh the table
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }


    /**
     * Handles the creating assigned user modal
     */
    createAccountUser(): void {
        this.createOrEditAssignedUserModal.show();
    }


    /**
     * Handles the deletion of an user
     * @param accountUser Hanl
     */
    deleteAccountUser(accountUser: AccountUserDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._accountUsersServiceProxy.delete(accountUser.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }


    /**
     * This method manages the methods wich save users to some system
     * modules (Accounts/Leads/Opportunities)
     * @param usersList
     * @returns
     */
    savingAssignedUsers(usersList: AccountUserUserLookupTableDto[]) {
        if (usersList.length > 0) {
            if (this.componentType === 'Account') {
                this.saveAccountAssignedUser(usersList);
            } else if (this.componentType === 'Lead') {
                //TO DO
            } else {
                return;
            }
        }

    }


    /**
     * Save a list of users of an especific account
     * @param usersList
     */
    saveAccountAssignedUser(usersList: AccountUserUserLookupTableDto[]) {
        const accountUserToSave: CreateOrEditAccountUserDto[] = [];
        usersList.forEach(element => {
            let accountUser = new CreateOrEditAccountUserDto();
            accountUser.userId = element.id;
            accountUser.customerNumber = this.idToStore + '';
            accountUserToSave.push(accountUser);
        });

        this.saving = true;
        this._accountUsersServiceProxy.createMultipleAccountUsers(accountUserToSave)
            .pipe(finalize(() => {
                this.saving = false;
            }))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.getAccountUsers();
            });
    }


}
