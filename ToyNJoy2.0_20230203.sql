USE [master]
GO
/****** Object:  Database [ToyNJoy2.0]    Script Date: 2023/2/3 20:00:53 ******/
CREATE DATABASE [ToyNJoy2.0]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToyNJoy2.0', FILENAME = N'E:\MyProject\SQLServer\ToyNJoy2.0.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToyNJoy2.0_log', FILENAME = N'E:\MyProject\SQLServer\ToyNJoy2.0_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ToyNJoy2.0] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToyNJoy2.0].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToyNJoy2.0] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToyNJoy2.0] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToyNJoy2.0] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToyNJoy2.0] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToyNJoy2.0] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET RECOVERY FULL 
GO
ALTER DATABASE [ToyNJoy2.0] SET  MULTI_USER 
GO
ALTER DATABASE [ToyNJoy2.0] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToyNJoy2.0] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToyNJoy2.0] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToyNJoy2.0] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToyNJoy2.0] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToyNJoy2.0] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ToyNJoy2.0', N'ON'
GO
ALTER DATABASE [ToyNJoy2.0] SET QUERY_STORE = OFF
GO
USE [ToyNJoy2.0]
GO

/****** Object:  User [NT AUTHORITY\NETWORK SERVICE]    Script Date: 2023/2/3 20:00:53 ******/
/*CREATE USER [NT AUTHORITY\NETWORK SERVICE] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo]
GO*/
/****** Object:  User [LAPTOP-QMUSL2MS\16973]    Script Date: 2023/2/3 20:00:53 ******/
/*CREATE USER [LAPTOP-QMUSL2MS\16973] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [LAPTOP-QMUSL2MS\16973]
GO*/

/****** Object:  Table [dbo].[Administrator]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sa_name] [varchar](50) NOT NULL,
	[sa_password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_System] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friend]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[id] [varchar](200) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[friend_name] [varchar](100) NOT NULL,
	[nickname] [varchar](max) NULL,
	[state] [int] NOT NULL,
	[group_id] [int] NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friend_Group]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend_Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[group_name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Friend_Group_User_name] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[product_id] [int] NOT NULL,
	[join_time] [datetime] NOT NULL,
	[last_time] [datetime] NOT NULL,
	[total_hours] [int] NOT NULL,
	[group_id] [int] NULL,
 CONSTRAINT [PK_library] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Library_Group]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library_Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[group_name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_varchar(32)] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [int] NOT NULL,
	[title] [varchar](max) NOT NULL,
	[text] [varchar](max) NOT NULL,
	[page_view] [int] NOT NULL,
	[commend] [int] NOT NULL,
	[trample] [int] NOT NULL,
	[update_time] [datetime] NOT NULL,
	[image] [varchar](max) NULL,
	[product_id] [int] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News_Type]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News_Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_News_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [varchar](255) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[total_amount] [float] NOT NULL,
	[state] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[alipay_data] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Item]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [varchar](255) NOT NULL,
	[product_id] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [int] NOT NULL,
	[name] [varchar](max) NOT NULL,
	[image] [varchar](max) NOT NULL,
	[price] [float] NOT NULL,
	[intro] [varchar](max) NOT NULL,
	[age_grading] [int] NOT NULL,
	[developers] [varchar](max) NOT NULL,
	[publisher] [varchar](max) NOT NULL,
	[release_date] [datetime] NOT NULL,
	[browse] [int] NOT NULL,
	[purchases] [int] NOT NULL,
	[discount] [float] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_hardware_requirements]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_hardware_requirements](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Product_id] [int] NOT NULL,
	[OS] [varchar](max) NOT NULL,
	[OS_] [varchar](max) NOT NULL,
	[CPU] [varchar](max) NOT NULL,
	[CPU_] [varchar](max) NOT NULL,
	[RAM] [varchar](max) NOT NULL,
	[RAM_] [varchar](max) NOT NULL,
	[GPU] [varchar](max) NOT NULL,
	[GPU_] [varchar](max) NOT NULL,
	[DirectX] [varchar](max) NOT NULL,
	[DirectX_] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Game_hardware_requirements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Photo_Gallery]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Photo_Gallery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[image] [varchar](max) NOT NULL,
	[join_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Product_Photo_Gallery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_type]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Product_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shopping_Car]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping_Car](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[product_id] [int] NOT NULL,
 CONSTRAINT [PK_Shopping_Car] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_info]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[signature] [varchar](max) NOT NULL,
	[wrapper_image] [varchar](max) NOT NULL,
	[gender] [varchar](max) NULL,
	[birthday] [date] NULL,
	[IDCard] [varchar](max) NULL,
	[address] [varchar](max) NULL,
	[phone] [varchar](max) NULL,
 CONSTRAINT [PK_User_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[username] [varchar](100) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[email] [varchar](max) NOT NULL,
	[nickname] [varchar](max) NOT NULL,
	[Lv] [int] NOT NULL,
	[virtual_image] [varchar](max) NOT NULL,
	[register_time] [date] NOT NULL,
	[state] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wish_List]    Script Date: 2023/2/3 20:00:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wish_List](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[product_id] [int] NOT NULL,
	[serial_namber] [int] NOT NULL,
	[join_date] [date] NOT NULL,
 CONSTRAINT [PK_Wish_List] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([id], [sa_name], [sa_password]) VALUES (1, N'huangjunxi', N'0120')
SET IDENTITY_INSERT [dbo].[Administrator] OFF
GO
SET IDENTITY_INSERT [dbo].[Library] ON 

INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (25, N'huangjunxi', 2, CAST(N'2020-03-10T02:37:31.667' AS DateTime), CAST(N'2023-01-27T14:20:17.000' AS DateTime), 18, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (26, N'huangjunxi', 5, CAST(N'2020-03-10T02:37:31.667' AS DateTime), CAST(N'2023-01-18T10:44:34.000' AS DateTime), 4, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (27, N'huangjunxi', 4, CAST(N'2020-03-27T13:31:09.767' AS DateTime), CAST(N'2023-01-18T10:44:36.000' AS DateTime), 1, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (28, N'huangjunxi', 3, CAST(N'2020-03-27T16:05:23.207' AS DateTime), CAST(N'2023-01-18T10:44:38.000' AS DateTime), 1, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (1030, N'huangjunxi', 1, CAST(N'2021-12-27T17:30:26.000' AS DateTime), CAST(N'2023-01-18T10:44:40.000' AS DateTime), 1, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (1031, N'huangjunxi', 6, CAST(N'2021-12-27T17:43:19.000' AS DateTime), CAST(N'2021-12-27T17:43:19.000' AS DateTime), 0, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (1032, N'huangjunxi', 19, CAST(N'2021-12-27T17:47:57.000' AS DateTime), CAST(N'2021-12-27T17:47:57.000' AS DateTime), 0, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (1033, N'huangjunxi', 29, CAST(N'2021-12-29T08:15:10.000' AS DateTime), CAST(N'2021-12-29T08:15:10.000' AS DateTime), 0, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (1034, N'huangjunxi', 18, CAST(N'2021-12-29T08:17:18.000' AS DateTime), CAST(N'2021-12-29T08:17:18.000' AS DateTime), 0, NULL)
INSERT [dbo].[Library] ([id], [user_name], [product_id], [join_time], [last_time], [total_hours], [group_id]) VALUES (1035, N'huangjunxi', 12, CAST(N'2023-02-03T17:58:14.260' AS DateTime), CAST(N'2023-02-03T17:58:20.227' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[Library] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([id], [type_id], [title], [text], [page_view], [commend], [trample], [update_time], [image], [product_id]) VALUES (2, 2, N'1月1日宣布2019 Steam奖获奖名单', N'我们很兴奋地宣布2019 Steam奖的获奖名单!以下是Steam社区投票选出的2019年最受欢迎的游戏和开发者。有八个类别需要做出很多艰难的决定;这就是为什么我们让你，我们的伟大的社区，去做!你不仅是一个值得信赖的、充满激情的、有品位的人，而且，我们不能相信自己能挑出一个最喜欢的。我们真的爱他们所有人!在今年的颁奖典礼上，我们要求大家把目光集中在过去12个月发行的影片上。我们很高兴呈现2019年最好的新版本，以及你选择的爱的劳动奖:今年更新的最佳游戏。那么闲话少说,??????:这是您的2019蒸汽奖!祝贺!', 178, 17, 1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), NULL, 2)
INSERT [dbo].[News] ([id], [type_id], [title], [text], [page_view], [commend], [trample], [update_time], [image], [product_id]) VALUES (4, 2, N'2019年12月31日最后一次投票的机会在蒸汽奖-获奖者明天宣布!', N'今天是2019 Steam大奖投票的最后一天了!最后一次投票的机会在蒸汽奖-获奖者明天宣布!请务必在太平洋时间12月31日上午9点前投票，然后在太平洋时间上午10点再来查看获胜者名单!
既然假期会很有压力，你的家人会逼得你发疯，让你更爱他们，那就把这当成是向你所爱的人表达感激的最后一种方式吧!虽然在这种情况下，我们所说的“所爱之人”指的是你在2019年最喜欢的全新或更新的Steam游戏。
现在就全部八个类别投票!然后坐下来，放松，并等待2019蒸汽奖得主的大揭牌明天上午10点太平洋。然后，去享受你应得的漫长的冬季小睡吧，我们将在2020年看到你更多的蒸汽乐趣!', 3, 1, 0, CAST(N'2019-12-31T00:00:00.000' AS DateTime), NULL, 4)
INSERT [dbo].[News] ([id], [type_id], [title], [text], [page_view], [commend], [trample], [update_time], [image], [product_id]) VALUES (5, 2, N'现在AvailLast机会为蒸汽秋季销售蒸汽奖提名!', N'2019年Steam秋季特卖将于24小时后结束。*不要错过Steam产品目录上的优惠信息。2019 Steam奖项的公开提名即将结束。一定要提名，并帮助确定所有八个类别的最终入围者。在12月，你可以在Steam冬季销售中为每个类别的获胜者投票。点击这里了解更多Steam奖项信息。*截止时间:12月3日，星期二上午10点。如果你喜欢今年Steam秋季特卖会的头版艺术，并想要一个桌面壁纸版本，你可以在下面下载它们，以及2019 Steam大奖的类别作品。下载蒸汽秋季销售和蒸汽奖2019壁纸', 2, 0, 0, CAST(N'2019-12-03T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[News] ([id], [type_id], [title], [text], [page_view], [commend], [trample], [update_time], [image], [product_id]) VALUES (8, 2, N'2019年Steam秋季特卖会继续!', N'2019年Steam秋季销售将持续至网络星期一*，在Steam目录上有大量交易。

除了Steam秋季销售，还有2019 Steam大奖的公开提名。
你的8个类别的提名将有助于确定每个类别的最终入围者——你可以获得个人资料XP和参与徽章。
在12月，你可以在Steam冬季销售中为每个类别的获胜者投票。
点击这里了解更多Steam奖项信息。

* 12月3日(星期二)上午10点太平洋时间截止。', 5, 6, 3, CAST(N'2019-11-30T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[News] ([id], [type_id], [title], [text], [page_view], [commend], [trample], [update_time], [image], [product_id]) VALUES (9, 2, N'2019年Steam秋季销售Steam大奖来了!', N'2019年Steam秋季特卖会现在已经开始了，从Steam目录到“黑色星期五”和“网络星期一”都有优惠活动。每天登录网站，就能在首页看到新的特色图书，以及个性化的推荐。除了数以千计的伟大的游戏在折扣，加入我们在我们的第四个年度Steam大奖，并提名你最喜欢的游戏在所有八个类别，并赚取个人资料XP和徽章参与!你的提名将有助于确定每个类别的最终入围者。在12月，你可以在Steam冬季销售中为每个类别的获胜者投票。点击这里了解更多Steam奖项信息。* 12月3日(星期二)上午10点太平洋时间截止。', 4, 0, 0, CAST(N'2019-11-27T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[News_Type] ON 

INSERT [dbo].[News_Type] ([id], [type_name]) VALUES (1, N'更新')
INSERT [dbo].[News_Type] ([id], [type_name]) VALUES (2, N'其他')
SET IDENTITY_INSERT [dbo].[News_Type] OFF
GO
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020315404640229', N'huangjunxi', 248, 0, CAST(N'2023-02-03T15:40:05.833' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020315415141780', N'huangjunxi', 248, 0, CAST(N'2023-02-03T15:41:13.677' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020315425442528', N'huangjunxi', 248, 0, CAST(N'2023-02-03T15:42:02.540' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020315433743466', N'huangjunxi', 248, 0, CAST(N'2023-02-03T15:43:51.260' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020315435643472', N'huangjunxi', 248, 0, CAST(N'2023-02-03T15:43:45.343' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020315441644127', N'huangjunxi', 248, 0, CAST(N'2023-02-03T15:44:07.520' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020317267826136', N'huangjunxi', 248, 0, CAST(N'2023-02-03T17:26:42.130' AS DateTime), NULL)
INSERT [dbo].[Order] ([id], [username], [total_amount], [state], [create_date], [alipay_data]) VALUES (N'2023020317513251901', N'huangjunxi', 248, 1, CAST(N'2023-02-03T17:51:01.193' AS DateTime), N'{"app_id":"2016101700709747","auth_app_id":"2016101700709747","charset":"UTF-8","method":"alipay.trade.page.pay.return","out_trade_no":"2023020317513251901","seller_id":"2088102180022561","sign":"MYiw3Ar9rehY3126SM23NtBjZvG2eHh5OHi0TRxGNzf7bTJ9wt2Lk+ArLTuxSkaAWJEamaP2ZlFjC+d8YhgjEU0smBjSCIlMshq+wvsQQo7NNvPFKToqCBS5uxMSz5emDQqDctYN6XGJ8hJJTz8qZZqS+cx60ZufsYwamhffiWBdSsjC5/AoS/fEoHKH1Jsnq2B+DJOWmS12TW5kLyKaX7SHA4FXZzq2Pzx0Tz9RDQMkn9Rj0vzG5ahCmGRU3U0LX8rcNqK8U9DAegJtIk8Wu+H1OXUgNxPgLAlgM+96Ql3Y9p14gzMaLtpPiuqGeTwz0gobQarbRXPdC0BGIoN7dg==","sign_type":"RSA2","timestamp":"2023-02-03 17:51:27","total_amount":"248.00","trade_no":"2023020322001422470502629320","version":"1.0"}')
GO
SET IDENTITY_INSERT [dbo].[Order_Item] ON 

INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (36, N'2023020315404640229', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (37, N'2023020315415141780', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (38, N'2023020315425442528', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (39, N'2023020315435643472', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (40, N'2023020315433743466', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (41, N'2023020315441644127', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (42, N'2023020317267826136', 12, 248)
INSERT [dbo].[Order_Item] ([id], [order_id], [product_id], [price]) VALUES (43, N'2023020317513251901', 12, 248)
SET IDENTITY_INSERT [dbo].[Order_Item] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (1, 1, N'Transport Fever 2', N'TransportFever2.jpg', 125, N'《狂热运输 2》为经典的交通模拟类型游戏打造了新的标杆。在指挥地面、水域和空中各类交通线路的过程中，一个全新的世界将在您的面前徐徐展开。长路漫漫，惟愿进步与繁荣相伴！

为人们提供必需的交通基础设施，利用交通服务赚取财富。看，火车在轨道疾驰，公交和货车在马路飞奔，船只在水域穿行，飞机冲上云霄。运载人们前去工作或是享受生活，将他们所需的货物运送到市镇，而您将成为当地市镇欣欣向荣的幕后功臣。运送原材料和商品，大力发展经济。从1850年到当今世界，您都可以投身其中，亲手解决最严峻的物流业难题，打造全球无可匹敌的交通帝国！

自由模式为您提供海量的创意可能，情景模式模式将重写跨越三个大陆的运输历史。《狂热运输 2》将提供来自欧洲、美国和亚洲的200多种交通工具，模型精细到每一个细节；内置的地图编辑器让您可以重塑三个不同气候带的地形。最后必须要提到的游戏亮点，就是逼真的运输和经济模拟系统以及全方位支持模组。', 0, N'
Urban Games', N'
Good Shepherd Entertainment', CAST(N'2019-12-11T00:00:00.000' AS DateTime), 10, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (2, 1, N'Red Dead Redemption 2', N'RedDeadRedemption2.jpg', 249, N'Rockstar Games 出品的史诗般的开放世界游戏 Red Dead Redemption 2 不仅好评如潮，也是主机世代评分最高的游戏，PC 版更是添加了全新故事模式内容，并进行了视觉效果升级等各项改进。
美国，1899 年。当警察开始打击残余亡命之徒的帮派时，蛮荒的西部时代终将迎来最后的黄昏。亚瑟·摩根和范德林德帮众在黑水镇一次抢劫行动中遭遇了始料不及的意外，他们不得不逃离这个西部小镇。联邦侦探和全国顶尖的赏金猎人在他们的身后穷追不舍，亚瑟一行人必须在广袤蛮荒的美国腹地上四处劫掠、挣扎求生。而帮派内部的矛盾分化日渐加深，摆在亚瑟面前的将是他无法避免的抉择：究竟是选择自己的理想，还是选择效忠于抚养了自己的帮派。

Red Dead Redemption 2 PC 版借助全新图形和技术改进以增强沉浸感，并充分利用了电脑强大的性能，使这个庞大、丰富而细致的世界的每个角落都栩栩如生。包括更广的渲染距离；为改良的昼夜照明而提供的更高质量的全局照明和环境光遮蔽；改良的反射和所有距离提供更深、更高分辨率的阴影；细分曲面处理树木纹理并改善草地和毛皮纹理，使所有植物和动物都更加逼真。

Red Dead Redemption 2 PC 版还提供 HDR 支持，可在高端显示设置上以 4K 及更高分辨率运行、多显示器配置、宽屏配置、更快的帧速率及更多。

Red Dead Redemption 2 PC 版也囊括了额外的故事模式内容，包括悬赏任务、帮派藏身处、武器及更多；还可免费享受在 Red Dead 在线模式中与众多玩家共享逼真世界，包含所有此前发布的改进内容及最新的内容更新，为您提供完整的在线游戏体验，包括像赏金猎人、商贩和收藏家这样的边境专家职业及更多。 

这款游戏是有史以来最受好评的游戏之一，已荣获超过 175 项年度游戏奖项且获得超过 250 个满分评价，而 Red Dead Redemption 2 PC 版便是体验此游戏的最佳方式。

安装游戏、激活游戏、进行在线游戏需有 Rockstar Games Launcher 并登录 Rockstar Social Club（需年满十三岁）账户；游戏激活、在线模式游玩、定期资格验证需要网络连接；需要安装的软件包括 Rockstar Games Launcher、DirectX、Microsoft Visual C++ 2015-2019 Redistributables (x64)、Chromium Embedded Framework、 Rockstar Games Social Club Framework 以及身份验证软件，该软件可识别某些硬件属性，以进行权利、数字版权管理、许可证实施、支持、 系统及其他目的。

需有网络连接和 Rockstar Games Launcher；每项购买仅能在一个 Rockstar Games Social Club 账户（需年满十三岁）上注册；每个 Rockstar Games Social Club 账户在任何时候仅允许一个 PC 登录；购买项目不可转让；Rockstar Games Social Club 账户不可转让。

系统需求会因为陆续推出之下载内容与提供的程序变更而有所改变。如需最新兼容性信息，请洽硬件制造商和参阅 support.rockstargames.com/zh/。部分系统组件，例如移动芯片组、集???和 AGP 显卡等可能不兼容。未于上方列出的规格，游戏发行商可能不支持。 ', 0, N'Rockstar Games', N'Rockstar Games', CAST(N'2019-12-06T00:00:00.000' AS DateTime), 213, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (3, 1, N'太吾绘卷', N'TAIWUHUIJUAN.jpg', 68, N'在《太吾绘卷》的世界中，你除了需要扮演神秘的“太吾氏传人”，还将以不同的处世立场——或善、或恶、或中庸——投身于纷繁复杂的江湖之中。你不仅可以拜访世界各地的武林门派，学习种类繁多的功法绝艺；还可以与人义结金兰，或结下血海深仇；不仅可以兴建自己的村庄，经营各种产业；还可以与自己的挚爱生儿育女，缘定三生；直到你终于面对太吾氏的宿敌，决定世界的命运！', 0, N'ConchShip Games', N'ConchShip Games', CAST(N'2018-09-28T00:00:00.000' AS DateTime), 30, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (4, 1, N'Destiny 2', N'Destiny2.jpg', 0, N'进入命运2的免费游戏世界来体验第一人称射击战斗，探索我们太阳系的隐秘并向你的强大的敌人们释放元素的怒火。今天下载就可以创建你的守护者，收集独特的武器、护甲和道具来个性化你的外观和游戏风格。独自或与其他朋友一起体验命运2的影片故事，加入其他守护者一起进行合作任务，或与其他守护者在PvP模式中进行竞争。你决定你的传奇。', 16, N'
Bungie', N'
Bungie', CAST(N'2019-10-01T00:00:00.000' AS DateTime), 890, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (5, 1, N'中国式家长', N'ZHONGGUOSHIJIAZHANG.jpg', 36, N'《中国式家长》是一款现实主义的模拟游戏，游戏模拟从出生到成人的整段过程，探讨孩子与家长之间的关系。', 0, N'墨鱼玩游戏', N'
Coconut Island Games', CAST(N'2018-09-29T00:00:00.000' AS DateTime), 20, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (6, 1, N'Dead by Daylight', N'DeadbyDaylight.jpg', 82, N'死亡并不是解脱。

Dead by Daylight是一款多人(4vs1) 恐怖生存游戏。游戏由其中一人扮演野蛮杀手，另外四人扮演逃生者。逃生者们将试图从野蛮杀手手中奋力逃脱，从而让自己免去被残忍折磨并杀害的危险。

逃生者们将以第三视角进行游戏，其优势在于对周围环境拥有更开阔的视野。而杀手则将以第一视角进行游戏并且更着眼于眼前的猎物。

逃生者的目标固然就是在不被杀手抓到的情况下安全的逃离杀戮场——不过相信我，这件事做起来真的没有听上去这么容易，特别是每当周围环境有所变化的时候。
', 18, N'
Behaviour Digital Inc.', N'
Behaviour Digital Inc.', CAST(N'2016-06-14T00:00:00.000' AS DateTime), 18, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (7, 1, N'Cyberpunk 2077', N'Cyberpunk2077.jpg', 298, N'《赛博朋克 2077》是一款开放世界动作冒险游戏，故事发生在夜之城。这是一座五光十色的大都会，权力更迭和身体改造是不变的主题。您扮演一名野心勃勃的雇佣兵：V，正在追寻一种独一无二的植入体。只要得到它，就能掌握获得永生的关键。您可以自定义角色的义体、技能和玩法，探索包罗万象的城市。您做出的选择也将会对剧情和周遭的世界产生影响。', 0, N'
CD PROJEKT RED', N'
CD PROJEKT RED', CAST(N'2020-04-16T00:00:00.000' AS DateTime), 23, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (8, 1, N'仁王：Complete Edition', N'RENGWANGCompleteEdition.jpg', 249, N'以贼人嚣张跋扈，妖怪四处蠢动的幽玄日本战国时代为舞台的黑暗风格战国动作RPG，史实人物「三浦按针」为蓝本的金发碧眼武士「威廉」以及历经几番死斗的故事。除战国时代末期史实为基础外，实际存在的武将也将登场，深奥札实的故事，紧张感与极高的成就感，足以称之为「战国殊死游戏」。', 18, N'
KOEI TECMO GAMES CO., LTD.', N'
KOEI TECMO GAMES CO., LTD.', CAST(N'2017-11-07T00:00:00.000' AS DateTime), 23, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (10, 1, N'RESIDENT EVIL 2', N'RESIDENTEVIL2.jpg', 325, N'生存恐怖游戏代表之作Resident Evil 2回归，带来重新建构的深层体验。通过Capcom专利的游戏引擎RE Engine，经典作品经过翻新，在原来的游戏模式之上，添加了惊艳的写实视觉效果，让人仿佛身临其境的音效，全新的越肩视角和操作方式。

本作中，Resident Evil系列经典的动作、紧凑的探索和解谜要素得以回归。玩家将会扮演新人警察里昂·S·肯尼迪和大学生克莱尔·雷德菲尔德，应对在浣熊市爆发的僵尸危机。里昂和克莱尔各有自己的路线，使玩家可从两人的不同角度欣赏剧情。玩家将掌控这两位极具人气的主人公的命运，分别操作他们揭开生化攻击背后的黑幕并最终成功逃脱危机。

?重新构想的经典恐怖之作──以1998年发售的原作为基础重新建构，提供更深层的叙事体验。

?全新的视角──全新越肩视角和操作方式令生存恐怖体验焕然一新，同时让玩家重温原作游戏模式。

?令人毛骨悚然的写实视觉效果──在Capcom专利游戏引擎「RE Engine」的打造之下，引人入胜的写实视觉效果及出色的光影效果，令玩家仿佛身临其境，在恐怖紧张的气氛中探索浣熊市警察局。

?面对奇形怪状的敌人──在写实的血腥特效下，僵尸变得栩栩如生，并且会在受到攻击时，即时显示所受伤害。

?生化系列代表性的玩法──在漫长的求生之路中，操作主人公同敌人展开激战，探索危机四伏的黑暗走廊，收集和使用各种道具，解开谜团并逐步解锁新区域。

?重新认识两位人气主角──扮演第一天到警局上班的里昂·S·肯尼迪，亦或是在僵尸重围中苦寻哥哥的大学生克莱尔·雷德菲尔德。玩家可完成其各自章节，以两人不同的视角欣赏故事的来龙去脉。', 18, N'
CAPCOM Co., Ltd.', N'
CAPCOM Co., Ltd.', CAST(N'2019-01-25T00:00:00.000' AS DateTime), 12, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (11, 1, N'Devil May Cry 5', N'DevilMayCry5.jpg', 325, N'最强的恶魔猎人强势回归！动作游戏迷翘首以待，传说中的Stylish Action《Devil May Cry》终于復活！

超越现实的真实感。
「最强」、「革新」、「王道」──三款不同的战斗风格。
互相竞争、炫示的联机游玩功能。

动作游戏的所有快感都集结于此！

【数位版预约特典】
-「男角色配色包(Nero、Dante)」
-「女角色配色包(Nico、Lady、Trish)」
-Devil May Cry 5 壁纸 ', 18, N'
CAPCOM Co., Ltd.', N'
CAPCOM Co., Ltd.', CAST(N'2019-03-19T00:00:00.000' AS DateTime), 14, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (12, 1, N'Assassins Creed Odyssey', N'AssassinsCreedOdyssey.jpg', 248, N'在《Assassin''s Creed? Odyssey》当中主宰自己的命运。 从一名流浪者蜕变成传奇人物，踏上这趟奥德赛之旅，找出你过往的秘密并改变古希腊的命运。', 18, N'
Ubisoft Quebec, Ubisoft Montreal', N'
Ubisoft', CAST(N'2018-10-06T00:00:00.000' AS DateTime), 12, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (18, 6, N'Test 1', N'123.png', 221, N'this is a test product', 0, N'bilibili', N'bilibili', CAST(N'2020-02-25T14:42:29.447' AS DateTime), 6, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (19, 5, N'Test 2', N'123.jpg', 2233, N'this is a test product', 0, N'bilibili', N'bilibili', CAST(N'2020-01-15T13:53:08.927' AS DateTime), 251, 1, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (20, 6, N'Test 3', N'Test_3.jpg', 0, N'this is test product', 10, N'ToyNJoy', N'ToyNJoy', CAST(N'2020-02-25T16:07:22.873' AS DateTime), 8, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (22, 6, N'Test 4', N'Test_4.jpg', 0, N'this is a test product', 0, N'ToyNJoy', N'ToyNJoy', CAST(N'2020-02-25T16:25:38.837' AS DateTime), 4, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (25, 1, N'NieR_Automata', N'NieR_Automata.jpg', 274, N'NieR: Automata tells the story of androids 2B, 9S and A2 and their battle to reclaim the machine-driven dystopia overrun by powerful machines.', 0, N' Square Enix, PlatinumGames Inc.', N' Square Enix', CAST(N'2021-05-11T16:25:15.203' AS DateTime), 3, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (28, 1, N'Test 5', N'Test_5.jpeg', 0, N'测试', 0, N'测试', N'测试', CAST(N'2021-12-01T11:24:55.603' AS DateTime), 0, 0, 1)
INSERT [dbo].[Product] ([id], [type_id], [name], [image], [price], [intro], [age_grading], [developers], [publisher], [release_date], [browse], [purchases], [discount]) VALUES (29, 1, N'测试', N'CESHI.jpeg', 1, N'测试', 0, N'测试', N'测试', CAST(N'2021-12-01T11:28:28.357' AS DateTime), 3, 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_hardware_requirements] ON 

INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (3, 4, N'123', N'123', N'123', N'123', N'123', N'123', N'123', N'123', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1003, 2, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1005, 1, N'Windows 7', N'Windows 7 及以上', N'i5 8450', N'i9 9580', N'16G', N'32G', N'GTX970', N'RTX2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1006, 3, N'Windows 7', N'Windows 7 及以上', N'i5 8450', N'i9 9580', N'16G', N'32G', N'GTX970', N'RTX2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1007, 4, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1008, 5, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1009, 6, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1010, 7, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1011, 8, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1012, 10, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1013, 11, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1014, 12, N'Windows 7/Windows 8/Windows 10', N'Windows 7/Windows 8/Windows 10', N'i5 8450', N'i9 9580', N'8G', N'32G', N'GTX 950', N'RTX 2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1015, 18, N'Windows 7', N'Windows 7 及以上', N'i5 8450', N'i9 9580', N'16G', N'32G', N'GTX970', N'RTX2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1016, 19, N'Windows 7', N'Windows 8.1', N'i5 8450', N'i9 9580', N'16G', N'32G', N'GTX970', N'RTX2080', N'123', N'123')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1017, 20, N'All', N'All', N'All', N'All', N'All', N'All', N'All', N'All', N'All', N'All')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1019, 22, N'ALL', N'ALL', N'ALL', N'ALL', N'ALL', N'ALL', N'ALL', N'ALL', N'ALL', N'ALL')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1022, 25, N'Windows 7 /8.1 /10 64bit', N'Windows 8.1 /10 64bit', N'Intel Core i3 2100 or AMD A8-6500', N'Intel Core i5 4670 or AMD A10-7850K', N'4 GB RAM', N' 8 GB RAM', N'NVIDIA GeForce GTX 770 VRAM 2GB ', N'NVIDIA GeForce GTX 980 VRAM 4GB', N'11', N'11')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1025, 28, N'Windows 7 /8.1 /10 64bit', N'Windows 8.1 /10 64bit', N'Intel Core i3 2100 or AMD A8-6500', N'Intel Core i5 4670 or AMD A10-7850K', N'4 GB RAM', N' 8 GB RAM', N'NVIDIA GeForce GTX 770 VRAM 2GB or AMD Radeon R9 270X VRAM 2GB', N'NVIDIA GeForce GTX 980 VRAM 4GB', N'11', N'11')
INSERT [dbo].[Product_hardware_requirements] ([id], [Product_id], [OS], [OS_], [CPU], [CPU_], [RAM], [RAM_], [GPU], [GPU_], [DirectX], [DirectX_]) VALUES (1026, 29, N'Windows 7 /8.1 /10 64bit', N'Windows 8.1 /10 64bit', N'Intel Core i3 2100 or AMD A8-6500', N'Intel Core i5 4670 or AMD A10-7850K', N'4 GB RAM', N' 8 GB RAM', N'NVIDIA GeForce GTX 770 VRAM 2GB or AMD Radeon R9 270X VRAM 2GB', N'NVIDIA GeForce GTX 980 VRAM 4GB', N'11', N'11')
SET IDENTITY_INSERT [dbo].[Product_hardware_requirements] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Photo_Gallery] ON 

INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (1, 12, N'AssassinsCreedOdyssey-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (2, 12, N'AssassinsCreedOdyssey-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (3, 12, N'AssassinsCreedOdyssey-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (4, 1, N'TransportFever2-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (5, 1, N'TransportFever2-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (6, 1, N'TransportFever2-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (7, 2, N'RedDeadRedemption2-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (8, 2, N'RedDeadRedemption2-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (9, 2, N'RedDeadRedemption2-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (10, 3, N'TAIWUHUIJUAN-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (11, 3, N'TAIWUHUIJUAN-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (12, 3, N'TAIWUHUIJUAN-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (13, 4, N'Destiny2-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (14, 4, N'Destiny2-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (15, 4, N'Destiny2-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (16, 7, N'Cyberpunk2077-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (17, 7, N'Cyberpunk2077-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (18, 7, N'Cyberpunk2077-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (19, 5, N'ZHONGGUOSHIJIAZHANG-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (20, 5, N'ZHONGGUOSHIJIAZHANG-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (21, 5, N'ZHONGGUOSHIJIAZHANG-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (22, 6, N'DeadbyDaylight-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (23, 6, N'DeadbyDaylight-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (24, 6, N'DeadbyDaylight-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (25, 8, N'RENGWANGCompleteEdition-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (26, 8, N'RENGWANGCompleteEdition-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (27, 8, N'RENGWANGCompleteEdition-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (28, 10, N'RESIDENTEVIL2-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (29, 10, N'RESIDENTEVIL2-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (30, 10, N'RESIDENTEVIL2-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (31, 11, N'DevilMayCry5-1.jpg', CAST(N'2020-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (32, 11, N'DevilMayCry5-2.jpg', CAST(N'2020-02-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (33, 11, N'DevilMayCry5-3.jpg', CAST(N'2020-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (35, 20, N'Test_3_202002260246464646.jpg', CAST(N'2020-02-26T02:46:46.250' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (36, 19, N'Test_2_202002260247164716.jpg', CAST(N'2020-02-26T02:47:16.597' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (37, 19, N'Test_2_202002260247234723.jpg', CAST(N'2020-02-26T02:47:23.673' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (38, 19, N'Test_2_202002260247284728.jpg', CAST(N'2020-02-26T02:47:28.980' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (42, 18, N'Test_1_202002260332533253.png', CAST(N'2020-02-26T03:32:53.640' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (44, 22, N'Test_4_202002260333173317.jpg', CAST(N'2020-02-26T03:33:17.630' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (45, 18, N'Test_1_202002260333303330.png', CAST(N'2020-02-26T03:33:30.000' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (51, 25, N'NieR_Automata_202105111630363036.jpg', CAST(N'2021-05-11T16:30:36.033' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (52, 25, N'NieR_Automata_202105111630413041.jpg', CAST(N'2021-05-11T16:30:41.537' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (53, 25, N'NieR_Automata_202105111630463046.jpg', CAST(N'2021-05-11T16:30:46.873' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (54, 25, N'NieR_Automata_202105111630503050.jpg', CAST(N'2021-05-11T16:30:50.987' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (56, 25, N'NieR_Automata_20210511163101311.jpg', CAST(N'2021-05-11T16:31:01.803' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (58, 29, N'CESHI_202112082132463246.jpeg', CAST(N'2021-12-08T21:32:46.583' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (59, 29, N'CESHI_202112082133113311.jpeg', CAST(N'2021-12-08T21:33:11.440' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (60, 29, N'CESHI_202112082134223422.jpg', CAST(N'2021-12-08T21:34:22.243' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (61, 29, N'CESHI_202112082134373437.jpg', CAST(N'2021-12-08T21:34:37.813' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (62, 29, N'CESHI_202112082134563456.jpeg', CAST(N'2021-12-08T21:34:56.433' AS DateTime))
INSERT [dbo].[Product_Photo_Gallery] ([id], [product_id], [image], [join_date]) VALUES (64, 28, N'Test_5_202301152023332333.png', CAST(N'2023-01-15T20:23:33.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product_Photo_Gallery] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_type] ON 

INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (1, N'开放世界')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (5, N'角色扮演')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (6, N'解谜')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (7, N'生存')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (8, N'射击')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (9, N'动作')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (10, N'视觉小说')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (11, N'即时战略')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (12, N'回合制')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (13, N'类 Rogue')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (14, N'塔防')
INSERT [dbo].[Product_type] ([id], [type_name]) VALUES (15, N'军事')
SET IDENTITY_INSERT [dbo].[Product_type] OFF
GO
SET IDENTITY_INSERT [dbo].[User_info] ON 

INSERT [dbo].[User_info] ([id], [user_name], [signature], [wrapper_image], [gender], [birthday], [IDCard], [address], [phone]) VALUES (13, N'huangjunxi', N'这个人懒死了，什么都没写', N'ToyNJoy(3).jpg', N'boy', CAST(N'2000-01-20' AS Date), N'430602200001202010', N'湖南省 岳阳市 岳阳楼区 岳阳大道 泓园小区', N'17680471967')
INSERT [dbo].[User_info] ([id], [user_name], [signature], [wrapper_image], [gender], [birthday], [IDCard], [address], [phone]) VALUES (1024, N'Keter', N'这个人懒死了，什么都没写', N'ToyNJoy(2).jpg', N'boy', CAST(N'2000-01-20' AS Date), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User_info] OFF
GO
INSERT [dbo].[Users] ([username], [password], [email], [nickname], [Lv], [virtual_image], [register_time], [state]) VALUES (N'huangjunxi', N'00000000', N'1697339219@qq.com', N'Keter', 0, N'huangjunxi_virtual.png', CAST(N'2020-02-24' AS Date), 1)
INSERT [dbo].[Users] ([username], [password], [email], [nickname], [Lv], [virtual_image], [register_time], [state]) VALUES (N'Keter', N'0120', N'huangjunxi.keter@qq.com', N'Keter', 0, N'Keter_virtual.png', CAST(N'2023-01-29' AS Date), 0)
GO
SET IDENTITY_INSERT [dbo].[Wish_List] ON 

INSERT [dbo].[Wish_List] ([id], [user_name], [product_id], [serial_namber], [join_date]) VALUES (16, N'huangjunxi', 3, 0, CAST(N'2021-12-25' AS Date))
SET IDENTITY_INSERT [dbo].[Wish_List] OFF
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_Friend_name] FOREIGN KEY([friend_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_Friend_name]
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_group_id] FOREIGN KEY([group_id])
REFERENCES [dbo].[Friend_Group] ([id])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_group_id]
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_username] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_username]
GO
ALTER TABLE [dbo].[Friend_Group]  WITH CHECK ADD  CONSTRAINT [FK_Friend_Group_user_name] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Friend_Group] CHECK CONSTRAINT [FK_Friend_Group_user_name]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_Library_Group_id] FOREIGN KEY([group_id])
REFERENCES [dbo].[Library_Group] ([id])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_Library_Group_id]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_library_product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_library_product_id]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_user_name] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_user_name]
GO
ALTER TABLE [dbo].[Library_Group]  WITH CHECK ADD  CONSTRAINT [FK_Library_Group_user_name] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Library_Group] CHECK CONSTRAINT [FK_Library_Group_user_name]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Type_id] FOREIGN KEY([type_id])
REFERENCES [dbo].[News_Type] ([id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Type_id]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [userOrder] FOREIGN KEY([username])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [userOrder]
GO
ALTER TABLE [dbo].[Order_Item]  WITH CHECK ADD  CONSTRAINT [inOrder] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Order_Item] CHECK CONSTRAINT [inOrder]
GO
ALTER TABLE [dbo].[Order_Item]  WITH CHECK ADD  CONSTRAINT [itemProduct] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Order_Item] CHECK CONSTRAINT [itemProduct]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Type_id] FOREIGN KEY([type_id])
REFERENCES [dbo].[Product_type] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Type_id]
GO
ALTER TABLE [dbo].[Product_hardware_requirements]  WITH CHECK ADD  CONSTRAINT [FK_Product_hardware_requirements_Product_id] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Product_hardware_requirements] CHECK CONSTRAINT [FK_Product_hardware_requirements_Product_id]
GO
ALTER TABLE [dbo].[Product_Photo_Gallery]  WITH CHECK ADD  CONSTRAINT [FK_Product_Photo_Gallery_Product_ID] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Product_Photo_Gallery] CHECK CONSTRAINT [FK_Product_Photo_Gallery_Product_ID]
GO
ALTER TABLE [dbo].[Shopping_Car]  WITH CHECK ADD  CONSTRAINT [FK_Shopping_Car_product_name] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Shopping_Car] CHECK CONSTRAINT [FK_Shopping_Car_product_name]
GO
ALTER TABLE [dbo].[Shopping_Car]  WITH CHECK ADD  CONSTRAINT [FK_Shopping_Car_user_name] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Shopping_Car] CHECK CONSTRAINT [FK_Shopping_Car_user_name]
GO
ALTER TABLE [dbo].[User_info]  WITH CHECK ADD  CONSTRAINT [FK_User_info_User_name] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[User_info] CHECK CONSTRAINT [FK_User_info_User_name]
GO
ALTER TABLE [dbo].[Wish_List]  WITH CHECK ADD  CONSTRAINT [FK_Wish_List_product_id] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Wish_List] CHECK CONSTRAINT [FK_Wish_List_product_id]
GO
ALTER TABLE [dbo].[Wish_List]  WITH CHECK ADD  CONSTRAINT [FK_Wish_List_user_name] FOREIGN KEY([user_name])
REFERENCES [dbo].[Users] ([username])
GO
ALTER TABLE [dbo].[Wish_List] CHECK CONSTRAINT [FK_Wish_List_user_name]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Administrator', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Administrator', @level2type=N'COLUMN',@level2name=N'sa_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Administrator', @level2type=N'COLUMN',@level2name=N'sa_password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'好友 用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend', @level2type=N'COLUMN',@level2name=N'friend_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'好友 备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend', @level2type=N'COLUMN',@level2name=N'nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend', @level2type=N'COLUMN',@level2name=N'state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend', @level2type=N'COLUMN',@level2name=N'group_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend_Group', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend_Group', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Friend_Group', @level2type=N'COLUMN',@level2name=N'group_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'join_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'last_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总操作时间（运行时长）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'total_hours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library', @level2type=N'COLUMN',@level2name=N'group_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library_Group', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library_Group', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分组名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Library_Group', @level2type=N'COLUMN',@level2name=N'group_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'type_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'text'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'page_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点赞' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'commend'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点踩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'trample'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相关产品id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News_Type', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News_Type', @level2type=N'COLUMN',@level2name=N'type_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'total_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0未支付 1支付' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'create_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付宝回调参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'alipay_data'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order_Item', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order_Item', @level2type=N'COLUMN',@level2name=N'order_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order_Item', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格（根据商品价格和折扣计算）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order_Item', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'type_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品封面' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'介绍' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'intro'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄分级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'age_grading'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开发商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'developers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'publisher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'release_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'browse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'purchases'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折扣' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'discount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'Product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准配置 系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'OS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐配置 系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'OS_'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准配置 处理器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'CPU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐配置 处理器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'CPU_'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准配置 运行内存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'RAM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐配置 运行内存' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'RAM_'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准配置 显卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'GPU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐配置 显卡' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'GPU_'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准配置 DX版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'DirectX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐配置 DX版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_hardware_requirements', @level2type=N'COLUMN',@level2name=N'DirectX_'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Photo_Gallery', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Photo_Gallery', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Photo_Gallery', @level2type=N'COLUMN',@level2name=N'image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_Photo_Gallery', @level2type=N'COLUMN',@level2name=N'join_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_type', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product_type', @level2type=N'COLUMN',@level2name=N'type_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Car', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Car', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shopping_Car', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'signature'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人空间背景' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'wrapper_image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'IDCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User_info', @level2type=N'COLUMN',@level2name=N'phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键（用户名）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Lv'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'virtual_image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'register_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'state'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wish_List', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wish_List', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wish_List', @level2type=N'COLUMN',@level2name=N'product_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序顺序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wish_List', @level2type=N'COLUMN',@level2name=N'serial_namber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wish_List', @level2type=N'COLUMN',@level2name=N'join_date'
GO
USE [master]
GO
ALTER DATABASE [ToyNJoy2.0] SET  READ_WRITE 
GO
