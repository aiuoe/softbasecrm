
INSERT INTO [web].[LeadStatuses] ([Description], [CreationTime], [Color], [IsDeleted] , [IsLeadConversionValid])
VALUES ('New', getdate(), '#2C4AB6', 0, 0),
       ('In progress', getdate(), '#FF8900', 0, 1),
       ('Converted', getdate(), '#008E26', 0, 1),
       ('Dead', getdate(), '#263950', 0, 1)
GO

INSERT INTO [web].[AccountTypes] ([Description], [CreationTime], [IsDeleted], IsDefault)
VALUES ('Open', getdate(), 0, 0),
       ('Prospect', getdate(), 0, 1)
GO

