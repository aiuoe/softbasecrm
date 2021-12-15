import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PrioritiesServiceProxy, PriorityDto } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditPriorityModalComponent } from './create-or-edit-priority-modal.component';

import { ViewPriorityModalComponent } from './view-priority-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

/**
 * Component that shows all priorities
 */
@Component({
    templateUrl: './priorities.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class PrioritiesComponent extends AppComponentBase {
    @ViewChild('createOrEditPriorityModal', { static: true })
    createOrEditPriorityModal: CreateOrEditPriorityModalComponent;
    @ViewChild('viewPriorityModalComponent', { static: true }) viewPriorityModal: ViewPriorityModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    descriptionFilter = '';
    isDefaultFilter = -1;

    /**
     * Main Constructor
     * @param injector 
     * @param _prioritiesServiceProxy 
     * @param _notifyService 
     * @param _tokenAuth 
     * @param _activatedRoute 
     * @param _fileDownloadService 
     * @param _dateTimeService 
     */
    constructor(
        injector: Injector,
        private _prioritiesServiceProxy: PrioritiesServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /**
     * Gets all the priorities
     * @param event 
     * @returns 
     */
    getPriorities(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._prioritiesServiceProxy
            .getAll(
                this.filterText,
                this.descriptionFilter,
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

    /**
     * Reload the page
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /**
     * Opens the modal to create a new priority
     */
    createPriority(): void {
        this.createOrEditPriorityModal.show();
    }

    /**
     * Deletes a priority
     * @param priority the priority to be deleted
     */
    deletePriority(priority: PriorityDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._prioritiesServiceProxy.delete(priority.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    exportToExcel(): void {
        this._prioritiesServiceProxy
            .getPrioritiesToExcel(this.filterText, this.descriptionFilter, this.isDefaultFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }
}
