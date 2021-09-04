USE SecretDb_Localization;
GO

IF OBJECT_ID('dbo.uspLocalize', 'P') IS NOT NULL  
    DROP PROCEDURE dbo.uspLocalize;  
GO

CREATE PROCEDURE dbo.uspLocalize
(
	@LanguageId UNIQUEIDENTIFIER,
	@KeyString NVARCHAR(max),
	@Value NVARCHAR(max)
)
AS 
BEGIN
	IF NOT EXISTS (SELECT TOP(1) Id FROM Languages WHERE Id = @LanguageId) OR @KeyString IS NULL OR @Value IS NULL
		THROW 50000 , 'Some arguments is not represented or incorrect!', 1;
	IF EXISTS (SELECT TOP(1) * FROM [dbo].[LocalizedString] WHERE KeyString = @KeyString AND LanguageId = @LanguageId)
	BEGIN
		UPDATE [dbo].[LocalizedString] SET Timestamp=CAST(CURRENT_TIMESTAMP AS TIMESTAMP), Value = @Value WHERE KeyString = @KeyString AND LanguageId = @LanguageId;
	END	ELSE
	BEGIN
		INSERT  [dbo].[LocalizedString](Id, Timestamp, LanguageId, KeyString, Value) VALUES(NEWID(), CAST(CURRENT_TIMESTAMP AS TIMESTAMP), @LanguageId, @KeyString, @Value);
	END
END