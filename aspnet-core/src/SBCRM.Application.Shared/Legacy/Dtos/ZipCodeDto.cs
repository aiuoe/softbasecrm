using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public class ZipCodeDto
    {
        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string County { get; set; }

        public string AddedBy { get; set; }

        public string ChangedBy { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateChanged { get; set; }

    }
}