import { Component, Injector, ViewEncapsulation, ViewChild, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
    ActivityStatusesServiceProxy,
    ActivityStatusDto,
    UpdateOrderActivityStatusDto,
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditActivityStatusModalComponent } from './create-or-edit-activityStatus-modal.component';
import { ViewActivityStatusModalComponent } from './view-activityStatus-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component for managing the activity statuses
 */
@Component({
    templateUrl: './activityStatuses.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class ActivityStatusesComponent extends AppComponentBase {
    @ViewChild('createOrEditActivityStatusModal', { static: true })
    createOrEditActivityStatusModal: CreateOrEditActivityStatusModalComponent;
    @ViewChild('viewActivityStatusModalComponent', { static: true })
    viewActivityStatusModal: ViewActivityStatusModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    descriptionFilter = '';

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    activityStatus1: UpdateOrderActivityStatusDto = new UpdateOrderActivityStatusDto();
    activityStatus2: UpdateOrderActivityStatusDto = new UpdateOrderActivityStatusDto();

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activityStatusesServiceProxy: ActivityStatusesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Get the list of activity status from the back-end
     */
    getActivityStatuses(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._activityStatusesServiceProxy
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

    /**
     * Reload page
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /**
     * Shows the form dialog for creating an activity status
     */
    createActivityStatus(): void {
        this.createOrEditActivityStatusModal.show();
    }

    /**
     * Delete an activity status
     */
    deleteActivityStatus(activityStatus: ActivityStatusDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._activityStatusesServiceProxy.delete(activityStatus.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
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
        this.activityStatus1.order = $event.dragIndex;
        this.activityStatus2.order = $event.dropIndex;

        let request: UpdateOrderActivityStatusDto[] = [this.activityStatus1, this.activityStatus2];

        this._activityStatusesServiceProxy.updateOrder(request).subscribe(() => {
            this.notify.info(this.l('UpdateSuccessfully'));
            this.modalSave.emit(null);
            this.getActivityStatuses();
        });
    }
}
