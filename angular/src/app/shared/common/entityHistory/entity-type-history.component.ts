import { Component, Injector, ViewChild } from '@angular/core';
import { EntityChangeDetailModalComponent } from './entity-change-detail-modal.component';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AuditLogServiceProxy, EntityChangeListDto } from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';

export interface IEntityTypeHistoryModalOptions {
    entityTypeFullName: string;
    entityTypeDescription: string;
    entityId: string;
}

@Component({
    selector: 'entityTypeHistory',
    templateUrl: './entity-type-history.component.html',
})
export class EntityTypeHistoryComponent extends AppComponentBase {
    @ViewChild('entityChangeDetailModal', { static: true }) entityChangeDetailModal: EntityChangeDetailModalComponent;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    options: IEntityTypeHistoryModalOptions;
    isShown = false;
    isInitialized = false;
    filterText = '';
    tenantId?: number;
    entityHistoryEnabled: false;

    constructor(injector: Injector, private _auditLogService: AuditLogServiceProxy) {
        super(injector);
    }

    show(options: IEntityTypeHistoryModalOptions): void {
        this.options = options;
        this.shown();
    }

    refreshTable(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    shown(): void {
        this.isShown = true;
        this.getRecordsIfNeeds(null);
    }

    getRecordsIfNeeds(event?: LazyLoadEvent): void {
        if (!this.isShown) {
            return;
        }

        this.getRecords(event);
        this.isInitialized = true;
    }

    getRecords(event?: LazyLoadEvent): void {
        this.primengTableHelper.showLoadingIndicator();

        if (this.primengTableHelper.getMaxResultCount(this.paginator, event) !== 0) {
            this._auditLogService
                .getEntityTypeChanges(
                    this.options.entityTypeFullName,
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

    showEntityChangeDetails(record: EntityChangeListDto): void {
        this.entityChangeDetailModal.show(record);
    }
}
