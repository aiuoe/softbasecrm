import { Injector, Component, OnInit, Inject } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ThemesLayoutBaseComponent } from '@app/shared/layout/themes/themes-layout-base.component';
import { UrlHelper } from '@shared/helpers/UrlHelper';
import { DOCUMENT } from '@angular/common';
import { OffcanvasOptions } from '@metronic/app/core/_base/layout/directives/offcanvas.directive';
import { AppConsts } from '@shared/AppConsts';
import { ToggleOptions } from '@metronic/app/core/_base/layout/directives/toggle.directive';
import { DateTimeService } from '@app/shared/common/timing/date-time.service';
import { Router } from '@angular/router';
import { DataService } from '@app/shared/common/crm/services/data.service';

@Component({
    templateUrl: './default-layout.component.html',
    selector: 'default-layout',
    animations: [appModuleAnimation()],
    providers: [DataService]
})
export class DefaultLayoutComponent extends ThemesLayoutBaseComponent implements OnInit {
    menuCanvasOptions: OffcanvasOptions = {
        baseClass: 'aside',
        overlay: true,
        closeBy: 'kt_aside_close_btn',
        toggleBy: 'kt_aside_mobile_toggle',
    };

    userMenuToggleOptions: ToggleOptions = {
        target: this.document.body,
        targetState: 'topbar-mobile-on',
        toggleState: 'active',
    };

    remoteServiceBaseUrl: string = AppConsts.remoteServiceBaseUrl;
    globalSearchFilter: string;

    constructor(
        injector: Injector,
        @Inject(DOCUMENT) private document: Document,
        _dateTimeService: DateTimeService,
        private _router: Router,
        private _dataService: DataService) {
        super(injector, _dateTimeService);
    }

    ngOnInit() {
        this.installationMode = UrlHelper.isInstallUrl(location.href);
    }

    globalSearch() {
        this._router.navigate(['/app/main/global-search'], { queryParams: { filter: this.globalSearchFilter }});
        this._dataService.updatedGlobalSearch(this.globalSearchFilter);
    }
}
