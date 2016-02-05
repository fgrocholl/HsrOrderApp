USE [HsrOrderApp]
GO

/****** Object:  Table [dbo].[Suppliers]    Script Date: 1/22/2016 4:26:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY (1, 1) NOT NULL,
	[SupplierName] [nvarchar](255) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
	[CreditRating] [smallint] NOT NULL,
	[PreferredSupplierFlag] [bit] NOT NULL,
	[ActiveFlag] [bit] NOT NULL,
	[PurchasingWebServiceURL] [varchar](255) NOT NULL,
	[Version] [timestamp] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

