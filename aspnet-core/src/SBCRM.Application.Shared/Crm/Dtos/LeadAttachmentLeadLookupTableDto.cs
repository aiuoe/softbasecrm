﻿using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm.Dtos
{

    /// <summary>
    /// Model to list the leads
    /// </summary>
    public class LeadAttachmentLeadLookupTableDto
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public List<LeadUserDto> Users { get; set; }
        public bool CanViewAttachments { get; set; }
        public bool CanAddAttachments { get; set; }
        public bool CanEditAttachments { get; set; }
        public bool CanDownloadAttachments { get; set; }
        public bool CanRemoveAttachments { get; set; }
    }
}