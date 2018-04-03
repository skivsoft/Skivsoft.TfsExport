CREATE FUNCTION [dbo].[DisplayName]
(
  @fullName NVARCHAR(100)
)
RETURNS NVARCHAR(50)
AS
BEGIN
  DECLARE @result NVARCHAR(50);
  DECLARE @index INT;

  SET @index = CHARINDEX('<', @fullName);
  SET @result = SUBSTRING(@fullName, 1, @index - 2);

  RETURN @result
END