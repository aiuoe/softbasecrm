/***************************************************************************************************
Author:             Webcreek
Description:        Process that is responsible for carrying out the
                    initial migration of existing users from the Secure table,
                    it will only take those records that have a relationship
                    with the Person table.
****************************************************************************************************
SUMMARY OF CHANGES
Date(yyyy-mm-dd)    Author              Comments
------------------- ------------------- ------------------------------------------------------------
2021-12-30          Webcreek            Creation
***************************************************************************************************/
BEGIN TRY
    BEGIN TRANSACTION
        DECLARE @InsertedEmployeeNo table
                                    (
                                        EmployeeNo int
                                    );

        INSERT INTO [web].[AbpUsers] ([UserName], [NormalizedUserName], [Name], [Surname], [EmailAddress],
                                      [NormalizedEmailAddress], [PhoneNumber], [Password], [CreationTime], [IsActive],
                                      [AccessFailedCount], [IsEmailConfirmed], [IsTwoFactorEnabled], [IsLockoutEnabled],
                                      [IsPhoneNumberConfirmed], [ShouldChangePasswordOnNextLogin], [IsDeleted],
                                      [TenantId])
        OUTPUT [INSERTED].[UserName]
            INTO @InsertedEmployeeNo
        SELECT [S].[EmployeeNo],
               [S].[EmployeeNo],
               [P].[FirstName],
               ISNULL([P].[LastName], '') AS LastName,
               ISNULL([P].[EMailAddress], ''),
               ISNULL(UPPER([P].[EMailAddress]), ''),
               P.Phone,
               '',
               GETDATE(),
               1,
               0,
               0,
               0,
               0,
               0,
               0,
               0,
               (SELECT Id FROM web.AbpTenants WHERE Name = 'Default')
        FROM [dbo].[secure] AS S
                 JOIN [dbo].[Person] AS P
                      ON [S].[EmployeeNo] = [P].[Number]
        WHERE [S].[EmployeeNo] NOT IN (SELECT ISNULL(TRY_PARSE([UserName] AS INT), 0) FROM [web].[AbpUsers])

        UPDATE [web].[AbpUsers]
        SET TenantId = (SELECT Id FROM web.AbpTenants WHERE Name = 'Default')
        WHERE UserName IN (SELECT CAST([EmployeeNo] as nvarchar(256)) FROM [dbo].[Secure])
          AND TenantId IS NULL

        SELECT EmployeeNo AS 'Imported Employees' FROM @InsertedEmployeeNo
    COMMIT TRANSACTION

END TRY
BEGIN CATCH
    DECLARE @Message varchar(MAX) = ERROR_MESSAGE(),
        @Severity int = ERROR_SEVERITY(),
        @State smallint = ERROR_STATE()
    PRINT (@Message)
    IF (XACT_STATE()) = -1
        ROLLBACK TRANSACTION
END CATCH