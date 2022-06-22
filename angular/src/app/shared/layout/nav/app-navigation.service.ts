import { Injectable } from '@angular/core';
import { AppMenu } from './app-menu';
import { AppMenuItem } from './app-menu-item';
import { PermissionCheckerService } from 'abp-ng2-module';
import { AppSessionService } from '@shared/common/session/app-session.service';

@Injectable()
export class AppNavigationService {
    constructor(
        private _permissionCheckerService: PermissionCheckerService,
        private _appSessionService: AppSessionService
    ) {}

    getMenu(): AppMenu {
        return new AppMenu('MainMenu', 'MainMenu', [
            new AppMenuItem(
                'Dashboard',
                'Pages.Administration.Host.Dashboard',
                'flaticon-line-graph',
                '/app/admin/hostDashboard'
            ),
            new AppMenuItem('Dashboard', 'Pages.Dashboard', 'fas fa-chart-pie', '/app/main/dashboard', ['/app/main/dashboard']),
            new AppMenuItem('Tenants', 'Pages.Tenants', 'flaticon-list-3', '/app/admin/tenants', ['/app/admin/tenants']),
            new AppMenuItem('Editions', 'Pages.Editions', 'flaticon-app', '/app/admin/editions', ['/app/admin/editions']),
            new AppMenuItem('Customers', 'Pages.Customer', 'fas fa-book', '/app/main/crm/accounts/', ['/app/main/crm/accounts']),
            new AppMenuItem('Leads', 'Pages.Leads', 'fas fa-id-badge', '/app/main/crm/leads', ['/app/main/crm/leads']),
            new AppMenuItem('Opportunities', 'Pages.Opportunities', 'fa fa-thumbs-up', '/app/main/crm/opportunities', ['/app/main/crm/opportunities']),
            new AppMenuItem('Activities', 'Pages.Activities', 'flaticon2-list-3', '/app/main/crm/activities', ['/app/main/crm/activities']),
            new AppMenuItem(
                'Configuration',
                '',
                'fas fa-cog',
                '',
                [],
                [
                    new AppMenuItem(
                        'OpportunityStages',
                        'Pages.OpportunityStages',
                        '',
                        '/app/main/crm/opportunityStages'
                    ),
                    new AppMenuItem(
                        'LeadSources',
                        'Pages.LeadSources',
                        '',
                        '/app/main/crm/leadSources'
                    ),
                    new AppMenuItem(
                        'LeadStatuses',
                        'Pages.LeadStatuses',
                        '',
                        '/app/main/crm/leadStatuses'
                    ),
                    new AppMenuItem(
                        'ActivityStatus',
                        'Pages.ActivityStatuses',
                        '',
                        '/app/main/crm/activityStatuses'
                    )
                ]
            ),
            // new AppMenuItem(
            //     'Business',
            //     '',
            //     'flaticon-interface-8',
            //     '',
            //     [],
            //     [
            //         new AppMenuItem('Countries', 'Pages.Countries', 'flaticon-more', '/app/main/crm/countries'),
            //         new AppMenuItem(
            //             'OpportunityTypes',
            //             'Pages.OpportunityTypes',
            //             'flaticon-more',
            //             '/app/main/crm/opportunityTypes'
            //         ),
            //         new AppMenuItem(
            //             'LeadStatuses',
            //             'Pages.LeadStatuses',
            //             'flaticon-more',
            //             '/app/main/crm/leadStatuses'
            //         ),
            //         new AppMenuItem(
            //             'LeadSources',
            //             'Pages.LeadSources',
            //             'flaticon-more',
            //             '/app/main/business/leadSources'
            //         ),
            //         new AppMenuItem(
            //             'LeadStatuses',
            //             'Pages.LeadStatuses',
            //             'flaticon-more',
            //             '/app/main/business/leadStatuses'
            //         ),
            //         new AppMenuItem('Priorities', 'Pages.Priorities', 'flaticon-more', '/app/main/crm/priorities'),
            //         new AppMenuItem(
            //             'ActivityTaskTypes',
            //             'Pages.ActivityTaskTypes',
            //             'flaticon-more',
            //             '/app/main/crm/activityTaskTypes'
            //         ),
            //         new AppMenuItem(
            //             'ActivityPriorities',
            //             'Pages.ActivityPriorities',
            //             'flaticon-more',
            //             '/app/main/crm/activityPriorities'
            //         ),
            //         new AppMenuItem(
            //             'ActivitySourceTypes',
            //             'Pages.ActivitySourceTypes',
            //             'flaticon-more',
            //             '/app/main/crm/activitySourceTypes'
            //         ),
            //         new AppMenuItem(
            //             'ActivityStatuses',
            //             'Pages.ActivityStatuses',
            //             'flaticon-more',
            //             '/app/main/crm/activityStatuses'
            //             ),
            //         new AppMenuItem(
            //             'AccountUsers',
            //             'Pages.AccountUsers',
            //             'flaticon-more',
            //             '/app/main/crm/accountUsers'
            //         ),
            //     ]
            // ),
            new AppMenuItem(
                'User Management',
                '',
                'fas fa-user-shield',
                '',
                [],
                [
                    new AppMenuItem('Users', 'Pages.Administration.Users', '', '/app/admin/users'),
                    new AppMenuItem('Roles', 'Pages.Administration.Roles', '', '/app/admin/roles')
                ]
            ),
            new AppMenuItem(
                'Administration',
                '',
                'fas fa-cog',
                '',
                [],
                [
                    new AppMenuItem(
                        'Appearance',
                        'Pages.Administration.Tenant.Settings',
                        '',
                        '/app/admin/tenantSettings'
                    ),
                    new AppMenuItem(
                        'Sale Codes',
                        '',
                        '',
                        '/app/main/administration/saleCodes'
                    )
                    // new AppMenuItem(
                    //     'OrganizationUnits',
                    //     'Pages.Administration.OrganizationUnits',
                    //     '',
                    //     '/app/admin/organization-units'
                    // ),
                    // new AppMenuItem(
                    //     'AuditLogs',
                    //     'Pages.Administration.AuditLogs',
                    //     '',
                    //     '/app/admin/auditLogs'
                    // ),
                    // new AppMenuItem(
                    //     'Maintenance',
                    //     'Pages.Administration.Host.Maintenance',
                    //     '',
                    //     '/app/admin/maintenance'
                    // ),
                    // new AppMenuItem(
                    //     'Subscription',
                    //     'Pages.Administration.Tenant.SubscriptionManagement',
                    //     '',
                    //     '/app/admin/subscription-management'
                    // ),
                    // new AppMenuItem(
                    //     'VisualSettings',
                    //     'Pages.Administration.UiCustomization',
                    //     '',
                    //     '/app/admin/ui-customization'
                    // ),
                    // new AppMenuItem(
                    //     'WebhookSubscriptions',
                    //     'Pages.Administration.WebhookSubscription',
                    //     '',
                    //     '/app/admin/webhook-subscriptions'
                    // ),
                    // new AppMenuItem(
                    //     'DynamicProperties',
                    //     'Pages.Administration.DynamicProperties',
                    //     '',
                    //     '/app/admin/dynamic-property'
                    // ),
                    // new AppMenuItem(
                    //     'Settings',
                    //     'Pages.Administration.Host.Settings',
                    //     '',
                    //     '/app/admin/hostSettings'
                    // ),
                    // new AppMenuItem(
                    //     'Languages',
                    //     'Pages.Administration.Languages',
                    //     '',
                    //     '/app/admin/languages',
                    //     ['/app/admin/languages/{name}/texts']
                    // )
                ])
        ]);
    }

    checkChildMenuItemPermission(menuItem): boolean {
        for (let i = 0; i < menuItem.items.length; i++) {
            let subMenuItem = menuItem.items[i];

            if (subMenuItem.permissionName === '' || subMenuItem.permissionName === null) {
                if (subMenuItem.route) {
                    return true;
                }
            } else if (this._permissionCheckerService.isGranted(subMenuItem.permissionName)) {
                return true;
            }

            if (subMenuItem.items && subMenuItem.items.length) {
                let isAnyChildItemActive = this.checkChildMenuItemPermission(subMenuItem);
                if (isAnyChildItemActive) {
                    return true;
                }
            }
        }
        return false;
    }

    showMenuItem(menuItem: AppMenuItem): boolean {
        if (
            menuItem.permissionName === 'Pages.Administration.Tenant.SubscriptionManagement' &&
            this._appSessionService.tenant &&
            !this._appSessionService.tenant.edition
        ) {
            return false;
        }

        let hideMenuItem = false;

        if (menuItem.requiresAuthentication && !this._appSessionService.user) {
            hideMenuItem = true;
        }

        if (menuItem.permissionName && !this._permissionCheckerService.isGranted(menuItem.permissionName)) {
            hideMenuItem = true;
        }

        if (this._appSessionService.tenant || !abp.multiTenancy.ignoreFeatureCheckForHostUsers) {
            if (menuItem.hasFeatureDependency() && !menuItem.featureDependencySatisfied()) {
                hideMenuItem = true;
            }
        }

        if (!hideMenuItem && menuItem.items && menuItem.items.length) {
            return this.checkChildMenuItemPermission(menuItem);
        }

        return !hideMenuItem;
    }

    /**
     * Returns all menu items recursively
     */
    getAllMenuItems(): AppMenuItem[] {
        let menu = this.getMenu();
        let allMenuItems: AppMenuItem[] = [];
        menu.items.forEach((menuItem) => {
            allMenuItems = allMenuItems.concat(this.getAllMenuItemsRecursive(menuItem));
        });

        return allMenuItems;
    }

    private getAllMenuItemsRecursive(menuItem: AppMenuItem): AppMenuItem[] {
        if (!menuItem.items) {
            return [menuItem];
        }

        let menuItems = [menuItem];
        menuItem.items.forEach((subMenu) => {
            menuItems = menuItems.concat(this.getAllMenuItemsRecursive(subMenu));
        });

        return menuItems;
    }
}
