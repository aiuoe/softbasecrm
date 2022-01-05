import { Injectable, OnInit } from '@angular/core';
import { WidgetViewDefinition, WidgetFilterViewDefinition } from './definitions';
import { DashboardCustomizationConst } from './DashboardCustomizationConsts';
import { WidgetOpportunitiesTopStatsComponent } from './widgets/widget-opportunities-stats/widget-opportunities-stats.component';
import { WidgetOpportunitiesListComponent } from './widgets/widget-opportunities-list/widget-opportunities-list.component';

@Injectable({
    providedIn: 'root',
})
export class DashboardViewConfigurationService {
    public WidgetViewDefinitions: WidgetViewDefinition[] = [];
    public widgetFilterDefinitions: WidgetFilterViewDefinition[] = [];

    constructor() {
        this.initializeConfiguration();
    }

    private initializeConfiguration() {
        //add your host side widgets here

        let opportunitiesStats = new WidgetViewDefinition(
            DashboardCustomizationConst.widgets.crm.opportunitiesTopStats,
            WidgetOpportunitiesTopStatsComponent
        );

        let opportunitiesList = new WidgetViewDefinition(
            DashboardCustomizationConst.widgets.crm.opportunitiesList,
            WidgetOpportunitiesListComponent
        );

        this.WidgetViewDefinitions.push(opportunitiesStats);
        this.WidgetViewDefinitions.push(opportunitiesList);
    }
}
