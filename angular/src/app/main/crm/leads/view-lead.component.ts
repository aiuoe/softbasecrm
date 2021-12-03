import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { LeadsServiceProxy, GetLeadForViewDto, LeadDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-lead.component.html',
    animations: [appModuleAnimation()],
})
export class ViewLeadComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    item: GetLeadForViewDto;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Lead'), '/app/main/crm/leads'),
        new BreadcrumbItem(this.l('Leads') + '' + this.l('Details')),
    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _leadsServiceProxy: LeadsServiceProxy
    ) {
        super(injector);
        this.item = new GetLeadForViewDto();
        this.item.lead = new LeadDto();
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(leadId: number): void {
        this._leadsServiceProxy.getLeadForView(leadId).subscribe((result) => {
            this.item = result;
            this.active = true;
        });
    }
}
