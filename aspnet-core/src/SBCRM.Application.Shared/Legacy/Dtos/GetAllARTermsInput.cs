using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Legacy.Dtos
{
    public class GetAllARTermsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string TermsFilter { get; set; }

        public short? MaxCODFilter { get; set; }
        public short? MinCODFilter { get; set; }

        public short? MaxDaysDueFilter { get; set; }
        public short? MinDaysDueFilter { get; set; }

        public short? MaxDaysFilter { get; set; }
        public short? MinDaysFilter { get; set; }

        public short? MaxDayOfMonthFilter { get; set; }
        public short? MinDayOfMonthFilter { get; set; }

        public short? MaxDayFilter { get; set; }
        public short? MinDayFilter { get; set; }

        public short? MaxPrintWaterMarkFilter { get; set; }
        public short? MinPrintWaterMarkFilter { get; set; }

        public string AddedByFilter { get; set; }

        public DateTime? MaxDateAddedFilter { get; set; }
        public DateTime? MinDateAddedFilter { get; set; }

        public string ChangedByFilter { get; set; }

        public DateTime? MaxDateChangedFilter { get; set; }
        public DateTime? MinDateChangedFilter { get; set; }

        public short? MaxCreditCardFilter { get; set; }
        public short? MinCreditCardFilter { get; set; }

    }
}