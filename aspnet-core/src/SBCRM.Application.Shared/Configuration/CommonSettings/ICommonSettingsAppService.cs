using Abp.Application.Services;
using SBCRM.Configuration.CommonSettings.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Configuration.CommonSettings
{
    public interface ICommonSettingsAppService : IApplicationService
    {
        Task UpdateTenentLevelSettings(UpdateCommonSettingsInput input);
        Task UpdateUserLevelSettings(UpdateCommonSettingsInput input);
    }
}
