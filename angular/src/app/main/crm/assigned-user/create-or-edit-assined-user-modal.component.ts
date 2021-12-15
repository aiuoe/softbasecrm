import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef, Input} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AccountUsersServiceProxy, CreateOrEditAccountUserDto ,AccountUserUserLookupTableDto, GetAccountUserForViewDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { LazyLoadEvent } from 'primeng/api';



@Component({
    selector: 'app-create-or-edit-assined-user-modal',
    templateUrl: './create-or-edit-assined-user-modal.component.html',
})
export class CreateOrEditAssignedUserModalComponent extends AppComponentBase implements OnInit{
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @Output() assignedUsers: EventEmitter<AccountUserUserLookupTableDto[]> = new EventEmitter<AccountUserUserLookupTableDto[]>();
    @Input() assignedUsersExists: GetAccountUserForViewDto[] = [];

    active = false;
    saving = false;
    accountUser: CreateOrEditAccountUserDto = new CreateOrEditAccountUserDto();
    userName = '';
	allUsers: AccountUserUserLookupTableDto[];
    selectedUsers: AccountUserUserLookupTableDto[];
					

    constructor(
        injector: Injector,
        private _accountUsersServiceProxy: AccountUsersServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        
    }    
    
    show(accountUserId?: number): void {
        if (!accountUserId) {
            this.accountUser = new CreateOrEditAccountUserDto();
            this.accountUser.id = accountUserId;
            this.userName = '';
            this.active = true;
            this.modal.show();
        } else {
            this._accountUsersServiceProxy.getAccountUserForEdit(accountUserId).subscribe(result => {
                this.accountUser = result.accountUser;
                this.userName = result.userName;
                this.active = true;
                this.modal.show();
            });
        }
        this._accountUsersServiceProxy.getAllUserForTableDropdown().subscribe(result => {						
						this.allUsers = result;
                        // Filtering by users who hasn't been assigned yet
                        let index = 0;
                        for(let item of this.allUsers){
                            for(let auItem of this.assignedUsersExists){
                                if(item.id === auItem.accountUser.userId){
                                    this.allUsers.splice(index, 1);
                                }
                            }
                            index++;
                        }
					});					
    }

    confirm(): void {
        this.assignedUsers.emit(this.selectedUsers);
        this.close();
    }

    close(): void {
        this.active = false;
        this.selectedUsers = [];
        this.modal.hide();
    }    

}
