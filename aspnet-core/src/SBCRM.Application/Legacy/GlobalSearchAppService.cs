using SBCRM.Authorization.Users;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SBCRM.Crm.Exporting;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using Abp.Application.Services.Dto;
using SBCRM.Authorization;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using SBCRM.Legacy;
using SBCRM.Legacy.Dtos;
using Abp.Extensions;
namespace SBCRM.Legacy
{
    public class GlobalSearchAppService: SBCRMAppServiceBase, IGlobalSearchAppService
    {
        private readonly IRepository<Customer, int> _customerRepository;

        public GlobalSearchAppService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ListResultDto<GetGlobalSearchDto>> GetAll(GetGlobalSearchInput input)
        {
            try
            {
                var filteredCustomer = _customerRepository.GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                p => p.Name.Contains(input.Filter)
            )
            .OrderBy(p => p.Name)
            .ToList();

                return new ListResultDto<GetGlobalSearchDto>(ObjectMapper.Map<List<GetGlobalSearchDto>>(filteredCustomer));
            }
            catch (Exception e)
            {
                Logger.Error("Error in CustomerAppService -> ", e);
                throw;
            }
        }
    }
}
