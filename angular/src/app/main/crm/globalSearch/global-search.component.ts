import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { LazyLoadEvent } from '@node_modules/primeng/api';
import { Table } from '@node_modules/primeng/table';
import { Paginator } from '@node_modules/primeng/paginator';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '@app/shared/common/crm/services/data.service';

@Component({
    templateUrl: './global-search.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class GlobalSearchComponent extends AppComponentBase implements OnInit {

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    results: any[];
    textFilter: string;

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _dataService: DataService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.textFilter = this._activatedRoute.snapshot.queryParams['filter'];
        this.results = [];
        this.results.push({ name: 'ABC', module: 'Account' });
        this.results.push({ name: 'L CDE', module: 'Lead' });

        this._dataService.globalSearch
            .subscribe(x => {
               if (x) {
                   this.textFilter = x;
                   this.getGlobalSearch();
               }
            });
    }

    getGlobalSearch(event?: LazyLoadEvent) {
        if (this.textFilter) {
            if (this.primengTableHelper.shouldResetPaging(event)) {
                this.paginator.changePage(0);
                return;
            }

            this.primengTableHelper.totalRecordsCount = this.results.length;
            this.primengTableHelper.records = this.results;
        }
    }
}
