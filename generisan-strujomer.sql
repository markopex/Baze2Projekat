USE [master]
GO

/****** Object:  Table [dbo].[Strujomer]    Script Date: 6/15/2022 10:55:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Strujomer](
	[BROJ] [int] IDENTITY(1,1) NOT NULL,
	[SNAGA] [decimal](18, 0) NOT NULL,
	[UKUPNO_KWH] [decimal](18, 0) NOT NULL,
	[TIP] [int] NOT NULL,
	[TR_KWH] [decimal](18, 0) NULL,
	[POTROSAC] [int] NOT NULL,
 CONSTRAINT [PK_STRUJOMER] PRIMARY KEY CLUSTERED 
(
	[BROJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Strujomer]  WITH CHECK ADD  CONSTRAINT [Strujomer_fk0] FOREIGN KEY([POTROSAC])
REFERENCES [dbo].[Potrosac] ([POT_ID])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[Strujomer] CHECK CONSTRAINT [Strujomer_fk0]
GO


