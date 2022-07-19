using AutoMapper;
using Branch = SBCRM.Core.BaseEntities.Branch;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM
{
    internal static class CustomCommandMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            #region [Branch mappings]

            configuration.CreateMap<UpsertBranchDto, CreateBranchCommand>();
                configuration.CreateMap<UpsertBranchDto, UpdateBranchCommand>();

            configuration.CreateMap<CreateBranchCommand, Branch>()
                .ForMember(dto => dto.TvhCountry, opt => opt.MapFrom(a => a.TvhCountryId))
                .ForMember(dto => dto.TvhWarehouse, opt => opt.MapFrom(a => a.TvhWarehouseId));

            configuration.CreateMap<UpdateBranchCommand, Branch>()
                .ForMember(dto => dto.TvhCountry, opt => opt.MapFrom(a => a.TvhCountryId))
                .ForMember(dto => dto.TvhWarehouse, opt => opt.MapFrom(a => a.TvhWarehouseId));

            #endregion
        }
    }
}
