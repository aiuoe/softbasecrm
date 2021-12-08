using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace SBCRM.Legacy.Dtos
{
    public class CreateOrEditZipCodeDto
    {
        [Required]
        [StringLength(ZipCodeConsts.MaxZipCodeLength, MinimumLength = ZipCodeConsts.MinZipCodeLength)]
        public string ZipCode { get; set; }

        [StringLength(ZipCodeConsts.MaxCityLength, MinimumLength = ZipCodeConsts.MinCityLength)]
        public string City { get; set; }

        [StringLength(ZipCodeConsts.MaxStateLength, MinimumLength = ZipCodeConsts.MinStateLength)]
        public string State { get; set; }

        [StringLength(ZipCodeConsts.MaxCountyLength, MinimumLength = ZipCodeConsts.MinCountyLength)]
        public string County { get; set; }

        [StringLength(ZipCodeConsts.MaxAddedByLength, MinimumLength = ZipCodeConsts.MinAddedByLength)]
        public string AddedBy { get; set; }

        [StringLength(ZipCodeConsts.MaxChangedByLength, MinimumLength = ZipCodeConsts.MinChangedByLength)]
        public string ChangedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateChanged { get; set; }

    }
}