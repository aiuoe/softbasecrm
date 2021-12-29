namespace SBCRM.Crm.Dtos
{
    /// <summary>
    /// DTO to manage the lead source for update order
    /// </summary>
    public class UpdateOrderleadSourceDto
    {
        /// <summary>
        /// Lead source description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// lead source order
        /// </summary>
        public virtual int Order { get; set; }
    }
}