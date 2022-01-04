namespace SBCRM.Legacy.Dtos
{
    public class CustomerTabsVisibilityDto
    {
        public bool CanViewOpportunitiesTab { get; set; }
        public bool CanViewInvoicesTab { get; set; }
        public bool CanViewEquipmentsTab { get; set; }
        public bool CanViewWipTab { get; set; }
        public bool CanViewEventsTab { get; set; }
    }
}
