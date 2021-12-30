CREATE OR ALTER TRIGGER SecureInsert --Trigger creates user in web.AbpUsers table after its creation in dbo.Secure table
ON dbo.Secure
AFTER INSERT
AS BEGIN
DECLARE 
@user_num INT
SELECT @user_num = EmployeeNo FROM inserted
INSERT INTO [web].[AbpUsers] ([UserName],[NormalizedUserName],[Name],[Surname], [EmailAddress],[NormalizedEmailAddress], [PhoneNumber],[Password],[CreationTime],[IsActive],[AccessFailedCount],[IsEmailConfirmed],[IsTwoFactorEnabled],[IsLockoutEnabled],[IsPhoneNumberConfirmed],[ShouldChangePasswordOnNextLogin], [IsDeleted], [TenantId])
	SELECT [S].[EmployeeNo],[S].[EmployeeNo], [P].[FirstName], ISNULL([P].[LastName],'') AS LastName, ISNULL([P].[EMailAddress],''),ISNULL([P].[EMailAddress],''), P.Phone, '', GETDATE(),1,0,0,0,0,0,0,0,1
	FROM [dbo].[secure] AS S
		JOIN [dbo].[Person] AS P
			ON [S].[EmployeeNo] = [P].[Number]
WHERE 
 (
    CASE
        WHEN ISNUMERIC([S].EmployeeNo) = 1 THEN CONVERT(INT, [S].EmployeeNo)
        ELSE 0
    END) = @user_num
END;

GO

CREATE OR ALTER TRIGGER PersonUpdate --Trigger edits user information in web.AbpUsers teble when it's changed in dbo.Person table
ON dbo.Person
AFTER UPDATE 
AS
DECLARE 
@name VARCHAR(128),
@surname VARCHAR(128),
@email VARCHAR(128),
@user_number INT
SELECT @name=FirstName, @surname=LastName, @email=EMailAddress, @user_number=Number  FROM Inserted
BEGIN
UPDATE [web].[AbpUsers] SET Name=@name, Surname=@surname, EmailAddress=@email, NormalizedEmailAddress=@email 
WHERE 
 (
    CASE
        WHEN ISNUMERIC([UserName]) = 1 THEN CONVERT(INT, [UserName])
        ELSE 0
    END) = @user_number
END
