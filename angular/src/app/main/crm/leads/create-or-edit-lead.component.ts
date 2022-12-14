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
    CountryDto,
    LeadUsersServiceProxy,
    GetLeadForEditOutput,
    LeadVisibilityTabDto,
    ZipCodeDto,
    GetZipCodeForViewDto,
    PagedResultDtoOfGetZipCodeForViewDto,
    ZipCodesServiceProxy
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
import { AppConsts } from '@shared/AppConsts';

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
    showEditButton = false;
    leadId: number;

    routerLink = '/app/main/crm/leads';

    lead: CreateOrEditLeadDto = new CreateOrEditLeadDto();
    leadSourceDescription = '';
    leadStatusDescription = '';
    priorityDescription = '';

    allLeadSources: LeadLeadSourceLookupTableDto[];
    allLeadStatuss: LeadLeadStatusLookupTableDto[];
    allPrioritys: LeadPriorityLookupTableDto[];
    usZipCodes: GetZipCodeForViewDto[] = [];
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
    showActivityWidget = false;
    showAttachmentsWidget = false;

    // Activity Widget Permissions
    canCreateActivity = false;
    canViewScheduleMeetingOption = false;
    canViewScheduleCallOption = false;
    canViewEmailReminderOption = false;
    canViewToDoReminderOption = false;
    canEditActivity = false;
    canAssignAnyUserInActivity = false;

    /**
     * Main constructor
     * @param injector
     * @param _activatedRoute
     * @param _leadsServiceProxy
     * @param _router
     * @param _countriesServiceProxy
     * @param location
     * @param _leadUsersServiceProxy
     * @param _zipCodeServiceProxy
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _router: Router,
        private _countriesServiceProxy: CountriesServiceProxy,
        private location: Location,
        private _leadUsersServiceProxy: LeadUsersServiceProxy,
        private _zipCodeServiceProxy: ZipCodesServiceProxy
    ) {
        super(injector);
    }

    /**
     * Initialize component
     */
    ngOnInit(): void {
        this.leadId = this._activatedRoute.snapshot.queryParams['id'];
        this.pageMode = this._activatedRoute.snapshot.routeConfig.path.toLowerCase();
        this.isReadOnlyMode = this.pageMode === AppConsts.ViewMode;
        this.isNew = !!!this.leadId;
        if (this.leadId) {
            this.setPermissions();
        }
        this.show(this.leadId);
    }

    /***
     * Set permissions
     */
    setPermissions() {
        this.showEventsTab = this.isGrantedAny('Pages.Leads.ViewEvents');

        // Dynamic at runtime Permissions
        const permissionsRequests: Observable<any>[] = [
            this._leadUsersServiceProxy.getCanViewAssignedUsersWidget(this.leadId),
            this._leadsServiceProxy.getVisibilityTabsPermissions(this.leadId)
        ];
        forkJoin([...permissionsRequests])
            .subscribe(([getCanViewAssignedUsersWidget, getVisibility]: [boolean, LeadVisibilityTabDto]) => {
                this.showAssignedUsersWidget = getCanViewAssignedUsersWidget;
                switch (this.pageMode) {
                    case AppConsts.ViewMode:
                        this.showEditButton = getVisibility.canEditOverviewTab;
                        break;
                    case AppConsts.CreateOrEditMode:
                        this.showSaveButton = getVisibility.canEditOverviewTab;
                        this.isReadOnlyMode = !getVisibility.canEditOverviewTab;
                        break;
                }
                this.entityTypeHistory.show({
                    entityId: this.leadId.toString(),
                    entityName: AppConsts.Lead,
                    show: this.showEventsTab
                });
            });
    }

    /**
     * Redirects to leads page
     */
    goToLeads() {
        this._router.navigate([this.routerLink]);
    }

    /**
     * Shows the form
     * @param leadId the id of the lead to be used, it can be null
     */
    show(leadId?: number): void {

        if ((this.pageMode === AppConsts.ViewMode) && !leadId) {
            this.goToLeads();
        }

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
            this._leadsServiceProxy.getLeadForEdit(leadId)
                .subscribe((result) => {
                    this.lead = result.lead;
                    this.breadcrumbs.push(new BreadcrumbItem(result.lead.companyName || this.l('EditLead')));
                    this.leadSourceDescription = result.leadSourceDescription;
                    this.leadStatusDescription = result.leadStatusDescription;
                    this.priorityDescription = result.priorityDescription;

                    this.assignRestrictionFields(result);

                    this.active = true;
                    // this.showSaveButton = !this.isReadOnlyMode;
                }, () => {
                    this.goToLeads();
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

        this._zipCodeServiceProxy.getAllZipCodesForTableDropdown()
            .subscribe((zipCodes: PagedResultDtoOfGetZipCodeForViewDto) => {
                this.usZipCodes = zipCodes.items;
            });
    }

    /**
     * Assign the values of restriction fields based on the permission level
     * @param leadForEdit
     * @returns void
     */
    assignRestrictionFields(leadForEdit: GetLeadForEditOutput): void {
        this.showAttachmentsWidget = leadForEdit.canViewAttachmentsWidget;
        this.showActivityWidget = leadForEdit.canViewActivityWidget;
        this.canCreateActivity = leadForEdit.canCreateActivity;
        this.canViewScheduleMeetingOption = leadForEdit.canViewScheduleMeetingOption;
        this.canViewScheduleCallOption = leadForEdit.canViewScheduleCallOption;
        this.canViewEmailReminderOption = leadForEdit.canViewEmailReminderOption;
        this.canViewToDoReminderOption = leadForEdit.canViewToDoReminderOption;
        this.canEditActivity = leadForEdit.canEditActivity;
        this.canAssignAnyUserInActivity = leadForEdit.canAssignAnyUserInActivity;
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
                this.notifyService.success(this.l('SavedSuccessfully'));
                this.goToLeads();
            });
    }

    /***
     * Open internal edition mode
     */
    openEditionMode() {
        this.showEditButton = false;
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

    /***
     * Search zipcode and populate City/State/Country
     * @param event
     */
    getZipCode(event: KeyboardEvent) {
        const zipCodeHasMoreThan5Characters = this.lead.zipCode?.trim().length >= 5 && this.lead.zipCode;
        const keyDownIsBackspace = event && event.key === AppConsts.Backspace;
        if (zipCodeHasMoreThan5Characters || keyDownIsBackspace) {
            const zipCodeFound: ZipCodeDto = this.usZipCodes.map(x => x.zipCode).find(x => x.zipCode === this.lead.zipCode);
            if (zipCodeFound) {
                this.lead.city = zipCodeFound.city;
                this.lead.state = zipCodeFound.state;
                this.lead.country = AppConsts.UnitedStatesCountryCode;
            }
        }
    }
}
