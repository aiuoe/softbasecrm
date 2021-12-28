using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Legacy.Dtos
{
    //Input for global search
    public class GetGlobalSearchInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
