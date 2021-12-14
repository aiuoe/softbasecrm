import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { AccountUsersServiceProxy, CreateOrEditAccountUserDto ,AccountUserUserLookupTableDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';



@Component({
    selector: 'app-create-or-edit-assined-user-modal',
    templateUrl: './create-or-edit-assined-user-modal.component.html',
})
export class CreateOrEditAssignedUserModalComponent extends AppComponentBase implements OnInit{
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    accountUser: CreateOrEditAccountUserDto = new CreateOrEditAccountUserDto();

    userName = '';

	allUsers: AccountUserUserLookupTableDto[];
					

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
        this._accountUsersServiceProxy.getAllUserForTableDropdown().subscribe(result => {						
						this.allUsers = result;
					});
					
        
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













    close(): void {
        this.active = false;
        this.modal.hide();
    }
    
     ngOnInit(): void {
        
     }    
}
