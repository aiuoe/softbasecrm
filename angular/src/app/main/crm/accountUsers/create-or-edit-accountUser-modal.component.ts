import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AccountUsersServiceProxy, CreateOrEditAccountUserDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

             import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { AccountUserUserLookupTableModalComponent } from './accountUser-user-lookup-table-modal.component';



@Component({
    selector: 'createOrEditAccountUserModal',
    templateUrl: './create-or-edit-accountUser-modal.component.html'
})
export class CreateOrEditAccountUserModalComponent extends AppComponentBase implements OnInit{
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('accountUserUserLookupTableModal', { static: true }) accountUserUserLookupTableModal: AccountUserUserLookupTableModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    accountUser: CreateOrEditAccountUserDto = new CreateOrEditAccountUserDto();

    userName = '';



    constructor(
        injector: Injector,
        private _accountUsersServiceProxy: AccountUsersServiceProxy,
             private _dateTimeService: DateTimeService
    ) {
        super(injector);
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
        
        
    }

    save(): void {
            this.saving = true;
            
			
			
            this._accountUsersServiceProxy.createOrEdit(this.accountUser)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }

    openSelectUserModal() {
        this.accountUserUserLookupTableModal.id = this.accountUser.userId;
        this.accountUserUserLookupTableModal.displayName = this.userName;
        this.accountUserUserLookupTableModal.show();
    }


    setUserIdNull() {
        this.accountUser.userId = null;
        this.userName = '';
    }


    getNewUserId() {
        this.accountUser.userId = this.accountUserUserLookupTableModal.id;
        this.userName = this.accountUserUserLookupTableModal.displayName;
    }








    close(): void {
        this.active = false;
        this.modal.hide();
    }
    
     ngOnInit(): void {
        
     }    
}
