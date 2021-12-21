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
using Microsoft.EntityFrameworkCore;

namespace SBCRM.Legacy
{
    /// <summary>
    /// App service to handle Contacts information
    /// </summary>
    [AbpAuthorize(AppPermissions.Pages_Contacts)]
    public class ContactsAppService : SBCRMAppServiceBase, IContactsAppService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactsAppService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;

        }

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<GetContactForViewDto>> GetAll(GetAllContactsInput input)
        {

            var filteredContacts = _contactRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CustomerNo.Contains(input.Filter) || e.ContactField.Contains(input.Filter) || e.Parent.Contains(input.Filter) || e.Position.Contains(input.Filter) || e.Phone.Contains(input.Filter) || e.Extention.Contains(input.Filter) || e.Fax.Contains(input.Filter) || e.Pager.Contains(input.Filter) || e.Cellular.Contains(input.Filter) || e.EMail.Contains(input.Filter) || e.wwwHomePage.Contains(input.Filter) || e.Comments.Contains(input.Filter) || e.AddedBy.Contains(input.Filter) || e.ChangedBy.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerNoFilter), e => e.CustomerNo == input.CustomerNoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ContactFilter), e => e.ContactField == input.ContactFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ParentFilter), e => e.Parent == input.ParentFilter)
                        .WhereIf(input.MinIndexPointerFilter != null, e => e.IndexPointer >= input.MinIndexPointerFilter)
                        .WhereIf(input.MaxIndexPointerFilter != null, e => e.IndexPointer <= input.MaxIndexPointerFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PositionFilter), e => e.Position == input.PositionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter), e => e.Phone == input.PhoneFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtentionFilter), e => e.Extention == input.ExtentionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FaxFilter), e => e.Fax == input.FaxFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.PagerFilter), e => e.Pager == input.PagerFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CellularFilter), e => e.Cellular == input.CellularFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EMailFilter), e => e.EMail == input.EMailFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.wwwHomePageFilter), e => e.wwwHomePage == input.wwwHomePageFilter)
                        .WhereIf(input.MinSalesGroup1Filter != null, e => e.SalesGroup1 >= input.MinSalesGroup1Filter)
                        .WhereIf(input.MaxSalesGroup1Filter != null, e => e.SalesGroup1 <= input.MaxSalesGroup1Filter)
                        .WhereIf(input.MinSalesGroup2Filter != null, e => e.SalesGroup2 >= input.MinSalesGroup2Filter)
                        .WhereIf(input.MaxSalesGroup2Filter != null, e => e.SalesGroup2 <= input.MaxSalesGroup2Filter)
                        .WhereIf(input.MinSalesGroup3Filter != null, e => e.SalesGroup3 >= input.MinSalesGroup3Filter)
                        .WhereIf(input.MaxSalesGroup3Filter != null, e => e.SalesGroup3 <= input.MaxSalesGroup3Filter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CommentsFilter), e => e.Comments == input.CommentsFilter)
                        .WhereIf(input.MinDateAddedFilter != null, e => e.DateAdded >= input.MinDateAddedFilter)
                        .WhereIf(input.MaxDateAddedFilter != null, e => e.DateAdded <= input.MaxDateAddedFilter)
                        .WhereIf(input.MinDateChangedFilter != null, e => e.DateChanged >= input.MinDateChangedFilter)
                        .WhereIf(input.MaxDateChangedFilter != null, e => e.DateChanged <= input.MaxDateChangedFilter)
                        .WhereIf(input.MinSalesGroup4Filter != null, e => e.SalesGroup4 >= input.MinSalesGroup4Filter)
                        .WhereIf(input.MaxSalesGroup4Filter != null, e => e.SalesGroup4 <= input.MaxSalesGroup4Filter)
                        .WhereIf(input.MinSalesGroup5Filter != null, e => e.SalesGroup5 >= input.MinSalesGroup5Filter)
                        .WhereIf(input.MaxSalesGroup5Filter != null, e => e.SalesGroup5 <= input.MaxSalesGroup5Filter)
                        .WhereIf(input.MinSalesGroup6Filter != null, e => e.SalesGroup6 >= input.MinSalesGroup6Filter)
                        .WhereIf(input.MaxSalesGroup6Filter != null, e => e.SalesGroup6 <= input.MaxSalesGroup6Filter)
                        .WhereIf(input.MinMailingListFilter != null, e => e.MailingList >= input.MinMailingListFilter)
                        .WhereIf(input.MaxMailingListFilter != null, e => e.MailingList <= input.MaxMailingListFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AddedByFilter), e => e.AddedBy == input.AddedByFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ChangedByFilter), e => e.ChangedBy == input.ChangedByFilter)
                        .WhereIf(input.MinIDFilter != null, e => e.Id >= input.MinIDFilter)
                        .WhereIf(input.MaxIDFilter != null, e => e.Id <= input.MaxIDFilter);

            var pagedAndFilteredContacts = filteredContacts
                .OrderBy(input.Sorting ?? "id asc")
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
                               Id = o.Id
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
                        Id = o.Id,
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
            var contact = await _contactRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetContactForEditOutput { Contact = ObjectMapper.Map<CreateOrEditContactDto>(contact) };

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
            await _contactRepository.InsertAsync(contact);
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts_Edit)]
        protected virtual async Task Update(CreateOrEditContactDto input)
        {
            var contact = await _contactRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, contact);

        }

        /// <summary>
        /// Delete contact
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Contacts_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _contactRepository.DeleteAsync(input.Id);
        }

    }
}