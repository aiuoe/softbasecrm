﻿import { AbpHttpInterceptor, RefreshTokenService, AbpHttpConfigurationService } from 'abp-ng2-module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import * as ApiServiceProxies from './service-proxies';
import * as ApiReportServiceProxies from './report-service-proxies';
import { ZeroRefreshTokenService } from '@account/auth/zero-refresh-token.service';
import { ZeroTemplateHttpConfigurationService } from './zero-template-http-configuration.service';

@NgModule({
    providers: [
        ApiReportServiceProxies.LeadsServiceProxy,
        ApiServiceProxies.CustomerAttachmentsServiceProxy,
        ApiServiceProxies.AccountActivitiesServiceProxy,
        ApiServiceProxies.ActivitiesServiceProxy,
        ApiServiceProxies.ActivitySourceTypesServiceProxy,
        ApiServiceProxies.ActivityPrioritiesServiceProxy,
        ApiServiceProxies.AccountUsersServiceProxy,
        ApiServiceProxies.BranchesServiceProxy,
        ApiServiceProxies.ReadCommonShareServiceProxy,
        ApiServiceProxies.CountriesServiceProxy,
        ApiServiceProxies.ActivityStatusesServiceProxy,
        ApiServiceProxies.ActivityTaskTypesServiceProxy,
        ApiServiceProxies.OpportunityTypesServiceProxy,
        ApiServiceProxies.OpportunityStagesServiceProxy,
        ApiServiceProxies.OpportunitiesServiceProxy,
        ApiServiceProxies.PrioritiesServiceProxy,
        ApiServiceProxies.LeadsServiceProxy,
        ApiServiceProxies.LeadStatusesServiceProxy,
        ApiServiceProxies.LeadSourcesServiceProxy,
        ApiServiceProxies.CustomerServiceProxy,
        ApiServiceProxies.AuditLogServiceProxy,
        ApiServiceProxies.CachingServiceProxy,
        ApiServiceProxies.ChatServiceProxy,
        ApiServiceProxies.CommonLookupServiceProxy,
        ApiServiceProxies.EditionServiceProxy,
        ApiServiceProxies.FriendshipServiceProxy,
        ApiServiceProxies.HostSettingsServiceProxy,
        ApiServiceProxies.InstallServiceProxy,
        ApiServiceProxies.LanguageServiceProxy,
        ApiServiceProxies.NotificationServiceProxy,
        ApiServiceProxies.OrganizationUnitServiceProxy,
        ApiServiceProxies.PermissionServiceProxy,
        ApiServiceProxies.ProfileServiceProxy,
        ApiServiceProxies.RoleServiceProxy,
        ApiServiceProxies.SessionServiceProxy,
        ApiServiceProxies.TenantServiceProxy,
        ApiServiceProxies.TenantDashboardServiceProxy,
        ApiServiceProxies.TenantSettingsServiceProxy,
        ApiServiceProxies.TimingServiceProxy,
        ApiServiceProxies.UserServiceProxy,
        ApiServiceProxies.UserLinkServiceProxy,
        ApiServiceProxies.UserLoginServiceProxy,
        ApiServiceProxies.WebLogServiceProxy,
        ApiServiceProxies.AccountServiceProxy,
        ApiServiceProxies.TokenAuthServiceProxy,
        ApiServiceProxies.TenantRegistrationServiceProxy,
        ApiServiceProxies.HostDashboardServiceProxy,
        ApiServiceProxies.PaymentServiceProxy,
        ApiServiceProxies.DemoUiComponentsServiceProxy,
        ApiServiceProxies.InvoiceServiceProxy,
        ApiServiceProxies.SubscriptionServiceProxy,
        ApiServiceProxies.InstallServiceProxy,
        ApiServiceProxies.UiCustomizationSettingsServiceProxy,
        ApiServiceProxies.PayPalPaymentServiceProxy,
        ApiServiceProxies.StripePaymentServiceProxy,
        ApiServiceProxies.DashboardCustomizationServiceProxy,
        ApiServiceProxies.WebhookEventServiceProxy,
        ApiServiceProxies.WebhookSubscriptionServiceProxy,
        ApiServiceProxies.WebhookSendAttemptServiceProxy,
        ApiServiceProxies.UserDelegationServiceProxy,
        ApiServiceProxies.DynamicPropertyServiceProxy,
        ApiServiceProxies.DynamicEntityPropertyDefinitionServiceProxy,
        ApiServiceProxies.DynamicEntityPropertyServiceProxy,
        ApiServiceProxies.DynamicPropertyValueServiceProxy,
        ApiServiceProxies.DynamicEntityPropertyValueServiceProxy,
        ApiServiceProxies.TwitterServiceProxy,
        ApiServiceProxies.OpportunitiesDashboardServiceProxy,
        ApiServiceProxies.BranchesServiceProxy,
        ApiServiceProxies.CommonSettingsServiceProxy,
        ApiServiceProxies.ReadCommonShareServiceProxy,
        { provide: RefreshTokenService, useClass: ZeroRefreshTokenService },
        { provide: AbpHttpConfigurationService, useClass: ZeroTemplateHttpConfigurationService },
        { provide: HTTP_INTERCEPTORS, useClass: AbpHttpInterceptor, multi: true },
    ],
})
export class ServiceProxyModule { }
