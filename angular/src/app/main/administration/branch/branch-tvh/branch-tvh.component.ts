import { Component, Injector, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CountryDto, TvhWarehouseLookupDto, UpsertBranchDto } from '@shared/service-proxies/service-proxies';

/**
 * Sub component for branch tvh tab
 */
@Component({
    selector: 'branchTvh',
    templateUrl: './branch-tvh.component.html'
})

export class BranchTvhComponent extends AppComponentBase {

    @Input() isViewMode: boolean;
    @Input() upsertBranchDto: UpsertBranchDto;
    @Input() countries: CountryDto[] = [];
    @Input() tvhWarehouses: TvhWarehouseLookupDto[] = [];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}