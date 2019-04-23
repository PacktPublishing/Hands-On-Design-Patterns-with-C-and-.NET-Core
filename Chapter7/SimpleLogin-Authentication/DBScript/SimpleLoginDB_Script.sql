/****** Object:  Table [dbo].[Categories]    Script Date: 4/23/2019 5:47:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/23/2019 5:47:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/23/2019 5:47:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[EmailId] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[SecretKey] [nvarchar](max) NULL,
	[Mobile] [varchar](13) NOT NULL,
	[EmailToken] [nchar](10) NULL,
	[EmailTokenDateTime] [datetime] NULL,
	[OTP] [nchar](10) NULL,
	[OtpDateTime] [datetime] NULL,
	[IsMobileVerified] [bit] NULL,
	[IsEmailVerified] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Roles] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (N'891872e6-5824-4096-ad42-b67408cddba0', N'Fruit', N'All fruits')
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Image], [Price], [CategoryId]) VALUES (N'09c2599e-652a-4807-a0f8-390a146f459b', N'Mango', N'A juicy mango', NULL, CAST(40.00 AS Decimal(18, 2)), N'891872e6-5824-4096-ad42-b67408cddba0')
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Image], [Price], [CategoryId]) VALUES (N'7af8c5c2-fa98-42a0-b4e0-6d6a22fc3d52', N'Apple', N'Red apple', NULL, CAST(100.00 AS Decimal(18, 2)), N'891872e6-5824-4096-ad42-b67408cddba0')
GO
INSERT [dbo].[Products] ([Id], [Name], [Description], [Image], [Price], [CategoryId]) VALUES (N'e2a8d6b3-a1f9-46dd-90bd-7f797e5c3986', N'Orange', N'Fruity oranges', NULL, CAST(35.00 AS Decimal(18, 2)), N'891872e6-5824-4096-ad42-b67408cddba0')
GO
INSERT [dbo].[Users] ([Id], [UserName], [EmailId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [SecretKey], [Mobile], [EmailToken], [EmailTokenDateTime], [OTP], [OtpDateTime], [IsMobileVerified], [IsEmailVerified], [IsActive], [Image], [Roles]) VALUES (N'db38ab09-b499-496a-979f-08d6c745083c', N'AroraG', N'gaurav@gaurav-arora.com', N'Gaurav', N'Arora', 0x683212B0F2F09EF84926A6880BE97EA372D6C9AFCD988DC1EE76983EB42A1736158B1A9E79F73F09B167A777C36C32A2D9DD405F62D46C600CAA604838743D38, 0xC68C1C21F50684E4F8AFC01F8907A953E160B64FD9B6EC9F4515C5B55A17C6D05250E0F9B1D922A270BF1B18D225C3C72DC8DC32B7AF8AC23823170BBDED71556CEE79413605B672AF74BC1D2033A0BC7D28826D56E6E55567FFFC7CFA184E4EC5437C16F03A4ED5470D23757FF7A1AE408FC4FB82F18104B43D99E89286D71B, N'', N'9812345678', N'2         ', CAST(N'2019-04-22T17:14:42.317' AS DateTime), N'1         ', CAST(N'2019-04-22T17:14:42.320' AS DateTime), 0, 0, 1, NULL, NULL)
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
