﻿import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    OpportunitiesServiceProxy,
    CreateOrEditOpportunityDto,
    OpportunityOpportunityStageLookupTableDto,
    OpportunityLeadSourceLookupTableDto,
    OpportunityOpportunityTypeLookupTableDto,
    GetCustomerForEditOutput,
    GetOpportunityForEditOutput,
    OpportunityCustomerLookupTableDto,
    OpportunityContactsLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { forkJoin, Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { EntityTypeHistoryModalComponent } from '@app/shared/common/entityHistory/entity-type-history-modal.component';
import { EntityTypeHistoryComponent } from '@app/shared/common/entityHistory/entity-type-history.component';

/**
 * Component to create or edit opportunity
 */
@Component({
    templateUrl: './create-or-edit-opportunity.component.html',
    animations: [appModuleAnimation()],
})
export class CreateOrEditOpportunityComponent extends AppComponentBase implements OnInit {    
    @ViewChild('entityTypeHistory', { static: true }) entityTypeHistory: EntityTypeHistoryComponent;

    routerLink = '/app/main/business/opportunities';
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Opportunity'), '/app/main/crm/opportunities'),
        new BreadcrumbItem(this.l('NewOpportunites'), '/app/main/crm/opportunities')
    ];

    pageMode = '';
    active = false;
    saving = false;
    isNew = true;
    showSaveButton = false;
    isReadOnlyMode = false;
    isExternalCreation = false;

    opportunity: CreateOrEditOpportunityDto = new CreateOrEditOpportunityDto();

    opportunityStageDescription = '';
    leadSourceDescription = '';
    opportunityTypeDescription = '';
    customerName = '';
    contactName = '';
    customerNumber = '';


    allOpportunityStages: OpportunityOpportunityStageLookupTableDto[];
    selectedOpportunityStageId;
    allLeadSources: OpportunityLeadSourceLookupTableDto[];
    allOpportunityTypes: OpportunityOpportunityTypeLookupTableDto[];
    allCustomers: OpportunityCustomerLookupTableDto[];
    allContacts: OpportunityContactsLookupTableDto[];

    opportunityId : number;
    
    // Tab permissions
    isPageLoading = true;

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
        this.pageMode = this._activatedRoute.snapshot.routeConfig.path.toLowerCase();
        this.isReadOnlyMode = this.pageMode === 'view';
        this.opportunityId = this._activatedRoute.snapshot.queryParams['id'];
        this.customerNumber = this._activatedRoute.snapshot.queryParams['customerNumber'];
        if (this.customerNumber)
            this.isExternalCreation = true;
        this.isNew = !!!this.opportunityId;
        this.show(this.opportunityId);
        this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewOpportunity') : this.l('EditOpportunity')));
    }

    /**
     * Shows the form
     * the id of the opportunity to be used, it can be null
     * @param opportunityId 
     */
    show(opportunityId?: number): void {
        if ((this.pageMode === 'view') && !this.opportunityId)
            this.goToOpportunities();

        const requests: Observable<any>[] = [
            this._opportunitiesServiceProxy.getAllOpportunityStageForTableDropdown(),
            this._opportunitiesServiceProxy.getAllLeadSourceForTableDropdown(),
            this._opportunitiesServiceProxy.getAllOpportunityTypeForTableDropdown(),
            this._opportunitiesServiceProxy.getAllCustomerForTableDropdown()            
        ];
            

        if (!opportunityId) {
            forkJoin([...requests])
                .subscribe(([opportunityStages, leadSources,opportunityTypes, customers]: [
                    OpportunityOpportunityStageLookupTableDto[],
                    OpportunityLeadSourceLookupTableDto[],
                    OpportunityOpportunityTypeLookupTableDto[],
                    OpportunityCustomerLookupTableDto[]]) => {
                        this.isPageLoading = false;
                        this.active = true;

                    this.opportunity = new CreateOrEditOpportunityDto();
                    this.allOpportunityStages = opportunityStages;
                    this.opportunity.opportunityStageId = this.allOpportunityStages[0].id;
                    this.allLeadSources = leadSources;
                    this.allOpportunityTypes = opportunityTypes;  
                    this.allCustomers = customers;

                    if (this.customerNumber) {
                        this.opportunity.customerNumber = this.customerNumber
                        this.getContactsAccordingToCostumer(this.customerNumber);
                    }                                                            
                    
                    this.showSaveButton = !this.isReadOnlyMode;
                    }, (error) => {
                    this.goToOpportunities();
                });

        } else {
            requests.push(this._opportunitiesServiceProxy.getOpportunityForEdit(opportunityId));
            forkJoin([...requests])
            .subscribe(([opportunityStages, leadSources,opportunityTypes, customers, opportunityForEdit]: [
                OpportunityOpportunityStageLookupTableDto[],
                OpportunityLeadSourceLookupTableDto[],
                OpportunityOpportunityTypeLookupTableDto[],
                OpportunityCustomerLookupTableDto[],
                GetOpportunityForEditOutput]) => {
                    this.isPageLoading = false;
                    this.active = true;

                this.opportunity = opportunityForEdit.opportunity;
                this.opportunityStageDescription = opportunityForEdit.opportunityStageDescription
                this.leadSourceDescription = opportunityForEdit.leadSourceDescription;
                this.opportunityTypeDescription = opportunityForEdit.opportunityTypeDescription;
                this.allOpportunityStages = opportunityStages;
                this.allLeadSources = leadSources;
                this.allOpportunityTypes = opportunityTypes;  
                this.allCustomers = customers;   

                this.getContactsAccordingToCostumer(opportunityForEdit.customerNumber);

                this.showSaveButton = !this.isReadOnlyMode;
                }, (error) => {
                    this.goToOpportunities();
                });
        }
    }

    /**
     * Get the contacts for the selected customer
     * @returns void
     */
    getContactsAccordingToCostumer(customerNumber : string) : void {
        this._opportunitiesServiceProxy.getAllContactsForTableDropdownCustomerSpecific(customerNumber).subscribe((result) => {
            this.allContacts = result;
        });         
    }

    /**
     * Saves the opportunity information to the db
     * @returns void
     */
    save(): void {
        this.saving = true;
        console.log(this.opportunity.contactId)
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
    
    
    /***
     * Open internal edition mode
     */
     openEditionMode() {
        this.isReadOnlyMode = false;
        this.showSaveButton = true;
    }

    /**
     * Redirects to opportunities page
     */
     goToOpportunities() {
        this._router.navigate(['/app/main/crm/opportunities'])
    }    

}
