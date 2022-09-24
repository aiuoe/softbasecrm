import { Component, Injector, Input, ViewChild } from '@angular/core';
import { EntityChangeDetailModalComponent } from './entity-change-detail-modal.component';
import { AppComponentBase } from '@shared/common/app-component-base';
import {
    AuditLogServiceProxy,
    CustomerServiceProxy,
    EntityChangeListDto, LeadsServiceProxy, OpportunitiesServiceProxy
} from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';

/***
 * Class to map the options for this component
 */
export class EntityTypeHistoryModalOptions {
    entityId: string;
    entityName: 'Account' | 'Lead' | 'Opportunity';
    show: boolean;
}

/***
 * Component to manage the entity history summary grid
 */
@Component({
    selector: 'entityTypeHistory',
    templateUrl: './entity-type-history.component.html',
})
export class EntityTypeHistoryComponent extends AppComponentBase {
    @ViewChild('entityChangeDetailModal', { static: true }) entityChangeDetailModal: EntityChangeDetailModalComponent;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    options: EntityTypeHistoryModalOptions;

    /***
     * Main constructor
     * @param injector
     * @param _auditLogService
     * @param _customerServiceProxy
     * @param _leadServiceProxy
     * @param _opportunitiesServiceProxy
     */
    constructor(injector: Injector,
                private _auditLogService: AuditLogServiceProxy,
                private _customerServiceProxy: CustomerServiceProxy,
                private _leadServiceProxy: LeadsServiceProxy,
                private _opportunitiesServiceProxy: OpportunitiesServiceProxy
    ) {
        super(injector);
    }

    /***
     * Initialize component
     * @param options
     */
    show(options: EntityTypeHistoryModalOptions): void {
        this.options = options;
        this.shown();
    }

    /***
     * Refresh table
     */
    refreshTable(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /***
     * Initialize component
     */
    shown(): void {
        this.getRecordsIfNeeds(null);
    }

    /***
     * Reload grid
     * @param event
     */
    getRecordsIfNeeds(event?: LazyLoadEvent): void {
        if (!this.options?.show) {
            return;
        }
        this.getRecords(event);
    }

    /***
     * Get history
     * @param event
     */
    getRecords(event?: LazyLoadEvent): void {
        this.primengTableHelper.showLoadingIndicator();

        if (this.primengTableHelper.getMaxResultCount(this.paginator, event) !== 0) {
            switch (this.options.entityName) {
                case 'Account':
                    this._customerServiceProxy
                        .getEntityTypeChanges(
                            '',
                            this.options.entityId,
                            this.primengTableHelper.getSorting(this.dataTable),
                            this.primengTableHelper.getMaxResultCount(this.paginator, event),
                            this.primengTableHelper.getSkipCount(this.paginator, event)
                        )
                        .pipe(finalize(() => this.primengTableHelper.hideLoadingIndicator()))
                        .subscribe((result) => {
                            this.primengTableHelper.totalRecordsCount = result.totalCount;
                            this.primengTableHelper.records = result.items;
                            this.primengTableHelper.hideLoadingIndicator();
                        });
                    break;
                case 'Lead':
                    this._leadServiceProxy
                        .getEntityTypeChanges(
                            '',
                            this.options.entityId,
                            this.primengTableHelper.getSorting(this.dataTable),
                            this.primengTableHelper.getMaxResultCount(this.paginator, event),
                            this.primengTableHelper.getSkipCount(this.paginator, event)
                        )
                        .pipe(finalize(() => this.primengTableHelper.hideLoadingIndicator()))
                        .subscribe((result) => {
                            this.primengTableHelper.totalRecordsCount = result.totalCount;
                            this.primengTableHelper.records = result.items;
                            this.primengTableHelper.hideLoadingIndicator();
                        });
                    break;
                case 'Opportunity':
                    this._opportunitiesServiceProxy
                        .getEntityTypeChanges(
                            '',
                            this.options.entityId,
                            this.primengTableHelper.getSorting(this.dataTable),
                            this.primengTableHelper.getMaxResultCount(this.paginator, event),
                            this.primengTableHelper.getSkipCount(this.paginator, event)
                        )
                        .pipe(finalize(() => this.primengTableHelper.hideLoadingIndicator()))
                        .subscribe((result) => {
                            this.primengTableHelper.totalRecordsCount = result.totalCount;
                            this.primengTableHelper.records = result.items;
                            this.primengTableHelper.hideLoadingIndicator();
                        });
            }
        }
    }

    /***
     * Show change details
     * @param record
     */
    showEntityChangeDetails(record: EntityChangeListDto): void {
        this.entityChangeDetailModal.show(record);
    }
}
