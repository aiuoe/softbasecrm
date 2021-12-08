import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { LeadStatusesServiceProxy, CreateOrEditLeadStatusDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditLeadStatusModal',
    templateUrl: './create-or-edit-leadStatus-modal.component.html',
})
export class CreateOrEditLeadStatusModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    leadStatus: CreateOrEditLeadStatusDto = new CreateOrEditLeadStatusDto();

    constructor(
        injector: Injector,
        private _leadStatusesServiceProxy: LeadStatusesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    show(leadStatusId?: number): void {
        if (!leadStatusId) {
            this.leadStatus = new CreateOrEditLeadStatusDto();
            this.leadStatus.id = leadStatusId;

            this.active = true;
            this.modal.show();
        } else {
            this._leadStatusesServiceProxy.getLeadStatusForEdit(leadStatusId).subscribe((result) => {
                this.leadStatus = result.leadStatus;

                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._leadStatusesServiceProxy
            .createOrEdit(this.leadStatus)
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

    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
