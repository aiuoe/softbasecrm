import { TokenService } from 'abp-ng2-module';
import { AppConsts } from '@shared/AppConsts';
import { Component, Injector, ViewEncapsulation, ViewChild, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerAttachmentCustomerLookupTableDto, CustomerAttachmentsServiceProxy, LeadAttachmentLeadLookupTableDto, LeadAttachmentsServiceProxy, OpportunityAttachmentsServiceProxy } from '@shared/service-proxies/service-proxies';
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
import { ConsoleLogger } from '@microsoft/signalr/dist/esm/Utils';

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

    customerForPermissions : CustomerAttachmentCustomerLookupTableDto;
    leadForPermissions : LeadAttachmentLeadLookupTableDto;

    advancedFiltersAreShown = false;
    filterText = '';
    nameFilter = '';
    filePathFilter = '';
    canViewAttachments = false;
    canAddAttachments = false;
    canEditAttachments = false;
    canDownloadAttachments = false;
    canRemoveAttachments = false;

    constructor(
        injector: Injector,
        private _customerAttachmentsServiceProxy: CustomerAttachmentsServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
        private _leadAttachmentsServiceProxy: LeadAttachmentsServiceProxy,
        private _opportunityAttachmentsServiceProxy: OpportunityAttachmentsServiceProxy,
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
                this._customerAttachmentsServiceProxy.getAllCustomerForTableDropdown(this.idToStore)
                .subscribe((result) => {
                   this.customerForPermissions = result[0];
                   this.canViewAttachments = this.customerForPermissions? this.customerForPermissions.canViewAttachments : false;
                   this.canAddAttachments = this.customerForPermissions? this.customerForPermissions.canAddAttachments : false;
                   this.canEditAttachments = this.customerForPermissions? this.customerForPermissions.canEditAttachments : false,
                   this.canDownloadAttachments = this.customerForPermissions? this.customerForPermissions.canDownloadAttachments : false,
                   this.canRemoveAttachments  = this.customerForPermissions? this.customerForPermissions.canRemoveAttachments : false             
               });
                break;

            case 'Lead':
                this._leadAttachmentsServiceProxy.getAllLeadForTableDropdown(this.idToStore)
                 .subscribe((result) => {
                    this.leadForPermissions = result[0];
                    this.canViewAttachments = this.leadForPermissions? this.leadForPermissions.canViewAttachments : false;
                    this.canAddAttachments = this.leadForPermissions? this.leadForPermissions.canAddAttachments : false;
                    this.canEditAttachments = this.leadForPermissions? this.leadForPermissions.canEditAttachments : false,
                    this.canDownloadAttachments = this.leadForPermissions? this.leadForPermissions.canDownloadAttachments : false,
                    this.canRemoveAttachments  = this.leadForPermissions? this.leadForPermissions.canRemoveAttachments : false             
                }); 
                break;

            case 'Opportunity':
                this.canAddAttachments = true;
                this.canEditAttachments = true;
                this.canRemoveAttachments = true;
                this.canDownloadAttachments = true;
                this.canRemoveAttachments = true;
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
                this.getLeadAttachments(event);
                break;

            case 'Opportunity':
                this.getOpportunityAttachments(event);
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
     * Populates the opportunity attachments list.
     * @param event 
     */
         getOpportunityAttachments(event?: LazyLoadEvent) {

            this.primengTableHelper.showLoadingIndicator();
    
            this._opportunityAttachmentsServiceProxy
                .getAll(
                    this.filterText,
                    this.nameFilter,
                    this.filePathFilter,
                    '',
                    this.idToStore,
                    this.primengTableHelper.getSorting(this.dataTable),
                    this.primengTableHelper.getSkipCount(this.paginator, event),
                    this.primengTableHelper.getMaxResultCount(this.paginator, event)
                )
                .subscribe((result) => {
                    this.primengTableHelper.totalRecordsCount = result.totalCount;
                    this.primengTableHelper.records = result.items.map(item => item.opportunityAttachment);
                    this.primengTableHelper.hideLoadingIndicator();
                });
        }

        /**
     * Populates the lead attachments list.
     * @param event 
     */
         getLeadAttachments(event?: LazyLoadEvent) {

            this.primengTableHelper.showLoadingIndicator();
            this._leadAttachmentsServiceProxy
                .getAll(
                    this.filterText,
                    this.nameFilter,
                    this.filePathFilter,
                    '',
                    this.idToStore,
                    this.primengTableHelper.getSorting(this.dataTable),
                    this.primengTableHelper.getSkipCount(this.paginator, event),
                    this.primengTableHelper.getMaxResultCount(this.paginator, event)
                )
                .subscribe((result) => {
                    this.primengTableHelper.totalRecordsCount = result.totalCount;
                    this.primengTableHelper.records = result.items.map(item => item.leadAttachment);
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
        this.message.confirm('', this.l('AreYouSure'), (isConfirmed) => {
            if (isConfirmed) {
                switch (this.componentType) {
                    case 'Account':
                        this._customerAttachmentsServiceProxy.delete(attachment.id).subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                        break;

                    case 'Lead':
                        this._leadAttachmentsServiceProxy.delete(attachment.id).subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                        break;

                    case 'Opportunity':
                        this._opportunityAttachmentsServiceProxy.delete(attachment.id).subscribe(() => {
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

        const url = AppConsts.remoteServiceBaseUrl +  this.getAPIUrlForDownloadAttachment(attachment);
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
                let url = window.URL.createObjectURL(blob);

                a.download = attachment.filePath;
                a.href = url;
                document.body.appendChild(a);
                a.click();
                a.remove();

                setTimeout(() => window.URL.revokeObjectURL(url), 100);
            })
            .catch((error) => {
                this.notify.error(this.l('DownloadErrorMessage'));
            });
    }

    private getAPIUrlForDownloadAttachment(attachment: IAttachment){
        switch(this.componentType){
            case 'Account':
                return `/CustomerImport/getAttachment?id=${attachment.id}`;
                break;

            case 'Lead':
                return `/LeadImportAttachment/getAttachment?id=${attachment.id}`
                break;

            case 'Opportunity':
                return `/OpportunityAttachment/getAttachment?id=${attachment.id}`
                break;
        }
    }
}
