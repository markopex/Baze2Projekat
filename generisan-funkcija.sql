USE [master]
GO

/****** Object:  UserDefinedFunction [dbo].[StatistikaPotrosaca]    Script Date: 6/15/2022 10:55:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[StatistikaPotrosaca] 
(
	@PotrosacId integer
)
RETURNS TABLE
AS
RETURN (
	select p.pot_id, p.naziv, count(Broj) as BrojStrujomera, sum(s.ukupno_kwh) as Ukupno
	from dbo.Strujomer s, dbo.Potrosac p
	where p.POT_ID = s.POTROSAC and p.pot_id = @PotrosacId
	group by POT_ID, naziv
	)
GO


