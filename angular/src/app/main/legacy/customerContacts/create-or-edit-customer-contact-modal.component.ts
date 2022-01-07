import { Component, ViewChild, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import {
    AccountUsersServiceProxy,
    CreateOrEditAccountUserDto,
    ContactsServiceProxy,
    CreateOrEditContactDto,
    GetContactForViewDto,
    GetContactForEditOutput,
    AccountUserLookupTableDto
} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { finalize } from '@node_modules/rxjs/operators';
import { forkJoin, Observable } from '@node_modules/rxjs';

/***
 * Component to manage creation of customer contacts
 */
@Component({
    selector: 'app-create-or-edit-customer-contact-modal',
    templateUrl: './create-or-edit-customer-contact-modal.component.html'
})
export class CreateOrEditCustomerContactModalComponent extends AppComponentBase implements OnInit {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    accountUser: CreateOrEditAccountUserDto = new CreateOrEditAccountUserDto();
    userName = '';
    selectedUsers: AccountUserLookupTableDto[];

    customerContact: CreateOrEditContactDto = new CreateOrEditContactDto();
    parentContacts: string[] = [];

    constructor(
        injector: Injector,
        private _accountUsersServiceProxy: AccountUsersServiceProxy,
        private _contactsServiceProxy: ContactsServiceProxy,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    /***
     * Initialize component
     */
    ngOnInit(): void {
    }


    /**
     * This method get the default information
     * @param customerNumber
     * @param customerContactId
     */
    show(customerNumber: string, customerContactId?: number): void {

        const requests: Observable<any>[] = [
            this._contactsServiceProxy.getAllWithoutPaging(customerNumber)
        ];

        if (!customerContactId) {
            forkJoin([...requests])
                .subscribe(([contactsResult]: [GetContactForViewDto[]]) => {
                    this.customerContact = new CreateOrEditContactDto();
                    this.customerContact.id = null;
                    this.customerContact.customerNo = customerNumber;
                    this.parentContacts = [];
                    this.parentContacts.push('root');
                    this.parentContacts.push(...contactsResult.map(x => x.contact.contact));
                    this.active = true;
                    this.modal.show();
                });
        } else {
            requests.push(this._contactsServiceProxy.getContactForEdit(customerContactId));

            forkJoin([...requests])
                .subscribe(([contactsResult, contactResult]: [GetContactForViewDto[], GetContactForEditOutput]) => {
                    this.customerContact = contactResult.contact;
                    const otherContacts = contactsResult
                        .map(x => x.contact.contact)
                        .filter(x => x.trim() !== this.customerContact.contact.trim());
                    this.parentContacts = [];
                    this.parentContacts.push('root');
                    this.parentContacts.push(...otherContacts);
                    this.active = true;
                    this.modal.show();
                }, () => {
                    this.message.error('GenericError');
                    this.modal.hide();
                });
        }
    }

    /**
     * This method save the contact
     */
    save(): void {
        this.saving = true;

        this._contactsServiceProxy
            .createOrEdit(this.customerContact)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notifyService.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    /**
     * Method to use to close the modal
     */
    close(): void {
        this.active = false;
        this.selectedUsers = [];
        this.modal.hide();
    }

}
