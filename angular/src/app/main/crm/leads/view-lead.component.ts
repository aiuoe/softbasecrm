import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { LeadsServiceProxy, GetLeadForViewDto, LeadDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
/**
 * Leads views only component
 */
@Component({
    templateUrl: './view-lead.component.html',
    animations: [appModuleAnimation()]
})
export class ViewLeadComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    item: GetLeadForViewDto;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Leads'), '/app/main/crm/leads'),
    ];
    /**
     * Main Constructor
     * @param injector 
     * @param _activatedRoute 
     * @param _leadsServiceProxy 
     * @param _router 
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _leadsServiceProxy: LeadsServiceProxy,
        private _router: Router
    ) {
        super(injector);
        this.item = new GetLeadForViewDto();
        this.item.lead = new LeadDto();
    }

    /**
     * Component Initializer
     */
    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    /**
     * Shows the form
     * @param leadId the id of the current lead 
     */
    show(leadId: number): void {
        this._leadsServiceProxy.getLeadForView(leadId).subscribe((result) => {
            this.item = result;
            this.breadcrumbs.push(new BreadcrumbItem(result.lead.companyName ||  this.l('Details')));
            this.active = true;
        });
    }

    /**
     * Navigates back to leads main page
     */
    goToLeads() {
        this._router.navigate(['/app/main/crm/leads'])
    }
}
