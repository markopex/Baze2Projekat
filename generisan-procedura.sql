USE [master]
GO

/****** Object:  StoredProcedure [dbo].[GenerisiRacune]    Script Date: 6/15/2022 10:55:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GenerisiRacune]
	-- Add the parameters for the stored procedure here
	@Period integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @broj int,
			@potrosac int,
			@potrosnja int;

    -- Insert statements for procedure here
	

	DECLARE OcitavanjaKursor CURSOR FOR
	SELECT broj, potrosac, kwh
	from [dbo].[Ocitavanje] o, [dbo].[Strujomer] s
	where s.Broj = o.Strujomer and o.Period = @Period;

	OPEN OcitavanjaKursor

	FETCH NEXT FROM OcitavanjaKursor
	INTO @broj, @potrosac, @potrosnja

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF NOT EXISTS (
			 SELECT 1
			 FROM [dbo].[Racun] racun
			 WHERE strujomer_broj = @broj and period = @Period
			 )
		-- dodaj racun
		INSERT INTO [dbo].[Racun]
           ([STRUJOMER_BROJ]
		   ,[POTROSAC]
           ,[DATUM]
           ,[IZNOS]
           ,[KWH]
           ,[PERIOD])
		 VALUES
			   (@broj
			   ,@potrosac
			   ,GETDATE()
			   ,@potrosnja * 5.243
			   ,@potrosnja
			   ,@Period)

		
		FETCH NEXT FROM OcitavanjaKursor
		INTO @broj, @potrosac, @potrosnja

	END
	CLOSE OcitavanjaKursor;
	DEALLOCATE OcitavanjaKursor;

END
GO


