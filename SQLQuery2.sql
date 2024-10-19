USE [C:\USERS\INSPI\DOWNLOADS\DATABASEDEMO\DATABASEDEMO\DATABASEDEMO\APP_DATA\MYCOMPANY.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[spGetProduct]
		@flag = 1

SELECT	@return_value as 'Return Value'

GO
