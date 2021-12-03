using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllZipCodesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string ZipCodeFilter { get; set; }

        public string CityFilter { get; set; }

        public string StateFilter { get; set; }

        public string CountyFilter { get; set; }

        public string AddedByFilter { get; set; }

        public string ChangedByFilter { get; set; }

        public DateTime? MaxDateAddedFilter { get; set; }
        public DateTime? MinDateAddedFilter { get; set; }

        public DateTime? MaxDateChangedFilter { get; set; }
        public DateTime? MinDateChangedFilter { get; set; }

    }
}