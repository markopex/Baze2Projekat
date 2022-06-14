-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
DROP FUNCTION IF EXISTS dbo.StatistikaPotrosaca 
go
CREATE FUNCTION dbo.StatistikaPotrosaca 
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
SELECT * FROM dbo.StatistikaPotrosaca(2);
GO