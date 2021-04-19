# repositoryPatternwithDI

It is by using Unity Container.

in nuget package manager console just paste 

" **Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r** "

for updating package

and the table structure will be

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[productDetails](
	[sNo] [bigint] NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[ProductDetails] [nvarchar](250) NULL,
	[Price] [money] NULL,
	[ProductType] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[sNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

