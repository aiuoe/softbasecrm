namespace SBCRM.Legacy.Dtos
{
    /// <summary>
    /// DTO representing the access level for the Account tabs
    /// </summary>
    public class CustomerVisibilityTabsDto
    {
        public bool CanEditOverviewTab { get; set; }
        public bool CanViewOpportunitiesTab { get; set; }
        public bool CanCreateOpportunities { get; set; }
        public bool CanViewOpportunities { get; set; }
        public bool CanEditOpportunities { get; set; }
        public bool CanViewInvoicesTab { get; set; }
        public bool CanViewEquipmentsTab { get; set; }
        public bool CanViewWipTab { get; set; }
        public bool CanViewEventsTab { get; set; }
    }
}
