using System.Collections.Generic;
using SBCRM.Crm.Dtos;
using SBCRM.Dto;

namespace SBCRM.Crm.Exporting
{
    /// <summary>
    /// Interface that contains method that  exporting data from opportunity stages to an excel file
    /// </summary>
    public interface IOpportunityStagesExcelExporter
    {
        /// <summary>
        /// Method that export data to excel
        /// </summary>
        /// <param name="opportunityStages"></param>
        /// <returns></returns>
        FileDto ExportToFile(List<GetOpportunityStageForViewDto> opportunityStages);
    }
}