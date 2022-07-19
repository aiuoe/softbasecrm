using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Common;
using SBCRM.Dto;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Queries
{
    /// <summary>
    /// Get branch by Id query
    /// </summary>
    public class GetAllPagedBranchQuery: PagedAndSortedInputDto, IShouldNormalize,  IRequest<PagedResultDto<BranchListItemDto>>
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Number";
            }

            Sorting = DtoSortingHelper.ReplaceSorting(Sorting, s =>
            {
                return s.Replace("editionDisplayName", "Edition.DisplayName");
            });
        }
    }
}
