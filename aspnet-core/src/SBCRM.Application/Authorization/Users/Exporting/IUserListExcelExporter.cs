using System.Collections.Generic;
using SBCRM.Authorization.Users.Dto;
using SBCRM.Dto;

namespace SBCRM.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}