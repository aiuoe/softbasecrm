-- ROLES DEFINITION

INSERT INTO [web].[AbpRoles] (ConcurrencyStamp, CreationTime, DisplayName, IsDefault, IsDeleted, IsStatic, Name, NormalizedName, TenantId) VALUES (N'8aa2f770-82b1-4bde-98df-fa930436e348', getdate(), N'Sales Manager', 0, 0, 0, N'9b51dea2191146e2acfe94acf565f287', N'9B51DEA2191146E2ACFE94ACF565F287', 1);
INSERT INTO [web].[AbpRoles] (ConcurrencyStamp, CreationTime, DisplayName, IsDefault, IsDeleted, IsStatic, Name, NormalizedName, TenantId) VALUES (N'382265d6-011c-4360-b943-a1e929a2e2fe', getdate(), N'Marketing', 0, 0, 0, N'98c59e9a52a743b1ab3116edaa42b040', N'98C59E9A52A743B1AB3116EDAA42B040', 1);
INSERT INTO [web].[AbpRoles] (ConcurrencyStamp, CreationTime, DisplayName, IsDefault, IsDeleted, IsStatic, Name, NormalizedName, TenantId) VALUES (N'518b0e92-d2f6-438f-a494-313b8983aa71', getdate(), N'Owner', 0, 0, 0, N'b18b5258f6ae4a2ca2adbc365baba8d8', N'B18B5258F6AE4A2CA2ADBC365BABA8D8', 1);
INSERT INTO [web].[AbpRoles] (ConcurrencyStamp, CreationTime, DisplayName, IsDefault, IsDeleted, IsStatic, Name, NormalizedName, TenantId) VALUES (N'2707e5e1-de80-4418-8f78-edf713dede8d', getdate(), N'Sales Representative', 0, 0, 0, N'19224b3b73b14c9ba87c12111da43415', N'19224B3B73B14C9BA87C12111DA43415', 1);

-- ROLE SALES PERMISSIONS

INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewWip', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.EditOpportunity', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.AddOpportunity', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewOpportunities', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewInvoices', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewEvents', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewEquipments', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts.Edit', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts.Delete__Dynamic', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts.Create', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.AccountUsers.View__Dynamic', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.Create', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.Edit', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.ViewEvents', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.Create', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.Edit', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.Delete', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.ConvertToAccount', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales Representative'), null);



-- ROLE MANAGER PERMISSIONS



-- ROLE MARKETING PERMISSIONS



-- ROLE OWNER PERMISSIONS