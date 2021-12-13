﻿import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    OpportunityStagesServiceProxy,
    CreateOrEditOpportunityStageDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    selector: 'createOrEditOpportunityStageModal',
    templateUrl: './create-or-edit-opportunityStage-modal.component.html',
})
export class CreateOrEditOpportunityStageModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    opportunityStage: CreateOrEditOpportunityStageDto = new CreateOrEditOpportunityStageDto();

    constructor(
        injector: Injector,
        private _opportunityStagesServiceProxy: OpportunityStagesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    show(opportunityStageId?: number): void {
        if (!opportunityStageId) {
            this.opportunityStage = new CreateOrEditOpportunityStageDto();
            this.opportunityStage.id = opportunityStageId;

            this.active = true;
            this.modal.show();
        } else {
            this._opportunityStagesServiceProxy.getOpportunityStageForEdit(opportunityStageId).subscribe((result) => {
                this.opportunityStage = result.opportunityStage;

                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._opportunityStagesServiceProxy
            .createOrEdit(this.opportunityStage)
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
