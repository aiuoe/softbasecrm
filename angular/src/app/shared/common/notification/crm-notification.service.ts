import { Injectable } from '@angular/core';
import { NotifyService } from '@node_modules/abp-ng2-module';
import { AppConsts } from '@shared/AppConsts';

/***
 * Service for global search component
 */
@Injectable()
export class CrmNotificationService {
    constructor(private notifyService: NotifyService) {
    }

    info(message: string, title?: string, options?: any): void {
        if (!options) {
            options = {};
        }
        options.timer = AppConsts.notifyToastTimer;
        options.showClass = { popup: 'toast-info' };
        this.notifyService.info(message, title, options);
    }

    error(message: string, title?: string, options?: any): void {
        if (!options) {
            options = {};
        }
        options.timer = AppConsts.notifyToastTimer;
        options.showClass = { popup: 'toast-error' };
        this.notifyService.error(message, title, options);
    }

    warn(message: string, title?: string, options?: any): void {
        if (!options) {
            options = {};
        }
        options.timer = AppConsts.notifyToastTimer;
        options.showClass = { popup: 'toast-warn' };
        this.notifyService.warn(message, title, options);
    }

    success(message: string, title?: string, options?: any): void {
        if (!options) {
            options = {};
        }  
        options.timer = AppConsts.notifyToastTimer;      
        options.showClass = { popup: 'toast-success' };
        this.notifyService.success(message, title, options);
    }
}
