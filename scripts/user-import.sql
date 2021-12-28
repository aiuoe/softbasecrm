USE SBCRMDb
GO

BEGIN TRY
	BEGIN TRANSACTION

    DECLARE @InsertedEmployeeNo table(EmployeeNo int);

	INSERT INTO [web].[AbpUsers] ([UserName],[NormalizedUserName],[Name],[Surname], [EmailAddress],[NormalizedEmailAddress], [PhoneNumber],[Password],[CreationTime],[IsActive],[AccessFailedCount],[IsEmailConfirmed],[IsTwoFactorEnabled],[IsLockoutEnabled],[IsPhoneNumberConfirmed],[ShouldChangePasswordOnNextLogin], [IsDeleted], [TenantId])
		OUTPUT [INSERTED].[UserName]
			INTO @InsertedEmployeeNo
	SELECT [S].[EmployeeNo],[S].[EmployeeNo], [P].[FirstName], ISNULL([P].[LastName],'') AS LastName, ISNULL([P].[EMailAddress],''),ISNULL([P].[EMailAddress],''), P.Phone, '', GETDATE(),1,0,0,0,0,0,0,0,1
	FROM [dbo].[secure] AS S
		JOIN [dbo].[Person] AS P
			ON [S].[EmployeeNo] = [P].[Number]
	WHERE [S].[EmployeeNo] NOT IN (SELECT ISNULL(TRY_PARSE([UserName] AS INT),0) FROM [web].[AbpUsers])

	UPDATE [web].[AbpUsers]
	SET TenantId = 1
	WHERE UserName IN (SELECT CAST([EmployeeNo] as nvarchar(256)) FROM @InsertedEmployeeNo)
	AND TenantId IS NULL

	SELECT EmployeeNo AS 'Imported Employees' FROM @InsertedEmployeeNo

    COMMIT TRANSACTION

END TRY
BEGIN CATCH
	DECLARE @Message varchar(MAX) = ERROR_MESSAGE(),
			@Severity int = ERROR_SEVERITY(),
			@State smallint = ERROR_STATE()
	PRINT(@Message)
-- Transaction uncommittable
    IF (XACT_STATE()) = -1
      ROLLBACK TRANSACTION
END CATCH