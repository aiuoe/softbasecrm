import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    ActivitySourceTypesServiceProxy,
    CreateOrEditActivitySourceTypeDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component for creating or updating an activity source type
 */
@Component({
    selector: 'createOrEditActivitySourceTypeModal',
    templateUrl: './create-or-edit-activitySourceType-modal.component.html',
})
export class CreateOrEditActivitySourceTypeModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    activitySourceType: CreateOrEditActivitySourceTypeDto = new CreateOrEditActivitySourceTypeDto();

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activitySourceTypesServiceProxy: ActivitySourceTypesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Show form dialog
     */
    show(activitySourceTypeId?: number): void {
        if (!activitySourceTypeId) {
            this.activitySourceType = new CreateOrEditActivitySourceTypeDto();
            this.activitySourceType.id = activitySourceTypeId;

            this.active = true;
            this.modal.show();
        } else {
            this._activitySourceTypesServiceProxy
                .getActivitySourceTypeForEdit(activitySourceTypeId)
                .subscribe((result) => {
                    this.activitySourceType = result.activitySourceType;

                    this.active = true;
                    this.modal.show();
                });
        }
    }

    /**
     * Save the activity source type
     */
    save(): void {
        this.saving = true;

        this._activitySourceTypesServiceProxy
            .createOrEdit(this.activitySourceType)
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
