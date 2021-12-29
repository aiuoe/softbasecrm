import { Component, ViewChild, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
    OpportunitiesServiceProxy,
    CreateOrEditOpportunityDto,
    OpportunityOpportunityStageLookupTableDto,
    OpportunityLeadSourceLookupTableDto,
    OpportunityOpportunityTypeLookupTableDto,
    GetOpportunityForEditOutput,
    OpportunityCustomerLookupTableDto,
    OpportunityContactsLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { forkJoin, Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { EntityTypeHistoryComponent } from '@app/shared/common/entityHistory/entity-type-history.component';
import { NgForm } from '@angular/forms';
import { Location } from '@angular/common';

/**
 * Component to create or edit opportunity
 */
@Component({
    templateUrl: './create-or-edit-opportunity.component.html',
    animations: [appModuleAnimation()],
})
export class CreateOrEditOpportunityComponent extends AppComponentBase implements OnInit {
    @ViewChild('opportunityForm', { static: true }) opportunityForm: NgForm;
    @ViewChild('entityTypeHistory', { static: true }) entityTypeHistory: EntityTypeHistoryComponent;

    routerLink = '/app/main/crm/opportunities';
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Opportunity'), this.routerLink),
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
    opportunityCustomerName = '';
    formDate: Date;


    allOpportunityStages: OpportunityOpportunityStageLookupTableDto[];
    allLeadSources: OpportunityLeadSourceLookupTableDto[];
    allOpportunityTypes: OpportunityOpportunityTypeLookupTableDto[];
    allCustomers: OpportunityCustomerLookupTableDto[];
    allContacts: OpportunityContactsLookupTableDto[];

    opportunityId: number;

    // Tab permissions
    isPageLoading = true;
    showEventsTab = false;

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
        private _dateTimeService: DateTimeService,
        private location: Location
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
        this.opportunityCustomerName = this._activatedRoute.snapshot.queryParams['customerName'];
        this.customerNumber = this._activatedRoute.snapshot.queryParams['customerNumber'];
        if (this.customerNumber) {
            this.isExternalCreation = true;
        }
        this.isNew = !!!this.opportunityId;

        this.setPermissions();

        this.show(this.opportunityId);
        this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('NewOpportunities') : this.opportunityCustomerName));
    }

    /***
     * Set permissions
     */
    setPermissions() {
        this.showEventsTab = this.isGrantedAny('Pages.Opportunities.ViewEvents');
    }

    /**
     * Shows the form
     * the id of the opportunity to be used, it can be null
     * @param opportunityId
     */
    show(opportunityId?: number): void {
        if ((this.pageMode === 'view') && !this.opportunityId) {
            this.goToOpportunities();
        }

        const requests: Observable<any>[] = [
            this._opportunitiesServiceProxy.getAllOpportunityStageForTableDropdown(),
            this._opportunitiesServiceProxy.getAllLeadSourceForTableDropdown(),
            this._opportunitiesServiceProxy.getAllOpportunityTypeForTableDropdown(),
            this._opportunitiesServiceProxy.getAllCustomerForTableDropdown()
        ];


        if (!opportunityId) {
            forkJoin([...requests])
                .subscribe(([opportunityStages, leadSources, opportunityTypes, customers]: [
                    OpportunityOpportunityStageLookupTableDto[],
                    OpportunityLeadSourceLookupTableDto[],
                    OpportunityOpportunityTypeLookupTableDto[],
                    OpportunityCustomerLookupTableDto[]]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.opportunity = new CreateOrEditOpportunityDto();
                    this.allOpportunityStages = opportunityStages;
                    this.opportunity.opportunityStageId = this.allOpportunityStages[0] ? this.allOpportunityStages[0].id : null;
                    this.allLeadSources = leadSources;
                    this.allOpportunityTypes = opportunityTypes;
                    this.allCustomers = customers;

                    if (this.customerNumber) {
                        this.opportunity.customerNumber = this.customerNumber;
                        this.getContactsAccordingToCustomer(this.customerNumber);
                    }

                    this.showSaveButton = !this.isReadOnlyMode;
                }, (error) => {
                    this.goToOpportunities();
                });

        } else {

            this.entityTypeHistory.show({
                entityId: opportunityId.toString(),
                entityName: 'Opportunity'
            });

            requests.push(this._opportunitiesServiceProxy.getOpportunityForEdit(opportunityId));
            forkJoin([...requests])
                .subscribe(([opportunityStages, leadSources, opportunityTypes, customers, opportunityForEdit]: [
                    OpportunityOpportunityStageLookupTableDto[],
                    OpportunityLeadSourceLookupTableDto[],
                    OpportunityOpportunityTypeLookupTableDto[],
                    OpportunityCustomerLookupTableDto[],
                    GetOpportunityForEditOutput]) => {
                    this.isPageLoading = false;
                    this.active = true;

                    this.opportunity = opportunityForEdit.opportunity;
                    this.opportunityStageDescription = opportunityForEdit.opportunityStageDescription;
                    this.leadSourceDescription = opportunityForEdit.leadSourceDescription;
                    this.opportunityTypeDescription = opportunityForEdit.opportunityTypeDescription;
                    this.allOpportunityStages = opportunityStages;
                    this.allLeadSources = leadSources;
                    this.allOpportunityTypes = opportunityTypes;
                    this.allCustomers = customers;

                    this.getContactsAccordingToCustomer(opportunityForEdit.customerNumber);

                    this.formDate = this.opportunity.closeDate ? new Date(this.opportunity.closeDate.toString()) : null;

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
    getContactsAccordingToCustomer(customerNumber: string): void {
        this._opportunitiesServiceProxy.getAllContactsForTableDropdownCustomerSpecific(customerNumber).subscribe((result) => {
            this.allContacts = result;
            if (this.allContacts.length === 1) {
                this.opportunity.contactId = this.allContacts[0].id;
            }
        });
    }

    /**
     * Saves the opportunity information to the db
     * @returns void
     */
    save(): void {
        if (!this.opportunityForm.form.valid) {
            this.opportunityForm.form.markAllAsTouched();
            this.message.warn(this.l('InvalidFormMessage'));
            return;
        }

        if (this.opportunity.probability < 1 || this.opportunity.probability > 100) {
            this.opportunityForm.form.controls['Opportunity_Probability'].setErrors(
                { 'opportunityInvalidProbability': true });
            this.message.warn(this.l('InvalidFormMessage'));
            return;
        }

        this.opportunity.closeDate = this._dateTimeService.fromJSDate(this.formDate);

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
                this._router.navigate([this.routerLink]);
            });
    }


    /***
     * Open internal edition mode
     */
    openEditionMode() {
        this.isReadOnlyMode = false;
        this.showSaveButton = true;
        this.location.replaceState(`${ this.routerLink }/createOrEdit?id=${ this.opportunityId }`);
    }

    /**
     * Redirects to opportunities page
     */
    goToOpportunities() {
        this._router.navigate([this.routerLink]);
    }

}
