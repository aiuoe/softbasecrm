import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { ActivityStatusesServiceProxy, CreateOrEditActivityStatusDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component for creating or updating an activity statuses
 */
@Component({
    selector: 'createOrEditActivityStatusModal',
    templateUrl: './create-or-edit-activityStatus-modal.component.html',
})
export class CreateOrEditActivityStatusModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    activityStatus: CreateOrEditActivityStatusDto = new CreateOrEditActivityStatusDto();

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activityStatusesServiceProxy: ActivityStatusesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Show the form dialog
     */
    show(activityStatusId?: number): void {
        if (!activityStatusId) {
            this.activityStatus = new CreateOrEditActivityStatusDto();
            this.activityStatus.id = activityStatusId;
            this.activityStatus.color = '#2c4ab6';

            this.active = true;
            this.modal.show();
        } else {
            this._activityStatusesServiceProxy.getActivityStatusForEdit(activityStatusId).subscribe((result) => {
                this.activityStatus = result.activityStatus;

                this.active = true;
                this.modal.show();
            });
        }
    }

    /**
     * Save the activity status
     */
    save(): void {
        this.saving = true;

        this._activityStatusesServiceProxy
            .createOrEdit(this.activityStatus)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notifyService.success(this.l('SavedSuccessfully'));
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
