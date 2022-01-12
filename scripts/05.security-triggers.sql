/***************************************************************************************************
Procedure:          dbo.SecureInsert
Author:             Webcreek
Description:        Trigger creates user in web.AbpUsers table after its creation/update in dbo.Secure table
****************************************************************************************************
SUMMARY OF CHANGES
Date(yyyy-mm-dd)    Author              Comments
------------------- ------------------- ------------------------------------------------------------
2021-12-30          Webcreek            Creation
***************************************************************************************************/ 
CREATE OR ALTER TRIGGER SecureInsert
    ON dbo.Secure
    AFTER UPDATE
    AS
BEGIN
    BEGIN TRY
        INSERT INTO [web].[AbpUsers] ([UserName], [NormalizedUserName], [Name], [Surname], [EmailAddress],
                                      [NormalizedEmailAddress], [PhoneNumber], [Password], [CreationTime], [IsActive],
                                      [AccessFailedCount], [IsEmailConfirmed], [IsTwoFactorEnabled], [IsLockoutEnabled],
                                      [IsPhoneNumberConfirmed], [ShouldChangePasswordOnNextLogin], [IsDeleted],
                                      [TenantId])
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
        WHERE [S].EmployeeNo = (SELECT TOP 1 EmployeeNo FROM inserted)
        AND [S].EmployeeNo NOT IN (SELECT ISNULL(TRY_PARSE([UserName] AS INT), 0) FROM [web].[AbpUsers])
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT @ErrorMessage = ERROR_MESSAGE(),
               @ErrorSeverity = ERROR_SEVERITY(),
               @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;

GO


/***************************************************************************************************
Procedure:          dbo.PersonUpdate
Author:             Webcreek
Description:        Trigger edits user information in web.AbpUsers table when it's 
                    changed in dbo.Person table
****************************************************************************************************
SUMMARY OF CHANGES
Date(yyyy-mm-dd)    Author              Comments
------------------- ------------------- ------------------------------------------------------------
2021-12-30          Webcreek            Creation
***************************************************************************************************/  
CREATE OR ALTER TRIGGER PersonUpdate
    ON dbo.Person
    AFTER UPDATE
    AS
    DECLARE
        @name        VARCHAR(128),
        @surname     VARCHAR(128),
        @email       VARCHAR(128),
        @user_number INT
    SELECT @name = FirstName, @surname = LastName, @email = EMailAddress, @user_number = Number
    FROM Inserted
BEGIN
    UPDATE [web].[AbpUsers]
    SET Name=@name,
        Surname=@surname,
        EmailAddress=@email,
        NormalizedEmailAddress=UPPER(@email)
    WHERE (
              CASE
                  WHEN ISNUMERIC([UserName]) = 1 THEN CONVERT(INT, [UserName])
                  ELSE 0
                  END) = @user_number
END