import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    LeadsServiceProxy,
    CreateOrEditLeadDto,
    LeadIndustryLookupTableDto,
    LeadLeadSourceLookupTableDto,
    LeadLeadStatusLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './create-or-edit-lead.component.html',
    animations: [appModuleAnimation()],
})
export class CreateOrEditLeadComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    lead: CreateOrEditLeadDto = new CreateOrEditLeadDto();

    industryDescription = '';
    leadSourceDescription = '';
    leadStatusDescription = '';

    allIndustrys: LeadIndustryLookupTableDto[];
    allLeadSources: LeadLeadSourceLookupTableDto[];
    allLeadStatuss: LeadLeadStatusLookupTableDto[];

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Lead'), '/app/main/crm/leads'),
        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
    ];

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(leadId?: number): void {
        if (!leadId) {
            this.lead = new CreateOrEditLeadDto();
            this.lead.id = leadId;
            this.industryDescription = '';
            this.leadSourceDescription = '';
            this.leadStatusDescription = '';

            this.active = true;
        } else {
            this._leadsServiceProxy.getLeadForEdit(leadId).subscribe((result) => {
                this.lead = result.lead;

                this.industryDescription = result.industryDescription;
                this.leadSourceDescription = result.leadSourceDescription;
                this.leadStatusDescription = result.leadStatusDescription;

                this.active = true;
            });
        }
        this._leadsServiceProxy.getAllIndustryForTableDropdown().subscribe((result) => {
            this.allIndustrys = result;
        });
        this._leadsServiceProxy.getAllLeadSourceForTableDropdown().subscribe((result) => {
            this.allLeadSources = result;
        });
        this._leadsServiceProxy.getAllLeadStatusForTableDropdown().subscribe((result) => {
            this.allLeadStatuss = result;
        });
    }

    save(): void {
        this.saving = true;

        this._leadsServiceProxy
            .createOrEdit(this.lead)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this._router.navigate(['/app/main/crm/leads']);
            });
    }

    saveAndNew(): void {
        this.saving = true;

        this._leadsServiceProxy
            .createOrEdit(this.lead)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this.lead = new CreateOrEditLeadDto();
            });
    }
}
