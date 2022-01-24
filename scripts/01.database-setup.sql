UPDATE [web].[AbpLanguages] SET IsDisabled = 1 WHERE Name <> 'en';
GO

UPDATE [web].AbpUsers SET UserName = 'SoftbaseAdmin', Name = 'Softbase', Surname = 'Admin', NormalizedUserName = 'SOFTBASEADMIN' WHERE UserName = 'admin';
UPDATE [web].AbpUsers SET Password = 'AQAAAAEAACcQAAAAEI4JxhWyG4aWjT4dqekpXVcSdT0FJr/PpqXzEUuC1qqZRKEo0AMsDjZ11dJgaAg2Dw==' WHERE UserName = 'SoftbaseAdmin';

GO

INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], [IsDefault], [Code], [Order]) VALUES ('New', getdate(), '#2C4AB6', 0, 1, 1, 'NEW', 1);
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], [IsDefault], [Code], [Order]) VALUES ('In progress', getdate(), '#FF8900', 0, 1, 0, 'IN_PROGRESS', 2);
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], [IsDefault], [Code], [Order]) VALUES ('Converted', getdate(), '#008E26', 0, 0, 0, 'CONVERTED', 3);
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], [IsDefault], [Code], [Order]) VALUES ('Dead', getdate(), '#263950', 0, 1, 0, 'DEAD', 4);
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], [IsDefault], [Code], [Order]) VALUES ('Duplicate', getdate(), '#5400FF', 0, 1, 0, 'DUPLICATE', 5);
GO

INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Needs Analysis', getdate(), '#2C4AB6', 0, 1, 'NEED_ANALYSIS');
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Qualification', getdate(), '#2C4AB6', 0, 2, 'QUALIFICATION');
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Prospecting', getdate(), '#2C4AB6', 0, 3, 'PROSPECTING');
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Proposal', getdate(), '#FF8900', 0, 4, 'PROPOSAL');
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Negotiation', getdate(), '#FF8900', 0, 5, 'NEGOTIATION');
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Closed / Won', getdate(), '#008E26', 0, 6, 'CLOSED_WON');
INSERT INTO [web].[OpportunityStages] ([Description], [CreationTime], [Color], [IsDeleted], [Order], [Code]) VALUES ('Closed / Lost', getdate(), '#FF1414', 0, 7, 'CLOSED_LOST');

INSERT INTO [web].[AccountTypes] ([Description], [CreationTime], [IsDeleted], IsDefault) VALUES ('Open', getdate(), 0, 0);
INSERT INTO [web].[AccountTypes] ([Description], [CreationTime], [IsDeleted], IsDefault) VALUES ('Prospect', getdate(), 0, 1);
GO

INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Color]) VALUES ('Low', GETDATE(), 0, 1, N'#263950');
INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Color]) VALUES ('Medium', GETDATE(),0, 0, N'#FF8900');
INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Color]) VALUES ('High', GETDATE(),0, 0, N'#FF0000');
GO

INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Order]) VALUES ('Email', GETDATE(), 0, 0, 1);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Order]) VALUES ('Social Media', GETDATE(),0, 0, 2);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Order]) VALUES ('Direct Mail', GETDATE(),0, 0, 3);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Order]) VALUES ('Referrals', GETDATE(),0, 0, 4);
INSERT INTO [web].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault], [Order]) VALUES ('Paid Advertisement', GETDATE(),0, 0, 5);
GO

INSERT INTO web.Countries (Name, Code, CreationTime, IsDeleted) VALUES ('United States', 'US', getdate(), 0);
INSERT INTO web.Countries (Name, Code, CreationTime, IsDeleted) VALUES ('Canada', 'Canada', getdate(), 0);
INSERT INTO web.Countries (Name, Code, CreationTime, IsDeleted) VALUES ('Mexico', 'Mexico', getdate(), 0);
GO


GO
INSERT [web].[ActivityPriorities] ([Description], [Color], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Order], [IsDefault]) VALUES (N'Low', N'#263950', GETDATE(), 0, NULL, NULL, 10, 0);
INSERT [web].[ActivityPriorities] ([Description], [Color], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Order], [IsDefault]) VALUES (N'Medium', N'#FF8900', GETDATE(), 0, NULL, NULL, 20, 1);
INSERT [web].[ActivityPriorities] ([Description], [Color], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Order], [IsDefault]) VALUES (N'High', N'#FF0000', GETDATE(), 0, NULL, NULL, 30, 0);
GO

INSERT [web].[ActivitySourceTypes] ([Description], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Order], [Code]) VALUES (N'Lead', GETDATE(), 0, NULL, NULL, 10, 'LEAD');
INSERT [web].[ActivitySourceTypes] ([Description], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Order], [Code]) VALUES (N'Account', GETDATE(), 0, NULL, NULL, 20, 'ACCOUNT');
INSERT [web].[ActivitySourceTypes] ([Description], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Order], [Code]) VALUES (N'Opportunity', GETDATE(), 0, NULL, NULL, 30, 'OPPORTUNITY');
GO

INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus], [IsDefault]) VALUES (N'Scheduled', 1, GETDATE(), 0, NULL, NULL, N'#2C4AB6', 0, 1);
INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus], [IsDefault]) VALUES (N'In Process', 2, GETDATE(), 0, NULL, NULL, N'#FF8900', 0, 0);
INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus], [IsDefault]) VALUES (N'Completed', 3, GETDATE(), 0, NULL, NULL, N'#008E26', 1, 0);
INSERT [web].[ActivityStatuses] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsCompletedStatus], [IsDefault]) VALUES (N'Due', 4, GETDATE(), 0, NULL, NULL, N'#FF0000', 0, 0);

GO

INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsDefault], [Code]) VALUES (N'Schedule Meeting', 10, GETDATE(), 0, NULL, NULL, N'#008CF2', 1, 'SCHEDULE_MEETING');
INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsDefault], [Code]) VALUES (N'Schedule Call', 20, GETDATE(), 0, NULL, NULL, N'#0AB3C1', 0, 'SCHEDULE_CALL');
INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsDefault], [Code]) VALUES (N'Email Reminder', 30, GETDATE(), 0, NULL, NULL, N'#FC42C3', 0, 'EMAIL_REMINDER');
INSERT [web].[ActivityTaskTypes] ([Description], [Order], [CreationTime], [IsDeleted], [DeleterUserId], [DeletionTime], [Color], [IsDefault], [Code]) VALUES (N'To-Do Reminder', 40, GETDATE(), 0, NULL, NULL, N'#5400FF', 0, 'TODO_REMINDER');
GO

