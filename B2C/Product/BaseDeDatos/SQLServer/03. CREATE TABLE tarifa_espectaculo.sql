CREATE TABLE [dbo].[tarifa_espectaculo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](4000) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_tarifa_espectaculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
