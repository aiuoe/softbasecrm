using Microsoft.AspNetCore.Http;
using SBCRM.Modules.Administration.Branch.Dtos;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Attributes;

namespace SBCRM.Web.Dto.Modules.Administration
{
    public class UpsertBranchWrapperDto
    {
        [FromJson]
        public UpsertBranchDto UpsertBranchDto { get; set; }
        public IFormFile? File { get; set; }
    }
}
