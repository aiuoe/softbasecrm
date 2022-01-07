using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Crm;
using SBCRM.Legacy.Dtos;
using SBCRM.Legacy;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityProperties;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using AutoMapper;
using IdentityServer4.Extensions;
using SBCRM.Auditing.Dto;
using SBCRM.Authorization.Accounts.Dto;
using SBCRM.Authorization.Delegation;
using SBCRM.Authorization.Permissions.Dto;
using SBCRM.Authorization.Roles;
using SBCRM.Authorization.Roles.Dto;
using SBCRM.Authorization.Users;
using SBCRM.Authorization.Users.Delegation.Dto;
using SBCRM.Authorization.Users.Dto;
using SBCRM.Authorization.Users.Importing.Dto;
using SBCRM.Authorization.Users.Profile.Dto;
using SBCRM.Chat;
using SBCRM.Chat.Dto;
using SBCRM.DynamicEntityProperties.Dto;
using SBCRM.Editions;
using SBCRM.Editions.Dto;
using SBCRM.Friendships;
using SBCRM.Friendships.Cache;
using SBCRM.Friendships.Dto;
using SBCRM.Localization.Dto;
using SBCRM.MultiTenancy;
using SBCRM.MultiTenancy.Dto;
using SBCRM.MultiTenancy.HostDashboard.Dto;
using SBCRM.MultiTenancy.Payments;
using SBCRM.MultiTenancy.Payments.Dto;
using SBCRM.Notifications.Dto;
using SBCRM.Organizations.Dto;
using SBCRM.Sessions.Dto;
using SBCRM.WebHooks.Dto;

namespace SBCRM
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<OpportunityStageDto, OpportunityStage>().ReverseMap();
            configuration.CreateMap<CreateOrEditOpportunityUserDto, OpportunityUser>().ReverseMap();
            configuration.CreateMap<OpportunityUserDto, OpportunityUser>().ReverseMap();
            configuration.CreateMap<CreateOrEditActivityDto, Activity>().ReverseMap();
            configuration.CreateMap<ActivityDto, Activity>().ReverseMap();
            configuration.CreateMap<CreateOrEditActivitySourceTypeDto, ActivitySourceType>().ReverseMap();
            configuration.CreateMap<ActivitySourceTypeDto, ActivitySourceType>().ReverseMap();
            configuration.CreateMap<CreateOrEditActivityPriorityDto, ActivityPriority>().ReverseMap();
            configuration.CreateMap<ActivityPriorityDto, ActivityPriority>().ReverseMap();
            configuration.CreateMap<CreateOrEditContactDto, Contact>().ReverseMap();
            configuration.CreateMap<ContactDto, Contact>().ReverseMap();
            configuration.CreateMap<CreateOrEditAccountUserDto, AccountUser>().ReverseMap();
            configuration.CreateMap<AccountUserDto, AccountUser>().ReverseMap();
            configuration.CreateMap<CreateOrEditCountryDto, Country>().ReverseMap();
            configuration.CreateMap<CountryDto, Country>().ReverseMap();
            configuration.CreateMap<SecureDto, Secure>().ReverseMap();
            configuration.CreateMap<CreateOrEditActivityStatusDto, ActivityStatus>().ReverseMap();
            configuration.CreateMap<ActivityStatusDto, ActivityStatus>().ReverseMap();
            configuration.CreateMap<CreateOrEditActivityTaskTypeDto, ActivityTaskType>().ReverseMap();
            configuration.CreateMap<ActivityTaskTypeDto, ActivityTaskType>().ReverseMap();
            configuration.CreateMap<CreateOrEditOpportunityDto, Opportunity>().ReverseMap();
            configuration.CreateMap<OpportunityDto, Opportunity>().ReverseMap();
            configuration.CreateMap<CreateOrEditOpportunityTypeDto, OpportunityType>().ReverseMap();
            configuration.CreateMap<OpportunityTypeDto, OpportunityType>().ReverseMap();

            //OpportunityStages
            configuration.CreateMap<CreateOrEditOpportunityStageDto, OpportunityStage>().ReverseMap();
            configuration.CreateMap<List<UpdateOrderOpportunityStageDto>, List<OpportunityStage>>().ReverseMap();

            //Lead Sources
            configuration.CreateMap<CreateOrEditLeadSourceDto, LeadSource>().ReverseMap();
            configuration.CreateMap<LeadSourceDto, LeadSource>().ReverseMap();
            configuration.CreateMap<List<UpdateOrderleadSourceDto>, List<LeadSource>>().ReverseMap();

            configuration.CreateMap<CreateOrEditLeadUserDto, LeadUser>().ReverseMap();
            configuration.CreateMap<LeadUserDto, LeadUser>().ReverseMap();
            configuration.CreateMap<CreateOrEditPriorityDto, Priority>().ReverseMap();
            configuration.CreateMap<PriorityDto, Priority>().ReverseMap();
            configuration.CreateMap<CreateOrEditLeadDto, Lead>().ReverseMap();
            configuration.CreateMap<LeadDto, Lead>().ReverseMap();
            configuration.CreateMap<CreateOrEditLeadStatusDto, LeadStatus>().ReverseMap();
            configuration.CreateMap<LeadStatusDto, LeadStatus>().ReverseMap();
            configuration.CreateMap<CreateOrEditIndustryDto, Industry>().ReverseMap();
            configuration.CreateMap<IndustryDto, Industry>().ReverseMap();
            configuration.CreateMap<CreateOrEditCustomerDto, Customer>().ReverseMap();
            configuration.CreateMap<CustomerDto, Customer>().ReverseMap();
            configuration.CreateMap<CreateOrEditAccountTypeDto, AccountType>().ReverseMap();
            configuration.CreateMap<AccountTypeDto, AccountType>().ReverseMap();
            configuration.CreateMap<CreateOrEditARTermsDto, ARTerms>().ReverseMap();
            configuration.CreateMap<ARTermsDto, ARTerms>().ReverseMap();
            configuration.CreateMap<CreateOrEditZipCodeDto, ZipCode>().ReverseMap();
            configuration.CreateMap<ZipCodeDto, ZipCode>().ReverseMap();
            //Inputs
            configuration.CreateMap<GetCrmEntityTypeChangeInput, GetEntityTypeChangeInput>().ReverseMap();
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Chat
            configuration.CreateMap<ChatMessage, ChatMessageDto>();
            configuration.CreateMap<ChatMessage, ChatMessageExportDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionCreateDto, SubscribableEdition>();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<SubscribableEdition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();

            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserAssignedDto>();
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<Role, OrganizationUnitRoleListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
            configuration.CreateMap<ImportUserDto, User>();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();
            configuration.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            //Friendship
            configuration.CreateMap<Friendship, FriendDto>();
            configuration.CreateMap<FriendCacheItem, FriendDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();

            //Webhooks
            configuration.CreateMap<WebhookSubscription, GetAllSubscriptionsOutput>();
            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOutput>()
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.WebhookName,
                    options => options.MapFrom(l => l.WebhookEvent.WebhookName))
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.Data,
                    options => options.MapFrom(l => l.WebhookEvent.Data));

            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOfWebhookEventOutput>();

            configuration.CreateMap<DynamicProperty, DynamicPropertyDto>().ReverseMap();
            configuration.CreateMap<DynamicPropertyValue, DynamicPropertyValueDto>().ReverseMap();
            configuration.CreateMap<DynamicEntityProperty, DynamicEntityPropertyDto>()
                .ForMember(dto => dto.DynamicPropertyName,
                    options => options.MapFrom(entity => entity.DynamicProperty.DisplayName.IsNullOrEmpty() ? entity.DynamicProperty.PropertyName : entity.DynamicProperty.DisplayName));
            configuration.CreateMap<DynamicEntityPropertyDto, DynamicEntityProperty>();

            configuration.CreateMap<DynamicEntityPropertyValue, DynamicEntityPropertyValueDto>().ReverseMap();

            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */

            configuration.CreateMap<User, AccountUserViewDto>()
                .ForMember(dto => dto.UserId, options => options.MapFrom(e => e.Id))
                .ForMember(dto => dto.SurName, options => options.MapFrom(e => e.Surname))
                .ForMember(dto => dto.SurName, options => options.MapFrom(e => e.Surname))
                ;

            configuration.CreateMap<CreateOrEditContactDto, Contact>()
                .ForMember(dto => dto.ContactField, options => options.MapFrom(e => e.Contact))
                .ReverseMap();

            configuration.CreateMap<Contact, CreateOrEditContactDto>()
                .ForMember(dto => dto.Id, options => options.MapFrom(e => e.ContactId))
                .ForMember(dto => dto.Contact, options => options.MapFrom(e => e.ContactField))
                .ReverseMap();

            configuration.CreateMap<GetCustomerForEditOutput, GetCustomerForViewOutput>()
                .ReverseMap();

            configuration.CreateMap<User, Person>()
                .ForMember(u => u.FirstName, opt => opt.MapFrom(u => u.Name))
                .ForMember(u => u.LastName, opt => opt.MapFrom(u => u.Surname))
                .ForMember(u => u.Phone, opt => opt.MapFrom(u => u.PhoneNumber))
                .ReverseMap();
        }
    }
}