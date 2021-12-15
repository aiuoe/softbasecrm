﻿using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm
{
    public interface IAccountUsersAppService : IApplicationService
    {
        Task<PagedResultDto<GetAccountUserForViewDto>> GetAll(GetAllAccountUsersInput input);

        Task<GetAccountUserForViewDto> GetAccountUserForView(int id);

        Task<GetAccountUserForEditOutput> GetAccountUserForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditAccountUserDto input);

        Task Delete(EntityDto input);

        Task<List<AccountUserUserLookupTableDto>> GetAllUserForTableDropdown();

        Task CreateMultipleAccountUsers(List<CreateOrEditAccountUserDto> input);

    }
}