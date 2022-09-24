import {
    PermissionCheckerService,
    FeatureCheckerService,
    LocalizationService,
    MessageService,
    AbpMultiTenancyService,
    NotifyService,
    SettingService,
} from 'abp-ng2-module';
import { Component, Injector, OnDestroy } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { AppUrlService } from '@shared/common/nav/app-url.service';
import { AppSessionService } from '@shared/common/session/app-session.service';
import { AppUiCustomizationService } from '@shared/common/ui/app-ui-customization.service';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';
import { FileParameter, UiCustomizationSettingsDto } from '@shared/service-proxies/service-proxies';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgxSpinnerTextService } from '@app/shared/ngx-spinner-text.service';
import { CrmNotificationService } from '@app/shared/common/notification/crm-notification.service';

interface AbpEventSubscription {
    eventName: string;
    callback: (...args: any[]) => void;
}

@Component({
    template: '',
})
export abstract class AppComponentBase implements OnDestroy {
    localizationSourceName = AppConsts.localization.defaultLocalizationSourceName;

    localization: LocalizationService;
    permission: PermissionCheckerService;
    feature: FeatureCheckerService;
    notify: NotifyService;
    setting: SettingService;
    message: MessageService;
    multiTenancy: AbpMultiTenancyService;
    appSession: AppSessionService;
    primengTableHelper: PrimengTableHelper;
    ui: AppUiCustomizationService;
    appUrlService: AppUrlService;
    spinnerService: NgxSpinnerService;
    notifyService: CrmNotificationService;
    private ngxSpinnerTextService: NgxSpinnerTextService;

    eventSubscriptions: AbpEventSubscription[] = [];

    constructor(injector: Injector) {
        this.localization = injector.get(LocalizationService);
        this.permission = injector.get(PermissionCheckerService);
        this.feature = injector.get(FeatureCheckerService);
        this.notify = injector.get(NotifyService);
        this.setting = injector.get(SettingService);
        this.message = injector.get(MessageService);
        this.multiTenancy = injector.get(AbpMultiTenancyService);
        this.appSession = injector.get(AppSessionService);
        this.ui = injector.get(AppUiCustomizationService);
        this.appUrlService = injector.get(AppUrlService);
        this.primengTableHelper = new PrimengTableHelper();
        this.spinnerService = injector.get(NgxSpinnerService);
        this.ngxSpinnerTextService = injector.get(NgxSpinnerTextService);
        this.notifyService = injector.get(CrmNotificationService);
    }

    flattenDeep(array) {
        return array.reduce(
            (acc, val) => (Array.isArray(val) ? acc.concat(this.flattenDeep(val)) : acc.concat(val)),
            []
        );
    }

    l(key: string, ...args: any[]): string {
        args.unshift(key);
        args.unshift(this.localizationSourceName);
        return this.ls.apply(this, args);
    }

    lupper(key: string, ...args: any[]): string {
        return this.l(key, ...args).toUpperCase();
    }

    ls(sourcename: string, key: string, ...args: any[]): string {
        let localizedText = this.localization.localize(key, sourcename);

        if (!localizedText) {
            localizedText = key;
        }

        if (!args || !args.length) {
            return localizedText;
        }

        args.unshift(localizedText);
        return abp.utils.formatString.apply(this, this.flattenDeep(args));
    }

    isGranted(permissionName: string): boolean {
        return this.permission.isGranted(permissionName);
    }

    isGrantedAny(...permissions: string[]): boolean {
        if (!permissions) {
            return false;
        }

        for (const permission of permissions) {
            if (this.isGranted(permission)) {
                return true;
            }
        }

        return false;
    }

    s(key: string): string {
        return abp.setting.get(key);
    }

    appRootUrl(): string {
        return this.appUrlService.appRootUrl;
    }

    get currentTheme(): UiCustomizationSettingsDto {
        return this.appSession.theme;
    }

    get containerClass(): string {
        return this.appSession.theme.baseSettings.layout.layoutType === 'fluid'
        ? 'container-fluid'
        : 'container';
    }

    showMainSpinner(text?: string): void {
        this.ngxSpinnerTextService.setText(text);
        this.spinnerService.show();
    }

    hideMainSpinner(text?: string): void {
        this.spinnerService.hide();
    }

    protected subscribeToEvent(eventName: string, callback: (...args: any[]) => void): void {
        abp.event.on(eventName, callback);
        this.eventSubscriptions.push({
            eventName,
            callback,
        });
    }

    private unSubscribeAllEvents() {
        this.eventSubscriptions.forEach((s) => abp.event.off(s.eventName, s.callback));
        this.eventSubscriptions = [];
    }

    ngOnDestroy(): void {
        this.unSubscribeAllEvents();
    }

    /**
     * This method is used as a workaround for the strange behavior of bsDatepicker
     * where the input value is not updated when the user selects a date right after clearing the input field.
     * This will make the input field lost it's focus whenever its text value is cleared (removed completely)
     * forcing the bsDatepicker to update its model value.
     * @param event The input event
     */
    removeFocusWhenCleared(event): void {
        const { target } = event;
        if (!target.value) {
            target.blur();
        }
    }

    /***
     * Shows an empty string in case the value is 0, this is necessary for certain modules in the system
     * @param rentalContractNo
     */
    showStringEmptyInsteadOfZero(rentalContractNo: any) {
        if (rentalContractNo == 0) {
            return '';
        }
        return rentalContractNo;
    }

    /***
     * Generate an empty file
     * @description using an explicit content type to mark the empty value to bypass NSWAG's limitation
     */
    getEmptyFileParameter(): FileParameter {
        const emptyFile = new Blob([], {
            type: 'emptyfile'
        }) as File;
        return {
            data: emptyFile,
            fileName: emptyFile.name
        };
    }

    /***
     * Get FileParameter from file if is valid
     * otherwise return an empty FileParameter
     * @param file
     */
    getFileParameterFromFile(file: File): FileParameter {
        if (!file) {
            return this.getEmptyFileParameter();
        }
        return {
            data: file,
            fileName: file.name
        };
    }
}
