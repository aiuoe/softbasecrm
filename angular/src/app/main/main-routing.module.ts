import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    
                    {
                        path: 'crm/opportunityStages',
                        loadChildren: () => import('./crm/opportunityStages/opportunityStage.module').then(m => m.OpportunityStageModule),
                        data: { permission: 'Pages.OpportunityStages' }
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
                        path: 'business/leadStatuses',
                        loadChildren: () => import('./crm/leadStatuses/leadStatus.module').then(m => m.LeadStatusModule),
                        data: { permission: 'Pages.LeadStatuses' }
                    },
                    {
                        path: 'business/leadSources',
                        loadChildren: () => import('./crm/leadSources/leadSource.module').then(m => m.LeadSourceModule),
                        data: { permission: 'Pages.LeadSources' }
                    },
                    {
                        path: 'business/accounts',
                        loadChildren: () => import('./legacy/customer/customer.module').then(m => m.CustomerModule),
                        data: { permission: 'Pages.Customer' }
                    },
                    {
                        path: 'dashboard',
                        loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
                        data: { permission: 'Pages.Tenant.Dashboard' },
                    },
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: '**', redirectTo: 'dashboard' },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class MainRoutingModule {}
