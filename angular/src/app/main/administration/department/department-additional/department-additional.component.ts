import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BranchLookupTableDto, CreateOrEditDepartmentDto } from '@shared/service-proxies/service-proxies';
import { TaxCodeSearchModalComponent } from '../../../common/tax-codes-search/tax-code-search-modal.component';

@Component({
  selector: 'app-department-additional',
  templateUrl: './department-additional.component.html',
  styleUrls: ['./department-additional.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
})
export class DepartmentAdditionalComponent extends AppComponentBase implements OnInit {

  miscDescriptions: BranchLookupTableDto[]; // TODO
  department: CreateOrEditDepartmentDto = new CreateOrEditDepartmentDto();

  @ViewChild('taxCodeSearchModal', { static: true })
  taxCodeSearchModal: TaxCodeSearchModalComponent;

  taxCode: string;


  constructor(
    injector: Injector
  ) {
    super(injector);
  }

  ngOnInit(): void {
  }

  searchAccount(): void {

  }

  //**Receives the tax code string from the Search Tax Code modal */
  receiveMessage($event) {
    this.taxCode = $event
  }


  //** Pulls up the Search Tax Codes Modal */
  searchTaxCode(): void {
    this.taxCodeSearchModal.show();
  }
}
