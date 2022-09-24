import { AppConsts } from '@shared/AppConsts';
import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { CustomerServiceProxy, GetCustomerForViewDto, CustomerDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ActivatedRoute } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BreadcrumbItem } from '@app/shared/common/sub-header/sub-header.component';
@Component({
    templateUrl: './view-customer.component.html',
    animations: [appModuleAnimation()],
})
export class ViewCustomerComponent extends AppComponentBase implements OnInit {
    active = false;
    saving = false;

    item: GetCustomerForViewDto;

    breadcrumbs: BreadcrumbItem[] = [
        new BreadcrumbItem(this.l('Customer'), '/app/main/legacy/customer'),
        new BreadcrumbItem(this.l('Customer') + '' + this.l('Details')),
    ];
    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
        private _customerServiceProxy: CustomerServiceProxy
    ) {
        super(injector);
        this.item = new GetCustomerForViewDto();
        this.item.customer = new CustomerDto();
    }

    ngOnInit(): void {
        this.show(this._activatedRoute.snapshot.queryParams['id']);
    }

    show(customerId: number): void {
        // this._customerServiceProxy.getCustomerForView(customerId).subscribe((result) => {
        //     this.item = result;
        //     this.active = true;
        // });
    }
}
