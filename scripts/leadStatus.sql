USE [Softbase]
GO

INSERT INTO [web].[LeadStatuses]
           ([Description]
           ,[CreationTime]
           ,[Color]
		   ,[IsDeleted]
		   ,[IsLeadConversionValid])
     VALUES
           (
			'New',
			'12/3/2021 3:20:16 PM',
			'#2C4AB6',
			0,
			0
		   ),
		   (
			'In progress',
			'12/3/2021 3:20:16 PM',
			'#FF8900',
			0,
			0
		   ),
		   (
			'Converted',
			'12/3/2021 3:20:16 PM',
			'#008E26',
			0,
			1
		   ),
		   (
			'Dead',
			'12/3/2021 3:20:16 PM',
			'#263950',
			0,
			0
		   )
GO


