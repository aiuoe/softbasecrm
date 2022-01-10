import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActivitySourceTypesServiceProxy, ActivitySourceTypeDto } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditActivitySourceTypeModalComponent } from './create-or-edit-activitySourceType-modal.component';

import { ViewActivitySourceTypeModalComponent } from './view-activitySourceType-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component for managing the activity source types
 */
@Component({
    templateUrl: './activitySourceTypes.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class ActivitySourceTypesComponent extends AppComponentBase {
    @ViewChild('createOrEditActivitySourceTypeModal', { static: true })
    createOrEditActivitySourceTypeModal: CreateOrEditActivitySourceTypeModalComponent;
    @ViewChild('viewActivitySourceTypeModalComponent', { static: true })
    viewActivitySourceTypeModal: ViewActivitySourceTypeModalComponent;

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
        private _activitySourceTypesServiceProxy: ActivitySourceTypesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Get the list of activity source types from the back-end
     */
    getActivitySourceTypes(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._activitySourceTypesServiceProxy
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
     * Reload the page
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /**
     * Shows the form dialog for creating a new activity source type
     */
    createActivitySourceType(): void {
        this.createOrEditActivitySourceTypeModal.show();
    }

    /**
     * Delete the activity source type
     */
    deleteActivitySourceType(activitySourceType: ActivitySourceTypeDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._activitySourceTypesServiceProxy.delete(activitySourceType.id).subscribe(() => {
                    this.reloadPage();
                    this.notifyService.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }
}
