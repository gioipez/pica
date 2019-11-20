CREATE TABLE [dbo].[address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[street] [varchar](50) NOT NULL,
	[address_type] [varchar](50) NOT NULL,
	[zip] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[country] [varchar](50) NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[address]  WITH CHECK ADD  CONSTRAINT [FK_address_customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[customer] ([id])
GO

ALTER TABLE [dbo].[address] CHECK CONSTRAINT [FK_address_customer]
GO
