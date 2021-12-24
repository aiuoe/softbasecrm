import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { ActivityStatusesServiceProxy, CreateOrEditActivityStatusDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';



@Component({
    selector: 'createOrEditActivityStatusModal',
    templateUrl: './create-or-edit-activityStatus-modal.component.html'
})
export class CreateOrEditActivityStatusModalComponent extends AppComponentBase implements OnInit{
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    activityStatus: CreateOrEditActivityStatusDto = new CreateOrEditActivityStatusDto();




    constructor(
        injector: Injector,
        private _activityStatusesServiceProxy: ActivityStatusesServiceProxy,
             private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }
    
    show(activityStatusId?: number): void {
    

        if (!activityStatusId) {
            this.activityStatus = new CreateOrEditActivityStatusDto();
            this.activityStatus.id = activityStatusId;


            this.active = true;
            this.modal.show();
        } else {
            this._activityStatusesServiceProxy.getActivityStatusForEdit(activityStatusId).subscribe(result => {
                this.activityStatus = result.activityStatus;



                this.active = true;
                this.modal.show();
            });
        }
        
        
    }

    save(): void {
            this.saving = true;
            
			
			
            this._activityStatusesServiceProxy.createOrEdit(this.activityStatus)
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
