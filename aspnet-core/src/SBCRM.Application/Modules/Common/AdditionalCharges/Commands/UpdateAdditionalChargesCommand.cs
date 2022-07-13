using Abp.Runtime.Validation;
using MediatR;
using SBCRM.Modules.Common.AdditionalCharges.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.AdditionalCharges.Commands
{
    public class UpdateAdditionalChargesCommand : IRequest<Unit>
    {
        public UpdateAdditionalChargesCommand(AdditionalChargeDto additionalCharge, long id)
        {
            AdditionalCharge = additionalCharge;
            Id = id;
        }

        public AdditionalChargeDto AdditionalCharge { get; set; }    
        public long Id { get; set; }
     }
}
