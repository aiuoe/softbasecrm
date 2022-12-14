using System.Collections.Generic;
using SBCRM.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace SBCRM.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
