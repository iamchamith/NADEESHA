 
CREATE TABLE [dbo].[Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerMessage] [varchar](50) NULL,
	[BookingDate] [datetime] NULL,
	[BookingTime] [time](7) NULL,
	[AdmitUserName] [varchar](50) NULL,
	[VehicleNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TB_BOOKING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Discription] [nvarchar](max) NULL,
 CONSTRAINT [PK_TB_BRANDS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Nic] [varchar](50) NULL,
	[UserEmale] [varchar](50) NULL,
	[RegDate] [datetime] NULL,
	[Url] [varchar](500) NULL,
 CONSTRAINT [PK_TB_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventoryInfomation]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventoryInfomation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Qty] [int] NULL,
	[Type] [int] NULL,
	[RegDate] [datetime] NULL,
	[UserName] [varchar](50) NULL,
 CONSTRAINT [PK_INVENTORY_PROCESS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[Name] [varchar](50) NULL,
	[Discription] [varchar](max) NULL,
	[PriceIn] [float] NULL,
	[PriceOut] [float] NULL,
	[Quantity] [int] NULL,
	[ReorderLevel] [int] NULL,
 CONSTRAINT [PK_TB_ITEMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Labours]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Labours](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Type] [int] NULL,
	[Discription] [nvarchar](max) NULL,
	[UserEmail] [varchar](50) NULL,
	[Nic] [varchar](50) NULL,
 CONSTRAINT [PK_TB_LABOURS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Model]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Model](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NULL,
	[Name] [varchar](50) NULL,
	[Discription] [nvarchar](max) NULL,
 CONSTRAINT [PK_TB_MODELS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](50) NULL,
	[Discription] [varchar](max) NULL,
 CONSTRAINT [PK_TB_TASKS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[State] [int] NULL,
	[Name] [varchar](50) NULL,
	[Nic] [varchar](50) NULL,
 CONSTRAINT [PK_TB_USER] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleID] [varchar](50) NOT NULL,
	[BrandID] [int] NULL,
	[ModelId] [int] NULL,
	[EngineNumber] [varchar](50) NULL,
	[ChassiNumber] [varchar](50) NULL,
	[Discription] [nvarchar](max) NULL,
	[OwnerID] [int] NULL,
	[UserEmail] [varchar](50) NULL,
	[RegDate] [datetime] NULL,
	[Url] [varchar](500) NULL,
 CONSTRAINT [PK_TB_VEHICLE] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleJobs]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleJobs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleNumber] [varchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[IsFinished] [int] NULL,
	[CloseDate] [datetime] NULL,
	[CloseTime] [datetime] NULL,
	[OpenDate] [datetime] NULL,
	[OpenTime] [datetime] NULL,
	[FinalAmount] [float] NULL,
 CONSTRAINT [PK_TB_VEHICLE_JOBS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleJobTaskItem]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleJobTaskItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
	[Discription] [nvarchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[RegDate] [datetime] NULL,
 CONSTRAINT [PK_TB_VEHICLE_JOB_TASK_ITEMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleJobTaskLabour]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleJobTaskLabour](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NULL,
	[LabourId] [int] NULL,
	[Discription] [nvarchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[IsClosed] [int] NULL,
	[OpenDateTime] [datetime] NULL,
	[CloseDateTime] [datetime] NULL,
 CONSTRAINT [PK_TB_VEHICLE_JOB_TASK_LABOURS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleJobTasks]    Script Date: 9/18/2016 9:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleJobTasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[Discription] [nvarchar](max) NULL,
	[UserEmail] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[IsClosed] [int] NULL,
	[TaskCost] [float] NULL,
 CONSTRAINT [PK_TB_VEHICLE_JOB_TASKS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (1, N'ssssss', CAST(0x0000A51F00000000 AS DateTime), CAST(0x07B2141DEF9A0000 AS Time), NULL, N'14-9698')
GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (5, N'kkkkkkkkkkkk', CAST(0x0000A4FB00000000 AS DateTime), CAST(0x07737145D3A60000 AS Time), NULL, N'14-9696')
GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (6, N'ppppppppp', CAST(0x0000A4FA00000000 AS DateTime), CAST(0x078D64D12FA70000 AS Time), NULL, N'14-9696')
GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (7, N'simple', CAST(0x0000A51C00000000 AS DateTime), CAST(0x078D64D12FA70000 AS Time), NULL, N'123-123')
GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (8, N'avaiable to 2015-9-22', CAST(0x0000A51B00000000 AS DateTime), CAST(0x0724DE96436C0000 AS Time), NULL, N'12-58965')
GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (9, N'sdfasdfasdfs', CAST(0x0000A52000000000 AS DateTime), CAST(0x0700930605840000 AS Time), NULL, N'123-123')
GO
INSERT [dbo].[Booking] ([ID], [CustomerMessage], [BookingDate], [BookingTime], [AdmitUserName], [VehicleNumber]) VALUES (10, N'avaiable to 2015-9-22', CAST(0x0000A51F00000000 AS DateTime), CAST(0x0724DE96436C0000 AS Time), NULL, N'12-58965')
GO
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (3, N'MICRO', N'sri lankan')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (4, N'MITSUBISHI', N'MADE IN JAPAN  dfgdfg')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (5, N'BENZE', N'made in german...')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (6, N'hhhhhh', N'hhhh')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (8, N'dddd', N'dddd')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (9, N'554535', N'dddd')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (10, N'nnnn', N'nnnn')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (11, N'google', N'google ')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (12, N'Yahoo', N'this is the test one')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (14, N'YAMAHA BIKE', N'MADE IN JAPAN...')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (16, N'FB', N'FB 123')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (17, N'Yahoo', N'Yahooooo')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (19, N'QQQ', N'sdfg')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (21, N'Volvo', N'German')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (22, N'Nadeesha', N'Google')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (1, N'charitha 12', N'2123123123', N'Gampaha 123', N'charith2@gmail.com', N'charitha 12', N'admin', CAST(0x0000A4C900000000 AS DateTime), N'4997bfd3-3851-4d78-80a0-42261d2f77fa.PNG')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (2, N'ruwan', N'12312312', N'nilwasa', N'ruwan@gmail.com', N'ruwan', N'admin', CAST(0x0000A4D900000000 AS DateTime), NULL)
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (3, N'vvvvv', N'1111111111', N'vvv', N'roshanj100#gmail.com', N'55555555V', N'admin', CAST(0x0000A4E800000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (4, N'roshan', N'0712343455', N'csffsff', N'roshanj100#gmail.com', N'883352335V', N'admin', CAST(0x0000A4F800000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (5, N'Methsika', N'5345454646', N'ddddd', N'roshanj100@gmail.com', N'Methsika', N'admin', CAST(0x0000A4FF00000000 AS DateTime), N'10c9adfe-4b4b-4b33-b68a-ecad4da757af.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (6, N'cccc', N'0712343255', N'ccccc', N'roshanj200#gmail.com', N'654656577V', N'admin', CAST(0x0000A4FF00000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (7, N'gayan perera', N'1213213213', N'gampaha', N'gayan#gmail.com', N'123456456V', N'admin', CAST(0x0000A51100000000 AS DateTime), N'e816d900-2c54-4737-a133-91f5529884ae.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (8, N'danuka', N'1231231231', N'Ragama', N'danuka#gmail.com', N'123123123V', N'admin', CAST(0x0000A51600000000 AS DateTime), N'5d9a102f-4ab5-45fd-b057-52ac0860e2e1.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (9, N'GANGA e', N'3218920205', N'MALABE e', N'gan2ga@gmail.com', N'GANGA e', N'admin', CAST(0x0000A51A00000000 AS DateTime), NULL)
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (12, N'Sunil', N'1231231231', N'Mawanalla', N'sunil@gmail.com', N'Sunil', N'admin', CAST(0x0000A61400000000 AS DateTime), N'74558419-297b-428b-8ce4-2c8d921474e2.PNG')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (13, N'Nadeesha', N'1231231231', N'Wattala ', N'nadeesha@gmail.com', N'Nadeesha', N'admin', CAST(0x0000A61400000000 AS DateTime), N'95cbc5d1-9de2-4337-8102-fbf566561607.PNG')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryInfomation] ON 

GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (4, 4, 77, 1, CAST(0x0000A4F7017AF665 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (5, 4, 45, 1, CAST(0x0000A4F7017B0C44 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (8, 5, 35, 1, CAST(0x0000A4F800C6C0B1 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (10, 7, 40, 1, CAST(0x0000A4F800CBB6F8 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (14, 10, 45, 1, CAST(0x0000A4F800DBA74F AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (15, 10, 6, 1, CAST(0x0000A4F800DBE396 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (16, 14, 100, 2, CAST(0x0000A5140060B111 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (18, 14, 1, 1, CAST(0x0000A51400662D83 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (19, 14, 99, 2, CAST(0x0000A5140068232C AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (20, 14, 100, 2, CAST(0x0000A51600D0888F AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (21, 14, 100, 1, CAST(0x0000A51600D0A59E AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (22, 14, 100, 1, CAST(0x0000A51600D0BE13 AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (23, 14, 100, 2, CAST(0x0000A51600D0E016 AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (24, 14, 100, 2, CAST(0x0000A51600D304F2 AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (25, 14, 200, 2, CAST(0x0000A5160100E857 AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (26, 14, 100, 2, CAST(0x0000A51601014798 AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (27, 14, 200, 2, CAST(0x0000A51601016E4F AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (28, 14, 100, 1, CAST(0x0000A5160101C688 AS DateTime), N'')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (29, 15, 120, 2, CAST(0x0000A51B00D5FB5C AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (30, 13, 20, 2, CAST(0x0000A51F00B6A481 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (31, 15, 90, 2, CAST(0x0000A51F00E9A000 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (32, 15, 100, 2, CAST(0x0000A51F00E9E47E AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (33, 18, 500, 0, CAST(0x0000A61401088C6D AS DateTime), N'admin')
GO
SET IDENTITY_INSERT [dbo].[InventoryInfomation] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (1, 1, N'T-1233', N'Tire', 1233, 1211, NULL, 34)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (4, 1, N'Tire', N'asdf', 123, 123, 0, 300)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (13, 9, N'nutss', N'ssssss', 100, 120, 100, 100)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (15, 3, N'Break oil', N'tick caltex brack oil - 150ml bottel', 120, 12, 8, 100)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (16, 3, N'WWWW', N'wqwqwqw', 12, 112, 0, 122)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (17, 5, N'12312', N'dsfsdf', 12, 32, 0, 1)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (18, 4, N'321-12312', N'BREAKS', 123, 343, 500, 100)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Labours] ON 

GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (1, N'RUWAN PERERA', 1, N'good  sdf', N'admin', N'232323123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (3, N'nalaka', 1, N'best', N'', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (4, N'ruwnn', 2, N'good sdfgdsfg', N'', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (5, N'uuuuuu', 3, N'fdfdsfsf', N'admin', N'883352335V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (7, N'Yashan', 1, N'gampaha', N'', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (8, N'Kerthi Perera', 1, N'lives in Colombo ', N'admin', N'342342323V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (9, N'Ganga Perera', 1, N'sss', N'admin', N'132123123V')
GO
SET IDENTITY_INSERT [dbo].[Labours] OFF
GO
SET IDENTITY_INSERT [dbo].[Model] ON 

GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (1, 2, N'Corolla', N'2012')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (2, 2, N'march', N'good')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (3, 3, N'panda', N'2012')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (4, 4, N'IO', N'littel paero')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (5, 5, N'vvvv', N'vvv')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (6, 1, N'Corolla', N'ddd')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (7, 8, N'kkkk', N'kkk')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (8, 1, N'dddd', N'dddd')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (9, 5, N'xxxxx', N'xxxxx')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (10, 10, N'Aqas', N'made in japan nn')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (11, 15, N'bYKE-5152', N'SIMPLE DISCRIPTION')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (13, 11, N'QWWW fdgdfg', N'SDSD fgdgdfg')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (14, 22, N'151-1212', N'sadfasdfas')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (15, 8, N'EEEEEEEEEEEE', N'dfsf')
GO
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (3, N'oil changing', N'oil changing ssssss dfsdf')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (4, N'Break handle ', N'Break handle ')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (7, N'Painting', N'Painting')
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'admin', N'123', 1, N'admin', N'880240684v')
GO
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'chami@gmail.com', N'123', 2, N'chami priyanwada', N'4667778888V')
GO
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'charitha@gmail.com', N'123', 3, N'Charitha', N'787987987V')
GO
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'dddd@gmail.com', N'123', 3, N'dddd', N'575757575V')
GO
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'roshan@gmail.com', N'456', 0, N'vvvvv', N'889352335V')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'1132323', 3, 3, N'232', N'2323', N'dfdfdfd', 12, N'admin', CAST(0x0000A68400000000 AS DateTime), N'7f3e7546-9dd8-4967-bd23-d50ce630cf6a.PNG')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'12-58965', 15, 11, N'4585475', N'8954125', N'SIMPLE DISCRIPTION', 9, N'admin', CAST(0x0000A51A00000000 AS DateTime), N'c7e36da0-aaea-4601-a473-f492fa1207ca.png')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'123-123', 3, 3, N'123123', N'23123', N'good', 7, N'admin', CAST(0x0000A51100000000 AS DateTime), N'a1a36eef-432b-4d35-990f-bde1478c2fac.PNG')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'250-6754', 11, 13, N'33333455566', N'32324353555', N'', 13, N'admin', CAST(0x0000A51F00000000 AS DateTime), N'588949bd-94e2-4d1e-b29e-52f3b086a25b.gif')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'99-99999', 5, 5, N'123123', N'123123', N'Nadeesha vehicle ', 12, N'admin', CAST(0x0000A61400000000 AS DateTime), N'3236fdee-d008-4149-89ba-f07623a49762.png')
GO
SET IDENTITY_INSERT [dbo].[VehicleJobs] ON 

GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (46, N'123-123', N'admin', 1, NULL, CAST(0x0000A68300B2D009 AS DateTime), CAST(0x0000A68300B2D009 AS DateTime), CAST(0x0000A68300B2D009 AS DateTime), 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (47, N'12-58965', N'admin', 1, NULL, CAST(0x0000A68400FDDF85 AS DateTime), CAST(0x0000A68400FDDF85 AS DateTime), NULL, 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (48, N'1132323', N'admin', 1, NULL, CAST(0x0000A68400FE5EFE AS DateTime), CAST(0x0000A68400FE5EFE AS DateTime), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleJobs] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskItem] ON 

GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (34, 6, 13, 2, 120, NULL, N'admin', CAST(0x0000A6840106A221 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (35, 6, 13, 3, 120, NULL, N'admin', CAST(0x0000A6840107400B AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskItem] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskLabour] ON 

GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (45, 6, 1, N'he is best', N'admin', 1, CAST(0x0000A68401013D49 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (46, 6, 3, N'he is best', N'admin', 1, CAST(0x0000A6840101570F AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskLabour] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTasks] ON 

GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (1, 46, 0, N'service', N'admin', CAST(0x0000A68300000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (2, 46, 1, N'Break handle ', N'admin', CAST(0x0000A68300000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (3, 47, 0, N'Break handle ', N'admin', CAST(0x0000A68400000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (4, 47, 0, N'Break handle ', N'admin', CAST(0x0000A68400000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (5, 48, 0, N'oil changing ssssss dfsdf', N'admin', CAST(0x0000A68400000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (6, 48, 0, N'Break handle ', N'admin', CAST(0x0000A68400000000 AS DateTime), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTasks] OFF
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_TB_CUSTOMER_URL]  DEFAULT ('no.jpg') FOR [Url]
GO
ALTER TABLE [dbo].[InventoryInfomation] ADD  CONSTRAINT [DF_INVENTORY_PROCESS_REG_DATE]  DEFAULT (getdate()) FOR [RegDate]
GO
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_TB_VEHICLE_URL]  DEFAULT ('car.jpg') FOR [Url]
GO
ALTER TABLE [dbo].[VehicleJobs] ADD  CONSTRAINT [DF_TB_VEHICLE_JOBS_FINAL_AMOUNT]  DEFAULT ((0.0)) FOR [FinalAmount]
GO
ALTER TABLE [dbo].[VehicleJobs]  WITH CHECK ADD  CONSTRAINT [FK_VehicleJobs_Vehicle] FOREIGN KEY([VehicleNumber])
REFERENCES [dbo].[Vehicle] ([VehicleID])
GO
ALTER TABLE [dbo].[VehicleJobs] CHECK CONSTRAINT [FK_VehicleJobs_Vehicle]
GO
ALTER TABLE [dbo].[VehicleJobTaskItem]  WITH CHECK ADD  CONSTRAINT [fk_items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[VehicleJobTaskItem] CHECK CONSTRAINT [fk_items]
GO
ALTER TABLE [dbo].[VehicleJobTaskItem]  WITH CHECK ADD  CONSTRAINT [fk_takssss] FOREIGN KEY([TaskId])
REFERENCES [dbo].[VehicleJobTasks] ([ID])
GO
ALTER TABLE [dbo].[VehicleJobTaskItem] CHECK CONSTRAINT [fk_takssss]
GO
ALTER TABLE [dbo].[VehicleJobTaskLabour]  WITH CHECK ADD  CONSTRAINT [fk_laburId] FOREIGN KEY([LabourId])
REFERENCES [dbo].[Labours] ([ID])
GO
ALTER TABLE [dbo].[VehicleJobTaskLabour] CHECK CONSTRAINT [fk_laburId]
GO
ALTER TABLE [dbo].[VehicleJobTasks]  WITH CHECK ADD  CONSTRAINT [fk_jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[VehicleJobs] ([ID])
GO
ALTER TABLE [dbo].[VehicleJobTasks] CHECK CONSTRAINT [fk_jobs]
GO
