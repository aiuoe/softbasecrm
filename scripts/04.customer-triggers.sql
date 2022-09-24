/***************************************************************************************************
Procedure:          dbo.CustomerUpdate
Author:             Webcreek
Description:        Trigger creates user in web.AbpUsers table after its creation in dbo.Secure table
****************************************************************************************************
SUMMARY OF CHANGES
Date(yyyy-mm-dd)    Author              Comments
------------------- ------------------- ------------------------------------------------------------
2021-12-30          Webcreek            Creation
***************************************************************************************************/ 
CREATE OR ALTER TRIGGER CustomerUpdate
    ON dbo.Customer
    AFTER UPDATE
    AS
BEGIN
    BEGIN TRY
        BEGIN
            IF ('Prospect' = (SELECT Terms FROM Customer WHERE Number = (SELECT TOP 1 Number FROM inserted)))
                UPDATE dbo.Customer SET AccountTypeId = (SELECT TOP 1 Id FROM web.AccountTypes WHERE IsDefault = 1)
                WHERE Number = (SELECT TOP 1 Number FROM inserted);
            ELSE
                UPDATE dbo.Customer SET AccountTypeId = (SELECT TOP 1 Id FROM web.AccountTypes WHERE IsDefault = 0)
                WHERE Number = (SELECT TOP 1 Number FROM inserted);
        END
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
Procedure:          dbo.CustomerInsert
Author:             Webcreek
Description:        Trigger responsible for updating the AccountTypeId field
                    when inserting a new Customer from Softbase
****************************************************************************************************
SUMMARY OF CHANGES
Date(yyyy-mm-dd)    Author              Comments
------------------- ------------------- ------------------------------------------------------------
2021-12-30          Webcreek            Creation
***************************************************************************************************/ 
CREATE OR ALTER TRIGGER CustomerInsert
    ON dbo.Customer
    AFTER INSERT
    AS
BEGIN
    BEGIN TRY
        BEGIN
            IF ((SELECT TOP 1 IsCreatedFromWebCrm FROM inserted) = 0)
                IF ('Prospect' = (SELECT Terms FROM Customer WHERE Number = (SELECT TOP 1 Number FROM inserted)))
                    UPDATE dbo.Customer SET AccountTypeId = (SELECT TOP 1 Id FROM web.AccountTypes WHERE IsDefault = 1)
                    WHERE Number = (SELECT TOP 1 Number FROM inserted);
                ELSE
                    UPDATE dbo.Customer SET AccountTypeId = (SELECT TOP 1 Id FROM web.AccountTypes WHERE IsDefault = 0)
                    WHERE Number = (SELECT TOP 1 Number FROM inserted);
        END
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
go

