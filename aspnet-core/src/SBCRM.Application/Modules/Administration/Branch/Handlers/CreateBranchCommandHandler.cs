using System.Threading;
using System.Threading.Tasks;
using Abp.UI;
using MediatR;
using SBCRM.Base;
using SBCRM.Modules.Administration.Branch.Commands;
using SBCRM.Modules.Administration.Branch.Dtos;

namespace SBCRM.Modules.Administration.Branch.Handlers
{
    /// <summary>
    /// Create branch command handler
    /// </summary>
    public class CreateBranchCommandHandler : SBCRMAppServiceBase, IRequestHandler<CreateBranchCommand, BranchForEditDto>
    {
        private readonly IBranchRepository _branchRepository;

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="branchRepository"></param>
        public CreateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// Create branch use case
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BranchForEditDto> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            var branchWithSameNumber = await _branchRepository.FirstOrDefaultAsync(x => x.Number == command.Number);
            if (branchWithSameNumber != null)
            {
                throw new UserFriendlyException("BranchNumberUnique");
            }

            var branch = new Core.BaseEntities.Branch
            {
                Number = command.Number,
                Name = command.Name,
                SubName = command.SubName,
                Address = command.Address,
                City = command.City,
                State = command.State,
                ZipCode = command.ZipCode,
                Country = command.Country,
                Phone = command.Phone,
                Fax = command.Fax,
                Receivable = command.Receivable,
                FinanceCharge = command.FinanceCharge,
                FinanceRate = command.FinanceRate,
                FinanceDays = command.FinanceDays,
                StateTaxLabel = command.StateTaxLabel,
                CountyTaxLabel = command.CountyTaxLabel,
                ShowSplitSalesTax = command.ShowSplitSalesTax,
                CityTaxLabel = command.CityTaxLabel,
                LocalTaxLabel = command.LocalTaxLabel,
                DefaultWarehouse = command.DefaultWarehouse,
                ClarkPartsCode = command.ClarkPartsCode,
                ClarkDealerAccessCode = command.ClarkDealerAccessCode,
                UseStateTaxCodeDescription = command.UseStateTaxCodeDescription,
                UseCountyTaxCodeDescription = command.UseCountyTaxCodeDescription,
                UseCityTaxCodeDescription = command.UseCityTaxCodeDescription,
                UseLocalTaxCodeDescription = command.UseLocalTaxCodeDescription,
                RentalDeliveryDefaultTime = command.RentalDeliveryDefaultTime,
                StateTaxCode = command.StateTaxCode,
                CountyTaxCode = command.CountyTaxCode,
                CityTaxCode = command.CityTaxCode,
                LocalTaxCode = command.LocalTaxCode,
                TaxCode = command.TaxCode,
                UseAbsoluteTaxCodes = command.UseAbsoluteTaxCodes,
                SmallSubName = command.SmallSubName,
                ShopId = command.ShopId,
                Image = command.Image,
                UseImage = command.UseImage,
                LogoFile = command.LogoFile,
                VendorId = command.VendorId,
                PrintFinalCc = command.PrintFinalCc,
                PrintFinalBcc = command.PrintFinalBcc,
                StoreName = command.StoreName,
                CreditCardAccountNo = command.CreditCardAccountNo,
                TvhAccountNo = command.TvhAccountNo,
                TvhKey = command.TvhKey,
                TvhCountry = command.TvhCountry,
                TvhWarehouse = command.TvhWarehouse,
            };

            SetTenant(branch);

            branch.Id = await _branchRepository.InsertAndGetIdAsync(branch);
            return ObjectMapper.Map<BranchForEditDto>(branch);
        }
    }

}
