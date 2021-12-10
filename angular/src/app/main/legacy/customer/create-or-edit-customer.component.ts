import { Component, ViewChild, Injector, Output, EventEmitter, OnInit, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {
    CustomerServiceProxy,
    CreateOrEditCustomerDto,
    CustomerAccountTypeLookupTableDto,
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTime } from 'luxon';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Observable } from '@node_modules/rxjs';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './create-or-edit-customer.component.html',
    animations: [appModuleAnimation()],
})
export class CreateOrEditCustomerComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    customer: CreateOrEditCustomerDto = new CreateOrEditCustomerDto();

    accountTypeDescription = '';

    allAccountTypes: CustomerAccountTypeLookupTableDto[];

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Customer'), '/app/main/legacy/customer'),
        new BreadcrumbItem(this.l('Entity_Name_Plural_Here') + '' + this.l('Details')),
    ];

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _customerServiceProxy: CustomerServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(customerId?: number): void {
        if (!customerId) {
            this.customer = new CreateOrEditCustomerDto();
            // this.customer.id = customerId;
            // this.customer.added = this._dateTimeService.getStartOfDay();
            // this.customer.changed = this._dateTimeService.getStartOfDay();
            // this.customer.companyCommentsDate = this._dateTimeService.getStartOfDay();
            // this.customer.hoursOfOpStart = this._dateTimeService.getStartOfDay();
            // this.customer.hoursOfOpEnd = this._dateTimeService.getStartOfDay();
            // this.customer.resaleExpDate = this._dateTimeService.getStartOfDay();
            // this.customer.mfgPermitExpDate = this._dateTimeService.getStartOfDay();
            // this.customer.insuranceNoDate = this._dateTimeService.getStartOfDay();
            // this.customer.insuranceNoRecvDate = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate1 = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate2 = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate3 = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate4 = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate5 = this._dateTimeService.getStartOfDay();
            // this.customer.lastAutoSalesmanUpdate6 = this._dateTimeService.getStartOfDay();
            this.accountTypeDescription = '';

            this.active = true;
        } else {
            // this._customerServiceProxy.getCustomerForEdit(customerId).subscribe((result) => {
            //     this.customer = result.customer;
            //
            //     this.accountTypeDescription = result.accountTypeDescription;
            //
            //     this.active = true;
            // });
        }
        this._customerServiceProxy.getAllAccountTypeForTableDropdown().subscribe((result) => {
            this.allAccountTypes = result;
        });
    }

    save(): void {
        this.saving = true;

        this._customerServiceProxy
            .createOrEdit(this.customer)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this._router.navigate(['/app/main/legacy/customer']);
            });
    }

    saveAndNew(): void {
        this.saving = true;

        this._customerServiceProxy
            .createOrEdit(this.customer)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((x) => {
                this.saving = false;
                this.notify.info(this.l('SavedSuccessfully'));
                this.customer = new CreateOrEditCustomerDto();
            });
    }
}
