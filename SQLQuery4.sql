
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
/****** Object:  Table [dbo].[Brands]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[InventoryInfomation]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[Items]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[Labours]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[Model]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[Tasks]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[Vehicle]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobs]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobTaskItem]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobTaskLabour]    Script Date: 5/24/2016 7:14:08 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobTasks]    Script Date: 5/24/2016 7:14:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleJobTasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NULL,
	[TaskId] [int] NULL,
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
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (1, N'Toyota', N'toyota aa')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (2, N'NISSAN', N'japan nissan')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (3, N'MICRO', N'sri lankan')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (4, N'MITSUBISHI', N'MADE IN JAPAN ')
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
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (11, N'asdfsadf', N'adffff')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (12, N'dsafsadfasdf', N'this is the test one')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (13, N'kkk', N'')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (14, N'YAMAHA BIKE', N'MADE IN JAPAN...')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (15, N'YAMAHA', N'MADE IN JAPAN')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (1, N'charitha', N'01452121', N'Gampaha', N'charitha#gmail.com', N'123123123V', N'admin', CAST(0x0000A4C900000000 AS DateTime), N'2c8b61ab-7f7a-4d2b-934e-128577bd3840.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (2, N'ruwan', N'12312312', N'asdf', N'ruwan#gmail.com', N'45612346V', N'admin', CAST(0x0000A4D900000000 AS DateTime), N'cc2ddf34-ba39-424e-92e5-ccb596cd3c3b.JPG')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (3, N'vvvvv', N'1111111111', N'vvv', N'roshanj100#gmail.com', N'55555555V', N'admin', CAST(0x0000A4E800000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (4, N'roshan', N'0712343455', N'csffsff', N'roshanj100#gmail.com', N'883352335V', N'admin', CAST(0x0000A4F800000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (5, N'ddddd', N'5345454646', N'ddddd', N'roshanj100#gmail.com', N'665484858V', N'admin', CAST(0x0000A4FF00000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (6, N'cccc', N'0712343255', N'ccccc', N'roshanj200#gmail.com', N'654656577V', N'admin', CAST(0x0000A4FF00000000 AS DateTime), N'no.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (7, N'gayan perera', N'1213213213', N'gampaha', N'gayan#gmail.com', N'123456456V', N'admin', CAST(0x0000A51100000000 AS DateTime), N'e816d900-2c54-4737-a133-91f5529884ae.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (8, N'danuka', N'1231231231', N'Ragama', N'danuka#gmail.com', N'123123123V', N'admin', CAST(0x0000A51600000000 AS DateTime), N'5d9a102f-4ab5-45fd-b057-52ac0860e2e1.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (9, N'GANGA', N'0718920205', N'MALABE', N'ganga#gmail.com', N'880240684v', N'admin', CAST(0x0000A51A00000000 AS DateTime), N'3b9ebf5a-488e-4305-8784-cb34ecd24803.jpg')
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
SET IDENTITY_INSERT [dbo].[InventoryInfomation] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (1, 1, N'T-123', N'Tire', 123, 123, 0, 0)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (2, 1, N'ABC', N'ddd', 34343, 50, 30, 500)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (4, 1, N'Tire', N'asdf', 123, 123, 0, 300)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (13, 9, N'nutss', N'ssssss', 100, 120, 100, 100)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (14, 4, N'12-232', N'google', 123, 123, 1790, 123)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (15, 3, N'Break oil', N'tick caltex brack oil - 150ml bottel', 120, 250, 8, 100)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Labours] ON 

GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (1, N'RUWAN', 3, N'good', N'', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (2, N'HASHAN', 1, N'simple text', N'admin', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (3, N'nalaka', 1, N'best', N'', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (4, N'ruwnn', 2, N'good sdfgdsfg', N'', N'123123123V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (5, N'uuuuuu', 3, N'fdfdsfsf', N'admin', N'883352335V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (6, N'ttttt', 2, N'sffff', N'admin', N'677899000V')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (7, N'Yashan', 1, N'gampaha', N'', N'123123123V')
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
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (10, 1, N'Aqas', N'made in japan')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (11, 15, N'bYKE-5152', N'SIMPLE DISCRIPTION')
GO
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (1, N'service', N'service')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (2, N'change tire', N'change all tires')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (3, N'oil changing', N'oil changing ssssss')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (4, N'nnn', N'nnn')
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
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'roshan@gmail.com', N'456', 4, N'vvvvv', N'883352335V')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'12-58965', 15, 11, N'4585475', N'8954125', N'SIMPLE DISCRIPTION', 9, N'admin', CAST(0x0000A51A00000000 AS DateTime), N'c7e36da0-aaea-4601-a473-f492fa1207ca.png')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'123-123', 3, 3, N'123123', N'23123', N'good', 1, N'admin', CAST(0x0000A51100000000 AS DateTime), N'ffe25d59-3eb7-49b5-8291-defce8df8981.png')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'250-6754', 1, 6, N'33333455566', N'32324353555', N'', 5, N'admin', CAST(0x0000A51F00000000 AS DateTime), N'588949bd-94e2-4d1e-b29e-52f3b086a25b.gif')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'QQ-6290', 3, 3, N'1524535387', N'53454654756', N'', 4, N'admin', CAST(0x0000A51F00000000 AS DateTime), N'e3c21caf-7027-48d9-a527-ba9e31b3b180.gif')
GO
SET IDENTITY_INSERT [dbo].[VehicleJobs] ON 

GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (33, N'123-123', N'', 2, CAST(0x0000A51100000000 AS DateTime), CAST(0x0000A51100000000 AS DateTime), CAST(0x0000A51100000000 AS DateTime), CAST(0x0000A51100000000 AS DateTime), 3685)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (34, N'123-123', N'', 2, CAST(0x0000A51100000000 AS DateTime), CAST(0x0000A51100000000 AS DateTime), CAST(0x0000A51100000000 AS DateTime), CAST(0x0000A51100000000 AS DateTime), 11050)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (35, N'123-123', N'admin', 2, CAST(0x0000A51600000000 AS DateTime), CAST(0x0000A51600000000 AS DateTime), CAST(0x0000A51400000000 AS DateTime), CAST(0x0000A51400000000 AS DateTime), 14750)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (36, N'12-58965', N'admin', 2, CAST(0x0000A51B00000000 AS DateTime), CAST(0x0000A51B00000000 AS DateTime), CAST(0x0000A51B00000000 AS DateTime), CAST(0x0000A51B00000000 AS DateTime), 19780)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (37, N'123-123', N'admin', 2, CAST(0x0000A52000000000 AS DateTime), CAST(0x0000A52000000000 AS DateTime), CAST(0x0000A52000000000 AS DateTime), CAST(0x0000A52000000000 AS DateTime), 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (38, N'123-123', N'admin', 2, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A52000000000 AS DateTime), CAST(0x0000A52000000000 AS DateTime), 500)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (39, N'123-123', N'admin', 2, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 8976)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (40, N'12-58965', N'admin', 2, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 8976)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (41, N'12-58965', N'admin', 2, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (42, N'12-58965', N'admin', 2, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (43, N'', N'admin', 1, NULL, NULL, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (44, N'123-123', N'admin', 1, NULL, NULL, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (45, N'12-58965', N'admin', 1, NULL, NULL, CAST(0x0000A51F00000000 AS DateTime), CAST(0x0000A51F00000000 AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleJobs] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskItem] ON 

GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (14, 18, 4, 10, 123, N'change all tires', N'', CAST(0x0000A51100F9AA10 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (15, 18, 13, 10, 120, N'change all tires', N'', CAST(0x0000A51100F9F060 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (16, 20, 4, 50, 123, N'change all tires', N'', CAST(0x0000A511011D1860 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (17, 21, 13, 10, 120, N'oil changing ssssss', N'', CAST(0x0000A511011D5EB0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (19, 23, 2, 5, 50, N'change all tires', N'', CAST(0x0000A514004BCE40 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (20, 25, 14, 10, 123, N'change all tires', N'admin', CAST(0x0000A51B00D5AF20 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (21, 25, 15, 10, 250, N'change all tires', N'admin', CAST(0x0000A51B00D5F570 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (22, 26, 14, 100, 123, N'oil changing ssssss', N'admin', CAST(0x0000A51B00D5F570 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (23, 29, 4, 3, 123, N'change all tires', N'admin', CAST(0x0000A52000D6C860 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (24, 31, 2, 10, 50, N'change all tires', N'admin', CAST(0x0000A51F00E13840 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (25, 32, 4, 12, 123, N'oil changing ssssss', N'admin', CAST(0x0000A51F00E4CA50 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (26, 35, 4, 5, 123, N'change all tires', N'admin', CAST(0x0000A51F00E7CFC0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (27, 36, 15, 50, 250, N'change all tires', N'admin', CAST(0x0000A51F00EA0240 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (28, 38, 15, 7, 250, N'change all tires', N'admin', CAST(0x0000A51F00EF3A30 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (29, 36, 2, 50, 50, N'change all tires', N'admin', CAST(0x0000A51F010E89D0 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskItem] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskLabour] ON 

GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (22, 19, 1, N'change tire', N'', 1, CAST(0x0000A51100F963C0 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (23, 20, 1, N'this is runwan', N'', 1, CAST(0x0000A511011C8BC0 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (24, 20, 2, N'this is runwan', N'', 1, CAST(0x0000A511011CD210 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (25, 21, 2, N'this is runwan', N'', 1, CAST(0x0000A511011CD210 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (26, 23, 1, N'for change tires', N'admin', 2, CAST(0x0000A514003C6CC0 AS DateTime), CAST(0x0000A51600BF2980 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (27, 23, 2, N'google doodle', N'', 2, CAST(0x0000A514003DCC50 AS DateTime), CAST(0x0000A514004B41A0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (28, 23, 3, N'must alert for this task', N'admin', 2, CAST(0x0000A51600C41B20 AS DateTime), CAST(0x0000A51600C4EE10 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (30, 24, 1, N'kjhkjh', N'admin', 2, CAST(0x0000A51600C57AB0 AS DateTime), CAST(0x0000A51600C57AB0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (31, 25, 1, N'do this ', N'admin', 2, CAST(0x0000A51B00D52280 AS DateTime), CAST(0x0000A51B00D6C860 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (32, 26, 2, N'do this', N'admin', 2, CAST(0x0000A51B00D568D0 AS DateTime), CAST(0x0000A51B00D70EB0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (33, 26, 1, N'do this ruwan', N'admin', 2, CAST(0x0000A51B00D568D0 AS DateTime), CAST(0x0000A51B00D70EB0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (34, 29, 2, N'vfdgdf', N'admin', 2, CAST(0x0000A52000D6C860 AS DateTime), CAST(0x0000A52000D70EB0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (35, 31, 2, N'vhgvfh', N'admin', 2, CAST(0x0000A51F00E0ABA0 AS DateTime), CAST(0x0000A51F00E1C4E0 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (37, 32, 3, N'', N'admin', 2, CAST(0x0000A51F00E25180 AS DateTime), CAST(0x0000A51F00E5E390 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (39, 33, 1, N'hghghg', N'admin', 1, CAST(0x0000A51F00E2DE20 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (40, 32, 2, N'ggfgfg', N'admin', 2, CAST(0x0000A51F00E43DB0 AS DateTime), CAST(0x0000A51F00E5E390 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (41, 34, 5, N'sdfdsfdfgf', N'admin', 1, CAST(0x0000A51F00E48400 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (42, 34, 2, N'fygfhg', N'admin', 1, CAST(0x0000A51F00E48400 AS DateTime), NULL)
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (43, 35, 2, N'', N'admin', 2, CAST(0x0000A51F00E74320 AS DateTime), CAST(0x0000A51F00E81610 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (44, 36, 2, N'', N'admin', 2, CAST(0x0000A51F010DFD30 AS DateTime), CAST(0x0000A51F010FE960 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskLabour] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTasks] ON 

GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (18, 33, 4, N'change all tires', N'', CAST(0x0000A51100000000 AS DateTime), 2, 1255)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (19, 33, 3, N'oil changing ssssss', N'', CAST(0x0000A51100000000 AS DateTime), 2, 0)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (20, 34, 2, N'change all tires', N'', CAST(0x0000A51100000000 AS DateTime), 2, 2500)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (21, 34, 3, N'oil changing ssssss', N'', CAST(0x0000A51100000000 AS DateTime), 2, 1200)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (23, 35, 2, N'change all tires', N'', CAST(0x0000A51400000000 AS DateTime), 2, 2500)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (24, 35, 3, N'oil changing ssssss', N'admin', CAST(0x0000A51600000000 AS DateTime), 2, 12000)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (25, 36, 2, N'change all tires', N'admin', CAST(0x0000A51B00000000 AS DateTime), 2, 2500)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (26, 36, 3, N'oil changing ssssss', N'admin', CAST(0x0000A51B00000000 AS DateTime), 2, 1250)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (27, 37, 2, N'change all tires', N'admin', CAST(0x0000A52000000000 AS DateTime), 2, 0)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (28, 37, 3, N'oil changing ssssss', N'admin', CAST(0x0000A52000000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (29, 38, 2, N'change all tires', N'admin', CAST(0x0000A52000000000 AS DateTime), 2, 2100)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (30, 38, 3, N'oil changing ssssss', N'admin', CAST(0x0000A52000000000 AS DateTime), 2, 0)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (32, 39, 3, N'oil changing ssssss', N'admin', CAST(0x0000A51F00000000 AS DateTime), 2, 7500)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (35, 40, 2, N'change all tires', N'admin', CAST(0x0000A51F00000000 AS DateTime), 2, 12500)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (36, 42, 2, N'change all tires', N'admin', CAST(0x0000A51F00000000 AS DateTime), 2, 5550)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (37, 43, 2, N'change all tires', N'admin', CAST(0x0000A51F00000000 AS DateTime), 1, NULL)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (38, 44, 2, N'change all tires', N'admin', CAST(0x0000A51F00000000 AS DateTime), 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTasks] OFF
GO
