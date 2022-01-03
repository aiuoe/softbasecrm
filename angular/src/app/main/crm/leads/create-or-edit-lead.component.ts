import {
    Component,
    ViewChild,
    Injector,
    OnInit,
    ViewEncapsulation
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
    LeadsServiceProxy,
    CreateOrEditLeadDto,
    LeadLeadSourceLookupTableDto,
    LeadLeadStatusLookupTableDto,
    LeadPriorityLookupTableDto,
    CountriesServiceProxy,
    CountryDto, AccountUsersServiceProxy, LeadUsersServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { MenuItem } from 'primeng/api';
import { NgForm } from '@angular/forms';
import { EntityTypeHistoryComponent } from '@app/shared/common/entityHistory/entity-type-history.component';
import { Location } from '@angular/common';
import { forkJoin, Observable } from '@node_modules/rxjs';

/**
 * Component to create or edit leads
 */
@Component({
    templateUrl: './create-or-edit-lead.component.html',
    animations: [appModuleAnimation()],
    encapsulation: ViewEncapsulation.None,
    styleUrls: ['./create-or-edit-lead.component.scss']
})
export class CreateOrEditLeadComponent extends AppComponentBase implements OnInit {

    @ViewChild('LeadForm', { static: true }) LeadForm: NgForm;
    @ViewChild('entityTypeHistory', { static: true }) entityTypeHistory: EntityTypeHistoryComponent;

    pageMode = '';
    active = false;
    saving = false;
    showSaveButton = false;
    leadId: number;

    routerLink = '/app/main/crm/leads';

    lead: CreateOrEditLeadDto = new CreateOrEditLeadDto();
    leadSourceDescription = '';
    leadStatusDescription = '';
    priorityDescription = '';

    allLeadSources: LeadLeadSourceLookupTableDto[];
    allLeadStatuss: LeadLeadStatusLookupTableDto[];
    allPrioritys: LeadPriorityLookupTableDto[];
    isNew = true;
    isReadOnlyMode = false;
    showEventsTab = false;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Lead'), this.routerLink)
    ];

    items: MenuItem[];
    countries: CountryDto[] = [];

    // Widgets
    showAssignedUsersWidget = false;

    /**
     * Main constructor
     * @param injector
     * @param _activatedRoute
     * @param _leadsServiceProxy
     * @param _router
     * @param _countriesServiceProxy
     * @param location
     * @param _leadUsersServiceProxy
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _router: Router,
        private _countriesServiceProxy: CountriesServiceProxy,
        private location: Location,
        private _leadUsersServiceProxy: LeadUsersServiceProxy
    ) {
        super(injector);
    }

    /**
     * Initialize component
     */
    ngOnInit(): void {
        this.leadId = this._activatedRoute.snapshot.queryParams['id'];
        this.pageMode = this._activatedRoute.snapshot.routeConfig.path.toLowerCase();
        this.isReadOnlyMode = this.pageMode === 'view';
        this.isNew = !!!this.leadId;
        this.setPermissions();

        this.show(this.leadId);
    }

    /***
     * Set permissions
     */
    setPermissions() {
        this.showEventsTab = this.isGrantedAny('Pages.Leads.ViewEvents');

        // Dynamic at runtime Permissions
        const permissionsRequests: Observable<any>[] = [
            this._leadUsersServiceProxy.getCanViewAssignedUsersWidget(this.leadId)
        ];
        forkJoin([...permissionsRequests])
            .subscribe(([getCanViewAssignedUsersWidget]) => {
                this.showAssignedUsersWidget = getCanViewAssignedUsersWidget;
            });
    }

    /**
     * Redirects to leads page
     */
    goToLeads() {
        this._router.navigate(['/app/main/crm/leads']);
    }

    /**
     * Shows the form
     * @param leadId the id of the lead to be used, it can be null
     */
    show(leadId?: number): void {
        if (!leadId) {
            this.lead = new CreateOrEditLeadDto();
            this.lead.id = leadId;
            this.leadSourceDescription = '';
            this.leadStatusDescription = '';
            this.priorityDescription = '';
            this.active = true;
            this.breadcrumbs.push(new BreadcrumbItem(this.l('CreateNewLead')));
            this.showSaveButton = !this.isReadOnlyMode;
        } else {
            this.entityTypeHistory.show({
                entityId: leadId.toString(),
                entityName: 'Lead'
            });
            this._leadsServiceProxy.getLeadForEdit(leadId)
                .subscribe((result) => {
                    this.lead = result.lead;
                    this.breadcrumbs.push(new BreadcrumbItem(result.lead.companyName || this.l('EditLead')));
                    this.leadSourceDescription = result.leadSourceDescription;
                    this.leadStatusDescription = result.leadStatusDescription;
                    this.priorityDescription = result.priorityDescription;

                    this.active = true;
                    this.showSaveButton = !this.isReadOnlyMode;
                });
        }
        this._leadsServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
            if (!this.lead.leadSourceId) {
                const defaultSource = result.find(p => p.isDefault)?.id;
                this.lead.leadSourceId = defaultSource;
            }
        });
        this._leadsServiceProxy.getAllLeadStatusForTableDropdown().subscribe((result) => {
            this.allLeadStatuss = result;
            if (!this.lead.leadStatusId) {
                const defaultStatus = result.find(p => p.isDefault)?.id;
                this.lead.leadStatusId = defaultStatus;
            }
        });
        this._leadsServiceProxy.getAllPriorityForTableDropdown().subscribe((result) => {
            this.allPrioritys = result;
            if (!this.lead.priorityId) {
                const defaultPriority = result.find(p => p.isDefault)?.id;
                this.lead.priorityId = defaultPriority;
            }
        });
        this._countriesServiceProxy.getAllForTableDropdown().subscribe((result) => {
            this.countries = result.map(c => c.country);
        });
    }

    /**
     * Saves the lead information to the db
     * @returns void
     */
    save(): void {
        if (!this.LeadForm.form.valid) {
            this.LeadForm.form.markAllAsTouched();
            this.message.warn(this.l('InvalidFormMessage'));
            return;
        }
        this.saving = true;
        this._leadsServiceProxy
            .createOrEdit(this.lead)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((_) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this.goToLeads();
            });
    }

    /***
     * Open internal edition mode
     */
    openEditionMode() {
        this.isReadOnlyMode = false;
        this.isNew = false;
        this.showSaveButton = true;
        this.location.replaceState(`${ this.routerLink }/createOrEdit?id=${ this.leadId }`);
    }


    /***
     * Reload entity events grid
     */
    reloadEvents() {
        this.entityTypeHistory.refreshTable();
    }
}
