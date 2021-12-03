using System.Collections.Generic;
using SBCRM.Legacy.Dtos;
using SBCRM.Dto;

namespace SBCRM.Legacy.Exporting
{
    public interface ICustomerExcelExporter
    {
        FileDto ExportToFile(List<GetCustomerForViewDto> customer);
    }
}