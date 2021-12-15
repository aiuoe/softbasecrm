
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid])
VALUES ('New', getdate(), '#2C4AB6', 0, 1),
       ('In progress', getdate(), '#FF8900', 0, 1),
       ('Converted', getdate(), '#008E26', 0, 0),
       ('Dead', getdate(), '#263950', 0, 1),
	   ('Duplicate', getdate(), '#5400FF', 0, 1, 0)

GO

INSERT INTO [web].[AccountTypes] ([Description], [CreationTime], [IsDeleted], IsDefault)
VALUES ('Open', getdate(), 0, 0),
       ('Prospect', getdate(), 0, 1)
GO

INSERT INTO [web].[Priorities] ([Description], [CreationTime],[IsDeleted],[IsDefault])
VALUES  ('Low', GETDATE(), 0, 1),
		('Medium', GETDATE(),0, 0),
		('High', GETDATE(),0, 0)
GO

INSERT INTO [WEB].[LeadSources] ([Description], [CreationTime],[IsDeleted],[IsDefault])
VALUES	('Email', GETDATE(), 0, 1),
		('Social Media', GETDATE(),0, 0),
		('Direct Mail', GETDATE(),0, 0),
		('Referrals', GETDATE(),0, 0),
		('Paid Advertisement', GETDATE(),0, 0)
GO