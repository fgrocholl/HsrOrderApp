USE [HsrOrderApp]
GO

/****** Object:  Table [dbo].[SupplierToProduct]    Script Date: 1/22/2016 4:51:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SupplierToProduct](
	[SupplierToProductId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[AverageLeadTime] [int] NOT NULL,
	[StandardPrice] [money] NOT NULL,
	[LastReceiptCost] [money] NOT NULL,
	[LastReceiptDate] [date] NULL,
	[MinOrderQty] [int] NOT NULL,
	[MaxOrderQty] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_SupplierToProduct] PRIMARY KEY CLUSTERED 
(
	[SupplierToProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SupplierToProduct] ADD  DEFAULT ((0)) FOR [AverageLeadTime]
GO

ALTER TABLE [dbo].[SupplierToProduct] ADD  DEFAULT ((0.00)) FOR [StandardPrice]
GO

ALTER TABLE [dbo].[SupplierToProduct] ADD  DEFAULT ((0.00)) FOR [LastReceiptCost]
GO

ALTER TABLE [dbo].[SupplierToProduct] ADD  DEFAULT ((1)) FOR [MinOrderQty]
GO

ALTER TABLE [dbo].[SupplierToProduct] ADD  DEFAULT ((1)) FOR [MaxOrderQty]
GO

ALTER TABLE [dbo].[SupplierToProduct]  WITH CHECK ADD  CONSTRAINT [FK_SupplierToProduct_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO

ALTER TABLE [dbo].[SupplierToProduct] CHECK CONSTRAINT [FK_SupplierToProduct_Product_ProductId]
GO

ALTER TABLE [dbo].[SupplierToProduct]  WITH CHECK ADD  CONSTRAINT [FK_SupplierToProduct_Supplier_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO

ALTER TABLE [dbo].[SupplierToProduct] CHECK CONSTRAINT [FK_SupplierToProduct_Supplier_SupplierId]
GO

