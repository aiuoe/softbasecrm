using MediatR;
using SBCRM.Modules.Common.AdditionalCharges.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBCRM.Modules.Common.AdditionalCharges.Commands
{
    public class GetAdditionalChargesByBranchAndDepartmentCommand : IRequest<List<AdditionalChargeDto>>
    {
        public GetAdditionalChargesByBranchAndDepartmentCommand(int branchNo, int departmentNo)
        {
            BranchNo = branchNo;
            DepartmentNo = departmentNo;
        }

        public int BranchNo { get; set; }   
        public int DepartmentNo { get; set; }   
    }
}
