CREATE TABLE [dbo].[customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[phone_number] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[credit_card_type_id] [int] NULL,
	[credit_card_number] [varchar](50) NULL,
	[status_id] [int] NOT NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [FK_customer_credit_card_type] FOREIGN KEY([credit_card_type_id])
REFERENCES [dbo].[credit_card_type] ([id])
GO

ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [FK_customer_credit_card_type]
GO

ALTER TABLE [dbo].[customer]  WITH CHECK ADD  CONSTRAINT [FK_customer_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([id])
GO

ALTER TABLE [dbo].[customer] CHECK CONSTRAINT [FK_customer_status]
GO
