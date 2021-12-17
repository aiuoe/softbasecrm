namespace SBCRM.Crm.Dtos
{
    public class GetAccountUserForViewDto
    {
        public AccountUserDto AccountUser { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string FullName { get; set; }
    }
}