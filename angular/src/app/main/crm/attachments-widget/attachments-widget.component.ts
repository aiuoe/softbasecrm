import { TokenService } from 'abp-ng2-module';
import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerAttachmentsServiceProxy } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAttachmentsWidgetModalComponent } from './create-or-edit-attachments-widget-modal.component';

import { ViewAttachmentsWidgetModalComponent } from './view-attachments-widget-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import { filter as _filter } from 'lodash-es';

import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { IAttachment } from './attachment.model';

/***
 * Component to manage the list of attachments.
 */
 @Component({
    templateUrl: './attachments-widget.component.html',
    selector: 'attachments-widget',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
})
export class AttachmentsWidgetComponent extends AppComponentBase implements OnInit {
    @ViewChild('createOrEditAttachmentsWidgetModal', { static: true }) createOrEditAttachmentsWidgetModal: CreateOrEditAttachmentsWidgetModalComponent;
    @ViewChild('viewAttachmentsWidgetModal', { static: true }) viewAttachmentsWidgetModal: ViewAttachmentsWidgetModalComponent;

    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    @Input() componentType = '';
    @Input() idToStore: any;
    @Output() onSaveAttachments: EventEmitter<any> = new EventEmitter<any>();

    advancedFiltersAreShown = false;
    filterText = '';
    nameFilter = '';
    filePathFilter = '';
    canAddAttachments = false;
    canEditAttachments = false;
    canDeleteAttachments = false;

    constructor(
        injector: Injector,
        private _customerAttachmentsServiceProxy: CustomerAttachmentsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _dateTimeService: DateTimeService,
        private _tokenService: TokenService,
    ) {
        super(injector);
    }

    /***
     * Initialize component
     */
     ngOnInit() {
        this.loadPermissions();
    }

    /***
     * Load permissions
     */
    private loadPermissions() {

        switch (this.componentType) {
            case 'Account':
                this.canAddAttachments = this.isGranted('Pages.CustomerAttachments.Create');
                this.canEditAttachments = this.isGranted('Pages.CustomerAttachments.Edit');
                this.canDeleteAttachments = this.isGranted('Pages.CustomerAttachments.Delete');
                break;

            case 'Lead':
                this.canAddAttachments = this.isGranted('Pages.LeadAttachments.Create');
                this.canEditAttachments = this.isGranted('Pages.LeadAttachments.Edit');
                this.canDeleteAttachments = this.isGranted('Pages.LeadAttachments.Delete');
                break;

            case 'Opportunity':
                this.canAddAttachments = this.isGranted('Pages.OpportunityAttachments.Create');
                this.canEditAttachments = this.isGranted('Pages.OpportunityAttachments.Edit');
                this.canDeleteAttachments = this.isGranted('Pages.OpportunityAttachments.Delete');
                break;
        }
    }

    /**
     * Method to call data
     * @param event
     */
    loadDataTable(event?: LazyLoadEvent) {
        switch (this.componentType) {
            case 'Account':
                this.getCustomerAttachments(event);
                break;

            case 'Lead':
//                this.getLeadAttachments(event);
                break;

            case 'Opportunity':
//                this.getOpportunityAttachments(event);
                break;
        }
    }
    
    /**
     * Populates the customer attachments list.
     * @param event 
     */
    getCustomerAttachments(event?: LazyLoadEvent) {

        this.primengTableHelper.showLoadingIndicator();

        this._customerAttachmentsServiceProxy
            .getAll(
                this.filterText,
                this.nameFilter,
                this.filePathFilter,
                this.idToStore,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getSkipCount(this.paginator, event),
                this.primengTableHelper.getMaxResultCount(this.paginator, event)
            )
            .subscribe((result) => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items.map(item => item.customerAttachment);
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
     * Creates new attachment
     */
    createAttachment(): void {
        this.createOrEditAttachmentsWidgetModal.show();
    }

    /**
     * Deletes existing attachment
     * @param attachment An attachment to be removed
     * @returns 
     */
    deleteAttachment(attachment: IAttachment): void {

        switch (this.componentType) {
            case 'Account':
                break;
            default:
                return;
        }

        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                switch (this.componentType) {
                    case 'Account':
                        this._customerAttachmentsServiceProxy.delete(attachment.id).subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                        break;        
                }
            }
        });
    }

    /**
     * Downloads existing attachment
     * @param attachment An attachment to download
     */
    downloadAttachment(attachment: IAttachment) {

        const url = AppConsts.remoteServiceBaseUrl + `/CustomerImport/getAttachment?filePath=${attachment.filePath}`;
        fetch(url, {
            headers: new Headers({
                    Origin: location.origin,
                    Authorization: 'Bearer ' + this._tokenService.getToken()
                }),
                mode: "cors",
            })
            .then((response) => response.blob())
            .then((blob) => {
                const a = document.createElement("a");
                a.download = attachment.filePath;
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
