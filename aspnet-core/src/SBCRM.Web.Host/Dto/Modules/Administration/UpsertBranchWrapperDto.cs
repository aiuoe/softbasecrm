using Microsoft.AspNetCore.Http;
using SBCRM.Modules.Administration.Branch.Dtos;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Attributes;

namespace SBCRM.Web.Dto.Modules.Administration
{
    /// <summary>
    /// Request DTO for create and update Branch
    /// </summary>
    public class UpsertBranchWrapperDto
    {
        [FromJson]
        public UpsertBranchDto UpsertBranchDto { get; set; }
        public IFormFile File { get; set; }
    }
}
