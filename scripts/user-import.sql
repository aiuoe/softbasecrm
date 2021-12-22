USE SBCRMDb
GO

BEGIN TRY
	BEGIN TRANSACTION
    DECLARE @InsertedEmployeeNo table(EmployeeNo int);

	INSERT INTO [web].[AbpUsers] ([UserName],[NormalizedUserName],[Name],[Surname], [EmailAddress],[NormalizedEmailAddress], [PhoneNumber], [Password],[CreationTime],[IsActive],[AccessFailedCount],[IsEmailConfirmed],[IsTwoFactorEnabled],[IsLockoutEnabled],[IsPhoneNumberConfirmed],[ShouldChangePasswordOnNextLogin], [IsDeleted])
		OUTPUT [inserted].[UserName]
			INTO @InsertedEmployeeNo
	SELECT [S].[EmployeeNo],[S].[EmployeeNo], [P].[FirstName], ISNULL([P].[LastName],'') AS LastName, ISNULL([P].[EMailAddress],''),ISNULL([P].[EMailAddress],''), P.Phone, S.[Password], GETDATE(),1,0,0,0,0,0,0,0
	FROM [dbo].[secure] AS s
		JOIN dbo.Person AS p
			ON s.EmployeeNo = p.Number

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
