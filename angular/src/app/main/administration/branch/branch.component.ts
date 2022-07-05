import { Component, Injector, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import {
    BranchesServiceProxy, BranchForEditDto, IAccountReceivableInBranchDto, IBranchLookupDto, ICurrencyTypeLookupDto,
    ICustomerCountryLookupTableDto, IGetBranchInitialDataDto, ITaxCodeInBranchDto, IWarehouseLookupDto
} from '@shared/service-proxies/service-proxies';
import { Subject } from 'rxjs';

@Component({
    templateUrl: './branch.component.html',
    animations: [appModuleAnimation()]
})

export class BranchComponent extends AppComponentBase implements OnInit {

    destroy$ = new Subject();
    saving: boolean = false;
    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Administration')),
        new BreadcrumbItem(this.l('Branch'))
    ];

    branches: IBranchLookupDto[] = [];
    accountsReceivables: IAccountReceivableInBranchDto[] = [];
    warehouses: IWarehouseLookupDto[] = [];
    currencyTypes: ICurrencyTypeLookupDto[] = [];
    taxCodes: ITaxCodeInBranchDto[] = [];

    branchForEdit: BranchForEditDto = new BranchForEditDto();
    branchId: number;

    countries: any[] = [
        { displayName: "US", value: "US" },
        { displayName: "Canada", value: "Canada" },
        { displayName: "Mexico", value: "Mexico" },
    ];


    constructor(
        injector: Injector,
        private _branchesService: BranchesServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._branchesService.getInitialData().pipe(takeUntil(this.destroy$)).subscribe((x: IGetBranchInitialDataDto) => {
            this.branches = x.branches;
            this.accountsReceivables = x.accountsReceivables;
            this.warehouses = x.warehouses;
            this.currencyTypes = x.currencyTypes;
            this.taxCodes = x.taxCodes;
        });
    }

    ngOnDestroy(): void {
        this.destroy$.next();
    }

    branchNumberOnChange(): void {
        this._branchesService.get(this.branchId).pipe(takeUntil(this.destroy$)).subscribe((x: BranchForEditDto) => {
            this.branchForEdit = x;
        });

    }
    add() {

    }

    delete() {

    }

    update() {

    }

    logoGraphicClear() {

    }

}