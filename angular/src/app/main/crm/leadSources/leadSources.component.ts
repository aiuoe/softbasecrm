import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
    LeadSourcesServiceProxy,
    LeadSourceDto,
    UpdateOrderleadSourceDto,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditLeadSourceModalComponent } from './create-or-edit-leadSource-modal.component';
import { ViewLeadSourceModalComponent } from './view-leadSource-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './leadSources.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class LeadSourcesComponent extends AppComponentBase {
    @ViewChild('createOrEditLeadSourceModal', { static: true })
    createOrEditLeadSourceModal: CreateOrEditLeadSourceModalComponent;
    @ViewChild('viewLeadSourceModalComponent', { static: true }) viewLeadSourceModal: ViewLeadSourceModalComponent;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    leadsourceSrc: UpdateOrderleadSourceDto = new UpdateOrderleadSourceDto();
    leadsourceDst: UpdateOrderleadSourceDto = new UpdateOrderleadSourceDto();

    advancedFiltersAreShown = false;
    filterText = '';
    descriptionFilter = '';

    /***
     * Class Constructor
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
        private _leadSourcesServiceProxy: LeadSourcesServiceProxy,
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
    getLeadSources(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._leadSourcesServiceProxy
            .getAll(
                this.filterText,
                this.descriptionFilter,
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
    createLeadSource(): void {
        this.createOrEditLeadSourceModal.show();
    }

    /***
     * Method that removes an opportunity from the database
     * @param opportunityStage
     */
    deleteLeadSource(leadSource: LeadSourceDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._leadSourcesServiceProxy.delete(leadSource.id).subscribe(() => {
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
        this._leadSourcesServiceProxy
            .getLeadSourcesToExcel(this.filterText, this.descriptionFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    /***
     * Method that updates the order of a row in the database
     * @param $event
     * @constructor
     */
    UpdateOrder($event: any): void {
        this.leadsourceSrc.order = $event.dragIndex;
        this.leadsourceDst.order = $event.dropIndex;

        let request: UpdateOrderleadSourceDto[] = [this.leadsourceSrc, this.leadsourceDst];

        this._leadSourcesServiceProxy.updateOrder(request).subscribe(() => {
            this.notify.info(this.l('UpdateSuccessfully'));
            this.modalSave.emit(null);
            this.getLeadSources();
        });
    }
}
