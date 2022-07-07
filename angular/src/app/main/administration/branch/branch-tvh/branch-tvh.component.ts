import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchForEditDto } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'branchTvh',
    templateUrl: './branch-tvh.component.html'
})

export class BranchTvhComponent extends AppComponentBase {
    
    @Input() branchForEdit: BranchForEditDto;

    countries: any[] = [
        { displayName: "United States", value: "0" },
        { displayName: "Canada", value: "1" },
        { displayName: "Mexico", value: "2" },
    ];

    warehouses:any[]=[
        { displayName: "All, US", value: "0" },
        { displayName: "Kansas, US", value: "1" },
        { displayName: "California, US", value: "2" },
        { displayName: "Oregon, US", value: "3" },
        { displayName: "South Carolina, US", value: "4" },
        { displayName: "Pennsylvania, US", value: "5" },
        { displayName: "Illinois, US", value: "6" },
        { displayName: "Lousiana, US", value: "7" },
        { displayName: "Florida, US", value: "8" },
        { displayName: "Ontario, Canada", value: "9" },
        { displayName: "British Columbia, Canada", value: "10" },
        { displayName: "Mexico City, Mexico", value: "11" },
        { displayName: "Monterrey, Mexico", value: "12" },
    ]

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}