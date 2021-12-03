using System;
using Abp.Application.Services.Dto;

namespace SBCRM.Legacy.Dtos
{
    public class CustomerDto : EntityDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public string BillTo { get; set; }

        public int ID { get; set; }

        public int AccountTypeId { get; set; }

    }
}