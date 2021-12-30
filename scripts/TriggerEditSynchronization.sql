CREATE OR ALTER TRIGGER sync_edited_user 
ON dbo.Person
AFTER UPDATE 
AS
DECLARE 
@name VARCHAR(128),
@surname VARCHAR(128),
@email VARCHAR(128),
@user_num INT
SELECT @name=FirstName, @surname=LastName, @email=EMailAddress, @user_num=Number  FROM Inserted
BEGIN
UPDATE [web].[AbpUsers] SET Name=@name, Surname=@surname, EmailAddress=@email, NormalizedEmailAddress=@email 
WHERE 
 (
    CASE
        WHEN ISNUMERIC([UserName]) = 1 THEN CONVERT(INT, [UserName])
        ELSE 0
    END) = @user_num
END