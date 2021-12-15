namespace SBCRM.Legacy
{
    /// <summary>
    /// DTO to manage the customer equipment result
    /// </summary>
    public class CustomerEquipmentViewDto
    {
        public string UnitNo { get; set; }
        public string Serial { get; set; }
        public string ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double? Meter { get; set; }
        public float? TotalExp { get; set; }
        public float? ExpMeter { get; set; }
    }
}
