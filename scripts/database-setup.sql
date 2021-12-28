
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], IsDefault, Code) VALUES ('New', getdate(), '#2C4AB6', 0, 1, 1, 'NEW');
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], IsDefault, Code) VALUES ('In progress', getdate(), '#FF8900', 0, 1, 0, 'IN PROGRESS');
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], IsDefault, Code) VALUES ('Converted', getdate(), '#008E26', 0, 0, 0, 'CONVERTED');
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], IsDefault, Code) VALUES ('Dead', getdate(), '#263950', 0, 1, 0, 'DEAD');
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], IsDefault, Code) VALUES ('Duplicate', getdate(), '#5400FF', 0, 1, 0, 'DUPLICATE');
GO

INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted]) VALUES ('Needs Analysis', getdate(), '#2C4AB6', 0);
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted]) VALUES ('Qualification', getdate(), '#2C4AB6', 0);
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted])	VALUES ('Prospecting', getdate(), '#2C4AB6', 0);
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted]) VALUES ('Proposal', getdate(), '#FF8900', 0);
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted]) VALUES ('Negotiation', getdate(), '#FF8900', 0);
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted]) VALUES ('Closed / Won', getdate(), '#008E26', 0);
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted]) VALUES ('Closed / Lost', getdate(), '#FF1414', 0);

INSERT INTO [web].[AccountTypes] ([Description], [CreationTime], [IsDeleted], IsDefault) VALUES ('Open', getdate(), 0, 0);
INSERT INTO [web].[AccountTypes] ([Description], [CreationTime], [IsDeleted], IsDefault) VALUES ('Prospect', getdate(), 0, 1);
GO

INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Low', GETDATE(), 0, 1);
INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Medium', GETDATE(),0, 0);
INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('High', GETDATE(),0, 0);
GO

INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Email', GETDATE(), 0, 1);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Social Media', GETDATE(),0, 0);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Direct Mail', GETDATE(),0, 0);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Referrals', GETDATE(),0, 0);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault]) VALUES ('Paid Advertisement', GETDATE(),0, 0);
GO


INSERT INTO web.Countries (Name, Code, CreationTime, IsDeleted) VALUES ('United States', 'US', getdate(), 0);
INSERT INTO web.Countries (Name, Code, CreationTime, IsDeleted) VALUES ('Canada', 'Canada', getdate(), 0);
INSERT INTO web.Countries (Name, Code, CreationTime, IsDeleted) VALUES ('Mexico', 'Mexico', getdate(), 0);
GO


UPDATE Web.LeadStatuses SET Code = UPPER(Description) WHERE 1 = 1;

-- Activity Lookup Data 
-- Added by Kevin C.
-- Date: 2021-12-23
GO
INSERT [web].[ActivityPriorities] ([Description], [Color], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Low', N'#263950', GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivityPriorities] ([Description], [Color], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Medium', N'#FF8900', GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivityPriorities] ([Description], [Color], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'High', N'#FF0000', GETDATE(), 0, NULL, NULL)
GO

INSERT [web].[ActivitySourceTypes] ([Description], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Account', GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivitySourceTypes] ([Description], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Lead', GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivitySourceTypes] ([Description], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Opportunity', GETDATE(), 0, NULL, NULL)
GO

INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus]) VALUES (N'Scheduled', 10, GETDATE(), 0, NULL, NULL, N'#2C4AB6', 0)
INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus]) VALUES (N'In Process', 20, GETDATE(), 0, NULL, NULL, N'#FF8900', 0)
INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus]) VALUES (N'Completed', 30, GETDATE(), 0, NULL, NULL, N'#008E26', 1)
GO

INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Schedule Meeting', 10, GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Schedule Call', 20, GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'Email Reminder', 30, GETDATE(), 0, NULL, NULL)
INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime]) VALUES (N'To Do Reminder', 40, GETDATE(), 0, NULL, NULL)
GO

-- Date: 2021-12-28
UPDATE web.ActivityPriorities SET [Order] = 10, IsDefault = 0 WHERE [Description] = 'Low'
UPDATE web.ActivityPriorities SET [Order] = 20, IsDefault = 1 WHERE [Description] = 'Medium'
UPDATE web.ActivityPriorities SET [Order] = 30, IsDefault = 0 WHERE [Description] = 'High'
GO

UPDATE web.ActivitySourceTypes SET [Order] = 10, EnumValue = 0 WHERE [Description] = 'Lead'
UPDATE web.ActivitySourceTypes SET [Order] = 20, EnumValue = 1 WHERE [Description] = 'Account'
UPDATE web.ActivitySourceTypes SET [Order] = 30, EnumValue = 2 WHERE [Description] = 'Opportunity'
GO

UPDATE web.ActivityStatuses SET IsDefault = 1 WHERE [Description] = 'Scheduled'
GO

UPDATE web.ActivityTaskTypes SET IsDefault = 1 WHERE [Description] = 'Schedule Meeting'
GO
-- END Kevin C.
