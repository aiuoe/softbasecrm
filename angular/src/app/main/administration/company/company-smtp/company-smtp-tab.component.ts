import { Component, Injector, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for SMTP
 */
@Component({
    selector: 'smtpCompanyTab',
    templateUrl: './company-smtp-tab.component.html',
})
export class SMTPCompanyTabComponent extends AppComponentBase implements OnInit {
    selectItems: SelectItem[] = [
        { label: 'Item 1', value: 'Item 1' },
        { label: 'Item 2', value: 'Item 2' },
    ];
    
    constructor(
        injector: Injector,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.primengTableHelper.showLoadingIndicator();
        this.primengTableHelper.hideLoadingIndicator();
    }
}
