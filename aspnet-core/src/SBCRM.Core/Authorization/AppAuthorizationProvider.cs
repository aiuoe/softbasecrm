using Abp.Authorization;
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
            var createActivity = activities.CreateChildPermission(AppPermissions.Pages_Activities_Create, L("CreateNewActivity"));
            createActivity.CreateChildPermission(AppPermissions.Pages_Activities_Create_Assign_Other_Users__Dynamic, L(AppPermissions.Pages_Activities_Create_Assign_Other_Users__Dynamic));
            createActivity.CreateChildPermission(AppPermissions.Pages_Activities_Create_View_All_Accounts_Leads_Opportunities__Dynamic, L(AppPermissions.Pages_Activities_Create_View_All_Accounts_Leads_Opportunities__Dynamic));
            activities.CreateChildPermission(AppPermissions.Pages_Activities_Edit, L("EditActivity"));
            //activities.CreateChildPermission(AppPermissions.Pages_Activities_Delete, L("DeleteActivity"));
            activities.CreateChildPermission(AppPermissions.Pages_Activities_View_AssignedUserFilter, L(AppPermissions.Pages_Activities_View_AssignedUserFilter));

            //var activitySourceTypes = pages.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes, L("ActivitySourceTypes"));
            //activitySourceTypes.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes_Create, L("CreateNewActivitySourceType"));
            //activitySourceTypes.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes_Edit, L("EditActivitySourceType"));
            //activitySourceTypes.CreateChildPermission(AppPermissions.Pages_ActivitySourceTypes_Delete, L("DeleteActivitySourceType"));

            //var activityPriorities = pages.CreateChildPermission(AppPermissions.Pages_ActivityPriorities, L("ActivityPriorities"));
            //activityPriorities.CreateChildPermission(AppPermissions.Pages_ActivityPriorities_Create, L("CreateNewActivityPriority"));
            //activityPriorities.CreateChildPermission(AppPermissions.Pages_ActivityPriorities_Edit, L("EditActivityPriority"));
            //activityPriorities.CreateChildPermission(AppPermissions.Pages_ActivityPriorities_Delete, L("DeleteActivityPriority"));

            //var contacts = pages.CreateChildPermission(AppPermissions.Pages_Contacts, L("Contacts"));
            //contacts.CreateChildPermission(AppPermissions.Pages_Contacts_Create, L("CreateNewContact"));
            //contacts.CreateChildPermission(AppPermissions.Pages_Contacts_Edit, L("EditContact"));
            //contacts.CreateChildPermission(AppPermissions.Pages_Contacts_Delete, L("DeleteContact"));

            //var countries = pages.CreateChildPermission(AppPermissions.Pages_Countries, L("Countries"));
            //countries.CreateChildPermission(AppPermissions.Pages_Countries_Create, L("CreateNewCountry"));
            //countries.CreateChildPermission(AppPermissions.Pages_Countries_Edit, L("EditCountry"));
            //countries.CreateChildPermission(AppPermissions.Pages_Countries_Delete, L("DeleteCountry"));

            //var accountUsers = pages.CreateChildPermission(AppPermissions.Pages_AccountUsers, L("CustomerAssignUsers"));
            //accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Create, L("CreateNewAccountUser"));
            //accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Edit, L("EditAccountUser"));
            //accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Delete, L("DeleteAccountUser"));

            //var activityTaskTypes = pages.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes, L("ActivityTaskTypes"));
            //activityTaskTypes.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes_Create, L("CreateNewActivityTaskType"));
            //activityTaskTypes.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes_Edit, L("EditActivityTaskType"));
            //activityTaskTypes.CreateChildPermission(AppPermissions.Pages_ActivityTaskTypes_Delete, L("DeleteActivityTaskType"));

            var opportunities = pages.CreateChildPermission(AppPermissions.Pages_Opportunities, L("Opportunities"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_Create, L("CreateNewOpportunity"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_Edit, L("EditOpportunity"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_Delete, L("DeleteOpportunity"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_View_Events, L("OpportunityViewEvents"));
            opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_ViewAllOpportunities__Dynamic, L("OpportunityViewAllOpportunities__Dynamic"));
            opportunities.CreateChildPermission(AppPermissions.Pages_OpportunityUsers_AutomateAssignment__Dynamic, L("AutomateAssignmentUser"));

            var opportunitiesViewAttachments = opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_View_Attachments, L("ViewOpportunityAttachments"));
            opportunitiesViewAttachments.CreateChildPermission(AppPermissions.Pages_Opportunities_Add_Attachments, L("AddOpportunityAttachments"));
            opportunitiesViewAttachments.CreateChildPermission(AppPermissions.Pages_Opportunities_Edit_Attachments, L("EditOpportunityAttachments"));
            opportunitiesViewAttachments.CreateChildPermission(AppPermissions.Pages_Opportunities_Download_Attachments, L("DownloadOpportunityAttachments"));
            opportunitiesViewAttachments.CreateChildPermission(AppPermissions.Pages_Opportunities_Remove_Attachments, L("RemoveOpportunityAttachments"));

            var opportunitiesViewAttachmentsDynamic = opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_View_Attachments__Dynamic, L("ViewOpportunityAttachments__Dynamic"));
            opportunitiesViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_Add_Attachments__Dynamic, L("AddOpportunityAttachments"));
            opportunitiesViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_Edit_Attachments__Dynamic, L("EditOpportunityAttachments"));
            opportunitiesViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_Download_Attachments__Dynamic, L("DownloadOpportunityAttachments"));
            opportunitiesViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_Remove_Attachments__Dynamic, L("RemoveOpportunityAttachments"));

            opportunities.CreateChildPermission(AppPermissions.Pages_OpportunityUsers_View__Dynamic, L("OpportunityViewDynamicAssignUsers"));
            var opportunityUsers = opportunities.CreateChildPermission(AppPermissions.Pages_OpportunityUsers, L("OpportunityViewAssignUsers"));
            opportunityUsers.CreateChildPermission(AppPermissions.Pages_OpportunityUsers_Create, L("CreateNewOpportunityUser"));
            opportunityUsers.CreateChildPermission(AppPermissions.Pages_OpportunityUsers_Edit, L("EditOpportunityUser"));
            opportunityUsers.CreateChildPermission(AppPermissions.Pages_OpportunityUsers_Delete, L("DeleteOpportunityUser"));

            var opportunityActivities = opportunities.CreateChildPermission(AppPermissions.Pages_Opportunities_View_Activities, L("ViewActivities"));
            opportunityActivities.CreateChildPermission(AppPermissions.Pages_Opportunities_View_Activities_Of_All_Users, L(AppPermissions.Pages_Opportunities_View_Activities_Of_All_Users));
            opportunityActivities.CreateChildPermission(AppPermissions.Pages_Opportunities_Assign_Activity_To_Any_Users, L(AppPermissions.Pages_Opportunities_Assign_Activity_To_Any_Users));
            opportunityActivities.CreateChildPermission(AppPermissions.Pages_Opportunities_Edit_Activities, L("EditActivity"));
            opportunityActivities.CreateChildPermission(AppPermissions.Pages_Opportunities_Edit_Activities__Dynamic, L(AppPermissions.Pages_Opportunities_Edit_Activities__Dynamic));

            var opportunityCreateActivity = opportunityActivities.CreateChildPermission(AppPermissions.Pages_Opportunities_Create_Activities, L("CreateNewActivity"));
            opportunityCreateActivity.CreateChildPermission(AppPermissions.Pages_Opportunities_ScheduleMeeting, L("ScheduleMeeting"));
            opportunityCreateActivity.CreateChildPermission(AppPermissions.Pages_Opportunities_ScheduleCall, L("ScheduleCall"));
            opportunityCreateActivity.CreateChildPermission(AppPermissions.Pages_Opportunities_EmailReminder, L("EmailReminder"));
            opportunityCreateActivity.CreateChildPermission(AppPermissions.Pages_Opportunities_ToDoReminder, L("ToDoReminder"));

            var opportunityCreateActivityDynamic = opportunityActivities.CreateChildPermission(AppPermissions.Pages_Opportunities_Create_Activities__Dynamic, L(AppPermissions.Pages_Opportunities_Create_Activities__Dynamic));
            opportunityCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_ScheduleMeeting__Dynamic, L("ScheduleMeeting"));
            opportunityCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_ScheduleCall__Dynamic, L("ScheduleCall"));
            opportunityCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_EmailReminder__Dynamic, L("EmailReminder"));
            opportunityCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Opportunities_ToDoReminder__Dynamic, L("ToDoReminder"));

            //var opportunityTypes = pages.CreateChildPermission(AppPermissions.Pages_OpportunityTypes, L("OpportunityTypes"));
            //opportunityTypes.CreateChildPermission(AppPermissions.Pages_OpportunityTypes_Create, L("CreateNewOpportunityType"));
            //opportunityTypes.CreateChildPermission(AppPermissions.Pages_OpportunityTypes_Edit, L("EditOpportunityType"));
            //opportunityTypes.CreateChildPermission(AppPermissions.Pages_OpportunityTypes_Delete, L("DeleteOpportunityType"));

            #region Module Configuration

            //Permission configuration = context.GetPermissionOrNull(AppPermissions.Pages_Configuration) ?? context.CreatePermission(AppPermissions.Pages_Configuration, L("Configuration"));
            var configuration = pages.CreateChildPermission(AppPermissions.Pages_Configuration, L("Configuration"));

            Permission opportunityStages = configuration.CreateChildPermission(AppPermissions.Pages_OpportunityStages, L("OpportunityStages"));
            opportunityStages.CreateChildPermission(AppPermissions.Pages_OpportunityStages_Create, L("CreateNewOpportunityStage"));
            opportunityStages.CreateChildPermission(AppPermissions.Pages_OpportunityStages_Edit, L("EditOpportunityStage"));
            opportunityStages.CreateChildPermission(AppPermissions.Pages_OpportunityStages_Delete, L("DeleteOpportunityStage"));

            Permission leadStatuses = configuration.CreateChildPermission(AppPermissions.Pages_LeadStatuses, L("LeadStatuses"));
            leadStatuses.CreateChildPermission(AppPermissions.Pages_LeadStatuses_Create, L("CreateNewLeadStatus"));
            leadStatuses.CreateChildPermission(AppPermissions.Pages_LeadStatuses_Edit, L("EditLeadStatus"));
            leadStatuses.CreateChildPermission(AppPermissions.Pages_LeadStatuses_Delete, L("DeleteLeadStatus"));

            Permission leadSources = configuration.CreateChildPermission(AppPermissions.Pages_LeadSources, L("LeadSources"));
            leadSources.CreateChildPermission(AppPermissions.Pages_LeadSources_Create, L("CreateNewLeadSource"));
            leadSources.CreateChildPermission(AppPermissions.Pages_LeadSources_Edit, L("EditLeadSource"));
            leadSources.CreateChildPermission(AppPermissions.Pages_LeadSources_Delete, L("DeleteLeadSource"));

            Permission activityStatuses = configuration.CreateChildPermission(AppPermissions.Pages_ActivityStatuses, L("ActivityStatus"));
            activityStatuses.CreateChildPermission(AppPermissions.Pages_ActivityStatuses_Create, L("CreateNewActivityStatus"));
            activityStatuses.CreateChildPermission(AppPermissions.Pages_ActivityStatuses_Edit, L("EditActivityStatus"));
            activityStatuses.CreateChildPermission(AppPermissions.Pages_ActivityStatuses_Delete, L("DeleteActivityStatus"));

            #endregion Module Configuration

            //var leadUsers = pages.CreateChildPermission(AppPermissions.Pages_LeadUsers, L("LeadUsers"));
            //leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Create, L("CreateNewLeadUser"));
            //leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Edit, L("EditLeadUser"));
            //leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Delete, L("DeleteLeadUser"));

            //var priorities = pages.CreateChildPermission(AppPermissions.Pages_Priorities, L("Priorities"));
            //priorities.CreateChildPermission(AppPermissions.Pages_Priorities_Create, L("CreateNewPriority"));
            //priorities.CreateChildPermission(AppPermissions.Pages_Priorities_Edit, L("EditPriority"));
            //priorities.CreateChildPermission(AppPermissions.Pages_Priorities_Delete, L("DeletePriority"));

            var leads = pages.CreateChildPermission(AppPermissions.Pages_Leads, L("Leads"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Create, L("CreateNewLead"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Edit, L("EditLead"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Delete, L("DeleteLead"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_ViewAllLeads__Dynamic, L("LeadViewAllLeads__Dynamic"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_Convert_Account, L("LeadConvertToAccount"));
            leads.CreateChildPermission(AppPermissions.Pages_Leads_View_Events, L("LeadViewEvents"));
            leads.CreateChildPermission(AppPermissions.Pages_LeadUsers_AutomateAssignment__Dynamic, L("AutomateAssignmentUser"));

            var leadViewAttachments =  leads.CreateChildPermission(AppPermissions.Pages_Leads_View_Attachments, L("ViewLeadAttachments"));
            leadViewAttachments.CreateChildPermission(AppPermissions.Pages_Leads_Add_Attachments, L("AddLeadAttachments"));
            leadViewAttachments.CreateChildPermission(AppPermissions.Pages_Leads_Edit_Attachments, L("EditLeadAttachments"));
            leadViewAttachments.CreateChildPermission(AppPermissions.Pages_Leads_Download_Attachments, L("DownloadLeadAttachments"));
            leadViewAttachments.CreateChildPermission(AppPermissions.Pages_Leads_Remove_Attachments, L("RemoveLeadAttachments"));

            var leadViewAttachmentsDynamic = leads.CreateChildPermission(AppPermissions.Pages_Leads_View_Attachments__Dynamic, L("ViewLeadAttachments__Dynamic"));
            leadViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Leads_Add_Attachments__Dynamic, L("AddLeadAttachments"));
            leadViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Leads_Edit_Attachments__Dynamic, L("EditLeadAttachments"));
            leadViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Leads_Download_Attachments__Dynamic, L("DownloadLeadAttachments"));
            leadViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Leads_Remove_Attachments__Dynamic, L("RemoveLeadAttachments"));

            leads.CreateChildPermission(AppPermissions.Pages_LeadUsers_View__Dynamic, L("LeadViewDynamicAssignUsers"));
            var leadUsers = leads.CreateChildPermission(AppPermissions.Pages_LeadUsers, L("LeadViewAssignUsers"));
            leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Create, L("CreateNewLeadUser"));
            leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Edit, L("EditLeadUser"));
            leadUsers.CreateChildPermission(AppPermissions.Pages_LeadUsers_Delete, L("DeleteLeadUser"));

            var leadActivities = leads.CreateChildPermission(AppPermissions.Pages_Leads_View_Activities, L("ViewActivities"));
            leadActivities.CreateChildPermission(AppPermissions.Pages_Leads_View_Activities_Of_All_Users, L(AppPermissions.Pages_Leads_View_Activities_Of_All_Users));
            leadActivities.CreateChildPermission(AppPermissions.Pages_Leads_Assign_Activity_To_Any_Users, L(AppPermissions.Pages_Leads_Assign_Activity_To_Any_Users));
            leadActivities.CreateChildPermission(AppPermissions.Pages_Leads_Edit_Activities, L("EditActivity"));
            leadActivities.CreateChildPermission(AppPermissions.Pages_Leads_Edit_Activities__Dynamic, L(AppPermissions.Pages_Leads_Edit_Activities__Dynamic));

            var leadCreateActivities = leadActivities.CreateChildPermission(AppPermissions.Pages_Leads_Create_Activities, L("CreateNewActivity"));
            leadCreateActivities.CreateChildPermission(AppPermissions.Pages_Leads_ScheduleMeeting, L("ScheduleMeeting"));
            leadCreateActivities.CreateChildPermission(AppPermissions.Pages_Leads_ScheduleCall, L("ScheduleCall"));
            leadCreateActivities.CreateChildPermission(AppPermissions.Pages_Leads_EmailReminder, L("EmailReminder"));
            leadCreateActivities.CreateChildPermission(AppPermissions.Pages_Leads_ToDoReminder, L("ToDoReminder"));

            var leadCreateActivitiesDynamic = leadActivities.CreateChildPermission(AppPermissions.Pages_Leads_Create_Activities__Dynamic, L(AppPermissions.Pages_Leads_Create_Activities__Dynamic));
            leadCreateActivitiesDynamic.CreateChildPermission(AppPermissions.Pages_Leads_ScheduleMeeting__Dynamic, L("ScheduleMeeting"));
            leadCreateActivitiesDynamic.CreateChildPermission(AppPermissions.Pages_Leads_ScheduleCall__Dynamic, L("ScheduleCall"));
            leadCreateActivitiesDynamic.CreateChildPermission(AppPermissions.Pages_Leads_EmailReminder__Dynamic, L("EmailReminder"));
            leadCreateActivitiesDynamic.CreateChildPermission(AppPermissions.Pages_Leads_ToDoReminder__Dynamic, L("ToDoReminder"));

            //var industries = pages.CreateChildPermission(AppPermissions.Pages_Industries, L("Industries"));
            //industries.CreateChildPermission(AppPermissions.Pages_Industries_Create, L("CreateNewIndustry"));
            //industries.CreateChildPermission(AppPermissions.Pages_Industries_Edit, L("EditIndustry"));
            //industries.CreateChildPermission(AppPermissions.Pages_Industries_Delete, L("DeleteIndustry"));

            var customer = pages.CreateChildPermission(AppPermissions.Pages_Customer, L("Customer"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_Create, L("CreateNewCustomer"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_Edit, L("EditCustomer"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_Edit__Dynamic, L("CustomerEdit__Dynamic"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Invoices, L("CustomerViewInvoices"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Equipments, L("CustomerViewEquipments"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Wip, L("CustomerViewWip"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Events, L("CustomerViewEvents"));
            customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Events__Dynamic, L("CustomerViewEventsDynamic"));

            var customerViewAttachments = customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Attachments, L("ViewCustomerAttachments"));
            customerViewAttachments .CreateChildPermission(AppPermissions.Pages_Customer_Add_Attachments, L("AddCustomerAttachments"));
            customerViewAttachments .CreateChildPermission(AppPermissions.Pages_Customer_Edit_Attachments, L("EditCustomerAttachments"));
            customerViewAttachments .CreateChildPermission(AppPermissions.Pages_Customer_Download_Attachments, L("DownloadCustomerAttachments"));
            customerViewAttachments.CreateChildPermission(AppPermissions.Pages_Customer_Remove_Attachments, L("RemoveCustomerAttachments"));

            var customerViewAttachmentsDynamic = customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Attachments__Dynamic, L("ViewCustomerAttachments__Dynamic"));
            customerViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Customer_Add_Attachments__Dynamic, L("AddCustomerAttachments"));
            customerViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Customer_Edit_Attachments__Dynamic, L("EditCustomerAttachments"));
            customerViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Customer_Download_Attachments__Dynamic, L("DownloadCustomerAttachments"));
            customerViewAttachmentsDynamic.CreateChildPermission(AppPermissions.Pages_Customer_Remove_Attachments__Dynamic, L("RemoveCustomerAttachments"));

            var accountOpportunitiesDynamic = customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Opportunities__Dynamic, L("CustomerViewOpportunitiesDynamic"));
            accountOpportunitiesDynamic.CreateChildPermission(AppPermissions.Pages_Customer_Add_Opportunity__Dynamic, L("CustomerAddOpportunityDynamic"));
            accountOpportunitiesDynamic.CreateChildPermission(AppPermissions.Pages_Customer_Edit_Opportunity__Dynamic, L("CustomerEditOpportunityDynamic"));

            var accountOpportunities = customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Opportunities, L("CustomerViewOpportunities"));
            accountOpportunities.CreateChildPermission(AppPermissions.Pages_Customer_Add_Opportunity, L("CustomerAddOpportunity"));
            accountOpportunities.CreateChildPermission(AppPermissions.Pages_Customer_Edit_Opportunity, L("CustomerEditOpportunity"));

            customer.CreateChildPermission(AppPermissions.Pages_AccountUsers_View__Dynamic, L("CustomerViewDynamicAssignUsers"));
            customer.CreateChildPermission(AppPermissions.Pages_AccountUsers_AutomateAssignment__Dynamic, L("AutomateAssignmentUser"));

            var accountUsers = customer.CreateChildPermission(AppPermissions.Pages_AccountUsers, L("CustomerViewAssignUsers"));
            accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Create, L("CreateNewAccountUser"));
            accountUsers.CreateChildPermission(AppPermissions.Pages_AccountUsers_Delete, L("DeleteAccountUser"));

            var accountContact = customer.CreateChildPermission(AppPermissions.Pages_Contacts, L("CustomerViewAssignContacts"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Create, L("CreateNewAccountContact"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Edit, L("EditAccountContact"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Delete, L("DeleteAccountContact"));
            accountContact.CreateChildPermission(AppPermissions.Pages_Contacts_Delete__Dynamic, L("DeleteDynamicAccountContact"));

            var accountActivities = customer.CreateChildPermission(AppPermissions.Pages_Customer_View_Activities, L("ViewActivities"));
            accountActivities.CreateChildPermission(AppPermissions.Pages_Customer_View_Activities_Of_All_Users, L(AppPermissions.Pages_Customer_View_Activities_Of_All_Users));
            accountActivities.CreateChildPermission(AppPermissions.Pages_Customer_Assign_Activity_To_Any_Users, L(AppPermissions.Pages_Customer_Assign_Activity_To_Any_Users));
            accountActivities.CreateChildPermission(AppPermissions.Pages_Customer_Edit_Activities, L("EditActivity"));
            accountActivities.CreateChildPermission(AppPermissions.Pages_Customer_Edit_Activities__Dynamic, L(AppPermissions.Pages_Customer_Edit_Activities__Dynamic));

            var accountCreateActivity = accountActivities.CreateChildPermission(AppPermissions.Pages_Customer_Create_Activities, L("CreateNewActivity"));
            accountCreateActivity.CreateChildPermission(AppPermissions.Pages_Customer_ScheduleMeeting, L("CustomerScheduleMeeting"));
            accountCreateActivity.CreateChildPermission(AppPermissions.Pages_Customer_ScheduleCall, L("CustomerScheduleCall"));
            accountCreateActivity.CreateChildPermission(AppPermissions.Pages_Customer_EmailReminder, L("CustomerEmailReminder"));
            accountCreateActivity.CreateChildPermission(AppPermissions.Pages_Customer_ToDoReminder, L("CustomerToDoReminder"));

            var accountCreateActivityDynamic = accountActivities.CreateChildPermission(AppPermissions.Pages_Customer_Create_Activities__Dynamic, L(AppPermissions.Pages_Customer_Create_Activities__Dynamic));
            accountCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Customer_ScheduleMeeting__Dynamic, L("CustomerScheduleMeeting"));
            accountCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Customer_ScheduleCall__Dynamic, L("CustomerScheduleCall"));
            accountCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Customer_EmailReminder__Dynamic, L("CustomerEmailReminder"));
            accountCreateActivityDynamic.CreateChildPermission(AppPermissions.Pages_Customer_ToDoReminder__Dynamic, L("CustomerToDoReminder"));

            //var accountTypes = pages.CreateChildPermission(AppPermissions.Pages_AccountTypes, L("AccountTypes"));
            //accountTypes.CreateChildPermission(AppPermissions.Pages_AccountTypes_Create, L("CreateNewAccountType"));
            //accountTypes.CreateChildPermission(AppPermissions.Pages_AccountTypes_Edit, L("EditAccountType"));
            //accountTypes.CreateChildPermission(AppPermissions.Pages_AccountTypes_Delete, L("DeleteAccountType"));
            //var arTerms = pages.CreateChildPermission(AppPermissions.Pages_ARTerms, L("ARTerms"));
            //arTerms.CreateChildPermission(AppPermissions.Pages_ARTerms_Create, L("CreateNewARTerms"));
            //arTerms.CreateChildPermission(AppPermissions.Pages_ARTerms_Edit, L("EditARTerms"));
            //arTerms.CreateChildPermission(AppPermissions.Pages_ARTerms_Delete, L("DeleteARTerms"));

            //var zipCodes = pages.CreateChildPermission(AppPermissions.Pages_ZipCodes, L("ZipCodes"));
            //zipCodes.CreateChildPermission(AppPermissions.Pages_ZipCodes_Create, L("CreateNewZipCode"));
            //zipCodes.CreateChildPermission(AppPermissions.Pages_ZipCodes_Edit, L("EditZipCode"));
            //zipCodes.CreateChildPermission(AppPermissions.Pages_ZipCodes_Delete, L("DeleteZipCode"));

            //pages.CreateChildPermission(AppPermissions.Pages_DemoUiComponents, L("DemoUiComponents"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));
            var usersManagement = pages.CreateChildPermission(AppPermissions.Pages_UsersManagement, L("UsersManagement"));

            var roles = usersManagement.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = usersManagement.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            //users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            //users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            //users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            //users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));
            //users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Unlock, L("Unlock"));

            //var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            //languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            //languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            //languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            //languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));
            //languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeDefaultLanguage, L("ChangeDefaultLanguage"));

            //administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            //var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            //organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            //organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));
            //organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageRoles, L("ManagingRoles"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_UiCustomization, L("VisualSettings"));

            //var webhooks = administration.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription, L("Webhooks"));
            //webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Create, L("CreatingWebhooks"));
            //webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Edit, L("EditingWebhooks"));
            //webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_ChangeActivity, L("ChangingWebhookActivity"));
            //webhooks.CreateChildPermission(AppPermissions.Pages_Administration_WebhookSubscription_Detail, L("DetailingSubscription"));
            //webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ListSendAttempts, L("ListingSendAttempts"));
            //webhooks.CreateChildPermission(AppPermissions.Pages_Administration_Webhook_ResendWebhook, L("ResendingWebhook"));

            //var dynamicProperties = administration.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties, L("DynamicProperties"));
            //dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Create, L("CreatingDynamicProperties"));
            //dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Edit, L("EditingDynamicProperties"));
            //dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicProperties_Delete, L("DeletingDynamicProperties"));

            //var dynamicPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue, L("DynamicPropertyValue"));
            //dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Create, L("CreatingDynamicPropertyValue"));
            //dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Edit, L("EditingDynamicPropertyValue"));
            //dynamicPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicPropertyValue_Delete, L("DeletingDynamicPropertyValue"));

            //var dynamicEntityProperties = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties, L("DynamicEntityProperties"));
            //dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Create, L("CreatingDynamicEntityProperties"));
            //dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Edit, L("EditingDynamicEntityProperties"));
            //dynamicEntityProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityProperties_Delete, L("DeletingDynamicEntityProperties"));

            //var dynamicEntityPropertyValues = dynamicProperties.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue, L("EntityDynamicPropertyValue"));
            //dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Create, L("CreatingDynamicEntityPropertyValue"));
            //dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Edit, L("EditingDynamicEntityPropertyValue"));
            //dynamicEntityPropertyValues.CreateChildPermission(AppPermissions.Pages_Administration_DynamicEntityPropertyValue_Delete, L("DeletingDynamicEntityPropertyValue"));

            pages.CreateChildPermission(AppPermissions.Pages_GlobalSearch, L("GlobalSearch"));

            var dashboard = pages.CreateChildPermission(AppPermissions.Pages_Dashboard, L("Dashboard"));
            dashboard.CreateChildPermission(AppPermissions.Pages_Dashboard_KPI_Widget, L("DashboardKPIWidget"));
            //TENANT-SPECIFIC PERMISSIONS

            //pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Tenant Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

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
            //administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SBCRMConsts.LocalizationSourceName);
        }
    }
}