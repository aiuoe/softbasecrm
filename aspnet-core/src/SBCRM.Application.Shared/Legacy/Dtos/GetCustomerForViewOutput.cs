namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object customer for view purposes
    /// </summary>
    public class GetCustomerForViewOutput
    {
        public CreateOrEditCustomerDto Customer { get; set; }
        public string AccountTypeDescription { get; set; }
    }
}