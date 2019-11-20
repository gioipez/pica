CREATE TABLE [dbo].[ciudad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](4000) NOT NULL,
	[pais] [varchar](4000) NOT NULL,
	[tarifa_ciudad_id] [int] NOT NULL,
 CONSTRAINT [PK_ciudad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ciudad]  WITH CHECK ADD  CONSTRAINT [FK_ciudad_tarifa_ciudad] FOREIGN KEY([tarifa_ciudad_id])
REFERENCES [dbo].[tarifa_ciudad] ([id])
GO

ALTER TABLE [dbo].[ciudad] CHECK CONSTRAINT [FK_ciudad_tarifa_ciudad]
GO


