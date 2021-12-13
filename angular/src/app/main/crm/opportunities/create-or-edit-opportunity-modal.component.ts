import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { OpportunitiesServiceProxy, CreateOrEditOpportunityDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { OpportunityOpportunityStageLookupTableModalComponent } from './opportunity-opportunityStage-lookup-table-modal.component';
import { OpportunityLeadSourceLookupTableModalComponent } from './opportunity-leadSource-lookup-table-modal.component';
import { OpportunityOpportunityTypeLookupTableModalComponent } from './opportunity-opportunityType-lookup-table-modal.component';

@Component({
    selector: 'createOrEditOpportunityModal',
    templateUrl: './create-or-edit-opportunity-modal.component.html',
})
export class CreateOrEditOpportunityModalComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('opportunityOpportunityStageLookupTableModal', { static: true })
    opportunityOpportunityStageLookupTableModal: OpportunityOpportunityStageLookupTableModalComponent;
    @ViewChild('opportunityLeadSourceLookupTableModal', { static: true })
    opportunityLeadSourceLookupTableModal: OpportunityLeadSourceLookupTableModalComponent;
    @ViewChild('opportunityOpportunityTypeLookupTableModal', { static: true })
    opportunityOpportunityTypeLookupTableModal: OpportunityOpportunityTypeLookupTableModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    opportunity: CreateOrEditOpportunityDto = new CreateOrEditOpportunityDto();

    opportunityStageDescription = '';
    leadSourceDescription = '';
    opportunityTypeDescription = '';

    constructor(
        injector: Injector,
        private _opportunitiesServiceProxy: OpportunitiesServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    show(opportunityId?: number): void {
        if (!opportunityId) {
            this.opportunity = new CreateOrEditOpportunityDto();
            this.opportunity.id = opportunityId;
            this.opportunity.closeDate = this._dateTimeService.getStartOfDay();
            this.opportunityStageDescription = '';
            this.leadSourceDescription = '';
            this.opportunityTypeDescription = '';

            this.active = true;
            this.modal.show();
        } else {
            this._opportunitiesServiceProxy.getOpportunityForEdit(opportunityId).subscribe((result) => {
                this.opportunity = result.opportunity;

                this.opportunityStageDescription = result.opportunityStageDescription;
                this.leadSourceDescription = result.leadSourceDescription;
                this.opportunityTypeDescription = result.opportunityTypeDescription;

                this.active = true;
                this.modal.show();
            });
        }
    }

    save(): void {
        this.saving = true;

        this._opportunitiesServiceProxy
            .createOrEdit(this.opportunity)
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

    openSelectOpportunityStageModal() {
        this.opportunityOpportunityStageLookupTableModal.id = this.opportunity.opportunityStageId;
        this.opportunityOpportunityStageLookupTableModal.displayName = this.opportunityStageDescription;
        this.opportunityOpportunityStageLookupTableModal.show();
    }
    openSelectLeadSourceModal() {
        this.opportunityLeadSourceLookupTableModal.id = this.opportunity.leadSourceId;
        this.opportunityLeadSourceLookupTableModal.displayName = this.leadSourceDescription;
        this.opportunityLeadSourceLookupTableModal.show();
    }
    openSelectOpportunityTypeModal() {
        this.opportunityOpportunityTypeLookupTableModal.id = this.opportunity.opportunityTypeId;
        this.opportunityOpportunityTypeLookupTableModal.displayName = this.opportunityTypeDescription;
        this.opportunityOpportunityTypeLookupTableModal.show();
    }

    setOpportunityStageIdNull() {
        this.opportunity.opportunityStageId = null;
        this.opportunityStageDescription = '';
    }
    setLeadSourceIdNull() {
        this.opportunity.leadSourceId = null;
        this.leadSourceDescription = '';
    }
    setOpportunityTypeIdNull() {
        this.opportunity.opportunityTypeId = null;
        this.opportunityTypeDescription = '';
    }

    getNewOpportunityStageId() {
        this.opportunity.opportunityStageId = this.opportunityOpportunityStageLookupTableModal.id;
        this.opportunityStageDescription = this.opportunityOpportunityStageLookupTableModal.displayName;
    }
    getNewLeadSourceId() {
        this.opportunity.leadSourceId = this.opportunityLeadSourceLookupTableModal.id;
        this.leadSourceDescription = this.opportunityLeadSourceLookupTableModal.displayName;
    }
    getNewOpportunityTypeId() {
        this.opportunity.opportunityTypeId = this.opportunityOpportunityTypeLookupTableModal.id;
        this.opportunityTypeDescription = this.opportunityOpportunityTypeLookupTableModal.displayName;
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit(): void {}
}
