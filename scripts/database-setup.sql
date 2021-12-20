
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid], IsDefault, Code) VALUES ('New', getdate(), '#2C4AB6', 0, 1, 0, 'NEW');
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