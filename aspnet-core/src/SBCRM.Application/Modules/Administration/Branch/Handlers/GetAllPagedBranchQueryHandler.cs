using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Linq.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Dtos;
using SBCRM.Modules.Administration.Branch.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Get branch data by id query handler
    /// </summary>
    public class GetAllPagedBranchQueryHandler : UseCaseServiceBase, IRequestHandler<GetAllPagedBranchQuery, PagedResultDto<BranchListItemDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IBranchARCurrencyTypeRepository _branchARCurrencyTypeRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        /// <param name="branchARCurrencyTypeRepository"></param>
        public GetAllPagedBranchQueryHandler(
            IBranchRepository branchRepository,
            IBranchARCurrencyTypeRepository branchARCurrencyTypeRepository)
        {
            _branchRepository = branchRepository;
            _branchARCurrencyTypeRepository = branchARCurrencyTypeRepository;
        }

        /// <summary>
        /// Handles request for getting branch details data
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<BranchListItemDto>> Handle(GetAllPagedBranchQuery query, CancellationToken cancellationToken)
        {
            var dbQuery = _branchRepository.GetAll()
                .WhereIf(!query.Filter.IsNullOrWhiteSpace(), t => t.Receivable.Contains(query.Filter));

            var branchCount = await dbQuery.CountAsync(cancellationToken);
            var branches = await dbQuery.OrderBy(query.Sorting).PageBy(query).ToListAsync(cancellationToken);

            var branchNumbers = branches.Select(x => x.Number).ToList();
            var branchARCurrencyTypes = await _branchARCurrencyTypeRepository.GetAll().Where(x => branchNumbers.Contains(Convert.ToInt16(x.Branch))).ToListAsync(cancellationToken);
            var branchsDto = ObjectMapper.Map<List<BranchListItemDto>>(branches);
            foreach(var branchDto in branchsDto)
            {
                branchDto.CurrencyType = branchARCurrencyTypes.FirstOrDefault(x => x.Branch == branchDto.Number)?.CurrencyType;
            }
            return new PagedResultDto<BranchListItemDto>(branchCount, branchsDto);
        }
    }
}
