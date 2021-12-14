USE [Softbase]
GO

INSERT INTO [web].[LeadStatuses] ([Description],[CreationTime],[Color],[IsDeleted],[IsLeadConversionValid])
     VALUES
           ('New',GETDATE(),'#2C4AB6',0,0),
		   ('In progress',GETDATE(),'#FF8900',0,0),
		   ('Converted',GETDATE(),'#008E26',0,1),
		   ('Dead',GETDATE(),'#263950',0,0)
GO