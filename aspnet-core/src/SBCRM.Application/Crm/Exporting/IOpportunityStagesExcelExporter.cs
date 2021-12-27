using SBCRM.Crm.Dtos;
using SBCRM.Dto;
using System.Collections.Generic;

namespace SBCRM.Crm.Exporting
{
    public interface IOpportunityStagesExcelExporter
    {
        FileDto ExportToFile(List<GetOpportunityStageForViewDto> opportunityStages);
    }
}