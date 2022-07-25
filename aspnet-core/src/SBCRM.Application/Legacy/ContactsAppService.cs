using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Legacy.Dtos;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Abp.Domain.Uow;
using Abp.EntityHistory;
using Abp.Timing;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SBCRM.Auditing;
using SBCRM.Auditing.Dto;
using SBCRM.Common;
using SBCRM.Crm;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Customer-Contacts information
    /// </summary>
    public class ContactsAppService : SBCRMAppServiceBase, IContactsAppService
    {
        private readonly IRepository<AccountUser> _accountUserRepository;
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IEntityChangeSetReasonProvider _reasonProvider;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IAuditEventsService _auditEventsService;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="contactRepository"></param>
        /// <param name="customerRepository"></param>
        /// <param name="reasonProvider"></param>
        /// <param name="unitOfWorkManager"></param>
        /// <param name="auditEventsService"></param>
        /// <param name="accountUserRepository"></param>
        public ContactsAppService(
            IRepository<Contact> contactRepository,
            IRepository<Customer> customerRepository,
            IEntityChangeSetReasonProvider reasonProvider,
            IUnitOfWorkManager unitOfWorkManager,
            IAuditEventsService auditEventsService,
            IRepository<AccountUser> accountUserRepository)
        {
            _contactRepository = contactRepository;
            _customerRepository = customerRepository;
            _reasonProvider = reasonProvider;
            _unitOfWorkManager = unitOfWorkManager;
            _auditEventsService = auditEventsService;
            _accountUserRepository = accountUserRepository;
        }

        /// <summary>
        /// Method to get permission to DELETE Contact in Accounts
        /// The user can see the widget if meet these 2 conditions:
        /// 1. The current user has <see cref="AppPermissions.Pages_Contacts_Delete"/>  permission, oriented for Managers
        /// 2. The current user has <see cref="AppPermissions.Pages_Contacts_Delete__Dynamic"/> permission and is assigned in the Account/Customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> GetCanDeleteContact(string customerNumber)
        {
            var currentUser = await GetCurrentUserAsync();
            var hasDynamicPermission =
                await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Contacts_Delete__Dynamic);
            var hasStaticPermission = await UserManager.IsGrantedAsync(currentUser.Id, AppPermissions.Pages_Contacts_Delete);

            var currentUserIsAssignedInCustomer = _accountUserRepository
                .GetAll()
                .Where(x => x.CustomerNumber == customerNumber)
                .Any(x => x.UserId == currentUser.Id);

            var canDeleteContactDynamic = hasDynamicPermission && currentUserIsAssignedInCustomer;
            return canDeleteContactDynamic || hasStaticPermission;
        }


        /// <summary>
        /// Get all contacts types without paging
        /// </summary>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts)]
        public async Task<List<GetContactForViewDto>> GetAllWithoutPaging(GetAllNoPagedContactsInput input)
        {
            var defaultInput = new GetAllContactsInput
            {
                SkipCount = 0,
                MaxResultCount = int.MaxValue,
                CustomerNumber = input.CustomerNumber
            };
            var pagedResultDto = await GetAll(defaultInput);
            return pagedResultDto.Items.ToList();
        }

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts)]
        public async Task<PagedResultDto<GetContactForViewDto>> GetAll(GetAllContactsInput input)
        {
            var filteredContacts = from contact in _contactRepository.GetAll()
                join customer in _customerRepository.GetAll() on contact.CustomerNo equals customer.Number
                select contact;

            filteredContacts = filteredContacts.WhereIf(
                !string.IsNullOrEmpty(input.CustomerNumber), x => x.CustomerNo == input.CustomerNumber);

            var pagedAndFilteredContacts = filteredContacts
                .OrderBy(input.Sorting ?? $"{nameof(Contact.ContactField)} asc")
                .PageBy(input);

            var contacts = from o in pagedAndFilteredContacts
                select new
                {
                    o.CustomerNo,
                    o.ContactField,
                    o.Parent,
                    o.IndexPointer,
                    o.Position,
                    o.Phone,
                    o.Extention,
                    o.Fax,
                    o.Pager,
                    o.Cellular,
                    o.EMail,
                    o.wwwHomePage,
                    o.SalesGroup1,
                    o.SalesGroup2,
                    o.SalesGroup3,
                    o.Comments,
                    o.DateAdded,
                    o.DateChanged,
                    o.SalesGroup4,
                    o.SalesGroup5,
                    o.SalesGroup6,
                    o.MailingList,
                    o.AddedBy,
                    o.ChangedBy,
                    o.ContactId,
                };

            var totalCount = await filteredContacts.CountAsync();

            var dbList = await contacts.ToListAsync();
            var results = new List<GetContactForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetContactForViewDto()
                {
                    Contact = new ContactDto
                    {
                        CustomerNo = o.CustomerNo,
                        Contact = o.ContactField,
                        Parent = o.Parent,
                        IndexPointer = o.IndexPointer,
                        Position = o.Position,
                        Phone = o.Phone,
                        Extention = o.Extention,
                        Fax = o.Fax,
                        Pager = o.Pager,
                        Cellular = o.Cellular,
                        EMail = o.EMail,
                        wwwHomePage = o.wwwHomePage,
                        SalesGroup1 = o.SalesGroup1,
                        SalesGroup2 = o.SalesGroup2,
                        SalesGroup3 = o.SalesGroup3,
                        Comments = o.Comments,
                        DateAdded = o.DateAdded,
                        DateChanged = o.DateChanged,
                        SalesGroup4 = o.SalesGroup4,
                        SalesGroup5 = o.SalesGroup5,
                        SalesGroup6 = o.SalesGroup6,
                        MailingList = o.MailingList,
                        AddedBy = o.AddedBy,
                        ChangedBy = o.ChangedBy,
                        Id = o.ContactId
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetContactForViewDto>(
                totalCount,
                results
            );
        }

        /// <summary>
        /// Get contact for edition mode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts_Edit)]
        public async Task<GetContactForEditOutput> GetContactForEdit(EntityDto input)
        {
            var contact = await _contactRepository.FirstOrDefaultAsync(x => x.ContactId == input.Id);
            var output = new GetContactForEditOutput {Contact = ObjectMapper.Map<CreateOrEditContactDto>(contact)};
            return output;
        }

        /// <summary>
        /// Create or edit contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditContactDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        /// <summary>
        /// Create contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts_Create)]
        protected virtual async Task Create(CreateOrEditContactDto input)
        {
            var contact = ObjectMapper.Map<Contact>(input);
            var currentUser = await GetCurrentUserAsync();

            await ValidateUniqueContactName(input);

            using (_reasonProvider.Use("Contact created"))
            {
                // Set legacy audit fields
                contact.AddedBy = currentUser.Name;
                contact.DateAdded = Clock.Now;

                await _contactRepository.InsertAsync(contact);
                await _unitOfWorkManager.Current.SaveChangesAsync();
            }

            await _auditEventsService.AddEvent(AuditEventDto.ForCreate(
                entityType: typeof(Customer),
                entityId: input.CustomerNo,
                message: $"Added contact, {contact.ContactField}")
            );
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts_Edit)]
        protected virtual async Task Update(CreateOrEditContactDto input)
        {
            var contact = await _contactRepository.FirstOrDefaultAsync(x => x.ContactId == input.Id);
            var currentUser = await GetCurrentUserAsync();

            await ValidateUniqueContactName(input);

            using (_reasonProvider.Use("Contact updated"))
            {
                // Set legacy audit fields
                contact.ChangedBy = currentUser.Name;
                contact.DateChanged = Clock.Now;

                ObjectMapper.Map(input, contact);
                await _unitOfWorkManager.Current.SaveChangesAsync();

                await _auditEventsService.AddEvent(AuditEventDto.ForUpdate(
                    entityType: typeof(Customer),
                    entityId: input.CustomerNo,
                    message: $"Updated contact, {contact.ContactField}")
                );
            }
        }

        /// <summary>
        /// Validate unique contact name by Account/Customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        private async Task ValidateUniqueContactName(CreateOrEditContactDto input)
        {
            var contactSameName = await _contactRepository.GetAll()
                .Where(x => !string.IsNullOrEmpty(x.ContactField))
                .Where(x => input.Contact.ToLower().Trim() == x.ContactField.ToLower().Trim())
                .Where(x => x.CustomerNo == input.CustomerNo && x.ContactId != input.Id)
                .ToListAsync();

            if (contactSameName.Any())
            {
                throw new UserFriendlyException(L("ContactNameAlreadyExist"));
            }
        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(
            permissions: new[]
            {
                AppPermissions.Pages_Contacts_Delete,
                AppPermissions.Pages_Contacts_Delete__Dynamic
            },
            RequireAllPermissions = false
        )]
        public async Task Delete(EntityDto input)
        {
            var contact = await _contactRepository.FirstOrDefaultAsync(x => x.ContactId == input.Id);
            GuardHelper.ThrowIf(!(await GetCanDeleteContact(contact.CustomerNo)), new AbpAuthorizationException());
            await _contactRepository.DeleteAsync(contact);
            await _auditEventsService.AddEvent(AuditEventDto.ForUpdate(
                entityType: typeof(Customer),
                entityId: contact.CustomerNo,
                message: $"Deleted contact, {contact.ContactField}")
            );
        }
    }
}