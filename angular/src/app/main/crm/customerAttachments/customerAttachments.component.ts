import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerAttachmentsServiceProxy, CustomerAttachmentDto } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditCustomerAttachmentModalComponent } from './create-or-edit-customerAttachment-modal.component';

import { ViewCustomerAttachmentModalComponent } from './view-customerAttachment-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';
import { DateTime } from 'luxon';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';

@Component({
    templateUrl: './customerAttachments.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class CustomerAttachmentsComponent extends AppComponentBase {
    @ViewChild('createOrEditCustomerAttachmentModal', { static: true })
    createOrEditCustomerAttachmentModal: CreateOrEditCustomerAttachmentModalComponent;
    @ViewChild('viewCustomerAttachmentModalComponent', { static: true })
    viewCustomerAttachmentModal: ViewCustomerAttachmentModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    nameFilter = '';
    filePathFilter = '';

    constructor(
        injector: Injector,
        private _customerAttachmentsServiceProxy: CustomerAttachmentsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService
    ) {
        super(injector);
    }

    getCustomerAttachments(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._customerAttachmentsServiceProxy
            .getAll(
                this.filterText,
                this.nameFilter,
                this.filePathFilter,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createCustomerAttachment(): void {
        this.createOrEditCustomerAttachmentModal.show();
    }

    deleteCustomerAttachment(customerAttachment: CustomerAttachmentDto): void {
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                this._customerAttachmentsServiceProxy.delete(customerAttachment.id).subscribe(() => {
                    this.reloadPage();
                    this.notify.success(this.l('SuccessfullyDeleted'));
                });
            }
        });
    }

    exportToExcel(): void {
        this._customerAttachmentsServiceProxy
            .getCustomerAttachmentsToExcel(this.filterText, this.nameFilter, this.filePathFilter)
            .subscribe((result) => {
                this._fileDownloadService.downloadTempFile(result);
            });
    }

    downloadAttachment(customerAttachment: CustomerAttachmentDto) {

        const url = AppConsts.remoteServiceBaseUrl + `/CustomerImport/getAttachment?filePath=${customerAttachment.filePath}`;
        fetch(url, {
            headers: new Headers({
                Origin: location.origin,
                }),
                mode: "cors",
            })
            .then((response) => response.blob())
            .then((blob) => {
                const a = document.createElement("a");
                a.download = customerAttachment.filePath;
                a.href = window.URL.createObjectURL(blob);
                document.body.appendChild(a);
                a.click();
                a.remove();
            })
            .catch((error) => {
                this.notify.error(this.l('DownloadErrorMessage'));
            });
    }
}
