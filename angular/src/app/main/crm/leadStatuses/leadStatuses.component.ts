import { Component, Injector, ViewEncapsulation, ViewChild, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    LeadStatusesServiceProxy,
    LeadStatusDto,
    UpdateOrderLeadStatusDto,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditLeadStatusModalComponent } from './create-or-edit-leadStatus-modal.component';
import { ViewLeadStatusModalComponent } from './view-leadStatus-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/***
 * Component to manage the lead status summary grid
 */
@Component({
    templateUrl: './leadStatuses.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class LeadStatusesComponent extends AppComponentBase {
    @ViewChild('createOrEditLeadStatusModal', { static: true })
    createOrEditLeadStatusModal: CreateOrEditLeadStatusModalComponent;
    @ViewChild('viewLeadStatusModalComponent', { static: true }) viewLeadStatusModal: ViewLeadStatusModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    leadStatus1: UpdateOrderLeadStatusDto = new UpdateOrderLeadStatusDto();
    leadStatus2: UpdateOrderLeadStatusDto = new UpdateOrderLeadStatusDto();

    advancedFiltersAreShown = false;
    filterText = '';
    descriptionFilter = '';
    colorFilter = '';
    isLeadConversionValidFilter = -1;
    isDefaultFilter = -1;
    
    /***
     * Class constructor
     * @param injector
     * @param _leadStatusesServiceProxy
     * @param _notifyService
     * @param _tokenAuth
     * @param _activatedRoute
     * @param _fileDownloadService
     * @param _dateTimeService
     */
    constructor(
        injector: Injector,
        private _leadStatusesServiceProxy: LeadStatusesServiceProxy,
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
    getLeadStatuses(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._leadStatusesServiceProxy
            .getAll(
                this.filterText,
                this.descriptionFilter,
                this.colorFilter,
                this.isLeadConversionValidFilter,
                this.isDefaultFilter,
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
    createLeadStatus(): void {
        this.createOrEditLeadStatusModal.show();
    }

    /***
     * Method that removes a lead status from the database
     * @param leadStatus
     */
    deleteLeadStatus(leadStatus: LeadStatusDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._leadStatusesServiceProxy.delete(leadStatus.id).subscribe(() => {
                    this.reloadPage();
                    this.notifyService.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    /***
     * Method that updates the order of a row in the database
     * @param $event
     * @constructor
     */
    updateOrder($event: any): void {
        this.leadStatus1.order = $event.dragIndex;
        this.leadStatus2.order = $event.dropIndex;

        let request: UpdateOrderLeadStatusDto[] = [this.leadStatus1, this.leadStatus2];

        this._leadStatusesServiceProxy.updateOrder(request).subscribe(() => {
            this.notifyService.success(this.l('UpdateSuccessfully'));
            this.modalSave.emit(null);
            this.getLeadStatuses();
        });
    }
}
