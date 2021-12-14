import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { finalize } from 'rxjs/operators';
import {
    CustomerServiceProxy,
    CreateOrEditCustomerDto,
    CustomerAccountTypeLookupTableDto, CustomerLeadSourceLookupTableDto, ZipCodesServiceProxy, GetZipCodeForViewDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { NgForm } from '@angular/forms';

@Component({
    templateUrl: './create-or-edit-customer.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditCustomerComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;
    isNew = true;
    customer: CreateOrEditCustomerDto = new CreateOrEditCustomerDto();
    accountTypeDescription = '';
    allAccountTypes: CustomerAccountTypeLookupTableDto[] = [];
    allLeadSources: CustomerLeadSourceLookupTableDto[] = [];
    usZipCodes: GetZipCodeForViewDto[] = [];
    routerLink = '/app/main/business/accounts';
    @ViewChild('CustomerForm', { static: true }) customerForm: NgForm;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Customer'), this.routerLink)
    ];

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _customerServiceProxy: CustomerServiceProxy,
        private _zipCodeServiceProxy: ZipCodesServiceProxy,
        private _router: Router,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        const customerNumber = this._activatedRoute.snapshot.queryParams['number'];
        this.isNew = !!!customerNumber;
        this.show(customerNumber);
        this.breadcrumbs.push(new BreadcrumbItem(this.isNew ? this.l('CreateNewCustomer') : this.l('EditCustomer')));
    }

    show(customerId?: string): void {
        if (!customerId) {
            this.customer = new CreateOrEditCustomerDto();
            this.customer.name = 'Smith Construction 2';
            this.customer.phone = '123-987-9878';
            this.customer.eMail = 'info@smithconstruction.io';
            this.customer.wwwAddress = 'smithconstruction.io';
            this.customer.address = '4917 Jerome Avenue Phoenix, AZ 77777';
            this.customer.poBox = 'PO Box 123';
            this.customer.accountTypeId = 2;
            this.customer.dunsCode = '00001';
            this.customer.sicCode = 'N/A';
            this.customer.sicCode2 = 'N/A';
            this.customer.sicCode3 = 'N/A';
            this.customer.sicCode4 = 'N/A';
            this.customer.businessDescription = 'Offers solutions for industrial equipment dealerships who want to manage their operations and grow their bottom line.';
            this.active = true;
        } else {
            this._customerServiceProxy.getCustomerForEdit(customerId).subscribe((result) => {
                this.customer = result.customer;
                this.accountTypeDescription = result.accountTypeDescription;
                this.active = true;
            });
        }

        //TODO ForkJoin
        this._customerServiceProxy.getAllAccountTypeForTableDropdown()
            .subscribe((result) => {
                this.allAccountTypes = result;
            });
        this._customerServiceProxy.getAllLeadSourceForTableDropdown()
            .subscribe((result) => {
                this.allLeadSources = result;
            });
        this._zipCodeServiceProxy.getAll('', '', 0, 100_000_000)
            .subscribe((result) => {
                this.usZipCodes = result.items;
            });
    }

    save(): void {
        if (!this.customerForm.form.valid) {
            this.customerForm.form.markAllAsTouched();
            this.message.warn(this.l('InvalidFormMessage'));
            return;
        }
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
                this._router.navigate([this.routerLink]);
            });
    }

    goToAccounts() {
        this._router.navigate([this.routerLink]);
    }
}
