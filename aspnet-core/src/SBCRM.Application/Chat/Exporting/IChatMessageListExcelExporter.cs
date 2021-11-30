using System.Collections.Generic;
using Abp;
using SBCRM.Chat.Dto;
using SBCRM.Dto;

namespace SBCRM.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
