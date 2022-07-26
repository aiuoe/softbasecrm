import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';

/***
 * Component for equipment comments
 */
@Component({
    selector: 'equipmentCommentsCompanyTab',
    templateUrl: './company-equipment-comments-tab.component.html',
})
export class EquipmentCommentsCompanyTabComponent extends AppComponentBase implements OnInit {
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
