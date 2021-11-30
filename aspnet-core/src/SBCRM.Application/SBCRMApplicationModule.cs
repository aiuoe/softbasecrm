﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SBCRM.Authorization;

namespace SBCRM
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(SBCRMApplicationSharedModule),
        typeof(SBCRMCoreModule)
        )]
    public class SBCRMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SBCRMApplicationModule).GetAssembly());
        }
    }
}