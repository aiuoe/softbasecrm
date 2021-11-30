using System.Collections.Generic;
using Abp.Application.Services.Dto;
using SBCRM.Editions.Dto;

namespace SBCRM.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}