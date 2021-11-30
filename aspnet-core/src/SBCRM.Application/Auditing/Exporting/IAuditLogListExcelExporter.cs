using System.Collections.Generic;
using SBCRM.Auditing.Dto;
using SBCRM.Dto;

namespace SBCRM.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
