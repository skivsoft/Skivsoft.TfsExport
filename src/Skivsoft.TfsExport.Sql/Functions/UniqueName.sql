CREATE FUNCTION [dbo].[UniqueName]
(
  @fullName NVARCHAR(100)
)
RETURNS NVARCHAR(50)
AS
BEGIN
  DECLARE @result NVARCHAR(50);
  DECLARE @start INT;
  DECLARE @end INT;

  SET @start = CHARINDEX('<', @fullName);
  SET @end = CHARINDEX('>', @fullName);
  SET @result = SUBSTRING(@fullName, @start + 1, @end - @start - 1);

  RETURN @result
END