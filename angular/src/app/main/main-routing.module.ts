import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'administration/saleCodes',
                        loadChildren: () => import('./administration/sale-codes/saleCodes.module').then(m => m.SaleCodesModule),
                        // data: { permission: 'Pages.ActivityStatuses' }
                    },
                    {
                        path: 'administration/branch',
                        loadChildren: () => import('./administration/branch/branch.module').then(m => m.BranchModule),
                        data: { permission: 'Pages.Administration' }
                    },
                    {
                        path: 'crm/activityStatuses',
                        loadChildren: () => import('./crm/activityStatuses/activityStatus.module').then(m => m.ActivityStatusModule),
                        data: { permission: 'Pages.ActivityStatuses' }
                    },
                    {
                        path: 'crm/activities',
                        loadChildren: () => import('./crm/activities/activity.module').then(m => m.ActivityModule),
                        data: { permission: 'Pages.Activities' }
                    },
                    {
                        path: 'crm/activitySourceTypes',
                        loadChildren: () => import('./crm/activitySourceTypes/activitySourceType.module').then(m => m.ActivitySourceTypeModule),
                        data: { permission: 'Pages.ActivitySourceTypes' }
                    },
                    {
                        path: 'crm/activityPriorities',
                        loadChildren: () => import('./crm/activityPriorities/activityPriority.module').then(m => m.ActivityPriorityModule),
                        data: { permission: 'Pages.ActivityPriorities' }
                    },
                    {
                        path: 'crm/opportunities',
                        loadChildren: () => import('./crm/opportunities/opportunity.module').then(m => m.OpportunityModule),
                        data: { permission: 'Pages.Opportunities' }
                    },
                    {
                        path: 'crm/opportunities',
                        loadChildren: () => import('./crm/opportunities/opportunity.module').then(m => m.OpportunityModule),
                        data: { permission: 'Pages.Opportunities' }
                    },
                    {
                        path: 'crm/opportunityStages',
                        loadChildren: () => import('./crm/opportunityStages/opportunityStage.module').then(m => m.OpportunityStageModule),
                        data: { permission: 'Pages.OpportunityStages' }
                    },
                    {
                        path: 'crm/accountUsers',
                        loadChildren: () => import('./crm/assigned-user/assigned-user.module').then(m => m.AssignedUserModule),
                        data: { permission: 'Pages.AccountUsers' }
                    },
                    {
                        path: 'crm/countries',
                        loadChildren: () => import('./crm/countries/country.module').then(m => m.CountryModule),
                        data: { permission: 'Pages.Countries' }
                    },
                    {
                        path: 'crm/leadSources',
                        loadChildren: () => import('./crm/leadSources/leadSource.module').then(m => m.LeadSourceModule),
                        data: { permission: 'Pages.LeadSources' }
                    },
                    {
                        path: 'crm/leadStatuses',
                        loadChildren: () => import('./crm/leadStatuses/leadStatus.module').then(m => m.LeadStatusModule),
                        data: { permission: 'Pages.LeadStatuses' }
                    },
                    {
                        path: 'crm/priorities',
                        loadChildren: () => import('./crm/priorities/priority.module').then(m => m.PriorityModule),
                        data: { permission: 'Pages.Priorities' }
                    },
                    {
                        path: 'crm/opportunityStages',
                        loadChildren: () => import('./crm/opportunityStages/opportunityStage.module').then(m => m.OpportunityStageModule),
                        data: { permission: 'Pages.OpportunityStages' }
                    },
                    {
                        path: 'crm/opportunities',
                        loadChildren: () => import('./crm/opportunities/opportunity.module').then(m => m.OpportunityModule),
                        data: { permission: 'Pages.Opportunities' }
                    },
                    {
                        path: 'crm/activityStatuses',
                        loadChildren: () => import('./crm/activityStatuses/activityStatus.module').then(m => m.ActivityStatusModule),
                        data: { permission: 'Pages.ActivityStatuses' }
                    },
                    {
                        path: 'crm/activityTaskTypes',
                        loadChildren: () => import('./crm/activityTaskTypes/activityTaskType.module').then(m => m.ActivityTaskTypeModule),
                        data: { permission: 'Pages.ActivityTaskTypes' }
                    },
                    {
                        path: 'crm/leadSources',
                        loadChildren: () => import('./crm/leadSources/leadSource.module').then(m => m.LeadSourceModule),
                        data: { permission: 'Pages.LeadSources' }
                    },
                    {
                        path: 'crm/opportunityTypes',
                        loadChildren: () => import('./crm/opportunityTypes/opportunityType.module').then(m => m.OpportunityTypeModule),
                        data: { permission: 'Pages.OpportunityTypes' }
                    },
                    {
                        path: 'crm/opportunityStages',
                        loadChildren: () => import('./crm/opportunityStages/opportunityStage.module').then(m => m.OpportunityStageModule),
                        data: { permission: 'Pages.OpportunityStages' }
                    },
                    {
                        path: 'crm/opportunityTypes',
                        loadChildren: () => import('./crm/opportunityTypes/opportunityType.module').then(m => m.OpportunityTypeModule),
                        data: { permission: 'Pages.OpportunityTypes' }
                    },
                    {
                        path: 'crm/opportunityStages',
                        loadChildren: () => import('./crm/opportunityStages/opportunityStage.module').then(m => m.OpportunityStageModule),
                        data: { permission: 'Pages.OpportunityStages' }
                    },
                    {
                        path: 'crm/opportunities',
                        loadChildren: () => import('./crm/opportunities/opportunity.module').then(m => m.OpportunityModule),
                        data: { permission: 'Pages.Opportunities' }
                    },
                    {
                        path: 'crm/leadStatuses',
                        loadChildren: () => import('./crm/leadStatuses/leadStatus.module').then(m => m.LeadStatusModule),
                        data: { permission: 'Pages.LeadStatuses' }
                    },
                    {
                        path: 'crm/leads',
                        loadChildren: () => import('./crm/leads/lead.module').then(m => m.LeadModule),
                        data: { permission: 'Pages.Leads' }
                    },
                    {
                        path: 'crm/priorities',
                        loadChildren: () => import('./crm/priorities/priority.module').then(m => m.PriorityModule),
                        data: { permission: 'Pages.Priorities' }
                    },
                    {
                        path: 'crm/leads',
                        loadChildren: () => import('./crm/leads/lead.module').then(m => m.LeadModule),
                        data: { permission: 'Pages.Leads' }
                    },
                    {
                        path: 'crm/accounts',
                        loadChildren: () => import('./legacy/customer/customer.module').then(m => m.CustomerModule),
                        data: { permission: 'Pages.Customer' }
                    },
                    {
                        path: 'dashboard',
                        loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
                        data: { permission: 'Pages.Dashboard' },
                    },
                    {
                        path: 'global-search',
                        loadChildren: () => import('./crm/globalSearch/global-search.module').then((m) => m.GlobalSearchModule),
                        data: { permission: 'Pages.GlobalSearch' },
                    },
                    {
                        path: 'administration/department',
                        loadChildren: () => import('./administration/department/department.module').then((m) => m.DepartmentModule),
                        data: { permission: 'Pages.Administration.Tenant.Department' },
                    },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class MainRoutingModule {
}
