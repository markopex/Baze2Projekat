USE [master]
GO

/****** Object:  Trigger [dbo].[NovaOcitavanjeStrujomera]    Script Date: 6/15/2022 10:47:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[NovaOcitavanjeStrujomera]
ON [dbo].[Ocitavanje]
AFTER INSERT
AS
BEGIN
	IF(ROWCOUNT_BIG() > 0)
	BEGIN
		DECLARE @Id integer,
				@Strujomer integer, 
				@Kwh integer;

		DECLARE NovaOcitavanjeKursor CURSOR FOR
		SELECT id, STRUJOMER, KWH
		FROM inserted;
		OPEN NovaOcitavanjeKursor
		FETCH NEXT FROM NovaOcitavanjeKursor
		INTO @Id, @Strujomer, @Kwh
		WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE @StanjeKwh int;
			SELECT @StanjeKwh = Ukupno_Kwh FROM dbo.Strujomer WHERE broj = @Strujomer;
			DECLARE @Potroseno int = @Kwh - @StanjeKwh;
			
			
			UPDATE dbo.Strujomer 
			SET Ukupno_kwh = @Kwh
			WHERE Broj = @Strujomer;

			UPDATE dbo.Ocitavanje
			SET Kwh = @Potroseno
			WHERE Strujomer = @Strujomer and Id = @Id;


			FETCH NEXT FROM NovaOcitavanjeKursor
			INTO @Id, @Strujomer, @Kwh
		END
		CLOSE NovaOcitavanjeKursor;
		DEALLOCATE NovaOcitavanjeKursor;
	END
END
--GO
GO

ALTER TABLE [dbo].[Ocitavanje] ENABLE TRIGGER [NovaOcitavanjeStrujomera]
GO


