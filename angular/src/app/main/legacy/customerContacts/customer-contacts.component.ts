import { Component, EventEmitter, Injector, Input, OnInit, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ViewAssignedUserModalComponent } from '@app/main/crm/assigned-user/view-assigned-user-modal.component';
import { Table } from '@node_modules/primeng/table';
import { Paginator } from '@node_modules/primeng/paginator';
import {
    ContactDto, ContactsServiceProxy, TokenAuthServiceProxy
} from '@shared/service-proxies/service-proxies';
import { NotifyService } from '@node_modules/abp-ng2-module';
import { ActivatedRoute } from '@angular/router';
import { LazyLoadEvent } from '@node_modules/primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';
import {
    CreateOrEditCustomerContactModalComponent
} from '@app/main/legacy/customerContacts/create-or-edit-customer-contact-modal.component';
import { forkJoin, Observable } from 'rxjs';

/***
 * Component to manage the list of assigned customer-contacts
 */
@Component({
    templateUrl: './customer-contacts-component.html',
    selector: 'app-customer-contacts',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class CustomerContactsComponent extends AppComponentBase implements OnInit {

    @ViewChild('createOrEditCustomerContactModal', { static: true }) createOrEditCustomerContactModal: CreateOrEditCustomerContactModalComponent;
    @ViewChild('viewAssignedUserModal', { static: true }) viewAssignedUserModal: ViewAssignedUserModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @Input() customerNumber: any;
    @Output() onSaveContact: EventEmitter<any> = new EventEmitter<any>();

    userNameFilter = '';
    saving = false;
    customerContacts: ContactDto[];

    // Permissions
    canRemove = false;

    /***
     * Main constructor
     * @param injector
     * @param _contactServiceProxy
     * @param _notifyService
     * @param _tokenAuth
     * @param _activatedRoute
     */
    constructor(
        injector: Injector,
        private _contactServiceProxy: ContactsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.loadPermissions();
    }

    /***
     * Load permissions
     */
    private loadPermissions() {
        const requests: Observable<any>[] = [
            this._contactServiceProxy.getCanDeleteContact(this.customerNumber)
        ];
        forkJoin([...requests])
            .subscribe(([canDeleteContact]: [boolean]) => {
                this.canRemove = canDeleteContact;
            });
    }

    /***
     * Output handler when contact is created or updated
     */
    onContactUpdated() {
        this.getCustomerContacts();
        this.onSaveContact.emit();
    }

    /***
     * @param event Gets the list of users assigned to an Account/Lead/Opportunity
     * @returns
     */
    getCustomerContacts(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._contactServiceProxy.getAll(
            this.userNameFilter,
            this.customerNumber,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.customerContacts = result.items.map(x => x.contact);
            this.primengTableHelper.records = this.customerContacts;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    /**
     * Refresh the table
     */
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    /**
     * Handles the creation context menu
     */
    addCustomerContact(): void {
        this.createOrEditCustomerContactModal.show(this.customerNumber);
    }

    /**
     * Handles the deletion of a contact
     * @param contact
     */
    deleteContact(contact: ContactDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._contactServiceProxy.delete(contact.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notifyService.success(this.l('SuccessfullyDeleted'));
                            this.onSaveContact.emit();
                        });
                }
            }
        );
    }

    /**
     * Handles the edition context menu
     * @param contact
     */
    editContact(contact: ContactDto): void {
        this.createOrEditCustomerContactModal.show(this.customerNumber, contact.id);
    }
}
