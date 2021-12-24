import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    ActivityTaskTypesServiceProxy,
    CreateOrEditActivityTaskTypeDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditActivityTaskTypeModal',
    templateUrl: './create-or-edit-activityTaskType-modal.component.html',
})
export class CreateOrEditActivityTaskTypeModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    activityTaskType: CreateOrEditActivityTaskTypeDto = new CreateOrEditActivityTaskTypeDto();

    constructor(
        injector: Injector,
        private _activityTaskTypesServiceProxy: ActivityTaskTypesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Show the form dialog
     */
    show(activityTaskTypeId?: number): void {
        if (!activityTaskTypeId) {
            this.activityTaskType = new CreateOrEditActivityTaskTypeDto();
            this.activityTaskType.id = activityTaskTypeId;

            this.active = true;
            this.modal.show();
        } else {
            this._activityTaskTypesServiceProxy.getActivityTaskTypeForEdit(activityTaskTypeId).subscribe((result) => {
                this.activityTaskType = result.activityTaskType;

                this.active = true;
                this.modal.show();
            });
        }
    }

    /**
     * Save the activity task type
     */
    save(): void {
        this.saving = true;

        this._activityTaskTypesServiceProxy
            .createOrEdit(this.activityTaskType)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    /**
     * Close the form dialog
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
