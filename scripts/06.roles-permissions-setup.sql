
-- ROLE SALES

INSERT INTO web.AbpRoles (ConcurrencyStamp, CreationTime, DisplayName, IsDefault, IsDeleted, IsStatic,
                                          Name, NormalizedName, TenantId)
VALUES (N'cb86cf8e-c7b4-4151-a605-cadf3656f3d8', getdate(), N'Sales', 0, 0, 0,
        N'92da06f5e4df4445939a7e2fb33f9ca2', N'92DA06F5E4DF4445939A7E2FB33F9CA2', 1);

INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewWip', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.EditOpportunity', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.AddOpportunity', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewOpportunities', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewInvoices', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewEvents', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.ViewEquipments', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts.Edit', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts.Delete__Dynamic', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts.Create', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Contacts', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.AccountUsers.View__Dynamic', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.Create', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer.Edit', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Customer', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.ViewEvents', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.Create', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.Edit', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.Delete', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages.Leads.ConvertToAccount', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);
INSERT INTO web.AbpPermissions (CreationTime, Discriminator, IsGranted, Name, TenantId, RoleId, UserId) VALUES (GETDATE(), N'RolePermissionSetting', 1, N'Pages', 1, (SELECT Id FROM web.AbpRoles WHERE DisplayName = 'Sales'), null);



-- ROLE MANAGER



-- ROLE MARKETING



-- ROLE OWNER