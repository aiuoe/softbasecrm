import { Component, Injector, ViewEncapsulation, ViewChild, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    AccountUsersServiceProxy,
    AccountUserDto,
    AccountUserUserLookupTableDto,
    CreateOrEditAccountUserDto,
    LeadUsersServiceProxy,
    LeadUserUserLookupTableDto,
    CreateOrEditLeadUserDto,
    LeadUserDto,
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
import { forkJoin, Observable } from '@node_modules/rxjs';

/***
 * Component to manage the list of assigned users
 */
@Component({
    templateUrl: './assigned-user-component.html',
    selector: 'app-assigned-user',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})

export class AssignedUserComponent extends AppComponentBase implements OnInit {

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
    assignedUsersExists: AccountUserUserLookupTableDto[];
    canAssignUser = false;

    leadCompanyNameFilter = '';
    constructor(
        injector: Injector,
        private _accountUsersServiceProxy: AccountUsersServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService,
        private _leadUserServiceProxy: LeadUsersServiceProxy
    ) {
        super(injector);
    }


    /***
     * Initialize component
     */
    ngOnInit() {
        this.loadPermissions();
    }

    /***
     * Load permissions
     */
    loadPermissions() {
        if ('Account' === this.componentType) {
            const requests: Observable<any>[] = [
                this._accountUsersServiceProxy.canAssignUsers(this.idToStore?.toString())
            ];
            forkJoin([...requests])
                .subscribe(([canAssignUsersResponse]: [boolean]) => {
                    this.canAssignUser = canAssignUsersResponse || this.isGranted('Pages.AccountUsers.Create');
                });
        } else {
            this.canAssignUser = true;
        }
    }
    

    /**
     * Method to call data 
     * @param event 
     */
    loadDataTable(event?: LazyLoadEvent){
        switch(this.componentType){
            case 'Account':
                this.getAccountUsers(event);
                break;

            case 'Lead':
                this.getLeadUsers(event);
                break;

            default:
                this.getLeadUsers(event);
                break;           
        }
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
            this.assignedUsersExists = [];
            result.items.forEach(x => {
                const assignedUser = new AccountUserUserLookupTableDto();
                assignedUser.id = x.accountUser.userId;
                assignedUser.displayName = x.fullName;
                this.assignedUsersExists.push(assignedUser);
            });
            // this.assignedUsersExists = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    /**
     * Gets the list of users assigned to an Account/Lead/Opportunity
     * @param event 
     */
    getLeadUsers(event?: LazyLoadEvent){
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._leadUserServiceProxy.getAll(
            this.filterText,
            this.leadCompanyNameFilter,
            this.userNameFilter,
            this.idToStore,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.assignedUsersExists = [];
            result.items.forEach(x => {
                const assignedUser = new AccountUserUserLookupTableDto();
                assignedUser.id = x.leadUser.userId;
                assignedUser.displayName = x.userName;
                this.assignedUsersExists.push(assignedUser);
            });
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
     * Handles the deletion of an lead user
     * @param accountUser Hanl
     */
    deleteLeadUser(leadUser: LeadUserDto): void{
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._leadUserServiceProxy.delete(leadUser.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        )
    }


    /**
     * This method manages the methods wich save users to some system
     * modules (Accounts/Leads/Opportunities)
     * @param usersList
     * @returns
     */
    savingAssignedUsers(usersList: AccountUserUserLookupTableDto[]) {
        if (usersList.length > 0) {
            switch (this.componentType){
                case 'Account':
                    this.saveAccountAssignedUser(usersList);
                    break;

                case 'Lead':
                    this.saveLeadAssignedUsers(usersList);
                    break;
                
                default:
                    this.saveLeadAssignedUsers(usersList);
                    break;
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


    /**
     * Save a list of users of an especific lead
     * @param usersList 
     */
    saveLeadAssignedUsers(usersList: LeadUserUserLookupTableDto[]){
        const leadUserToSave: CreateOrEditLeadUserDto[] = [];
        usersList.forEach(element => {
            let leadUser = new CreateOrEditLeadUserDto();
            leadUser.userId = element.id;
            leadUser.leadId = this.idToStore;
            leadUserToSave.push(leadUser);
        });

        this.saving = true;

        this._leadUserServiceProxy.createMultipleLeadUsers(leadUserToSave)
        .pipe(finalize(() => {
            this.saving = false;
        }))
        .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.getLeadUsers();
        });
    }


}
