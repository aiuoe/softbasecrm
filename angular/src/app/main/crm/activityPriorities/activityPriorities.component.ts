import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActivityPrioritiesServiceProxy, ActivityPriorityDto } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditActivityPriorityModalComponent } from './create-or-edit-activityPriority-modal.component';

import { ViewActivityPriorityModalComponent } from './view-activityPriority-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component for managing the activity priorities
 */
@Component({
    templateUrl: './activityPriorities.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class ActivityPrioritiesComponent extends AppComponentBase {
    @ViewChild('createOrEditActivityPriorityModal', { static: true })
    createOrEditActivityPriorityModal: CreateOrEditActivityPriorityModalComponent;
    @ViewChild('viewActivityPriorityModalComponent', { static: true })
    viewActivityPriorityModal: ViewActivityPriorityModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    descriptionFilter = '';

    /**
     * Constructor method
     */
    constructor(
        injector: Injector,
        private _activityPrioritiesServiceProxy: ActivityPrioritiesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Get all activity priorities
     */
    getActivityPriorities(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._activityPrioritiesServiceProxy
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
     * Shows the form dialog for creating a new activity prioriy
     */
    createActivityPriority(): void {
        this.createOrEditActivityPriorityModal.show();
    }

    /**
     * Delete an activity priority
     */
    deleteActivityPriority(activityPriority: ActivityPriorityDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._activityPrioritiesServiceProxy.delete(activityPriority.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    /**
     * Export activity priorities to excel
     */
    exportToExcel(): void {
        this._activityPrioritiesServiceProxy
            .getActivityPrioritiesToExcel(this.filterText, this.descriptionFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
}
