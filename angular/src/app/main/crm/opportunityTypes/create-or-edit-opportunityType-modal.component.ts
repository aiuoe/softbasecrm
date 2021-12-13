﻿import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { OpportunityTypesServiceProxy, CreateOrEditOpportunityTypeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

             import { DateTimeService } from '@app/shared/common/timing/date-time.service';



@Component({
    selector: 'createOrEditOpportunityTypeModal',
    templateUrl: './create-or-edit-opportunityType-modal.component.html'
})
export class CreateOrEditOpportunityTypeModalComponent extends AppComponentBase implements OnInit{
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    opportunityType: CreateOrEditOpportunityTypeDto = new CreateOrEditOpportunityTypeDto();




    constructor(
        injector: Injector,
        private _opportunityTypesServiceProxy: OpportunityTypesServiceProxy,
             private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }
    
    show(opportunityTypeId?: number): void {
    

        if (!opportunityTypeId) {
            this.opportunityType = new CreateOrEditOpportunityTypeDto();
            this.opportunityType.id = opportunityTypeId;


            this.active = true;
            this.modal.show();
        } else {
            this._opportunityTypesServiceProxy.getOpportunityTypeForEdit(opportunityTypeId).subscribe(result => {
                this.opportunityType = result.opportunityType;



                this.active = true;
                this.modal.show();
            });
        }
        
        
    }

    save(): void {
            this.saving = true;
            
			
			
            this._opportunityTypesServiceProxy.createOrEdit(this.opportunityType)
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
