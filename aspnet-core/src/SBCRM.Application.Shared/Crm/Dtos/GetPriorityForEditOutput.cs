using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Crm.Dtos
{
    public class GetPriorityForEditOutput
    {
        public CreateOrEditPriorityDto Priority { get; set; }

    }
}