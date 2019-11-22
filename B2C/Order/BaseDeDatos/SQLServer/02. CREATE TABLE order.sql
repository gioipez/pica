CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[status_id] [int] NOT NULL,
	[comments] [varchar](4000) NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([id])
GO

ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_status]
GO
