import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    
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
                        path: 'business/leadStatuses',
                        loadChildren: () => import('./crm/leadStatuses/leadStatus.module').then(m => m.LeadStatusModule),
                        data: { permission: 'Pages.LeadStatuses' }
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
                        path: 'business/customer',
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
