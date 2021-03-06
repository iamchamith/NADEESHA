USE [Nadeesha2]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 9/28/2016 5:17:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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
/****** Object:  Table [dbo].[Brands]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[InventoryInfomation]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[Items]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[Labours]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[Model]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[Tasks]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[Vehicle]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobs]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobTaskItem]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobTaskLabour]    Script Date: 9/28/2016 5:17:58 AM ******/
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
/****** Object:  Table [dbo].[VehicleJobTasks]    Script Date: 9/28/2016 5:17:58 AM ******/
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
SET IDENTITY_INSERT [dbo].[Brands] ON 

GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (2, N'MITSUBISHI', N'MITSUBISHI JAPAN')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (4, N'NISSAN', N'NISSAN JAPAN')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (5, N'TOYOTA', N'TOYOTA JAPAN')
GO
INSERT [dbo].[Brands] ([ID], [Name], [Discription]) VALUES (6, N'MICRO', N'MICRO SRI LANKA')
GO
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (1, N'NADEESHA', N'1231231231', N'COLOMBO', N'nadeesha@gmail.com', N'123123123V', N'admin', CAST(0x0000A68500000000 AS DateTime), N'c9d3ce5a-2e14-4491-bf95-ba6d0b632f97.jpg')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (3, N'ROSHAN', N'1231231231', N'GAMPAHA', N'roshan@gmail.com', N'231231231V', N'admin', CAST(0x0000A68500000000 AS DateTime), N'26241353-0c2b-4cb3-bc48-285706db0de8.gif')
GO
INSERT [dbo].[Customer] ([ID], [Name], [Phone], [Address], [Email], [Nic], [UserEmale], [RegDate], [Url]) VALUES (5, N'CHAMITH', N'2131231231', N'GAMPAHA', N'chamith@gmail.com', N'342342342V', N'admin', CAST(0x0000A68500000000 AS DateTime), N'b9144eda-4090-451f-a708-e40905258c70.png')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[InventoryInfomation] ON 

GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (1, 3, 10000, 0, CAST(0x0000A685014CF222 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (2, 4, 8989, 0, CAST(0x0000A685014D1701 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (3, 2, 2001, 0, CAST(0x0000A685014D2309 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (4, 5, 989, 0, CAST(0x0000A685014D3B19 AS DateTime), N'admin')
GO
INSERT [dbo].[InventoryInfomation] ([ID], [ItemID], [Qty], [Type], [RegDate], [UserName]) VALUES (5, 3, 500, 1, CAST(0x0000A68501548EE2 AS DateTime), N'admin')
GO
SET IDENTITY_INSERT [dbo].[InventoryInfomation] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (2, 9, N'Tire 12''', N'Tire 12''', 90, 100, 2001, 20)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (3, 1, N'Nails 98''', N'Nails 98''', 80, 100, 9500, 10)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (4, 1, N'Nails 88''', N'Nails 88''', 80, 100, 8989, 10)
GO
INSERT [dbo].[Items] ([ID], [CategoryId], [Name], [Discription], [PriceIn], [PriceOut], [Quantity], [ReorderLevel]) VALUES (5, 4, N'Tire 50''', N'Tire 50''', 12, 20, 989, 50)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Labours] ON 

GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (1, N'NADEESHA', 1, N'BIT STUDENT', N'admin', N'123123123v')
GO
INSERT [dbo].[Labours] ([ID], [Name], [Type], [Discription], [UserEmail], [Nic]) VALUES (2, N'MAWAN', 2, N'MAWAN ATAPATTU', N'admin', N'323232323v')
GO
SET IDENTITY_INSERT [dbo].[Labours] OFF
GO
SET IDENTITY_INSERT [dbo].[Model] ON 

GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (2, 5, N'VITZ', N'VITZ DISCRIPTION')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (3, 4, N'NAVARA', N'NAVARA DISCRIPTION')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (4, 2, N'MONTERO', N'')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (5, 2, N'IO', N'')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (6, 6, N'PANDA', N'')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (7, 6, N'CROSS', N'')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (8, 6, N'REXTON', N'')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (9, 5, N'LITEACE', N'LITEACE DISCRIPTION')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (10, 5, N'TOWNACE', N'TOWNACE DISCRIPTION')
GO
INSERT [dbo].[Model] ([ID], [BrandId], [Name], [Discription]) VALUES (11, 5, N'AUQA', N'AUQA DISCRIPTION')
GO
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (2, N'CHANGE ENGINE OIL', N'CHANGE ENGINE OIL')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (3, N'WASH', N'WASH')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (4, N'CHANGE TIRES', N'CHANGE TIRES')
GO
INSERT [dbo].[Tasks] ([ID], [TaskName], [Discription]) VALUES (5, N'PAINTING ', N'PAINTING BODY')
GO
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
INSERT [dbo].[User] ([Email], [Password], [State], [Name], [Nic]) VALUES (N'admin', N'123', 1, N'Admin', N'78978798V')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'12-45645', 5, 2, N'789696', N'98969545', N'GOOD CONDITION ', 1, N'admin', CAST(0x0000A68500000000 AS DateTime), N'38d6a556-1290-4f07-8c80-e4bf3ef2492b.jpg')
GO
INSERT [dbo].[Vehicle] ([VehicleID], [BrandID], [ModelId], [EngineNumber], [ChassiNumber], [Discription], [OwnerID], [UserEmail], [RegDate], [Url]) VALUES (N'12-98989', 2, 4, N'121', N'5465', N'GOOD CONDITION ', 5, N'admin', CAST(0x0000A68500000000 AS DateTime), N'542810b7-ae13-4c1c-90ea-a68c93e174a2.png')
GO
SET IDENTITY_INSERT [dbo].[VehicleJobs] ON 

GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (1, N'12-45645', N'admin', 2, CAST(0x0000A68E00674736 AS DateTime), CAST(0x0000A68E00674736 AS DateTime), CAST(0x0000A685013DBFBB AS DateTime), NULL, 23)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (2, N'12-45645', N'admin', 2, CAST(0x0000A68E00672890 AS DateTime), CAST(0x0000A68E00672890 AS DateTime), CAST(0x0000A68E005D0F48 AS DateTime), NULL, 23)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (3, N'12-98989', N'admin', 2, CAST(0x0000A68E0065D535 AS DateTime), CAST(0x0000A68E0065D535 AS DateTime), CAST(0x0000A68E00655FAC AS DateTime), NULL, 0)
GO
INSERT [dbo].[VehicleJobs] ([ID], [VehicleNumber], [UserEmail], [IsFinished], [CloseDate], [CloseTime], [OpenDate], [OpenTime], [FinalAmount]) VALUES (4, N'12-45645', N'admin', 1, NULL, CAST(0x0000A68E00693225 AS DateTime), CAST(0x0000A68E00693225 AS DateTime), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[VehicleJobs] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskItem] ON 

GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (1, 6, 2, 100, 100, NULL, N'admin', CAST(0x0000A6850154F4BE AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskItem] ([ID], [TaskId], [ItemId], [Quantity], [Price], [Discription], [UserEmail], [RegDate]) VALUES (3, 10, 2, 4, 100, NULL, N'admin', CAST(0x0000A68E0060AC17 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskItem] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskLabour] ON 

GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (3, 6, 1, N'HE IS BEST', N'admin', 2, CAST(0x0000A685014BE15B AS DateTime), CAST(0x0000A68E00000000 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (4, 6, 2, N'HE IS BEST', N'admin', 2, CAST(0x0000A685014BF4E8 AS DateTime), CAST(0x0000A68E00000000 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (6, 10, 1, N'', N'admin', 2, CAST(0x0000A68E00608F53 AS DateTime), CAST(0x0000A68E00000000 AS DateTime))
GO
INSERT [dbo].[VehicleJobTaskLabour] ([ID], [TaskId], [LabourId], [Discription], [UserEmail], [IsClosed], [OpenDateTime], [CloseDateTime]) VALUES (7, 10, 2, N'', N'admin', 2, CAST(0x0000A68E00609837 AS DateTime), CAST(0x0000A68E00000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTaskLabour] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleJobTasks] ON 

GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (6, 1, 3, N'WASH', N'admin', CAST(0x0000A68500000000 AS DateTime), 2, 0)
GO
INSERT [dbo].[VehicleJobTasks] ([ID], [JobId], [TaskId], [Discription], [UserEmail], [Date], [IsClosed], [TaskCost]) VALUES (10, 2, 3, N'WASH', N'admin', CAST(0x0000A68E00000000 AS DateTime), 2, 0)
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
ALTER TABLE [dbo].[InventoryInfomation]  WITH CHECK ADD  CONSTRAINT [fk_item_inventory] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ID])
GO
ALTER TABLE [dbo].[InventoryInfomation] CHECK CONSTRAINT [fk_item_inventory]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [fk_model_brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([ID])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [fk_model_brand]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [fk_vehicle_owner] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [fk_vehicle_owner]
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
ALTER TABLE [dbo].[VehicleJobTaskLabour]  WITH CHECK ADD  CONSTRAINT [fk_taskid_labarar_eee] FOREIGN KEY([TaskId])
REFERENCES [dbo].[VehicleJobTasks] ([ID])
GO
ALTER TABLE [dbo].[VehicleJobTaskLabour] CHECK CONSTRAINT [fk_taskid_labarar_eee]
GO
ALTER TABLE [dbo].[VehicleJobTasks]  WITH CHECK ADD  CONSTRAINT [fk_jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[VehicleJobs] ([ID])
GO
ALTER TABLE [dbo].[VehicleJobTasks] CHECK CONSTRAINT [fk_jobs]
GO
