import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { PrioritiesServiceProxy, CreateOrEditPriorityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditPriorityModal',
    templateUrl: './create-or-edit-priority-modal.component.html',
})
export class CreateOrEditPriorityModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    priority: CreateOrEditPriorityDto = new CreateOrEditPriorityDto();

    constructor(
        injector: Injector,
        private _prioritiesServiceProxy: PrioritiesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    show(priorityId?: number): void {
        if (!priorityId) {
            this.priority = new CreateOrEditPriorityDto();
            this.priority.id = priorityId;

            this.active = true;
            this.modal.show();
        } else {
            this._prioritiesServiceProxy.getPriorityForEdit(priorityId).subscribe((result) => {
                this.priority = result.priority;

                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._prioritiesServiceProxy
            .createOrEdit(this.priority)
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

    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
