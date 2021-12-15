import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef, ViewEncapsulation } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    LeadsServiceProxy,
    CreateOrEditLeadDto,
    LeadLeadSourceLookupTableDto,
    LeadLeadStatusLookupTableDto,
    LeadPriorityLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { MenuItem } from 'primeng/api';
import { NgForm } from '@angular/forms';
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
    active = false;
    saving = false;

    lead: CreateOrEditLeadDto = new CreateOrEditLeadDto();
    @ViewChild('LeadForm', { static: true }) LeadForm: NgForm;

    leadSourceDescription = '';
    leadStatusDescription = '';
    priorityDescription = '';

    allLeadSources: LeadLeadSourceLookupTableDto[];
    allLeadStatuss: LeadLeadStatusLookupTableDto[];
    allPrioritys: LeadPriorityLookupTableDto[];

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Lead'), '/app/main/crm/leads')
    ];

    items: MenuItem[];

    /**
     * Main constructor
     * @param injector 
     * @param _activatedRoute 
     * @param _leadsServiceProxy 
     * @param _router 
     * @param _dateTimeService 
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService,
    ) {
        super(injector);
    }

    /**
     * Initialize component
     */
    ngOnInit(): void {
        const hasId = this._activatedRoute.snapshot.queryParams['id'];
        this.show(hasId);
        this.breadcrumbs.push(new BreadcrumbItem(hasId ? this.l('EditLead') : this.l('CreateNewLead')));
    }

    /**
     * Redirects to leads page
     */
    goToLeads() {
        this._router.navigate(['/app/main/crm/leads'])
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
        } else {
            this._leadsServiceProxy.getLeadForEdit(leadId).subscribe((result) => {
                this.lead = result.lead;

                this.leadSourceDescription = result.leadSourceDescription;
                this.leadStatusDescription = result.leadStatusDescription;
                this.priorityDescription = result.priorityDescription;

                this.active = true;
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
}
