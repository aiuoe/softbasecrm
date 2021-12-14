import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import {
    OpportunitiesServiceProxy,
    GetOpportunityForViewDto,
    OpportunityDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-opportunity.component.html',
    animations: [appModuleAnimation()],
})
export class ViewOpportunityComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    item: GetOpportunityForViewDto;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Opportunity'), '/app/main/crm/opportunities'),
        new BreadcrumbItem(this.l('Opportunities') + '' + this.l('Details')),
    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _opportunitiesServiceProxy: OpportunitiesServiceProxy
    ) {
        super(injector);
        this.item = new GetOpportunityForViewDto();
        this.item.opportunity = new OpportunityDto();
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(opportunityId: number): void {
        this._opportunitiesServiceProxy.getOpportunityForView(opportunityId).subscribe((result) => {
            this.item = result;
            this.active = true;
        });
    }
}
