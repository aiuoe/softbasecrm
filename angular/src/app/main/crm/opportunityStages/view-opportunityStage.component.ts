import { Component, Injector, OnInit } from '@angular/core';
import {
    OpportunityStagesServiceProxy,
    GetOpportunityStageForViewDto,
    OpportunityStageDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

/***
 * Component to view opportunity stage
 */
@Component({
    templateUrl: './view-opportunityStage.component.html',
    animations: [appModuleAnimation()],
})
export class ViewOpportunityStageComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    item: GetOpportunityStageForViewDto;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('OpportunityStage'), '/app/main/crm/opportunityStages'),
        new BreadcrumbItem(this.l('OpportunityStages') + '' + this.l('Details')),
    ];

    /***
     * Class constructor
     * @param injector
     * @param _activatedRoute
     * @param _opportunityStagesServiceProxy
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _opportunityStagesServiceProxy: OpportunityStagesServiceProxy
    ) {
        super(injector);
        this.item = new GetOpportunityStageForViewDto();
        this.item.opportunityStage = new OpportunityStageDto();
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    /***
     * Method that show the view
     * @param opportunityStageId
     */
    show(opportunityStageId: number): void {
        this._opportunityStagesServiceProxy.getOpportunityStageForView(opportunityStageId).subscribe((result) => {
            this.item = result;
            this.active = true;
        });
    }
}
