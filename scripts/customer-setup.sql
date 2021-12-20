BEGIN
    DECLARE @i int
    DECLARE @CurrentCustomerNumber varchar(100)
    DECLARE @CurrentTerms varchar(100)
    DECLARE @numrows int
    DECLARE @CustomerTable TABLE
                           (
                               idx            smallint Primary Key IDENTITY (1,1),
                               CustomerNumber varchar(100),
                               Terms          nvarchar(255)
                           )

    INSERT @CustomerTable
    SELECT Number, Terms
    FROM Customer;

    SET @i = 1
    SET @numrows = (SELECT COUNT(*)
                    FROM @CustomerTable)
    IF @numrows > 0
        BEGIN TRY
            WHILE (@i <= (SELECT MAX(idx) FROM @CustomerTable))
                BEGIN
                    SET @CurrentCustomerNumber = (SELECT CustomerNumber FROM @CustomerTable WHERE idx = @i)
                    SET @CurrentTerms = (SELECT Terms FROM @CustomerTable WHERE idx = @i)

                    IF (@CurrentTerms = 'Prospect')
                        UPDATE dbo.Customer SET AccountTypeId = (SELECT Id FROM web.AccountTypes WHERE IsDefault = 1) WHERE Number = @CurrentCustomerNumber
                    ELSE
                        UPDATE dbo.Customer SET AccountTypeId = (SELECT Id FROM web.AccountTypes WHERE IsDefault = 0) WHERE Number = @CurrentCustomerNumber
                    
                    SET @i = @i + 1
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
END



CREATE TRIGGER CustomerUpdate
    ON Customer
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


CREATE TRIGGER CustomerInsert
    ON Customer
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

