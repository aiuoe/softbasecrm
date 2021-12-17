using System;
using System.Collections.Generic;
using SBCRM.Crm;

namespace SBCRM.Legacy.Dto
{
    public class CustomerQueryDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public string BillTo { get; set; }

        public int? AccountTypeId { get; set; }
        public List<AccountUser> Users { get; set; }
        public string AccountTypeDescription { get; set; }

        public string AddedBy { get; set; }
        public DateTime? Added { get; set; }

        public string ChangedBy { get; set; }
        public DateTime? Changed { get; set; }
        public string FirstUserAssignedName { get; set; }
    }
}
