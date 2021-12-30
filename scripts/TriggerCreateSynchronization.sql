CREATE OR ALTER TRIGGER sync_create_user
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
UPDATE [web].[AbpUsers]
SET TenantId = 1
WHERE
(
 CASE
        WHEN ISNUMERIC(UserName) = 1 THEN CONVERT(INT, UserName)
        ELSE 0
    END) = @user_num
AND TenantId IS NULL
END