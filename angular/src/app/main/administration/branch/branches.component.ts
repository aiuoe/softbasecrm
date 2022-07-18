import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil, finalize } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
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
import { IActionButton } from './branch.model';

/**
 * Main component for branch
 */
@Component({
    templateUrl: './branches.component.html',
    animations: [appModuleAnimation()]
})

export class BranchesComponent extends AppComponentBase implements OnInit, OnDestroy {

    destroy$ = new Subject();
    loading: boolean = false;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];
    actionButtons: IActionButton[] = [];
    filters: { filterText: string } = { filterText: '' };

    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
        private _router: Router,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.initActionButtons();
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    isButtonActive(): boolean {
        return true;
    }

    addOnClick(): void {
        this._router.navigate(['app', 'main', 'administration', 'branch', 'add']);
    }

    closeOnClick(): void {
        this._router.navigate(['app', 'main', 'administration']);
    }

    viewOnClick(branchId: number): void {
        this._router.navigate(['app', 'main', 'administration', 'branch', branchId, 'view']);
    }

    editOnClick(branchId: number): void {
        this._router.navigate(['app', 'main', 'administration', 'branch', branchId, 'edit']);
    }

    deleteOnClick(branch: BranchListItemDto): void {
        this.deleteBranch(branch.id, branch.name);
    }

    getBrances(event?: LazyLoadEvent): void {
        if (!this.dataTable || !this.paginator) {
            return;
        }
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

    private initActionButtons(): void {
        this.actionButtons = [
            { name: this.l('Close'), cssClass: 'btn-secondary', isActive: () => this.isButtonActive(), action: () => this.closeOnClick() },
            { name: this.l('Branch'), cssClass: 'btn-primary', iconClass: 'fa fa-plus', isActive: () => this.isButtonActive(), action: () => this.addOnClick() },
        ];
    }
}
