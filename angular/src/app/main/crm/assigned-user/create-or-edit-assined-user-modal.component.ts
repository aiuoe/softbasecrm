import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, Input } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import {
    AccountUserLookupTableDto,
    AccountUsersServiceProxy,
    CreateOrEditAccountUserDto,
    LeadUsersServiceProxy,
    OpportunityUsersServiceProxy
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/***
 * Component to manage creation of assigned users
 */
@Component({
    selector: 'app-create-or-edit-assined-user-modal',
    templateUrl: './create-or-edit-assined-user-modal.component.html'
})
export class CreateOrEditAssignedUserModalComponent extends AppComponentBase implements OnInit {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @Output() assignedUsers: EventEmitter<AccountUserLookupTableDto[]> = new EventEmitter<AccountUserLookupTableDto[]>();
    @Input() assignedUsersExists: AccountUserLookupTableDto[] = [];
    @Input() excludeSelectedItemsInMultiSelect = false;
    @Input() componentType = '';

    active = false;
    saving = false;
    accountUser: CreateOrEditAccountUserDto = new CreateOrEditAccountUserDto();
    userName = '';
    allUsers: AccountUserLookupTableDto[];
    selectedUsers: AccountUserLookupTableDto[];


    constructor(
        injector: Injector,
        private _accountUsersServiceProxy: AccountUsersServiceProxy,
        private _dateTimeService: DateTimeService,
        private _leadUserServiceProxy: LeadUsersServiceProxy,
        private _opportunityUserServiceProxy: OpportunityUsersServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {

    }


    /**
     * This method filter ther users to be shown on the list box
     * @param accountUserId
     */
    show(accountUserId?: number): void {
        if (!accountUserId) {
            this.accountUser = new CreateOrEditAccountUserDto();
            this.accountUser.id = accountUserId;
            this.userName = '';
            this.active = true;
            this.modal.show();
        }

        switch(this.componentType){
            case 'Account':
                this.getAllUsersForAccountModule();
                break;

            case 'Lead':
                this.getAllUserForLeadsModule();
                break;

            case 'Opportunity':
                this.getAllUsersForOpportunityModule();
                break;

            default:
                this.getAllUserForLeadsModule();
                break;
        }
    }


    /***
    * Gets all the users  to list on the popup onlt for Account module
    */
    getAllUsersForAccountModule(){
        this._accountUsersServiceProxy.getAllUserForTableDropdown().subscribe(result => {
            this.allUsers = result;

            const userIdsArray = [];
            for (let i = 0; i < this.assignedUsersExists.length; i++) {
                userIdsArray.push(this.assignedUsersExists[i].id);
            }

            if (this.excludeSelectedItemsInMultiSelect) {
                // Filtering by users who hasn't been assigned yet
                const arrayResult = [];
                this.allUsers.forEach(element => {
                    if (!userIdsArray.find(p => p === element.id)) {
                        arrayResult.push(element);
                    }
                });
                this.allUsers = [];
                this.allUsers = arrayResult;
            } else {
                this.selectedUsers = [...this.allUsers.filter(x => userIdsArray.includes(x.id))];
            }
        });
    }


    /**
     * Gets all the users  to list on the popup onlt for Account module
     */
    getAllUserForLeadsModule(){
        this._leadUserServiceProxy.getAllUserForTableDropdown().subscribe(result => {
            this.allUsers = result;

            const userIdsArray = [];
            for (let i = 0; i < this.assignedUsersExists.length; i++) {
                userIdsArray.push(this.assignedUsersExists[i].id);
            }

            if (this.excludeSelectedItemsInMultiSelect) {
                // Filtering by users who hasn't been assigned yet
                const arrayResult = [];
                this.allUsers.forEach(element => {
                    if (!userIdsArray.find(p => p === element.id)) {
                        arrayResult.push(element);
                    }
                });
                this.allUsers = [];
                this.allUsers = arrayResult;
            } else {
                this.selectedUsers = [...this.allUsers.filter(x => userIdsArray.includes(x.id))];
            }
        });
    }

        /***
    * Gets all the users  to list on the popup only for Opportunity module
    */
         getAllUsersForOpportunityModule(){
            this._opportunityUserServiceProxy.getAllUserForTableDropdown().subscribe(result => {
                this.allUsers = result;
    
                const userIdsArray = [];
                for (let i = 0; i < this.assignedUsersExists.length; i++) {
                    userIdsArray.push(this.assignedUsersExists[i].id);
                }
    
                if (this.excludeSelectedItemsInMultiSelect) {
                    // Filtering by users who hasn't been assigned yet
                    const arrayResult = [];
                    this.allUsers.forEach(element => {
                        if (!userIdsArray.find(p => p === element.id)) {
                            arrayResult.push(element);
                        }
                    });
                    this.allUsers = [];
                    this.allUsers = arrayResult;
                } else {
                    this.selectedUsers = [...this.allUsers.filter(x => userIdsArray.includes(x.id))];
                }
            });
        }

    /**
     * This method emites the list of selected users
     */
    confirm(): void {
        this.assignedUsers.emit(this.selectedUsers);
        this.close();
    }

    /**
     * Method to use to close the modal
     */
    close(): void {
        this.active = false;
        this.selectedUsers = [];
        this.modal.hide();
    }

}
