﻿using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace SBCRM.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public AppAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AppAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Modules"));

            var activities = pages.CreateChildPermission(AppPermissions.Pages_Activities, L("Activities"));
            activities.CreateChildPermission(AppPermissions.Pages_Activities_Create, L("CreateNewActivity"));
            activities.CreateChildPermission(AppPermissions.Pages_Activities_Edit, L("EditActivity"));
            //activities.CreateChildPermission(AppPermissions.Pages_Activities_Delete, L("DeleteActivity"));
            activities.CreateChildPermission(AppPermissions.Pages_Activities_View_AssignedUserFilter, L("FilterByAssignee"));

            var activitySourceTypes = pages.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes, L("ActivitySourceTypes"));
            activitySourceTypes.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes_Create, L("CreateNewActivitySourceType"));
            activitySourceTypes.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes_Edit, L("EditActivitySourceType"));
            activitySourceTypes.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes_Delete, L("DeleteActivitySourceType"));

            var activityPriorities = pages.CreateChildPermission(AppPermissions.Pages_ActivityPriorities, L("ActivityPriorities"));
            activityPriorities.CreateChildPermission(AppPermissions.Pages_ActivityPriorities_Create, L("CreateNewActivityPriority"));
            activityPriorities.CreateChildPermission(AppPermissions.Pages_ActivityPriorities_Edit, L("EditActivityPriority"));
            activityPriorities.CreateChildPermission(AppPermissions.Pages_ActivityPriorities_Delete, L("DeleteActivityPriority"));

            //var contacts = pages.CreateChildPermission(AppPermissions.Pages_Contacts, L("Contacts"));
            //contacts.CreateChildPermission(AppPermissions.Pages_Contacts_Create, L("CreateNewContact"));
            //contacts.CreateChildPermission(AppPermissions.Pages_Contacts_Edit, L("EditContact"));
            //contacts.CreateChildPermission(AppPermissions.Pages_Contacts_Delete, L("DeleteContact"));
            
            var countries = pages.CreateChildPermission(AppPermissions.Pages_Countries, L("Countries"));
            countries.CreateChildPermission(AppPermissions.Pages_Countries_Create, L("CreateNewCountry"));
            countries.CreateChildPermission(AppPermissions.Pages_Countries_Edit, L("EditCountry"));
            countries.CreateChildPermission(AppPermissions.Pages_Countries_Delete, L("DeleteCountry"));

            //var accountUsers = pages.CreateChildPermission(AppPermissions.Pages_AccountUsers, L("CustomerAssignUsers"));
            //accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Create, L("CreateNewAccountUser"));
            //accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Edit, L("EditAccountUser"));
            //accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Delete, L("DeleteAccountUser"));

            var activityStatuses = pages.CreateChildPermission(AppPermissions.Pages_ActivityStatuses, L("ActivityStatuses"));
            activityStatuses.CreateChildPermission(AppPermissions.Pages_ActivityStatuses_Create, L("CreateNewActivityStatus"));
            activityStatuses.CreateChildPermission(AppPermissions.Pages_ActivityStatuses_Edit, L("EditActivityStatus"));
            activityStatuses.CreateChildPermission(AppPermissions.Pages_ActivityStatuses_Delete, L("DeleteActivityStatus"));

            var activityTaskTypes = pages.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes, L("ActivityTaskTypes"));
            activityTaskTypes.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes_Create, L("CreateNewActivityTaskType"));
            activityTaskTypes.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes_Edit, L("EditActivityTaskType"));
            activityTaskTypes.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes_Delete, L("DeleteActivityTaskType"));

            var opportunities = pages.CreateChildPermission(AppPermissions.Pages_Opportunities, L("Opportunities"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_Create, L("CreateNewOpportunity"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_Edit, L("EditOpportunity"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_Delete, L("DeleteOpportunity"));

            var opportunityTypes = pages.CreateChildPermission(AppPermissions.Pages_OpportunityTypes, L("OpportunityTypes"));
            opportunityTypes.CreateChildPermission(AppPermissions.Pages_OpportunityTypes_Create, L("CreateNewOpportunityType"));
            opportunityTypes.CreateChildPermission(AppPermissions.Pages_OpportunityTypes_Edit, L("EditOpportunityType"));
            opportunityTypes.CreateChildPermission(AppPermissions.Pages_OpportunityTypes_Delete, L("DeleteOpportunityType"));

            var opportunityStages = pages.CreateChildPermission(AppPermissions.Pages_OpportunityStages, L("OpportunityStages"));
            opportunityStages.CreateChildPermission(AppPermissions.Pages_OpportunityStages_Create, L("CreateNewOpportunityStage"));
            opportunityStages.CreateChildPermission(AppPermissions.Pages_OpportunityStages_Edit, L("EditOpportunityStage"));
            opportunityStages.CreateChildPermission(AppPermissions.Pages_OpportunityStages_Delete, L("DeleteOpportunityStage"));

            var leadUsers = pages.CreateChildPermission(AppPermissions.Pages_LeadUsers, L("LeadUsers"));
            leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Create, L("CreateNewLeadUser"));
            leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Edit, L("EditLeadUser"));
            leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Delete, L("DeleteLeadUser"));

            var priorities = pages.CreateChildPermission(AppPermissions.Pages_Priorities, L("Priorities"));
            priorities.CreateChildPermission(AppPermissions.Pages_Priorities_Create, L("CreateNewPriority"));
            priorities.CreateChildPermission(AppPermissions.Pages_Priorities_Edit, L("EditPriority"));
            priorities.CreateChildPermission(AppPermissions.Pages_Priorities_Delete, L("DeletePriority"));

            var leads = pages.CreateChildPermission(AppPermissions.Pages_Leads, L("Leads"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Create, L("CreateNewLead"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Edit, L("EditLead"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Delete, L("DeleteLead"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Convert_Account, L("LeadConvertToAccount"));

            var leadStatuses = pages.CreateChildPermission(AppPermissions.Pages_LeadStatuses, L("LeadStatuses"));
            leadStatuses.CreateChildPermission(AppPermissions.Pages_LeadStatuses_Create, L("CreateNewLeadStatus"));
            leadStatuses.CreateChildPermission(AppPermissions.Pages_LeadStatuses_Edit, L("EditLeadStatus"));
            leadStatuses.CreateChildPermission(AppPermissions.Pages_LeadStatuses_Delete, L("DeleteLeadStatus"));

            var leadSources = pages.CreateChildPermission(AppPermissions.Pages_LeadSources, L("LeadSources"));
            leadSources.CreateChildPermission(AppPermissions.Pages_LeadSources_Create, L("CreateNewLeadSource"));
            leadSources.CreateChildPermission(AppPermissions.Pages_LeadSources_Edit, L("EditLeadSource"));
            leadSources.CreateChildPermission(AppPermissions.Pages_LeadSources_Delete, L("DeleteLeadSource"));

            var industries = pages.CreateChildPermission(AppPermissions.Pages_Industries, L("Industries"));
            industries.CreateChildPermission(AppPermissions.Pages_Industries_Create, L("CreateNewIndustry"));
            industries.CreateChildPermission(AppPermissions.Pages_Industries_Edit, L("EditIndustry"));
            industries.CreateChildPermission(AppPermissions.Pages_Industries_Delete, L("DeleteIndustry"));

            var customer = pages.CreateChildPermission(AppPermissions.Pages_Customer, L("Customer"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_Create, L("CreateNewCustomer"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_Edit, L("EditCustomer"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Invoices, L("CustomerViewInvoices"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Equipments, L("CustomerViewEquipments"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Wip, L("CustomerViewWip"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Events, L("CustomerViewEvents"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_Add_Opportunity, L("CustomerAddOpportunity"));

            var accountUsers = customer.CreateChildPermission(AppPermissions.Pages_AccountUsers, L("CustomerViewAssignUsers"));
            accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Create, L("CreateNewAccountUser"));
            accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Delete, L("DeleteAccountUser"));
            accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Create_Restricted, L("CreateNewAccountUserRestricted"));

            var accountContact = customer.CreateChildPermission(AppPermissions.Pages_Contacts, L("CustomerViewAssignContacts"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Create, L("CreateNewAccountContact"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Edit, L("EditAccountContact"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Delete, L("DeleteAccountContact"));

            var accountTypes = pages.CreateChildPermission(AppPermissions.Pages_AccountTypes, L("AccountTypes"));
            accountTypes.CreateChildPermission(AppPermissions.Pages_AccountTypes_Create, L("CreateNewAccountType"));
            accountTypes.CreateChildPermission(AppPermissions.Pages_AccountTypes_Edit, L("EditAccountType"));
            accountTypes.CreateChildPermission(AppPermissions.Pages_AccountTypes_Delete, L("DeleteAccountType"));

            var arTerms = pages.CreateChildPermission(AppPermissions.Pages_ARTerms, L("ARTerms"));
            arTerms.CreateChildPermission(AppPermissions.Pages_ARTerms_Create, L("CreateNewARTerms"));
            arTerms.CreateChildPermission(AppPermissions.Pages_ARTerms_Edit, L("EditARTerms"));
            arTerms.CreateChildPermission(AppPermissions.Pages_ARTerms_Delete, L("DeleteARTerms"));

            var zipCodes = pages.CreateChildPermission(AppPermissions.Pages_ZipCodes, L("ZipCodes"));
            zipCodes.CreateChildPermission(AppPermissions.Pages_ZipCodes_Create, L("CreateNewZipCode"));
            zipCodes.CreateChildPermission(AppPermissions.Pages_ZipCodes_Edit, L("EditZipCode"));
            zipCodes.CreateChildPermission(AppPermissions.Pages_ZipCodes_Delete, L("DeleteZipCode"));

            pages.CreateChildPermission(AppPermissions.Pages_DemoUiComponents, L("DemoUiComponents"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
            var usersManagement = pages.CreateChildPermission(AppPermissions.Pages_UsersManagement, L("UsersManagement"));

            var roles = usersManagement.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = usersManagement.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Unlock, L("Unlock"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeDefaultLanguage, L("ChangeDefaultLanguage"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageRoles, L("ManagingRoles"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_UiCustomization, L("VisualSettings"));

            var webhooks = administration.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription, L("Webhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Create, L("CreatingWebhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Edit, L("EditingWebhooks"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_ChangeActivity, L("ChangingWebhookActivity"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Detail, L("DetailingSubscription"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ListSendAttempts, L("ListingSendAttempts"));
            webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ResendWebhook, L("ResendingWebhook"));

            var dynamicProperties = administration.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties, L("DynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Create, L("CreatingDynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Edit, L("EditingDynamicProperties"));
            dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Delete, L("DeletingDynamicProperties"));

            var dynamicPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue, L("DynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Create, L("CreatingDynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Edit, L("EditingDynamicPropertyValue"));
            dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Delete, L("DeletingDynamicPropertyValue"));

            var dynamicEntityProperties = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties, L("DynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Create, L("CreatingDynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Edit, L("EditingDynamicEntityProperties"));
            dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Delete, L("DeletingDynamicEntityProperties"));

            var dynamicEntityPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue, L("EntityDynamicPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Create, L("CreatingDynamicEntityPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Edit, L("EditingDynamicEntityPropertyValue"));
            dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Delete, L("DeletingDynamicEntityPropertyValue"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("SettingsAppearance"), multiTenancySides: MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_SubscriptionManagement, L("Subscription"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_MoveTenantsToAnotherEdition, L("MoveTenantsToAnotherEdition"), multiTenancySides: MultiTenancySides.Host);

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Maintenance, L("Maintenance"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_HangfireDashboard, L("HangfireDashboard"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SBCRMConsts.LocalizationSourceName);
        }
    }
}