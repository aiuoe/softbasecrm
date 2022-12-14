using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    public interface IPrioritiesExcelExporter
    {
        FileDto ExportToFile(List<GetPriorityForViewDto> priorities);
    }
}