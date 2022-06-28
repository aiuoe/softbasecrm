﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SBCRM.Modules.Administration.Branch.Dtos
{
    /// <summary>
    /// DTO for City Tax Code dropdown
    /// </summary>
    public class CityTaxCodeInBranchDto
    {
        public long Id { get; set; }
        public string CityTaxCodes { get; set; }
    }
}
