import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { LazyLoadEvent } from '@node_modules/primeng/api';
import { Table } from '@node_modules/primeng/table';
import { Paginator } from '@node_modules/primeng/paginator';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '@app/shared/common/crm/services/data.service';
import { GlobalSearchCategory, GlobalSearchServiceProxy } from '@shared/service-proxies/service-proxies';
import { GlobalSearchTypeDto } from '@app/shared/common/crm/dto/global-search-type.dto';

/***
 * Component to manage the global search bar
 */
@Component({
    templateUrl: './global-search.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class GlobalSearchComponent extends AppComponentBase implements OnInit {
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    textFilter: string;
    types: GlobalSearchTypeDto[] = [];
    selectedType: GlobalSearchCategory;

    /***
     * Main constructor
     * @param injector
     * @param _activatedRoute
     * @param _dataService
     * @param _globalSearchServiceProxy
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _dataService: DataService,
        private _globalSearchServiceProxy: GlobalSearchServiceProxy
    ) {
        super(injector);
    }

    /***
     * Initialize component
     */
    ngOnInit(): void {
        this.textFilter = this._activatedRoute.snapshot.queryParams['filter'];
        this.paginator.rows = 10;

        this.types = [];
        this.types.push({ id: GlobalSearchCategory.All, name: this.l('All')});
        this.types.push({ id: GlobalSearchCategory.Account, name: this.l('Customer')});
        this.types.push({ id: GlobalSearchCategory.Lead, name: this.l('Lead')});
        this.types.push({ id: GlobalSearchCategory.Opportunity, name: this.l('Opportunity')});
        this.types.push({ id: GlobalSearchCategory.Activity, name: this.l('Activity')});
        this.selectedType = this.types[0].id;

        this._dataService.globalSearch
            .subscribe(x => {
                if (x) {
                    this.textFilter = x;
                    this.getGlobalSearch({
                        rows: this.primengTableHelper.defaultRecordsCountPerPage
                    });
                }
            });
    }

    /***
     * Get global search by text filter and category type
     * @param event
     */
    getGlobalSearch(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();
        this._globalSearchServiceProxy
            .getAll(
                this.textFilter,
                this.selectedType,
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
}
