import { Component, Injector, ViewEncapsulation, ViewChild, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    OpportunityStagesServiceProxy,
    OpportunityStageDto,
    UpdateOrderOpportunityStageDto,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditOpportunityStageModalComponent } from './create-or-edit-opportunityStage-modal.component';
import { ViewOpportunityStageModalComponent } from './view-opportunityStage-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/***
 * Component to manage the opportunity stages summary grid
 */
@Component({
    templateUrl: './opportunityStages.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class OpportunityStagesComponent extends AppComponentBase {
    @ViewChild('createOrEditOpportunityStageModal', { static: true })
    createOrEditOpportunityStageModal: CreateOrEditOpportunityStageModalComponent;
    @ViewChild('viewOpportunityStageModalComponent', { static: true })
    viewOpportunityStageModal: ViewOpportunityStageModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    descriptionFilter = '';
    colorFilter = '';
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    opportunityStage1: UpdateOrderOpportunityStageDto = new UpdateOrderOpportunityStageDto();
    opportunityStage2: UpdateOrderOpportunityStageDto = new UpdateOrderOpportunityStageDto();

    /***
     * Class constructor
     * @param injector
     * @param _opportunityStagesServiceProxy
     * @param _notifyService
     * @param _tokenAuth
     * @param _activatedRoute
     * @param _fileDownloadService
     * @param _dateTimeService
     */
    constructor(
        injector: Injector,
        private _opportunityStagesServiceProxy: OpportunityStagesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /***
     * Method that gets the rows to display in the grid
     * @param event
     */
    getOpportunityStages(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._opportunityStagesServiceProxy
            .getAll(
                this.filterText,
                this.descriptionFilter,
                this.colorFilter,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    /***
     * Method that reload a page
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /***
     * Method that shows the create or edit modal
     */
    createOpportunityStage(): void {
        this.createOrEditOpportunityStageModal.show();
    }

    /***
     * Method that removes an opportunity from the database
     * @param opportunityStage
     */
    deleteOpportunityStage(opportunityStage: OpportunityStageDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._opportunityStagesServiceProxy.delete(opportunityStage.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    /***
     * Method that exports the rows of the grid in an excel file
     */
    exportToExcel(): void {
        this._opportunityStagesServiceProxy
            .getOpportunityStagesToExcel(this.filterText, this.descriptionFilter, this.colorFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    /***
     * Method that updates the order of a row in the database
     * @param $event
     * @constructor
     */
    updateOrder($event: any): void {
        this.opportunityStage1.order = $event.dragIndex;
        this.opportunityStage2.order = $event.dropIndex;

        let request: UpdateOrderOpportunityStageDto[] = [this.opportunityStage1, this.opportunityStage2];

        this._opportunityStagesServiceProxy.updateOrder(request).subscribe(() => {
            this.notify.info(this.l('UpdateSuccessfully'));
            this.modalSave.emit(null);
            this.getOpportunityStages();
        });
    }
}
