using Abp.Application.Services.Dto;
using System;

namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage filter object to get paged result from contacts
    /// </summary>
    public class GetAllContactsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string CustomerNoFilter { get; set; }

        public string ContactFilter { get; set; }

        public string ParentFilter { get; set; }

        public short? MaxIndexPointerFilter { get; set; }
        public short? MinIndexPointerFilter { get; set; }

        public string PositionFilter { get; set; }

        public string PhoneFilter { get; set; }

        public string ExtentionFilter { get; set; }

        public string FaxFilter { get; set; }

        public string PagerFilter { get; set; }

        public string CellularFilter { get; set; }

        public string EMailFilter { get; set; }

        public string wwwHomePageFilter { get; set; }

        public short? MaxSalesGroup1Filter { get; set; }
        public short? MinSalesGroup1Filter { get; set; }

        public short? MaxSalesGroup2Filter { get; set; }
        public short? MinSalesGroup2Filter { get; set; }

        public short? MaxSalesGroup3Filter { get; set; }
        public short? MinSalesGroup3Filter { get; set; }

        public string CommentsFilter { get; set; }

        public DateTime? MaxDateAddedFilter { get; set; }
        public DateTime? MinDateAddedFilter { get; set; }

        public DateTime? MaxDateChangedFilter { get; set; }
        public DateTime? MinDateChangedFilter { get; set; }

        public short? MaxSalesGroup4Filter { get; set; }
        public short? MinSalesGroup4Filter { get; set; }

        public short? MaxSalesGroup5Filter { get; set; }
        public short? MinSalesGroup5Filter { get; set; }

        public short? MaxSalesGroup6Filter { get; set; }
        public short? MinSalesGroup6Filter { get; set; }

        public short? MaxMailingListFilter { get; set; }
        public short? MinMailingListFilter { get; set; }

        public string AddedByFilter { get; set; }

        public string ChangedByFilter { get; set; }

        public int? MaxIDFilter { get; set; }
        public int? MinIDFilter { get; set; }

    }
}