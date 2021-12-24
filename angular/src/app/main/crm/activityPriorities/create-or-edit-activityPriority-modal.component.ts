import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    ActivityPrioritiesServiceProxy,
    CreateOrEditActivityPriorityDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditActivityPriorityModal',
    templateUrl: './create-or-edit-activityPriority-modal.component.html',
})
export class CreateOrEditActivityPriorityModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    activityPriority: CreateOrEditActivityPriorityDto = new CreateOrEditActivityPriorityDto();

    constructor(
        injector: Injector,
        private _activityPrioritiesServiceProxy: ActivityPrioritiesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Show the form dialog
     */
    show(activityPriorityId?: number): void {
        if (!activityPriorityId) {
            this.activityPriority = new CreateOrEditActivityPriorityDto();
            this.activityPriority.id = activityPriorityId;

            this.active = true;
            this.modal.show();
        } else {
            this._activityPrioritiesServiceProxy.getActivityPriorityForEdit(activityPriorityId).subscribe((result) => {
                this.activityPriority = result.activityPriority;

                this.active = true;
                this.modal.show();
            });
        }
    }

    /**
     * Save the activity priority
     */
    save(): void {
        this.saving = true;

        this._activityPrioritiesServiceProxy
            .createOrEdit(this.activityPriority)
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
