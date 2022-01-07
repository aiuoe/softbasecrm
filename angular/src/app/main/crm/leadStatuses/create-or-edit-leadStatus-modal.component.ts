import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { LeadStatusesServiceProxy, CreateOrEditLeadStatusDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/***
 * Component to create or edit lead statuses
 */
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

    /***
     * Class constructor
     */
    constructor(
        injector: Injector,
        private _leadStatusesServiceProxy: LeadStatusesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /***
     * Method that gets the rows to display in the grid
     * @param opportunityStageId
     */
    show(leadStatusId?: number): void {
        if (!leadStatusId) {
            this.leadStatus = new CreateOrEditLeadStatusDto();
            this.leadStatus.id = leadStatusId;
            this.leadStatus.color = '#2c4ab6';

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

    /***
     * Method that saves an lead status in the database
     */
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
                this.notifyService.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    /***
     * Method that close modal
     */
    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
