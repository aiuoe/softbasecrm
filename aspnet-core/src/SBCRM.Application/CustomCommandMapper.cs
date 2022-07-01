using AutoMapper;
using Branch = SBCRM.Core.BaseEntities.Branch;
using SBCRM.Modules.Administration.Branch.Commands;

namespace SBCRM
{
    internal static class CustomCommandMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            #region [Branch mappings]

            configuration.CreateMap<CreateBranchCommand, Branch>();
            configuration.CreateMap<UpdateBranchCommand, Branch>();

            #endregion
        }
    }
}
