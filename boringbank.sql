CREATE DATABASE [boringbank]
GO
USE [boringbank]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12/01/2010 20:12:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON
INSERT [dbo].[Client] ([Id], [Name]) VALUES (1, N'Jan Bazodanowy')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (2, N'Wiktor Beznadziejski')
INSERT [dbo].[Client] ([Id], [Name]) VALUES (3, N'Julia Tamteż')
SET IDENTITY_INSERT [dbo].[Client] OFF
/****** Object:  Table [dbo].[Transaction]    Script Date: 12/01/2010 20:12:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[CreditClient] [int] NOT NULL,
	[DebitClient] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[ValueDate] [date] NOT NULL,
	[Currency] [nvarchar](4) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON
INSERT [dbo].[Transaction] ([Id], [Title], [CreditClient], [DebitClient], [Amount], [ValueDate], [Currency]) VALUES (1, N'Faktura DB1', 1, 2, 100.0000, CAST(0x7D330B00 AS Date), N'PLN')
INSERT [dbo].[Transaction] ([Id], [Title], [CreditClient], [DebitClient], [Amount], [ValueDate], [Currency]) VALUES (2, N'DBTEST', 1, 3, 200.0000, CAST(0x7E330B00 AS Date), N'PLN')
INSERT [dbo].[Transaction] ([Id], [Title], [CreditClient], [DebitClient], [Amount], [ValueDate], [Currency]) VALUES (3, N'Funky', 2, 1, 10.0000, CAST(0x9A330B00 AS Date), N'EUR')
INSERT [dbo].[Transaction] ([Id], [Title], [CreditClient], [DebitClient], [Amount], [ValueDate], [Currency]) VALUES (4, N'Kieszonkowe', 3, 2, 123.0000, CAST(0x9A330B00 AS Date), N'USD')
INSERT [dbo].[Transaction] ([Id], [Title], [CreditClient], [DebitClient], [Amount], [ValueDate], [Currency]) VALUES (5, N'TESTY', 2, 3, 222.0000, CAST(0x88330B00 AS Date), N'EEK')
SET IDENTITY_INSERT [dbo].[Transaction] OFF
/****** Object:  Table [dbo].[Beneficiaries]    Script Date: 12/01/2010 20:12:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiaries](
	[ClientId] [int] NOT NULL,
	[BeneficiaryId] [int] NOT NULL,
 CONSTRAINT [PK_Beneficiaries_1] PRIMARY KEY CLUSTERED 
(
	[BeneficiaryId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Beneficiaries] ([ClientId], [BeneficiaryId]) VALUES (3, 1)
INSERT [dbo].[Beneficiaries] ([ClientId], [BeneficiaryId]) VALUES (1, 2)
INSERT [dbo].[Beneficiaries] ([ClientId], [BeneficiaryId]) VALUES (3, 2)
INSERT [dbo].[Beneficiaries] ([ClientId], [BeneficiaryId]) VALUES (1, 3)
INSERT [dbo].[Beneficiaries] ([ClientId], [BeneficiaryId]) VALUES (2, 3)
/****** Object:  ForeignKey [FK_BenClientId_ClientId]    Script Date: 12/01/2010 20:12:26 ******/
ALTER TABLE [dbo].[Beneficiaries]  WITH CHECK ADD  CONSTRAINT [FK_BenClientId_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Beneficiaries] CHECK CONSTRAINT [FK_BenClientId_ClientId]
GO
/****** Object:  ForeignKey [FK_BenId_ClientID]    Script Date: 12/01/2010 20:12:26 ******/
ALTER TABLE [dbo].[Beneficiaries]  WITH CHECK ADD  CONSTRAINT [FK_BenId_ClientID] FOREIGN KEY([BeneficiaryId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Beneficiaries] CHECK CONSTRAINT [FK_BenId_ClientID]
GO
/****** Object:  ForeignKey [FK_CreditClient]    Script Date: 12/01/2010 20:12:26 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_CreditClient] FOREIGN KEY([CreditClient])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_CreditClient]
GO
/****** Object:  ForeignKey [FK_DebitClient]    Script Date: 12/01/2010 20:12:26 ******/
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_DebitClient] FOREIGN KEY([DebitClient])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_DebitClient]
GO
