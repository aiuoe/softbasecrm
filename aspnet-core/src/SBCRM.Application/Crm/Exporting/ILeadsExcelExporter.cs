using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    public interface ILeadsExcelExporter
    {
        FileDto ExportToFile(List<GetLeadForViewDto> leads);

        FileDto ExportDuplicatedLeadsToExcel(List<LeadDto> leads);
    }
}