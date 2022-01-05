using System.Collections.Generic;
using System.Linq;
using Abp.MultiTenancy;
using SBCRM.Authorization;

namespace SBCRM.DashboardCustomization.Definitions
{
    public class DashboardConfiguration
    {
        public List<DashboardDefinition> DashboardDefinitions { get; } = new List<DashboardDefinition>();

        public List<WidgetDefinition> WidgetDefinitions { get; } = new List<WidgetDefinition>();

        public List<WidgetFilterDefinition> WidgetFilterDefinitions { get; } = new List<WidgetFilterDefinition>();

        public DashboardConfiguration()
        {
            #region FilterDefinitions
            // Add your filters here

            #endregion

            #region WidgetDefinitions

            // Define Widgets
            #endregion

            #region CRMWidgets

            var crmDefaultPermission = new List<string>
            {
                AppPermissions.Pages_Dashboard
            };

            var opportunitiesStats = new WidgetDefinition(
                  SBCRMDashboardCustomizationConsts.Widgets.Crm.OpportunitiesStats,
                  "WidgetOpportunitiesStats",
                  usedWidgetFilters: new List<string>() { },
                  permissions: crmDefaultPermission);

            var opportunitiesList = new WidgetDefinition(
                  SBCRMDashboardCustomizationConsts.Widgets.Crm.OpportunitiesList,
                  "WidgetOpportunitiesList",
                  usedWidgetFilters: new List<string>() { },
                  permissions: crmDefaultPermission);

            WidgetDefinitions.Add(opportunitiesStats);
            WidgetDefinitions.Add(opportunitiesList);

            #endregion
            #region DashboardDefinitions

            // Add your dashboard definiton here

            var defaultCrmDashboard = new DashboardDefinition(
              SBCRMDashboardCustomizationConsts.DashboardNames.DefaultCrmDashboard,
              new List<string>
              {
                    opportunitiesStats.Id,
                    opportunitiesList.Id
              });

            DashboardDefinitions.Add(defaultCrmDashboard);
            #endregion

        }

    }
}
