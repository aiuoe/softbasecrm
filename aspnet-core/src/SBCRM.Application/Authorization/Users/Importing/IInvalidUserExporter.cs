using System.Collections.Generic;
using SBCRM.Authorization.Users.Importing.Dto;
using SBCRM.Dto;

namespace SBCRM.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
