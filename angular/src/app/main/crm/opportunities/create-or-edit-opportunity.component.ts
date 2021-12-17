import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    OpportunitiesServiceProxy,
    CreateOrEditOpportunityDto,
    OpportunityOpportunityStageLookupTableDto,
    OpportunityLeadSourceLookupTableDto,
    OpportunityOpportunityTypeLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component to create or edit opportunity
 */
@Component({
    templateUrl: './create-or-edit-opportunity.component.html',
    animations: [appModuleAnimation()],
})
export class CreateOrEditOpportunityComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    opportunity: CreateOrEditOpportunityDto = new CreateOrEditOpportunityDto();

    opportunityStageDescription = '';
    leadSourceDescription = '';
    opportunityTypeDescription = '';

    allOpportunityStages: OpportunityOpportunityStageLookupTableDto[];
    allLeadSources: OpportunityLeadSourceLookupTableDto[];
    allOpportunityTypes: OpportunityOpportunityTypeLookupTableDto[];

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Opportunity'), '/app/main/crm/opportunities'),
    ];

    /**
     * Main constructor
     * @param injector 
     * @param _activatedRoute 
     * @param _opportunityServiceProxy 
     * @param _router 
     * @param _dateTimeService 
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _opportunitiesServiceProxy: OpportunitiesServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Initialize component
     */
    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    /**
     * Redirects to opportunities page
     */
    goToOpportunities() {
        this._router.navigate(['/app/main/crm/opportunities'])
    }

    /**
     * Shows the form
     * @param opportunityId the id of the lead to be used, it can be null
     */
    show(opportunityId?: number): void {
        if (!opportunityId) {
            this.opportunity = new CreateOrEditOpportunityDto();
            this.opportunity.id = opportunityId;
            this.opportunity.closeDate = this._dateTimeService.getStartOfDay();
            this.opportunityStageDescription = '';
            this.leadSourceDescription = '';
            this.opportunityTypeDescription = '';

            this.active = true;
        } else {
            this._opportunitiesServiceProxy.getOpportunityForEdit(opportunityId).subscribe((result) => {
                this.opportunity = result.opportunity;

                this.opportunityStageDescription = result.opportunityStageDescription;
                this.leadSourceDescription = result.leadSourceDescription;
                this.opportunityTypeDescription = result.opportunityTypeDescription;

                this.active = true;
            });
        }
        this._opportunitiesServiceProxy.getAllOpportunityStageForTableDropdown().subscribe((result) => {
            this.allOpportunityStages = result;
        });
        this._opportunitiesServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
        });
        this._opportunitiesServiceProxy.getAllOpportunityTypeForTableDropdown().subscribe((result) => {
            this.allOpportunityTypes = result;
        });
    }

    /**
     * Saves the opportunity information to the db
     * @returns void
     */
    save(): void {
        this.saving = true;
        this._opportunitiesServiceProxy
            .createOrEdit(this.opportunity)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this._router.navigate(['/app/main/crm/opportunities']);
            });
    }

    /**
     * Saves the opportunity information to the db and stays on create new page
     * @returns void
     */
    saveAndNew(): void {
        this.saving = true;

        this._opportunitiesServiceProxy
            .createOrEdit(this.opportunity)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this.opportunity = new CreateOrEditOpportunityDto();
            });
    }
}
