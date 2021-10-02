USE [SecretDb_Localization];
GO

IF OBJECT_ID('dbo.Languages', 'U') IS NOT NULL
BEGIN
    --# Clear [dbo].[Languages] and insert into it initial values
	TRUNCATE TABLE [dbo].[Languages];

	INSERT INTO [dbo].[Languages](Id, Timestamp,LanguageCode,CommonName,SelfName) VALUES('8AD8D0ED-752A-4CA2-8559-8BAE32B225A8', CAST(CURRENT_TIMESTAMP AS TIMESTAMP), 'EN', 'English', 'English');
	INSERT INTO [dbo].[Languages](Id, Timestamp,LanguageCode,CommonName,SelfName) VALUES('38C104DC-6A5D-4D8D-8819-5EC2CCAAA425', CAST(CURRENT_TIMESTAMP AS TIMESTAMP), 'RU', 'Russian', 'Русский');
END;