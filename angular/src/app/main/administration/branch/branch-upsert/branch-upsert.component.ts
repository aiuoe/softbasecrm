import { Component, Injector, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { isEmpty as _isEmpty } from 'lodash-es';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchCurrencyTypeDto, BranchesServiceProxy, UpsertBranchDto, GetBranchInitialDataDto,
    IGetChartOfAccountDetailsDto, IGetZipCodeDetailsDto, PatchBranchCurrencyTypeCommand,
    ReadCommonShareServiceProxy
} from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from '@shared/AppEnums';

/**
 * Main component for branch edit
 */
@Component({
    templateUrl: './branch-upsert.component.html',
    animations: [appModuleAnimation()],
})

export class BranchUpsertComponent extends AppComponentBase implements OnInit, OnDestroy {

    destroy$ = new Subject();
    loading: boolean = false;
    pageMode: PageMode;
    pageModes = PageMode;
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];
    filters: { filterText: string } = { filterText: '' };
    branchId: number;
    currencyTypeId: number;
    branchCurrencyType = new BranchCurrencyTypeDto();
    upsertBranchDto = new UpsertBranchDto();
    initialDropdownData = new GetBranchInitialDataDto();
    logoFile: File = null;
    isAccountNumberValid: boolean = true;
    selectedDate = new Date();
    creationTime = new Date();
    lastModificationTime = new Date();

    /**
     * constructor
     */
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _branchesService: BranchesServiceProxy,
        private _commonServiceProxy: ReadCommonShareServiceProxy,
        private _router: Router,
    ) {
        super(injector);
    }

    /**
     * OnInit
     */
    ngOnInit(): void {
        this.pageMode = this._activatedRoute.snapshot.data.pageMode;
        if (this._activatedRoute.snapshot.params.id) {
            this.branchId = this._activatedRoute.snapshot.params.id;
            this.getBranch(this.branchId);
        }
        this.initBranch();
        this.setInitialDropdownData();
    }

    /**
     * OnDestroy
     */
    ngOnDestroy(): void {
        this.destroy$.next();
    }

    /**
     * check if input is in view mode
     */
    isViewMode(): boolean {
        return this.pageMode === PageMode.View;
    }

    /**
     * check if branch number field is disable
     */
    isBranchNumberFieldDisabled(): boolean {
        return [PageMode.View, PageMode.Edit].includes(this.pageMode);
    }

    /**
     * file input on change action
     */
    onChangeFile(event: File) {
        this.logoFile = event;
    }

    /**
     * cancel butone on click action
     */
    cancelOnClick(): void {
        this.redirectToBranchListPage();
    }

    /**
     * save butone on click action
     */
    saveOnClick(): void {
        return this.branchId
            ? this.updateBranch()
            : this.addBranch();
    }

    /**
     * delete butone on click action
     */
    deleteOnClick(): void {
        if (this.branchId) {
            this.deleteBranch(this.branchId, this.upsertBranchDto.name);
        }
    }

    /**
     * currency type input on change action
     */
    currencyTypeOnChange(): void {
        if (this.branchId && this.currencyTypeId) {
            this._branchesService.getBranchCurrencyType(this.branchId, this.currencyTypeId)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    /**
     * delete currency type on click action
     */
    deleteBranchCurrencyTypeOnClick(): void {
        this.deleteBranchCurrencyType();
    }

    /**
     * update currency type on click action
     */
    updateBranchCurrencyTypeOnClick(): void {
        this.updateBranchCurrencyType();
    }

    /**
     * ar account input on change action
     */
    acountsReceivableGLAccountNumberOnChange(): void {
        if (this.upsertBranchDto.receivable) {
            this._branchesService.getChartOfAccountDetails(this.upsertBranchDto.receivable)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: IGetChartOfAccountDetailsDto) => {
                    this.isAccountNumberValid = !!x.id;
                });
        }
    }

    /**
     * ar account dropdown on change action
     */
    accountsReceivablesOnChange(e: any): void {
        if (e.value) {
            this.upsertBranchDto.receivable = this.initialDropdownData.accountsReceivables.find(x => x.id === e.value).accountReceivable;
        }
    }

    /**
     * zip code on change action
     */
    zipCodeOnChange(): void {
        if (this.upsertBranchDto.zipCode) {
            this._branchesService.getZipCodeDetails(this.upsertBranchDto.zipCode)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: IGetZipCodeDetailsDto) => {
                    if (!_isEmpty(x)) {
                        this.upsertBranchDto.city = x.city;
                        this.upsertBranchDto.state = x.state;
                    }
                });
        }
    }

    /**
     * set dropdown data
     */
    private setInitialDropdownData(): void {
        this._branchesService.getInitialData()
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: GetBranchInitialDataDto) => {
                this.initialDropdownData = x;
            });
    }

    /**
     * get branch information
     */
    private getBranch(branchId: number): void {
        this._branchesService.get(branchId)
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: UpsertBranchDto) => {
                this.upsertBranchDto = x;
                this.selectedDate = this.upsertBranchDto.rentalDeliveryDefaultTime?.toJSDate();
            });
    }

    /**
     * add a branch
     */
    private addBranch(): void {
        this._branchesService.create(this.upsertBranchDto, this.getFileParameterFromFile(this.logoFile))
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: UpsertBranchDto) => {
                this.notifyService.success(this.l('SuccessfullyAdded'));
                this.redirectToBranchListPage();
            });
    }

    /**
    * update a branch
    */
    private updateBranch(): void {
        this._branchesService.update(this.upsertBranchDto.id, this.upsertBranchDto, this.getFileParameterFromFile(this.logoFile))
            .pipe(
                takeUntil(this.destroy$)
            ).subscribe((x: UpsertBranchDto) => {
                this.notifyService.success(this.l('UpdateSuccessfully'));
                this.redirectToBranchListPage();
            });
    }

    /**
    * delete a branch
    */
    private deleteBranch(branchId: number, branchName: string): void {
        this.message.confirm(
            this.l('BranchDeleteWarningMessage', branchName),
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this.loading = true;
                    this._branchesService.delete(branchId).subscribe(() => {
                        this.notifyService.success(this.l('SuccessfullyDeleted'));
                        this.redirectToBranchListPage();
                    }, () => {

                    }, () => {
                        this.loading = false;
                    });
                }
            }
        );
    }

    /**
     * delete a branch currency type
     */
    private deleteBranchCurrencyType(): void {
        if (this.branchId && this.currencyTypeId) {
            this.branchCurrencyType = new BranchCurrencyTypeDto();
            const patchBranchCurrencyTypeCommand = new PatchBranchCurrencyTypeCommand();
            this._branchesService.patchBranchCurrencyType(this.branchId, this.currencyTypeId, patchBranchCurrencyTypeCommand)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    /**
     * update a branch currency type
     */
    private updateBranchCurrencyType(): void {
        if (this.branchId && this.currencyTypeId) {
            const patchBranchCurrencyTypeCommand = new PatchBranchCurrencyTypeCommand({
                branchId: -1,
                currencyTypeId: -1,
                arAccountNo: this.branchCurrencyType.arAccountNo,
                debitAccount: this.branchCurrencyType.debitAccount,
                creditAccount: this.branchCurrencyType.creditAccount,
                debitAccountReevaluate: this.branchCurrencyType.debitAccountReevaluate,
                creditAccountReevaluate: this.branchCurrencyType.creditAccountReevaluate,
            });

            this._branchesService.patchBranchCurrencyType(this.branchId, this.currencyTypeId, patchBranchCurrencyTypeCommand)
                .pipe(
                    takeUntil(this.destroy$)
                ).subscribe((x: BranchCurrencyTypeDto) => {
                    this.branchCurrencyType = x;
                });
        }
    }

    /**
     * initialize branch object
     */
    private initBranch(): void {
        this.upsertBranchDto = new UpsertBranchDto();
        this.upsertBranchDto.init({});
    }

    /**
     * branch list page redirection
     */
    private redirectToBranchListPage(): void {
        this._router.navigate(['app', 'main', 'administration', 'branch']);
    }
}


