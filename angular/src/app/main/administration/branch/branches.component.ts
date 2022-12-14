import { Component, Injector, OnDestroy, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil, finalize } from 'rxjs/operators';
import { debounce as _debounce } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchesServiceProxy, BranchListItemDto, PagedResultDtoOfBranchListItemDto
} from '@shared/service-proxies/service-proxies';
import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { Router } from '@angular/router';
import { AppConsts } from '@shared/AppConsts';

/**
 * Main component for branch
 */
@Component({
    templateUrl: './branches.component.html',
    animations: [appModuleAnimation()]
})

export class BranchesComponent extends AppComponentBase implements OnDestroy {
    destroy$ = new Subject();
    loading: boolean = false;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];
    filters: { filterText: string } = { filterText: '' };

    /**
     * constructor
     */
    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
        private _router: Router,
    ) {
        super(injector);
    }

    /**
     * OnDestroy
     */
    ngOnDestroy(): void {
        this.destroy$.next();
    }

    /**
     * add button on click action
     */
    addOnClick(): void {
        this._router.navigate(['app', 'main', 'administration', 'branch', 'add']);
    }

    /**
     * close button on click action
     */
    closeOnClick(): void {
        this._router.navigate(['app', 'main', 'administration']);
    }

    /**
     * view button on click action
     */
    viewOnClick(branchId: number): void {
        this._router.navigate(['app', 'main', 'administration', 'branch', branchId, 'view']);
    }

    /**
     * edit button on click action
     */
    editOnClick(branchId: number): void {
        this._router.navigate(['app', 'main', 'administration', 'branch', branchId, 'edit']);
    }

    /**
     * delete button on click action
     */
    deleteOnClick(branch: BranchListItemDto): void {
        this.deleteBranch(branch.id, branch.name);
    }

    /**
     * branch name search filter on input action
     */
    branchNameSearchOnInput = _debounce(this.getBranches, AppConsts.SearchBarDelayMilliseconds);

    /**
     * get paged branch list
     */
    getBranches(event?: LazyLoadEvent): void {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }
        this.primengTableHelper.showLoadingIndicator();

        this._branchesService.getAllPaged(
            this.filters.filterText,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event)
        ).pipe(
            takeUntil(this.destroy$),
            finalize(() => this.primengTableHelper.hideLoadingIndicator())
        ).subscribe((x: PagedResultDtoOfBranchListItemDto) => {
            this.primengTableHelper.totalRecordsCount = x.totalCount;
            this.primengTableHelper.records = x.items;
        });
    }

    /**
     * delete branch method
     */
    private deleteBranch(branchId: number, branchName: string): void {
        this.message.confirm(
            this.l('BranchDeleteWarningMessage', branchName),
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this.loading = true;
                    this._branchesService.delete(branchId).subscribe(() => {
                        this.paginator.changePage(this.paginator.getPage());
                        this.notifyService.success(this.l('SuccessfullyDeleted'));
                    }, () => {

                    }, () => {
                        this.loading = false;
                    });
                }
            }
        );
    }
}
