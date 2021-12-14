namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO to manage the object customer for edit purposes
    /// </summary>
    public class GetCustomerForEditOutput
    {
        public CreateOrEditCustomerDto Customer { get; set; }
        public string AccountTypeDescription { get; set; }
    }
}