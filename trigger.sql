CREATE TRIGGER dbo.NovaOcitavanjeStrujomera
ON dbo.Ocitavanje
AFTER INSERT
				@Strujomer integer, 
				@Kwh integer;

		DECLARE NovaOcitavanjeKursor CURSOR FOR
		SELECT id, STRUJOMER, KWH
		FROM inserted;
		FETCH NEXT FROM NovaOcitavanjeKursor
		INTO @Id, @Strujomer, @Kwh
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
		DEALLOCATE NovaOcitavanjeKursor;