USE [master]
GO

/****** Object:  Table [dbo].[KVAR]    Script Date: 6/15/2022 10:52:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KVAR](
	[BROJ_KV] [int] IDENTITY(1,1) NOT NULL,
	[DATUM_PR] [datetime] NOT NULL,
	[POT_ID] [int] NOT NULL,
	[OPIS] [varchar](255) NOT NULL,
	[DATUM_POPRAVKE] [datetime] NULL,
	[POPRAVIO] [int] NULL,
 CONSTRAINT [PK_KVAR] PRIMARY KEY CLUSTERED 
(
	[BROJ_KV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[KVAR]  WITH CHECK ADD  CONSTRAINT [FK_KVAR_fk1] FOREIGN KEY([POPRAVIO])
REFERENCES [dbo].[Elektricar] ([JMBG])
GO

ALTER TABLE [dbo].[KVAR] CHECK CONSTRAINT [FK_KVAR_fk1]
GO

ALTER TABLE [dbo].[KVAR]  WITH CHECK ADD  CONSTRAINT [KVAR_fk0] FOREIGN KEY([POT_ID])
REFERENCES [dbo].[Potrosac] ([POT_ID])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[KVAR] CHECK CONSTRAINT [KVAR_fk0]
GO

