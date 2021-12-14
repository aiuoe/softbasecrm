import {AppConsts} from "@shared/AppConsts";
import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetAccountUserForViewDto, AccountUserDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewAccountUserModal',
    templateUrl: './view-accountUser-modal.component.html'
})
export class ViewAccountUserModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetAccountUserForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetAccountUserForViewDto();
        this.item.accountUser = new AccountUserDto();
    }

    show(item: GetAccountUserForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }
    
    

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
