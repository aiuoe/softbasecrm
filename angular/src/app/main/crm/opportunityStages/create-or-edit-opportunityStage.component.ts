import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    OpportunityStagesServiceProxy,
    CreateOrEditOpportunityStageDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './create-or-edit-opportunityStage.component.html',
    animations: [appModuleAnimation()],
})
export class CreateOrEditOpportunityStageComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    opportunityStage: CreateOrEditOpportunityStageDto = new CreateOrEditOpportunityStageDto();

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('OpportunityStage'), '/app/main/crm/opportunityStages'),
        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
    ];

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _opportunityStagesServiceProxy: OpportunityStagesServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    /** Method that gets the rows to display in the grid */
    show(opportunityStageId?: number): void {
        if (!opportunityStageId) {
            this.opportunityStage = new CreateOrEditOpportunityStageDto();
            this.opportunityStage.id = opportunityStageId;

            this.active = true;
        } else {
            this._opportunityStagesServiceProxy.getOpportunityStageForEdit(opportunityStageId).subscribe((result) => {
                this.opportunityStage = result.opportunityStage;

                this.active = true;
            });
        }
    }

    /** Method that saves an opportunity in the database */
    save(): void {
        this.saving = true;

        this._opportunityStagesServiceProxy
            .createOrEdit(this.opportunityStage)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notifyService.info(this.l('SavedSuccessfully'));
                this._router.navigate(['/app/main/crm/opportunityStages']);
            });
    }

    /** Method that saves an opportunity in the database and reload the modal */
    saveAndNew(): void {
        this.saving = true;

        this._opportunityStagesServiceProxy
            .createOrEdit(this.opportunityStage)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notifyService.info(this.l('SavedSuccessfully'));
                this.opportunityStage = new CreateOrEditOpportunityStageDto();
            });
    }
}
