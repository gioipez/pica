CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](10) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](4000) NOT NULL,
	[url_imagen] [varchar](50) NOT NULL,
	[fecha_espectaculo] [date] NOT NULL,
	[fecha_llegada] [date] NOT NULL,
	[fecha_salida] [date] NOT NULL,
	[ciudad_id] [int] NOT NULL,
	[tarifa_transporte_id] [int] NOT NULL,
	[tarifa_espectaculo_id] [int] NOT NULL,
	[tarifa_hospedaje_id] [int] NOT NULL,
 CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_ciudad] FOREIGN KEY([ciudad_id])
REFERENCES [dbo].[ciudad] ([id])
GO

ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_ciudad]
GO

ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_tarifa_espectaculo] FOREIGN KEY([tarifa_espectaculo_id])
REFERENCES [dbo].[tarifa_espectaculo] ([id])
GO

ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_tarifa_espectaculo]
GO

ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_tarifa_hospedaje] FOREIGN KEY([tarifa_hospedaje_id])
REFERENCES [dbo].[tarifa_hospedaje] ([id])
GO

ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_tarifa_hospedaje]
GO

ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_tarifa_transporte] FOREIGN KEY([tarifa_transporte_id])
REFERENCES [dbo].[tarifa_transporte] ([id])
GO

ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_tarifa_transporte]
GO
