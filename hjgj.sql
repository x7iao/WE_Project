USE [master]
GO
/****** Object:  Database [my_hjgj]    Script Date: 02/04/2017 11:32:52 ******/
CREATE DATABASE [my_hjgj] ON  PRIMARY 
( NAME = N'my_hjgj', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\my_hjgj.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'my_hjgj_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\my_hjgj_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [my_hjgj] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [my_hjgj].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [my_hjgj] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [my_hjgj] SET ANSI_NULLS OFF
GO
ALTER DATABASE [my_hjgj] SET ANSI_PADDING OFF
GO
ALTER DATABASE [my_hjgj] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [my_hjgj] SET ARITHABORT OFF
GO
ALTER DATABASE [my_hjgj] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [my_hjgj] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [my_hjgj] SET AUTO_SHRINK ON
GO
ALTER DATABASE [my_hjgj] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [my_hjgj] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [my_hjgj] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [my_hjgj] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [my_hjgj] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [my_hjgj] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [my_hjgj] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [my_hjgj] SET  DISABLE_BROKER
GO
ALTER DATABASE [my_hjgj] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [my_hjgj] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [my_hjgj] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [my_hjgj] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [my_hjgj] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [my_hjgj] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [my_hjgj] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [my_hjgj] SET  READ_WRITE
GO
ALTER DATABASE [my_hjgj] SET RECOVERY SIMPLE
GO
ALTER DATABASE [my_hjgj] SET  MULTI_USER
GO
ALTER DATABASE [my_hjgj] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [my_hjgj] SET DB_CHAINING OFF
GO
USE [my_hjgj]
GO
/****** Object:  Table [dbo].[Reward]    Script Date: 02/04/2017 11:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reward](
	[RewardType] [varchar](50) NOT NULL,
	[RewardName] [varchar](50) NULL,
	[RewardState] [bit] NULL,
	[NeedProcess] [bit] NULL,
	[RewardIndex] [int] NULL,
 CONSTRAINT [PK_RewradType] PRIMARY KEY CLUSTERED 
(
	[RewardType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'CZ', N'充值', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'DH', N'兑换', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'MCW', N'回馈币', 0, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'MGP', N'排单币', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'MHB', N'静态收益', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'MJB', N'动态奖金', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'R_GL', N'管理奖', 1, 1, 2)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'R_TJ', N'推荐奖', 1, 1, 1)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'SH', N'激活', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'SJ', N'升级', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'TX', N'提现', 1, 0, NULL)
INSERT [dbo].[Reward] ([RewardType], [RewardName], [RewardState], [NeedProcess], [RewardIndex]) VALUES (N'ZZ', N'转账', 1, 0, NULL)
/****** Object:  Table [dbo].[Remind]    Script Date: 02/04/2017 11:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Remind](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RType] [int] NULL,
	[RTypeName] [varchar](150) NULL,
	[RemindMsg] [text] NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_Remind] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistInfo]    Script Date: 02/04/2017 11:32:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistInfo](
	[GId] [varchar](70) NOT NULL,
	[MID] [varchar](50) NULL,
	[MEmail] [varchar](50) NULL,
	[MCreateTime] [datetime] NULL,
	[UseTime] [datetime] NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_RegistInfo] PRIMARY KEY CLUSTERED 
(
	[GId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[P_AspNetPage]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_AspNetPage]
/*
nzperfect [no_mIss] 高效通用分页存储过程(双向检索) 2007.5.7   QQ:34813284
敬告：适用于单一主键或存在唯一值列的表或视图
ps:Sql语句为8000字节,调用时请注意传入参数及sql总长度不要超过指定范围
*/
@TableName VARCHAR(200),      --表名
@FieldList VARCHAR(2000),     --显示列名，如果是全部字段则为*
@PrimaryKey VARCHAR(100),     --单一主键或唯一值键
@Where VARCHAR(2000),         --查询条件 不含'where'字符，如id>10 and len(userid)>9
@Order VARCHAR(1000),         --排序 不含'order by'字符，如id asc,userid desc，必须指定asc或desc
--注意当@SortType=3时生效，记住一定要在最后加上主键，否则会让你比较郁闷
@SortType INT,                --排序规则 1:正序asc 2:倒序desc 3:多列排序方法
@RecorderCount INT,           --记录总数 0:会返回总记录
@PageSize INT,                --每页输出的记录数
@PageIndex INT,               --当前页数
@TotalCount INT OUTPUT,       --记返回总记录
@TotalPageCount INT OUTPUT    --返回总页数
AS
SET NOCOUNT ON
IF ISNULL(@TotalCount,'') = '' SET @TotalCount = 0
SET @Order = RTRIM(LTRIM(@Order))
SET @PrimaryKey = RTRIM(LTRIM(@PrimaryKey))
SET @FieldList = REPLACE(RTRIM(LTRIM(@FieldList)),' ','')
WHILE CHARINDEX(', ',@Order) > 0 OR CHARINDEX(' ,',@Order) > 0
BEGIN
SET @Order = REPLACE(@Order,', ',',')
SET @Order = REPLACE(@Order,' ,',',')
END
IF ISNULL(@TableName,'') = '' OR ISNULL(@FieldList,'') = ''
OR ISNULL(@PrimaryKey,'') = ''
OR @SortType < 1 OR @SortType >3
OR @RecorderCount   < 0 OR @PageSize < 0 OR @PageIndex < 0
BEGIN
PRINT('ERR_00')
RETURN
END
IF @SortType = 3
BEGIN
IF (UPPER(RIGHT(@Order,4))!=' ASC' AND UPPER(RIGHT(@Order,5))!=' DESC')
BEGIN PRINT('ERR_02') RETURN END
END
DECLARE @new_where1 VARCHAR(1000)
DECLARE @new_where2 VARCHAR(1000)
DECLARE @new_order1 VARCHAR(1000)
DECLARE @new_order2 VARCHAR(1000)
DECLARE @new_order3 VARCHAR(1000)
DECLARE @Sql VARCHAR(8000)
DECLARE @SqlCount NVARCHAR(4000)
IF ISNULL(@where,'') = ''
BEGIN
SET @new_where1 = ' '
SET @new_where2 = ' WHERE   '
END
ELSE
BEGIN
SET @new_where1 = ' WHERE ' + @where
SET @new_where2 = ' WHERE ' + @where + ' AND '
END
IF ISNULL(@order,'') = '' OR @SortType = 1   OR @SortType = 2
BEGIN
IF @SortType = 1
BEGIN
SET @new_order1 = ' ORDER BY ' + @PrimaryKey + ' ASC'
SET @new_order2 = ' ORDER BY ' + @PrimaryKey + ' DESC'
END
IF @SortType = 2
BEGIN
SET @new_order1 = ' ORDER BY ' + @PrimaryKey + ' DESC'
SET @new_order2 = ' ORDER BY ' + @PrimaryKey + ' ASC'
END
END
ELSE
BEGIN
SET @new_order1 = ' ORDER BY ' + @Order
END
IF @SortType = 3 AND   CHARINDEX(','+@PrimaryKey+' ',','+@Order)>0
BEGIN
SET @new_order1 = ' ORDER BY ' + @Order
SET @new_order2 = @Order + ','
SET @new_order2 = REPLACE(REPLACE(@new_order2,'ASC,','{ASC},'),'DESC,','{DESC},')
SET @new_order2 = REPLACE(REPLACE(@new_order2,'{ASC},','DESC,'),'{DESC},','ASC,')
SET @new_order2 = ' ORDER BY ' + SUBSTRING(@new_order2,1,LEN(@new_order2)-1)
IF @FieldList <> '*'
BEGIN
SET @new_order3 = REPLACE(REPLACE(@Order + ',','ASC,',','),'DESC,',',')
SET @FieldList = ',' + @FieldList
WHILE CHARINDEX(',',@new_order3)>0
BEGIN
IF CHARINDEX(SUBSTRING(','+@new_order3,1,CHARINDEX(',',@new_order3)),','+@FieldList+',')>0
BEGIN
SET @FieldList =
@FieldList + ',' + SUBSTRING(@new_order3,1,CHARINDEX(',',@new_order3))
END
SET @new_order3 =
SUBSTRING(@new_order3,CHARINDEX(',',@new_order3)+1,LEN(@new_order3))
END
SET @FieldList = SUBSTRING(@FieldList,2,LEN(@FieldList))
END
END
SET @SqlCount = 'SELECT @TotalCount=COUNT(*),@TotalPageCount=CEILING((COUNT(*)+0.0)/'
+ CAST(@PageSize AS VARCHAR)+') FROM ' + @TableName + @new_where1
IF @RecorderCount   = 0
BEGIN
EXEC SP_EXECUTESQL @SqlCount,N'@TotalCount INT OUTPUT,@TotalPageCount INT OUTPUT',
@TotalCount OUTPUT,@TotalPageCount OUTPUT
END
ELSE
BEGIN
SELECT @TotalCount = @RecorderCount
END
IF @PageIndex > CEILING((@TotalCount+0.0)/@PageSize)
BEGIN
SET @PageIndex =   CEILING((@TotalCount+0.0)/@PageSize)
END
IF @PageIndex = 1 OR @PageIndex >= CEILING((@TotalCount+0.0)/@PageSize)
BEGIN
IF @PageIndex = 1 --返回第一页数据
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM '
+ @TableName + @new_where1 + @new_order1
END
IF @PageIndex >= CEILING((@TotalCount+0.0)/@PageSize)   --返回最后一页数据
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ('
+ 'SELECT TOP ' + STR(ABS(@PageSize*@PageIndex-@TotalCount-@PageSize))
+ ' ' + @FieldList + ' FROM '
+ @TableName + @new_where1 + @new_order2 + ' ) AS TMP '
+ @new_order1
END
END
ELSE
BEGIN
IF @SortType = 1   --仅主键正序排序
BEGIN
IF @PageIndex <= CEILING((@TotalCount+0.0)/@PageSize)/2   --正向检索
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM '
+ @TableName + @new_where2 + @PrimaryKey + ' > '
+ '(SELECT MAX(' + @PrimaryKey + ') FROM (SELECT TOP '
+ STR(@PageSize*(@PageIndex-1)) + ' ' + @PrimaryKey
+ ' FROM ' + @TableName
+ @new_where1 + @new_order1 +' ) AS TMP) '+ @new_order1
END
ELSE   --反向检索
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ('
+ 'SELECT TOP ' + STR(@PageSize) + ' '
+ @FieldList + ' FROM '
+ @TableName + @new_where2 + @PrimaryKey + ' < '
+ '(SELECT MIN(' + @PrimaryKey + ') FROM (SELECT TOP '
+ STR(@TotalCount-@PageSize*@PageIndex) + ' ' + @PrimaryKey
+ ' FROM ' + @TableName
+ @new_where1 + @new_order2 +' ) AS TMP) '+ @new_order2
+ ' ) AS TMP ' + @new_order1
END
END
IF @SortType = 2   --仅主键反序排序
BEGIN
IF @PageIndex <= CEILING((@TotalCount+0.0)/@PageSize)/2   --正向检索
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM '
+ @TableName + @new_where2 + @PrimaryKey + ' < '
+ '(SELECT MIN(' + @PrimaryKey + ') FROM (SELECT TOP '
+ STR(@PageSize*(@PageIndex-1)) + ' ' + @PrimaryKey
+' FROM '+ @TableName
+ @new_where1 + @new_order1 + ') AS TMP) '+ @new_order1
END
ELSE   --反向检索
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ('
+ 'SELECT TOP ' + STR(@PageSize) + ' '
+ @FieldList + ' FROM '
+ @TableName + @new_where2 + @PrimaryKey + ' > '
+ '(SELECT MAX(' + @PrimaryKey + ') FROM (SELECT TOP '
+ STR(@TotalCount-@PageSize*@PageIndex) + ' ' + @PrimaryKey
+ ' FROM ' + @TableName
+ @new_where1 + @new_order2 +' ) AS TMP) '+ @new_order2
+ ' ) AS TMP ' + @new_order1
END
END
IF @SortType = 3   --多列排序，必须包含主键，且放置最后，否则不处理
BEGIN
IF CHARINDEX(',' + @PrimaryKey + ' ',',' + @Order) = 0
BEGIN PRINT('ERR_02') RETURN END
IF @PageIndex <= CEILING((@TotalCount+0.0)/@PageSize)/2   --正向检索
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ( '
+ 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ( '
+ ' SELECT TOP ' + STR(@PageSize*@PageIndex) + ' ' + @FieldList
+ ' FROM ' + @TableName + @new_where1 + @new_order1 + ' ) AS TMP '
+ @new_order2 + ' ) AS TMP ' + @new_order1
END
ELSE   --反向检索
BEGIN
SET @Sql = 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ( '
+ 'SELECT TOP ' + STR(@PageSize) + ' ' + @FieldList + ' FROM ( '
+ ' SELECT TOP ' + STR(@TotalCount-@PageSize *@PageIndex+@PageSize) + ' ' + @FieldList
+ ' FROM ' + @TableName + @new_where1 + @new_order2 + ' ) AS TMP '
+ @new_order1 + ' ) AS TMP ' + @new_order1
END
END
END
print(@sql)
EXEC(@Sql)
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NTitle] [nvarchar](100) NULL,
	[NContent] [text] NULL,
	[NCreateTime] [datetime] NULL,
	[NClicks] [int] NOT NULL,
	[NState] [bit] NOT NULL,
	[IsFixed] [bit] NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NConfigDictionary]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NConfigDictionary](
	[NDTpye] [varchar](50) NOT NULL,
	[DKey] [varchar](10) NOT NULL,
	[StartLevel] [int] NOT NULL,
	[EndLevel] [int] NOT NULL,
	[StartRec] [int] NOT NULL,
	[EndRec] [int] NULL,
	[DValue] [varchar](10) NULL,
	[Remark] [varchar](100) NULL,
 CONSTRAINT [PK_NConfigDictionary] PRIMARY KEY CLUSTERED 
(
	[NDTpye] ASC,
	[DKey] ASC,
	[StartLevel] ASC,
	[EndLevel] ASC,
	[StartRec] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'002', 1, 1, 1, 999999, N'0.1', N'推荐奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'002', 1, 2, 3, 999999, N'0.05', N'二代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'002', 1, 3, 4, 999999, N'0.03', N'三代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'002', 1, 4, 5, 999999, N'0.02', N'四代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'002', 1, 5, 6, 999999, N'0.01', N'五代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'003', 1, 1, 1, 999999, N'0.1', N'推荐奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'003', 1, 2, 3, 999999, N'0.05', N'二代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'003', 1, 3, 4, 999999, N'0.03', N'三代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'003', 1, 4, 5, 999999, N'0.02', N'四代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'003', 1, 5, 6, 999999, N'0.01', N'五代管理奖')
INSERT [dbo].[NConfigDictionary] ([NDTpye], [DKey], [StartLevel], [EndLevel], [StartRec], [EndRec], [DValue], [Remark]) VALUES (N'GLFloat', N'003', 6, 99999999, 1, 999999, N'0.001', N'无限代管理奖')
/****** Object:  Table [dbo].[MOfferHelp]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOfferHelp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SQCode] [varchar](50) NULL,
	[SQMID] [varchar](50) NULL,
	[SQMoney] [decimal](18, 2) NULL,
	[MatchMoney] [decimal](18, 2) NULL,
	[SQDate] [datetime] NULL,
	[PPState] [int] NULL,
	[DKState] [int] NULL,
	[MFLMoney] [decimal](18, 2) NULL,
	[Remark] [varchar](500) NULL,
	[TotalInterest] [decimal](18, 2) NULL,
	[TotalInterestDays] [int] NULL,
	[TotalSincerity] [decimal](18, 2) NULL,
	[TotalSincerityDays] [int] NULL,
	[SincerityState] [int] NULL,
	[InterestState] [int] NULL,
	[CompleteTime] [datetime] NULL,
	[dayInterest] [decimal](18, 4) NULL,
	[HelpType] [int] NULL,
	[MoneyType] [varchar](50) NULL,
 CONSTRAINT [PK_MOfferHelp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MOfferHelp] ON
INSERT [dbo].[MOfferHelp] ([Id], [SQCode], [SQMID], [SQMoney], [MatchMoney], [SQDate], [PPState], [DKState], [MFLMoney], [Remark], [TotalInterest], [TotalInterestDays], [TotalSincerity], [TotalSincerityDays], [SincerityState], [InterestState], [CompleteTime], [dayInterest], [HelpType], [MoneyType]) VALUES (137, N'F223461AA4544F1', N'bbb111', CAST(2000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A69F00FFF8E8 AS DateTime), 4, 2, CAST(0.00 AS Decimal(18, 2)), N'', CAST(400.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 2, 2, CAST(0x0000A69F010EC6C0 AS DateTime), CAST(0.0000 AS Decimal(18, 4)), 1, NULL)
INSERT [dbo].[MOfferHelp] ([Id], [SQCode], [SQMID], [SQMoney], [MatchMoney], [SQDate], [PPState], [DKState], [MFLMoney], [Remark], [TotalInterest], [TotalInterestDays], [TotalSincerity], [TotalSincerityDays], [SincerityState], [InterestState], [CompleteTime], [dayInterest], [HelpType], [MoneyType]) VALUES (138, N'9501F869DF764B1', N'aaa111', CAST(2000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A69F0111CD5C AS DateTime), 3, 2, CAST(0.00 AS Decimal(18, 2)), N'', CAST(600.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, CAST(0x0000A69F01127350 AS DateTime), CAST(0.0000 AS Decimal(18, 4)), 0, NULL)
INSERT [dbo].[MOfferHelp] ([Id], [SQCode], [SQMID], [SQMoney], [MatchMoney], [SQDate], [PPState], [DKState], [MFLMoney], [Remark], [TotalInterest], [TotalInterestDays], [TotalSincerity], [TotalSincerityDays], [SincerityState], [InterestState], [CompleteTime], [dayInterest], [HelpType], [MoneyType]) VALUES (139, N'1A4F46260FBE4BD', N'aaa111', CAST(2000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A6A000BA36B4 AS DateTime), 3, 2, CAST(0.00 AS Decimal(18, 2)), N'', CAST(400.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 1, 1, CAST(0x0000A6AA00BE4511 AS DateTime), CAST(0.0000 AS Decimal(18, 4)), 1, NULL)
SET IDENTITY_INSERT [dbo].[MOfferHelp] OFF
/****** Object:  Table [dbo].[MMMConfigScramble]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MMMConfigScramble](
	[PayLimitTimes] [int] NULL,
	[ConfirmLimitTimes] [int] NULL,
	[OpenTime] [varchar](100) NULL,
	[OpenSwitch] [bit] NULL,
	[FreezeTimes] [int] NULL,
	[ScrambleReward] [decimal](18, 2) NULL,
	[ScrambleLiXiDays] [int] NULL,
	[DisappearTimes] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MMMConfigScramble] ([PayLimitTimes], [ConfirmLimitTimes], [OpenTime], [OpenSwitch], [FreezeTimes], [ScrambleReward], [ScrambleLiXiDays], [DisappearTimes]) VALUES (300, 300, N'00:00-23:59', 1, 300, CAST(0.10 AS Decimal(18, 2)), 10, NULL)
INSERT [dbo].[MMMConfigScramble] ([PayLimitTimes], [ConfirmLimitTimes], [OpenTime], [OpenSwitch], [FreezeTimes], [ScrambleReward], [ScrambleLiXiDays], [DisappearTimes]) VALUES (300, 300, N'00:00-23:59', 1, 300, CAST(0.10 AS Decimal(18, 2)), 10, NULL)
/****** Object:  Table [dbo].[MMMConfig]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MMMConfig](
	[ActiveCodePrice] [decimal](18, 2) NOT NULL,
	[MCWPrice] [decimal](18, 2) NOT NULL,
	[MOfferNeedMCW] [decimal](18, 2) NOT NULL,
	[OfferHelpMin] [decimal](18, 2) NOT NULL,
	[OfferHelpMax] [decimal](18, 2) NOT NULL,
	[OfferHelpBase] [int] NOT NULL,
	[OfferHelpRangeTimes] [int] NOT NULL,
	[OfferHelpRangeCount] [int] NOT NULL,
	[OfferHelpNeedComplete] [bit] NOT NULL,
	[OfferHelpDayTotalMoney] [decimal](18, 2) NOT NULL,
	[OfferHelpTimes] [varchar](100) NOT NULL,
	[OfferHelpSwitch] [bit] NOT NULL,
	[GetHelpMin] [decimal](18, 2) NOT NULL,
	[GetHelpMax] [decimal](18, 2) NOT NULL,
	[GetHelpBase] [int] NOT NULL,
	[GetHelpRangeTimes] [int] NOT NULL,
	[GetHelpRangeCount] [int] NOT NULL,
	[GetHelpNeedComplete] [bit] NOT NULL,
	[GetHelpDayTotalMoney] [decimal](18, 2) NOT NULL,
	[GetHelpTimes] [varchar](100) NOT NULL,
	[GetHelpSwitch] [bit] NOT NULL,
	[LineTimes] [int] NOT NULL,
	[FreezeTimes] [int] NOT NULL,
	[OutTimes] [int] NOT NULL,
	[InterestPer] [decimal](18, 4) NOT NULL,
	[LiXi1] [decimal](18, 4) NOT NULL,
	[LiXi2] [decimal](18, 4) NOT NULL,
	[PayLimitTimes] [int] NOT NULL,
	[ConfirmLimitTimes] [int] NOT NULL,
	[OfferHelpFloat] [decimal](18, 4) NOT NULL,
	[GetHelpFloat] [decimal](18, 4) NOT NULL,
	[NoLineTimesMoneyFloat] [decimal](18, 4) NOT NULL,
	[HonestTimes] [int] NOT NULL,
	[HonestFloat] [decimal](18, 4) NOT NULL,
	[PayLimitTimesPre] [int] NOT NULL,
	[ConfirmLimitTimesPre] [int] NOT NULL,
	[LastProportion] [decimal](18, 4) NOT NULL,
	[OfferTJKF] [decimal](18, 4) NOT NULL,
	[GetTJKF] [decimal](18, 4) NOT NULL,
	[ReleasePer] [decimal](18, 2) NOT NULL,
	[ReleaseConditionCount] [int] NOT NULL,
	[GLRewardFreezeTimes] [int] NOT NULL,
	[MacthTimesRange] [varchar](100) NOT NULL,
	[MacthSwitch] [bit] NOT NULL,
	[MHBBase] [int] NOT NULL,
	[MHBRangeTimes] [int] NOT NULL,
	[MCWBase] [int] NOT NULL,
	[MCWRangeTimes] [int] NOT NULL,
	[MJBBase] [int] NOT NULL,
	[MJBRangeTimes] [int] NOT NULL,
	[FreezeTimesOfRegister] [int] NOT NULL,
	[FreezeTimesOfOffer] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MMMConfig] ([ActiveCodePrice], [MCWPrice], [MOfferNeedMCW], [OfferHelpMin], [OfferHelpMax], [OfferHelpBase], [OfferHelpRangeTimes], [OfferHelpRangeCount], [OfferHelpNeedComplete], [OfferHelpDayTotalMoney], [OfferHelpTimes], [OfferHelpSwitch], [GetHelpMin], [GetHelpMax], [GetHelpBase], [GetHelpRangeTimes], [GetHelpRangeCount], [GetHelpNeedComplete], [GetHelpDayTotalMoney], [GetHelpTimes], [GetHelpSwitch], [LineTimes], [FreezeTimes], [OutTimes], [InterestPer], [LiXi1], [LiXi2], [PayLimitTimes], [ConfirmLimitTimes], [OfferHelpFloat], [GetHelpFloat], [NoLineTimesMoneyFloat], [HonestTimes], [HonestFloat], [PayLimitTimesPre], [ConfirmLimitTimesPre], [LastProportion], [OfferTJKF], [GetTJKF], [ReleasePer], [ReleaseConditionCount], [GLRewardFreezeTimes], [MacthTimesRange], [MacthSwitch], [MHBBase], [MHBRangeTimes], [MCWBase], [MCWRangeTimes], [MJBBase], [MJBRangeTimes], [FreezeTimesOfRegister], [FreezeTimesOfOffer]) VALUES (CAST(200.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), 1000, 10, 2, 1, CAST(2000.00 AS Decimal(18, 2)), N'00:00-23:00', 1, CAST(500.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), 100, 20, 5, 1, CAST(2000.00 AS Decimal(18, 2)), N'00:00-23:00', 1, 100, 100, 1, CAST(0.2000 AS Decimal(18, 4)), CAST(0.0100 AS Decimal(18, 4)), CAST(0.0500 AS Decimal(18, 4)), 1440, 2880, CAST(1.0000 AS Decimal(18, 4)), CAST(0.5000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 240, CAST(0.0100 AS Decimal(18, 4)), 5, 5, CAST(1.0000 AS Decimal(18, 4)), CAST(0.1000 AS Decimal(18, 4)), CAST(0.0200 AS Decimal(18, 4)), CAST(0.50 AS Decimal(18, 2)), 2, 100, N'12:00-23:00', 1, 720, 0, 500, 1440, 500, 1440, 0, 0)
INSERT [dbo].[MMMConfig] ([ActiveCodePrice], [MCWPrice], [MOfferNeedMCW], [OfferHelpMin], [OfferHelpMax], [OfferHelpBase], [OfferHelpRangeTimes], [OfferHelpRangeCount], [OfferHelpNeedComplete], [OfferHelpDayTotalMoney], [OfferHelpTimes], [OfferHelpSwitch], [GetHelpMin], [GetHelpMax], [GetHelpBase], [GetHelpRangeTimes], [GetHelpRangeCount], [GetHelpNeedComplete], [GetHelpDayTotalMoney], [GetHelpTimes], [GetHelpSwitch], [LineTimes], [FreezeTimes], [OutTimes], [InterestPer], [LiXi1], [LiXi2], [PayLimitTimes], [ConfirmLimitTimes], [OfferHelpFloat], [GetHelpFloat], [NoLineTimesMoneyFloat], [HonestTimes], [HonestFloat], [PayLimitTimesPre], [ConfirmLimitTimesPre], [LastProportion], [OfferTJKF], [GetTJKF], [ReleasePer], [ReleaseConditionCount], [GLRewardFreezeTimes], [MacthTimesRange], [MacthSwitch], [MHBBase], [MHBRangeTimes], [MCWBase], [MCWRangeTimes], [MJBBase], [MJBRangeTimes], [FreezeTimesOfRegister], [FreezeTimesOfOffer]) VALUES (CAST(200.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)), 1000, 10, 2, 1, CAST(2000.00 AS Decimal(18, 2)), N'00:00-23:00', 1, CAST(500.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), 100, 20, 5, 1, CAST(2000.00 AS Decimal(18, 2)), N'00:00-23:00', 1, 100, 100, 1, CAST(0.2000 AS Decimal(18, 4)), CAST(0.0100 AS Decimal(18, 4)), CAST(0.0500 AS Decimal(18, 4)), 1440, 2880, CAST(1.0000 AS Decimal(18, 4)), CAST(0.5000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), 240, CAST(0.0100 AS Decimal(18, 4)), 5, 5, CAST(1.0000 AS Decimal(18, 4)), CAST(0.1000 AS Decimal(18, 4)), CAST(0.0200 AS Decimal(18, 4)), CAST(0.50 AS Decimal(18, 2)), 2, 100, N'12:00-23:00', 1, 720, 0, 500, 1440, 500, 1440, 0, 0)
/****** Object:  Table [dbo].[MHelpMatch]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MHelpMatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchCode] [varchar](50) NULL,
	[OfferId] [int] NULL,
	[GetId] [int] NULL,
	[MatchTime] [datetime] NULL,
	[MatchMoney] [decimal](18, 2) NULL,
	[PayTime] [datetime] NULL,
	[ConfirmTime] [datetime] NULL,
	[MatchState] [int] NULL,
	[PicUrl] [varchar](500) NULL,
	[Remark] [varchar](500) NULL,
	[OfferMID] [varchar](50) NULL,
	[GetMID] [varchar](50) NULL,
	[PicUrl1] [varchar](500) NULL,
	[PicUrl2] [varchar](500) NULL,
	[ChangeCount] [int] NOT NULL,
	[ChangeMTJTime] [datetime] NULL,
	[ChangeVIPTime] [datetime] NULL,
	[PicUrl3] [varchar](500) NULL,
	[MatchType] [int] NULL,
 CONSTRAINT [PK_MHelpMatch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MHelpMatch] ON
INSERT [dbo].[MHelpMatch] ([Id], [MatchCode], [OfferId], [GetId], [MatchTime], [MatchMoney], [PayTime], [ConfirmTime], [MatchState], [PicUrl], [Remark], [OfferMID], [GetMID], [PicUrl1], [PicUrl2], [ChangeCount], [ChangeMTJTime], [ChangeVIPTime], [PicUrl3], [MatchType]) VALUES (180, N'9C7AFFE7DE334E1', 137, 62, CAST(0x0000A69F0103CB6C AS DateTime), CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A69F010AE17C AS DateTime), CAST(0x0000A69F010EC7C4 AS DateTime), 3, N'/plugin/kindeditor/attached/image/20161014/20161014161138_1595.jpg', N'', N'bbb111', N'aaa111', N'', N'', 0, NULL, NULL, N'3', 2)
INSERT [dbo].[MHelpMatch] ([Id], [MatchCode], [OfferId], [GetId], [MatchTime], [MatchMoney], [PayTime], [ConfirmTime], [MatchState], [PicUrl], [Remark], [OfferMID], [GetMID], [PicUrl1], [PicUrl2], [ChangeCount], [ChangeMTJTime], [ChangeVIPTime], [PicUrl3], [MatchType]) VALUES (181, N'FF356A2ADDFA429', 138, 63, CAST(0x0000A69F011213AC AS DateTime), CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A69F01122D74 AS DateTime), CAST(0x0000A69F0112734F AS DateTime), 3, N'/plugin/kindeditor/attached/image/20161014/20161014163809_3725.jpg', N'', N'aaa111', N'bbb111', N'', N'', 0, NULL, NULL, N'3', 0)
INSERT [dbo].[MHelpMatch] ([Id], [MatchCode], [OfferId], [GetId], [MatchTime], [MatchMoney], [PayTime], [ConfirmTime], [MatchState], [PicUrl], [Remark], [OfferMID], [GetMID], [PicUrl1], [PicUrl2], [ChangeCount], [ChangeMTJTime], [ChangeVIPTime], [PicUrl3], [MatchType]) VALUES (182, N'A767DD3F173B40E', 139, 64, CAST(0x0000A6A000C40BE4 AS DateTime), CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A6AA00BE3110 AS DateTime), CAST(0x0000A6AA00BE450F AS DateTime), 3, N'/plugin/kindeditor/attached/image/20161025/20161025113220_2174.jpg', N'', N'aaa111', N'bbb111', N'', N'', 0, NULL, NULL, N'3', 2)
SET IDENTITY_INSERT [dbo].[MHelpMatch] OFF
/****** Object:  StoredProcedure [dbo].[Proc_CountForIndexChart]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--  exec Proc_CountForIndexChart '2015-05-10','2015-05-22'
CREATE PROCEDURE [dbo].[Proc_CountForIndexChart] 
	-- Add the parameters for the stored procedure here
	@BeginDate varchar(40), --2015-05-20
	@EndDate  varchar(40)   --2015-05-22
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 CREATE table #tempCount
	 (
		CountDate datetime,	--日期
		SumCount varchar(10),--数量
		CountType int		--统计类型：1-每天最后成交价;2-每天成交总量
	)
	 
	declare @dayAdd int,@countTime datetime,@count int,@i int,@isHasCount int
	select @isHasCount=COUNT(1) from MGP_BuyRecord t1 left join MGP_Publish t2 on t1.PublishId=t2.Id where datediff(DD,t1.BuyTime,@BeginDate)=0  
	if @isHasCount=0
	begin
		insert #tempCount(CountDate,SumCount,CountType)
		 values(@BeginDate,'0.10',1)
	end
	set @i=0
	select @count=datediff(dd,@BeginDate,@EndDate)
	while @i<=@count
	begin
		set @countTime=DATEADD(DD,@i,@BeginDate)
		--从开始时间开始统计,统计每天的成交单价
		--如果今天没有成交，就取前一天的成交价格
	select @isHasCount=COUNT(1) from MGP_BuyRecord t1 left join MGP_Publish t2 on t1.PublishId=t2.Id where datediff(DD,t1.BuyTime,@countTime)=0  
	if @isHasCount=0
	begin
		insert #tempCount(CountDate,SumCount,CountType)
		 select @countTime,SumCount,1 from #tempCount where CountDate=DATEADD(DD,-1,@countTime) and CountType=1 
	end
	else
	begin
		insert #tempCount(CountDate,SumCount,CountType)
	      select top 1  CONVERT(varchar(100),  t1.BuyTime, 23),CONVERT(varchar(10),t1.BuyPrice),1 from MGP_BuyRecord t1 left join MGP_Publish t2 on t1.PublishId=t2.Id where datediff(DD,t1.BuyTime,@countTime)=0  order by Sort desc 
	   
	end
	 
	    
		--从开始时间开始统计,统计每天的成交量
		insert #tempCount(CountDate,SumCount,CountType)
		   select @countTime,SUM(BuyCount),2 from MGP_BuyRecord t1 left join MGP_Publish t2 on t1.PublishId=t2.Id where datediff(DD,t1.BuyTime,@countTime)=0
		set @i=@i+1
	end
	 
	 select CONVERT(varchar(100),CountDate,23) CountDate,SumCount,CountType from #tempCount order by CountDate
	 drop table #tempCount
END
GO
/****** Object:  Table [dbo].[MGetHelp]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MGetHelp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SQMID] [varchar](50) NULL,
	[SQMoney] [decimal](18, 2) NULL,
	[SQCode] [varchar](50) NULL,
	[SQDate] [datetime] NULL,
	[PPState] [int] NULL,
	[ConfirmState] [int] NULL,
	[MFLMoney] [decimal](18, 2) NULL,
	[Remark] [varchar](500) NULL,
	[MatchMoney] [decimal](18, 2) NULL,
	[HelpType] [int] NULL,
	[MoneyType] [varchar](50) NULL,
	[ComfirmDate] [datetime] NULL,
 CONSTRAINT [PK_MGetHelp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MGetHelp] ON
INSERT [dbo].[MGetHelp] ([Id], [SQMID], [SQMoney], [SQCode], [SQDate], [PPState], [ConfirmState], [MFLMoney], [Remark], [MatchMoney], [HelpType], [MoneyType], [ComfirmDate]) VALUES (62, N'aaa111', CAST(2000.00 AS Decimal(18, 2)), N'01A9D41F14D34E2', CAST(0x0000A69F010004A0 AS DateTime), 3, 3, CAST(0.00 AS Decimal(18, 2)), N'', CAST(2000.00 AS Decimal(18, 2)), 0, N'MHB', NULL)
INSERT [dbo].[MGetHelp] ([Id], [SQMID], [SQMoney], [SQCode], [SQDate], [PPState], [ConfirmState], [MFLMoney], [Remark], [MatchMoney], [HelpType], [MoneyType], [ComfirmDate]) VALUES (63, N'bbb111', CAST(2000.00 AS Decimal(18, 2)), N'C738F7DD1FCD483', CAST(0x0000A69F0111D914 AS DateTime), 3, 3, CAST(0.00 AS Decimal(18, 2)), N'', CAST(2000.00 AS Decimal(18, 2)), 0, N'MHB', NULL)
INSERT [dbo].[MGetHelp] ([Id], [SQMID], [SQMoney], [SQCode], [SQDate], [PPState], [ConfirmState], [MFLMoney], [Remark], [MatchMoney], [HelpType], [MoneyType], [ComfirmDate]) VALUES (64, N'bbb111', CAST(2000.00 AS Decimal(18, 2)), N'87768986155E48E', CAST(0x0000A6A000C40608 AS DateTime), 3, 3, CAST(0.00 AS Decimal(18, 2)), N'', CAST(2000.00 AS Decimal(18, 2)), 0, N'MHB', CAST(0x0000A6AA00BE4517 AS DateTime))
SET IDENTITY_INSERT [dbo].[MGetHelp] OFF
/****** Object:  Table [dbo].[Message]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MContent] [varchar](500) NULL,
	[MDate] [datetime] NULL,
	[MDx] [bit] NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberSafe]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberSafe](
	[S_ID] [int] IDENTITY(1,1) NOT NULL,
	[S_MID] [varchar](50) NULL,
	[S_Safe] [nchar](10) NULL,
 CONSTRAINT [PK_MemberSafe] PRIMARY KEY CLUSTERED 
(
	[S_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberConfig]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberConfig](
	[MID] [varchar](20) NOT NULL,
	[SHMoney] [int] NULL,
	[YJCount] [int] NULL,
	[YJMoney] [int] NULL,
	[TJCount] [int] NULL,
	[TJMoney] [int] NULL,
	[UpSumMoney] [int] NULL,
	[TotalMoney] [decimal](18, 2) NULL,
	[RealMoney] [decimal](18, 2) NULL,
	[TakeOffMoney] [decimal](18, 2) NULL,
	[ReBuyMoney] [decimal](18, 2) NULL,
	[TotalTXMoney] [decimal](18, 2) NULL,
	[JJTypeList] [varchar](300) NULL,
	[MHB] [decimal](18, 2) NULL,
	[MJB] [decimal](18, 2) NULL,
	[MCW] [decimal](18, 2) NULL,
	[MGP] [decimal](18, 2) NULL,
	[DTFHState] [bit] NULL,
	[JTFHState] [bit] NULL,
	[TotalDFHMoney] [decimal](18, 2) NULL,
	[TotalZFHMoney] [decimal](18, 2) NULL,
	[TotalYFHMoney] [decimal](18, 2) NULL,
	[StockCount] [int] NULL,
	[TotalFHCount] [int] NULL,
	[TXStatus] [bit] NULL,
	[ZZStatus] [bit] NULL,
	[EPTimeOutCount] [int] NULL,
	[EPXingCount] [int] NULL,
	[FDTrade] [varchar](30) NULL,
	[TJLDLevel] [int] NULL,
	[ReadNoticeID] [int] NULL,
	[GLMoneyDate] [datetime] NULL,
	[GLMoney] [decimal](18, 2) NULL,
	[TotalLDMoney] [decimal](18, 2) NULL,
	[OfferQuota] [decimal](18, 2) NULL,
	[SQCount] [int] NULL,
	[TotalHLMoney] [decimal](18, 2) NULL,
	[HLMoneyState] [bit] NULL,
	[PPLeavel] [int] NULL,
	[NomalTotalThaw] [decimal](18, 2) NULL,
	[VIPTotalThaw] [decimal](18, 2) NULL,
	[MJBF] [decimal](18, 2) NULL,
 CONSTRAINT [PK_MemberConfig] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'投资额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'SHMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市场人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'YJCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市场业绩' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'YJMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'TJCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'双轨用到对碰用到' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'UpSumMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人所得毛收益' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'TotalMoney'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人所得净收益' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MemberConfig', @level2type=N'COLUMN',@level2name=N'RealMoney'
GO
INSERT [dbo].[MemberConfig] ([MID], [SHMoney], [YJCount], [YJMoney], [TJCount], [TJMoney], [UpSumMoney], [TotalMoney], [RealMoney], [TakeOffMoney], [ReBuyMoney], [TotalTXMoney], [JJTypeList], [MHB], [MJB], [MCW], [MGP], [DTFHState], [JTFHState], [TotalDFHMoney], [TotalZFHMoney], [TotalYFHMoney], [StockCount], [TotalFHCount], [TXStatus], [ZZStatus], [EPTimeOutCount], [EPXingCount], [FDTrade], [TJLDLevel], [ReadNoticeID], [GLMoneyDate], [GLMoney], [TotalLDMoney], [OfferQuota], [SQCount], [TotalHLMoney], [HLMoneyState], [PPLeavel], [NomalTotalThaw], [VIPTotalThaw], [MJBF]) VALUES (N'aaa111', 8000, 1, 8000, 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'R_TJ(推荐奖),R_GL(管理奖),', CAST(98400.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(99600.00 AS Decimal(18, 2)), 1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 1, 1, 0, 5, NULL, 0, 0, CAST(0x0000A6BC0102AAEF AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 5, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[MemberConfig] ([MID], [SHMoney], [YJCount], [YJMoney], [TJCount], [TJMoney], [UpSumMoney], [TotalMoney], [RealMoney], [TakeOffMoney], [ReBuyMoney], [TotalTXMoney], [JJTypeList], [MHB], [MJB], [MCW], [MGP], [DTFHState], [JTFHState], [TotalDFHMoney], [TotalZFHMoney], [TotalYFHMoney], [StockCount], [TotalFHCount], [TXStatus], [ZZStatus], [EPTimeOutCount], [EPXingCount], [FDTrade], [TJLDLevel], [ReadNoticeID], [GLMoneyDate], [GLMoney], [TotalLDMoney], [OfferQuota], [SQCount], [TotalHLMoney], [HLMoneyState], [PPLeavel], [NomalTotalThaw], [VIPTotalThaw], [MJBF]) VALUES (N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 0, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MemberConfig] ([MID], [SHMoney], [YJCount], [YJMoney], [TJCount], [TJMoney], [UpSumMoney], [TotalMoney], [RealMoney], [TakeOffMoney], [ReBuyMoney], [TotalTXMoney], [JJTypeList], [MHB], [MJB], [MCW], [MGP], [DTFHState], [JTFHState], [TotalDFHMoney], [TotalZFHMoney], [TotalYFHMoney], [StockCount], [TotalFHCount], [TXStatus], [ZZStatus], [EPTimeOutCount], [EPXingCount], [FDTrade], [TJLDLevel], [ReadNoticeID], [GLMoneyDate], [GLMoney], [TotalLDMoney], [OfferQuota], [SQCount], [TotalHLMoney], [HLMoneyState], [PPLeavel], [NomalTotalThaw], [VIPTotalThaw], [MJBF]) VALUES (N'bbb111', 4000, 1, 4000, 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'R_TJ(推荐奖),R_GL(管理奖),', CAST(193399.00 AS Decimal(18, 2)), CAST(600000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 1, 1, 0, 5, NULL, 0, 0, CAST(0x0000A6BC0118EDF3 AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 2, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[MemberConfig] ([MID], [SHMoney], [YJCount], [YJMoney], [TJCount], [TJMoney], [UpSumMoney], [TotalMoney], [RealMoney], [TakeOffMoney], [ReBuyMoney], [TotalTXMoney], [JJTypeList], [MHB], [MJB], [MCW], [MGP], [DTFHState], [JTFHState], [TotalDFHMoney], [TotalZFHMoney], [TotalYFHMoney], [StockCount], [TotalFHCount], [TXStatus], [ZZStatus], [EPTimeOutCount], [EPXingCount], [FDTrade], [TJLDLevel], [ReadNoticeID], [GLMoneyDate], [GLMoney], [TotalLDMoney], [OfferQuota], [SQCount], [TotalHLMoney], [HLMoneyState], [PPLeavel], [NomalTotalThaw], [VIPTotalThaw], [MJBF]) VALUES (N'frr1111', 0, 0, 0, 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'R_TJ(推荐奖),R_GL(管理奖),', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, 0, 1, 1, 0, 5, NULL, 0, 0, CAST(0x0000A6CA00DF5771 AS DateTime), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[MemberBonus]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberBonus](
	[MID] [varchar](20) NOT NULL,
	[TotalPoints] [int] NULL,
	[ValidPoints] [int] NULL,
	[TotalBonus] [int] NULL,
	[ValidBonus] [int] NULL,
 CONSTRAINT [PK_MemberBonus] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberApply]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberApply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MID] [varchar](50) NULL,
	[MQQ] [varchar](20) NULL,
	[MQQGroup] [varchar](20) NULL,
	[MTel] [varchar](20) NULL,
	[ApplyTime] [datetime] NULL,
	[State] [int] NULL,
	[ConfirmTime] [datetime] NULL,
	[Remark] [nvarchar](500) NULL,
	[ApplyType] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[ID] [int] IDENTITY(692828,9) NOT NULL,
	[MID] [varchar](20) NOT NULL,
	[FMID] [varchar](20) NULL,
	[MName] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Zone] [nvarchar](50) NULL,
	[Tel] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Bank] [nvarchar](50) NULL,
	[Branch] [nvarchar](50) NULL,
	[BankNumber] [nvarchar](50) NULL,
	[BankCardName] [nvarchar](50) NULL,
	[Password] [varchar](32) NULL,
	[SecPsd] [varchar](32) NULL,
	[MTJ] [varchar](20) NULL,
	[MSH] [varchar](20) NULL,
	[MBD] [varchar](20) NULL,
	[MBDIndex] [int] NULL,
	[MCreateDate] [datetime] NULL,
	[MDate] [datetime] NULL,
	[MState] [bit] NOT NULL,
	[IsClose] [bit] NULL,
	[IsClock] [bit] NULL,
	[RoleCode] [varchar](10) NULL,
	[AgencyCode] [varchar](10) NULL,
	[Salt] [varchar](10) NULL,
	[ThrPsd] [varchar](50) NULL,
	[SHMoney] [int] NULL,
	[NumID] [nvarchar](50) NULL,
	[QQ] [varchar](20) NULL,
	[GCount] [int] NULL,
	[ActiveCode] [varchar](20) NULL,
	[WeChat] [nvarchar](50) NULL,
	[Alipay] [nvarchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'安置点位：1（左），2（中），3（右）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Member', @level2type=N'COLUMN',@level2name=N'MBDIndex'
GO
SET IDENTITY_INSERT [dbo].[Member] ON
INSERT [dbo].[Member] ([ID], [MID], [FMID], [MName], [Country], [Province], [City], [Zone], [Tel], [Email], [Address], [Bank], [Branch], [BankNumber], [BankCardName], [Password], [SecPsd], [MTJ], [MSH], [MBD], [MBDIndex], [MCreateDate], [MDate], [MState], [IsClose], [IsClock], [RoleCode], [AgencyCode], [Salt], [ThrPsd], [SHMoney], [NumID], [QQ], [GCount], [ActiveCode], [WeChat], [Alipay]) VALUES (694727, N'aaa111', NULL, N'速度', N'', N'', N'', N'', N'15012345678', NULL, N'', N'中国银行', N'222222', N'222222', N'222222', N'A4FCFC6B8853D325ABE98B35AD4CD3CA', N'9208CB9C982119BA467B1ABFC1A1284B', N'admin', N'admin', N'admin', 0, CAST(0x0000A69E0102A9F8 AS DateTime), CAST(0x0000A69E0102CE4C AS DateTime), 1, 0, 0, N'Nomal', N'002', N'37489', N'5c8fd329aa50de90c5d74a93e1b97dc4', 0, N'222222', N'', 0, N'', N'222222', N'222222')
INSERT [dbo].[Member] ([ID], [MID], [FMID], [MName], [Country], [Province], [City], [Zone], [Tel], [Email], [Address], [Bank], [Branch], [BankNumber], [BankCardName], [Password], [SecPsd], [MTJ], [MSH], [MBD], [MBDIndex], [MCreateDate], [MDate], [MState], [IsClose], [IsClock], [RoleCode], [AgencyCode], [Salt], [ThrPsd], [SHMoney], [NumID], [QQ], [GCount], [ActiveCode], [WeChat], [Alipay]) VALUES (692837, N'admin', NULL, N'管理', N'', N'', N'地市', N'县市', N'15012346576', N'1@123.com', N'323322323', N'中国银hang', N'北京亮马桥支', N'1', N'管理', N'4800E29E8B1F0076567EA0F3113C772C', N'4800E29E8B1F0076567EA0F3113C772C', N'admin', N'admin', N'admin', 1, CAST(0x0000A69E00A67879 AS DateTime), CAST(0x0000A69E00A67879 AS DateTime), 1, 0, 0, N'Manage', N'003', N'84679', N'5872bfc7127491e674e2df22320c6dd9', 8560, N'', N'', 0, N'', N's', N's')
INSERT [dbo].[Member] ([ID], [MID], [FMID], [MName], [Country], [Province], [City], [Zone], [Tel], [Email], [Address], [Bank], [Branch], [BankNumber], [BankCardName], [Password], [SecPsd], [MTJ], [MSH], [MBD], [MBDIndex], [MCreateDate], [MDate], [MState], [IsClose], [IsClock], [RoleCode], [AgencyCode], [Salt], [ThrPsd], [SHMoney], [NumID], [QQ], [GCount], [ActiveCode], [WeChat], [Alipay]) VALUES (694736, N'bbb111', NULL, N'速度', N'', N'', N'', N'', N'15012345678', NULL, N'', N'中国银行', N'222222', N'222222', N'222222', N'BAC04BEFC4C0586735F104CE674B35FA', N'C8D22A906672CB69C4628514C114079A', N'admin', N'admin', N'admin', 0, CAST(0x0000A69E0118ECCC AS DateTime), CAST(0x0000A69E01190FF4 AS DateTime), 1, 0, 0, N'Nomal', N'002', N'77534', N'451a1b36a0b44893a058f738b72c00a8', 0, N'222222', N'', 0, N'', N'222222', N'222222')
INSERT [dbo].[Member] ([ID], [MID], [FMID], [MName], [Country], [Province], [City], [Zone], [Tel], [Email], [Address], [Bank], [Branch], [BankNumber], [BankCardName], [Password], [SecPsd], [MTJ], [MSH], [MBD], [MBDIndex], [MCreateDate], [MDate], [MState], [IsClose], [IsClock], [RoleCode], [AgencyCode], [Salt], [ThrPsd], [SHMoney], [NumID], [QQ], [GCount], [ActiveCode], [WeChat], [Alipay]) VALUES (694745, N'frr1111', NULL, N'速度', NULL, NULL, NULL, NULL, N'15617926640', NULL, NULL, N'中国银行', N'zh213423423', N'kh3453434', N'多大的', N'AA3B7F7B706C29BBFC49AE48124F60EF', N'E41ED80B535617412D8E71C09FFB1397', N'admin', N'admin', N'admin', 0, CAST(0x0000A6AC00DF5770 AS DateTime), CAST(0x002D247F018B81FF AS DateTime), 0, 0, 0, N'Notactive', N'001', N'95756', N'303a469e2ce2d474f9305038ddf02bd8', 0, N'wx1111111', NULL, 0, NULL, N'dawd', N'dawdwa')
SET IDENTITY_INSERT [dbo].[Member] OFF
/****** Object:  Table [dbo].[MConfigChange]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MConfigChange](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [varchar](20) NOT NULL,
	[SHMID] [varchar](20) NULL,
	[ChangeDate] [datetime] NULL,
	[ConfigName] [varchar](20) NULL,
	[ConfigValue] [varchar](20) NULL,
	[DataType] [varchar](20) NULL,
	[IsValue] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Language]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [bigint] NULL,
	[Zh_Name] [nvarchar](150) NULL,
	[En_Name] [varchar](150) NULL,
	[State] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IPClick]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IPClick](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MID] [varchar](50) NULL,
	[IP] [varchar](20) NULL,
	[ClickTime] [datetime] NULL,
	[Money] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HKModel]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HKModel](
	[HKCode] [varchar](36) NOT NULL,
	[HKCreateDate] [datetime] NULL,
	[HKDate] [datetime] NULL,
	[MID] [varchar](30) NULL,
	[HKType] [int] NULL,
	[RealMoney] [decimal](18, 2) NULL,
	[ValidMoney] [decimal](18, 2) NULL,
	[FromBank] [varchar](50) NULL,
	[BankName] [varchar](20) NULL,
	[ToBank] [varchar](50) NULL,
	[HKState] [bit] NULL,
	[IsAuto] [bit] NULL,
	[Sign] [bit] NULL,
	[Remark] [nvarchar](500) NULL,
	[ConfirmTime] [datetime] NULL,
 CONSTRAINT [PK_HKModel] PRIMARY KEY CLUSTERED 
(
	[HKCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HelpChat]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HelpChat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MatchCode] [varchar](50) NULL,
	[SendMID] [varchar](20) NULL,
	[SendName] [nvarchar](10) NULL,
	[TContent] [nvarchar](500) NULL,
	[SendTime] [datetime] NULL,
	[SendType] [int] NULL,
	[SendImages] [text] NULL,
 CONSTRAINT [PK_HelpChat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[HelpChat] ON
INSERT [dbo].[HelpChat] ([ID], [MatchCode], [SendMID], [SendName], [TContent], [SendTime], [SendType], [SendImages]) VALUES (10, N'A767DD3F173B40E', N'admin', N'管理', N'dawdawdw', CAST(0x0000A6A000C5C31F AS DateTime), 2, N'')
INSERT [dbo].[HelpChat] ([ID], [MatchCode], [SendMID], [SendName], [TContent], [SendTime], [SendType], [SendImages]) VALUES (11, N'A767DD3F173B40E', N'admin', N'管理', N'dawdaw', CAST(0x0000A6A000C63193 AS DateTime), 2, N'')
INSERT [dbo].[HelpChat] ([ID], [MatchCode], [SendMID], [SendName], [TContent], [SendTime], [SendType], [SendImages]) VALUES (12, N'A767DD3F173B40E', N'aaa111', N'速度', N'dawdawd', CAST(0x0000A6A000C64DFE AS DateTime), 1, N'')
SET IDENTITY_INSERT [dbo].[HelpChat] OFF
/****** Object:  Table [dbo].[Contents]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contents](
	[CID] [varchar](10) NOT NULL,
	[CTitle] [varchar](20) NULL,
	[CLevel] [int] NOT NULL,
	[CAddress] [varchar](100) NULL,
	[CFID] [varchar](10) NOT NULL,
	[CState] [bit] NOT NULL,
	[CIndex] [int] NOT NULL,
	[CImage] [varchar](100) NULL,
	[VState] [bit] NULL,
	[IsQuickMenu] [bit] NULL,
	[Remark] [varchar](150) NULL,
	[IsOuterLink] [bit] NULL,
	[OuterAddress] [varchar](100) NULL,
 CONSTRAINT [PK_Contents] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'000', N'系统', 1, N'/Default.aspx', N'0', 1, 1, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001', N'个人信息', 1, N'', N'0', 1, 2, N'icon-user', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001001', N'个人信息', 2, N'../Member/View.aspx', N'001', 1, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001002', N'修改资料', 2, N'../Member/Modify.aspx', N'001', 1, 2, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001003', N'线下汇款', 2, N'../Member/BuyActiveCode.aspx', N'001', 0, 3, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001004', N'购买记录', 2, N'../ChangeMoney/HKList.aspx', N'001', 0, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001005', N'我的激活码', 0, N'../Member/MyActiveCode.aspx', N'001', 1, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001007', N'银行卡管理', 2, N'../SecurityCenter/BankList.aspx', N'001', 0, 6, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001008', N'添加银行卡', 2, N'../SecurityCenter/AddBankInfo.aspx', N'001', 0, 7, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001009', N'修改银行卡', 2, N'../SecurityCenter/ModifyBankInfo.aspx', N'001', 0, 8, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001101', N'激活账户', 2, N'../Member/UpMember.aspx', N'001', 1, 6, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001102', N'购买激活码', 0, N'../Member/BuyActive.aspx', N'001', 0, 5, N'', 1, 0, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'001103', N'激活码记录', 0, N'../Member/ActiveCodeList.aspx', N'001', 0, 10, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002', N'EGD互助社区', 1, N'', N'0', 0, 3, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002003', N'提现申请', 2, N'../ChangeMoney/TXChange.aspx', N'002', 0, 7, N'', 0, 1, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002004', N'提现管理', 2, N'../ChangeMoney/TXList.aspx', N'002', 0, 6, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002005', N'会员转账', 2, N'../ChangeMoney/HBChange.aspx', N'001', 1, 7, N'', 0, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002006', N'转账记录', 2, N'../ChangeMoney/HBList.aspx', N'001', 1, 8, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002011', N'财务总账', 2, N'../Welcome.aspx', N'002', 0, 16, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002012', N'拨比流水', 2, N'../ChangeMoney/Finance.aspx', N'004', 0, 15, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002014', N'在线购买记录', 2, N'../ChangeMoney/HKChange.aspx', N'002', 0, 4, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002015', N'在线购买激活码', 2, N'../ChangeMoney/PayHB.aspx', N'001', 0, 5, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002016', N'收支流水', 2, N'../ChangeMoney/DayLiuShui.aspx', N'002', 0, 13, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002020', N'在线充值', 2, N'../Payment/Index.aspx', N'002', 0, 18, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002021', N'币种互转', 2, N'../ChangeMoney/HBToJBChange.aspx', N'001', 0, 7, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002026', N'财付通充值', 0, N'../ChangeMoney/Recharge.aspx?type=qq', N'002', 0, 12, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002027', N'支付宝充值', 0, N'../ChangeMoney/Recharge.aspx?type=alipay', N'002', 0, 12, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'002029', N'网银充值', 0, N'../ChangeMoney/Recharge.aspx?type=bank', N'002', 0, 12, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00248', N'分红明细', 0, N'../ChangeMoney/FHList.aspx', N'002', 0, 6, N'', 1, 0, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00249', N'批量扣费', 0, N'../ChangeMoney/BathCostMemberMHB.aspx', N'002', 0, 229, N'', 1, 0, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003', N'公告留言', 1, N'', N'0', 1, 10, N'icon-envelope', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003001', N'发送短信', 2, N'../Message/Add.aspx', N'003', 0, 8, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003002', N'历史短信', 2, N'../Message/List.aspx', N'003', 0, 9, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003003', N'发布公告', 2, N'../Message/NoticeAdd.aspx', N'003', 1, 2, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003004', N'公告管理', 2, N'../Message/NoticeList.aspx', N'003', 1, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003007', N'修改公告', 2, N'../Message/NoticeModify.aspx', N'003', 1, 3, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003008', N'公告查看', 2, N'../Message/NoticeViewList.aspx', N'003', 1, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003009', N'查看公告', 2, N'../Message/NoticeView.aspx', N'003', 1, 5, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003016', N'线上应用', 0, N' ../Message/Info.aspx', N'003', 0, 56, N'', 1, 1, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'003019', N'留言详情', 0, N'../Message/TaskView.aspx', N'003', 1, 5, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00317', N'留言记录', 0, N'../Message/TaskList.aspx', N'003', 1, 6, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00318', N'我要留言', 0, N'../Message/TaskAdd.aspx', N'003', 1, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00319', N'回复', 0, N'../Message/TaskReply.aspx', N'003', 1, 5, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004', N'参与者', 1, N'', N'0', 1, 6, N'icon-book', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004001', N'新成员注册', 2, N'../Member/Add.aspx', N'004', 1, 1, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004002', N'参与者列表', 2, N'../Member/List.aspx', N'004', 1, 2, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004003', N'我的推荐', 2, N'../Member/TJList.aspx', N'004', 1, 3, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004004', N'推荐图谱', 2, N'../Member/TJNet.aspx', N'004', 1, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004005', N'交易统计', 2, N'../Member/ListInfo.aspx', N'004', 1, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004006', N'收入统计', 2, N'../Member/MemberYJList.aspx', N'004', 1, 6, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'0040061', N'团队图谱', 2, N'../Member/Structure.aspx', N'004', 0, 3, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004007', N'我的链接', 2, N'../Member/MyLink.aspx', N'004', 1, 7, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'0040071', N'推荐列表', 2, N'../Member/TJList.aspx', N'004', 0, 9, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004008', N'快捷设置', 2, N'../Member/ShortcutSet.aspx', N'004', 1, 0, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004010', N'修改资料', 2, N'../Member/ModifyMember.aspx', N'004', 1, 0, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004014', N'我的市场', 2, N'../Member/MyTJBDList.aspx', N'004', 0, 1, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'004015', N'激活会员', 2, N'../Member/SHList.aspx', N'004', 0, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005', N'系统设置', 1, N'', N'0', 1, 14, N'icon-cogs', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005001', N'权限修改', 2, N'../SysManage/MenuEdit.aspx', N'005', 1, 4, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005002', N'权限管理', 2, N'../SysManage/GrantPowers.aspx', N'005', 1, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005003', N'奖金参数', 2, N'../SysManage/Configuration.aspx', N'005', 1, 3, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005005', N'模拟器', 2, N'../Simulate/Index.aspx', N'005', 0, 6, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005006', N'页面验证', 2, N'../SysManage/RolePowers.aspx', N'005', 1, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005007', N'网站设置', 2, N'../SysManage/WebSet.aspx', N'005', 1, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005008', N'数据备份', 2, NULL, N'005', 0, 10, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005009', N'数据还原', 2, NULL, N'005', 0, 11, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005010', N'角色管理', 2, N'../SysManage/RolesList.aspx', N'005', 0, 7, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005011', N'添加角色', 2, N'../SysManage/AddRoles.aspx', N'005', 0, 8, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005012', N'修改角色', 2, N'../SysManage/ModifyRoles.aspx', N'005', 0, 8, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005013', N'银行管理', 2, N'../SysManage/BankInfo.aspx', N'005', 0, 12, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'005015', N'语言配置', 2, N'../Language/List.aspx', N'005', 0, 15, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00516', N'数据字典', 0, N'../SysManage/DictEdit.aspx', N'005', 0, 30, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00517', N'重置业绩', 0, N'../SysManage/ReCountYJCount.aspx', N'005', 0, 2, N'', 1, 0, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00518', N'提示信息', 0, N'../Message/RemindMsg.aspx', N'005', 0, 9, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00519', N'3M配置', 0, N'../SysManage/MMMConfigEdit.aspx', N'005', 1, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00520', N'官网轮播', 0, N'../Message/IndexShowMsgList.aspx', N'005', 0, 90, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'00521', N'3M抢单配置', 0, N'../SysManage/MMMConfigScrambleEdit.aspx', N'005', 0, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'006', N'公司产品', 1, NULL, N'0', 0, 7, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'006001', N'产品管理', 2, N'../Goods/GoodsList.aspx', N'006', 0, 1, N'', 1, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'006002', N'添加产品', 2, N'../Goods/Add.aspx', N'006', 0, 2, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'006003', N'修改产品', 2, N'../Goods/Modify.aspx', N'006', 0, 3, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'007', N'账户安全', 1, N'', N'0', 1, 10, N'icon-tasks', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'007001', N'登录密码修改', 2, N'../SecurityCenter/ModifyPwd.aspx', N'007', 1, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'007002', N'二级密码修改', 2, N'../SecurityCenter/ModifySecPwd.aspx', N'007', 1, 2, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'007003', N'安全问题', 2, NULL, N'007', 0, 3, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'007004', N'邮箱功能', 2, N'../SecurityCenter/MyEMail.aspx', N'007', 0, 4, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'007005', N'密保问题', 2, N'../SecurityCenter/SecurityQuestion.aspx', N'007', 0, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009', N'互助交易', 1, N'', N'0', 1, 8, N'icon-glass', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009001', N'提供帮助', 0, N'../Mafull/OfferHelp.aspx', N'009', 1, 1, N'', 1, 1, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009002', N'提供帮助列表 ', 0, N'../Mafull/OfferHelpList.aspx', N'009', 1, 2, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009003', N'获得帮助', 0, N'../Mafull/GetHelp.aspx', N'009', 1, 3, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009004', N'获得帮助列表', 0, N'../Mafull/GetHelpList.aspx', N'009', 1, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009005', N'抢购放单', 2, N'../Mafull/OfferPutScramble.aspx', N'009', 0, 5, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009006', N'我要抢单', 2, N'../Mafull/OfferScramble.aspx', N'009', 1, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009007', N'提供帮助拆分', 2, N'../Mafull/OfferSplit.aspx', N'009', 0, 16, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009008', N'获得帮助拆分', 2, N'../Mafull/GetSplit.aspx', N'009', 0, 17, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009016', N'奖金统计', 2, N'../Member/MemberYJList.aspx', N'009', 0, 5, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009017', N'奖金明细', 2, N'../ChangeMoney/JJList.aspx', N'009', 1, 6, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009018', N'奖金统计', 2, N'../ChangeMoney/JJJLList.aspx', N'009', 1, 7, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009019', N'获得帮助—匹配记录', 0, N'../Mafull/MatchGetList.aspx', N'009', 1, 8, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009020', N'提供帮助—匹配列表', 0, N'../Mafull/MatchOfferList.aspx', N'009', 1, 9, N'', 0, 0, N'', 0, N'')
GO
print 'Processed 100 total records'
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009021', N'审核拒绝列表', 0, N'../Mafull/MatchGetListJujue.aspx', N'009', 1, 10, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009022', N'付款', 0, N'../Mafull/PayMoney.aspx', N'009', 1, 11, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009023', N'收款', 0, N'../Mafull/GetMoney.aspx', N'009', 1, 12, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009024', N'详情', 0, N'../Mafull/MatchView.aspx', N'009', 1, 13, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009025', N'交易总计', 2, N'../Mafull/MafullStatic.aspx', N'009', 1, 14, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009026', N'查看信息', 2, N'../Member/ViewMember.aspx', N'009', 1, 15, N'', 0, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'009027', N'聊天', 0, N'../Mafull/chat/chat.aspx', N'009', 1, 13, N'', 0, 0, N'Attachment/2015102016392518.png', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'016', N'升级经理', 1, N'', N'0', 0, 8, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'016002', N'我的申请', 2, N'../ChangeMoney/HTSJList.aspx', N'016', 0, 2, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'01617', N'审核激活码详细', 0, N'../Member/SHActiveCodeDetail.aspx', N'020', 0, 2, N'', 0, 0, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'0164', N'审核购买激活码', 0, N'../Member/SHActiveCode.aspx', N'020', 0, 2, N'', 1, 0, N'', 0, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'0166', N'申请升级', 0, N'../Member/UpMAgencyCode.aspx', N'016', 0, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'0167', N'审核申请', 0, N'../Member/BCenterList.aspx', N'016', 0, 1, N'', 1, 1, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'017', N'增值币交易', 1, N'', N'0', 0, 17, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'017005', N'交易配置', 2, N'../JD/JDConfig.aspx', N'017', 0, 17, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'017006', N'增值币买入', 2, N'../JD/JDBuy.aspx', N'017', 0, 17, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'019', N'我要复投', 0, N'', N'0', 0, 9, N'icon-glass', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'019001', N'我要复投', 0, N'../FuTou/FTAdd.aspx', N'019', 0, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'019002', N'复投明细', 0, N'../FuTou/FTList.aspx', N'019', 0, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'020', N'手动操作', 1, N'', N'0', 1, 15, N'icon-th-list', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'020002', N'充值管理', 2, N'../ChangeMoney/GMList.aspx', N'020', 1, 3, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'020011', N'会员充值', 2, N'../ChangeMoney/HBGM.aspx', N'020', 1, 1, N'', 0, 1, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'020018', N'奖励会员', 2, N'../ChangeMoney/HBJL.aspx', N'020', 1, 1, N'', 0, 0, N'', NULL, NULL)
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'02010', N'创建激活码', 0, N'../Member/GetActiveCode.aspx', N'020', 1, 1, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'02011', N'手动匹配/时', 0, N'../Mafull/MatchHelp.aspx', N'020', 1, 4, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'02043', N'打款收款检验/分', 0, N'../Mafull/JTAccont2.aspx', N'020', 1, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'02044', N'利息/日解/天', 0, N'../Mafull/JTAccont.aspx', N'020', 0, 5, N'', 1, 0, N'', 0, N'')
INSERT [dbo].[Contents] ([CID], [CTitle], [CLevel], [CAddress], [CFID], [CState], [CIndex], [CImage], [VState], [IsQuickMenu], [Remark], [IsOuterLink], [OuterAddress]) VALUES (N'02045', N'会员扣费', 0, N'../ChangeMoney/HBKF.aspx', N'020', 1, 3, N'', 1, 0, N'', 0, N'')
/****** Object:  Table [dbo].[Configuration]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configuration](
	[YLMoney] [int] NULL,
	[BDCount] [int] NULL,
	[DefaultRole] [varchar](10) NULL,
	[TXMinMoney] [int] NULL,
	[TXBaseMoney] [int] NULL,
	[ZZMinMoney] [int] NULL,
	[ZZBaseMoney] [int] NULL,
	[DHMinMoney] [int] NULL,
	[DHBaseMoney] [int] NULL,
	[InFloat] [decimal](18, 2) NULL,
	[OutFloat] [decimal](18, 2) NULL,
	[MaxDPCount] [int] NULL,
	[DPTopFloat] [decimal](18, 4) NULL,
	[DMHBPart] [decimal](18, 2) NULL,
	[DMGPPart] [decimal](18, 2) NULL,
	[JMHBPart] [decimal](18, 2) NULL,
	[JMGPPart] [decimal](18, 2) NULL,
	[GPrice] [decimal](18, 2) NULL,
	[DFHFloat] [decimal](18, 2) NULL,
	[DFHTopMoney] [decimal](18, 2) NULL,
	[MinBuyGCount] [int] NULL,
	[GLMoney] [decimal](18, 2) NULL,
	[AutoDFH] [bit] NULL,
	[MaxBuyGCount] [int] NULL,
	[DFHXFCount] [int] NULL,
	[DFHOutCount] [int] NULL,
	[CanRegedit] [bit] NULL,
	[DayRegeditNumber] [int] NULL,
	[ShowOfferTotalMoney] [decimal](18, 2) NULL,
	[ShowGetTotalMoney] [decimal](18, 2) NULL,
	[ShowTotalNumber] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Configuration] ([YLMoney], [BDCount], [DefaultRole], [TXMinMoney], [TXBaseMoney], [ZZMinMoney], [ZZBaseMoney], [DHMinMoney], [DHBaseMoney], [InFloat], [OutFloat], [MaxDPCount], [DPTopFloat], [DMHBPart], [DMGPPart], [JMHBPart], [JMGPPart], [GPrice], [DFHFloat], [DFHTopMoney], [MinBuyGCount], [GLMoney], [AutoDFH], [MaxBuyGCount], [DFHXFCount], [DFHOutCount], [CanRegedit], [DayRegeditNumber], [ShowOfferTotalMoney], [ShowGetTotalMoney], [ShowTotalNumber]) VALUES (100, 999999, N'Nomal', 1000, 50000, 1, 1, 0, 20, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 5, CAST(0.1000 AS Decimal(18, 4)), CAST(0.70 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), CAST(1.60 AS Decimal(18, 2)), 1, CAST(70.00 AS Decimal(18, 2)), 0, 1, 1, 43200, 1, 222, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Configuration] ([YLMoney], [BDCount], [DefaultRole], [TXMinMoney], [TXBaseMoney], [ZZMinMoney], [ZZBaseMoney], [DHMinMoney], [DHBaseMoney], [InFloat], [OutFloat], [MaxDPCount], [DPTopFloat], [DMHBPart], [DMGPPart], [JMHBPart], [JMGPPart], [GPrice], [DFHFloat], [DFHTopMoney], [MinBuyGCount], [GLMoney], [AutoDFH], [MaxBuyGCount], [DFHXFCount], [DFHOutCount], [CanRegedit], [DayRegeditNumber], [ShowOfferTotalMoney], [ShowGetTotalMoney], [ShowTotalNumber]) VALUES (100, 999999, N'Nomal', 1000, 50000, 1, 1, 0, 20, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 5, CAST(0.1000 AS Decimal(18, 4)), CAST(0.70 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), CAST(1.60 AS Decimal(18, 2)), 1, CAST(70.00 AS Decimal(18, 2)), 0, 1, 1, 43200, 1, 222, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0)
/****** Object:  Table [dbo].[ConfigDictionary]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfigDictionary](
	[DType] [varchar](10) NOT NULL,
	[StartLevel] [int] NOT NULL,
	[EndLevel] [int] NULL,
	[DValue] [varchar](10) NULL,
	[DKey] [varchar](100) NOT NULL,
	[Remark] [varchar](100) NULL,
 CONSTRAINT [PK_BDMoneySetUp] PRIMARY KEY CLUSTERED 
(
	[DType] ASC,
	[StartLevel] ASC,
	[DKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 1, 1, N'0', N'', N'1代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 2, 2, N'0.01', N'', N'2代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 3, 3, N'0.03', N'', N'3代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 4, 4, N'0.02', N'', N'4代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 5, 5, N'0.004', N'', N'5代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 6, 6, N'0.003', N'', N'6代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 7, 7, N'0.002', N'', N'7代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLFloat', 8, 99999, N'0.001', N'', N'8-无限代管理奖')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 1, 1, N'1', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 2, 2, N'2', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 3, 3, N'3', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 4, 4, N'4', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 5, 5, N'5', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 6, 6, N'6', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 7, 7, N'7', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'GLLevel', 8, 99999, N'99999', N'', N'推荐1人拿一层')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'MGetMGP', 0, 100000, N'0.1', N'', N'动态奖提现消耗排单币')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'MGPOffer', 2000, 2000, N'100', N'', N'消耗排单币')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'MGPOffer', 5000, 5000, N'200', N'', N'消耗排单币')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'MGPOffer', 10000, 10000, N'300', N'', N'消耗排单币')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'MGPOffer', 20000, 20000, N'500', N'', N'消耗排单币')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferLX', 0, 19999, N'0.3', N'', N'排单正常利息')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferLX', 20000, 20000, N'0.25', N'', N'排单正常利息')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopTJ', 0, 1, N'2000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopTJ', 2, 2, N'5000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopTJ', 3, 4, N'10000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopTJ', 5, 99999, N'20000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopYJ', 0, 4, N'2000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopYJ', 5, 9, N'5000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopYJ', 10, 19, N'10000', N'', N'最大排单金额')
INSERT [dbo].[ConfigDictionary] ([DType], [StartLevel], [EndLevel], [DValue], [DKey], [Remark]) VALUES (N'OfferTopYJ', 20, 99999, N'20000', N'', N'最大排单金额')
/****** Object:  Table [dbo].[ChangeMoney]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChangeMoney](
	[CID] [int] IDENTITY(1,1) NOT NULL,
	[FromMID] [varchar](20) NULL,
	[ToMID] [varchar](20) NULL,
	[Money] [decimal](18, 4) NULL,
	[ChangeDate] [datetime] NULL,
	[ChangeType] [varchar](10) NULL,
	[MoneyType] [varchar](10) NULL,
	[CState] [bit] NULL,
	[SHMID] [varchar](20) NULL,
	[TakeOffMoney] [decimal](18, 4) NULL,
	[ReBuyMoney] [decimal](18, 4) NULL,
	[MCWMoney] [decimal](18, 4) NULL,
	[CRemarks] [varchar](200) NULL,
	[CFileds] [varchar](50) NULL,
	[CFileds2] [varchar](50) NULL,
	[OrderState] [int] NULL,
	[CompleteTime] [datetime] NULL,
 CONSTRAINT [PK_ChangeMoney] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_ChangeMoney] ON [dbo].[ChangeMoney] 
(
	[ToMID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChangeMoney] ON
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (819, N'admin', N'aaa111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69E011827A7 AS DateTime), N'CZ', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (820, N'admin', N'aaa111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69E01184AFD AS DateTime), N'CZ', N'MGP', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (821, N'aaa111', N'admin', CAST(100.0000 AS Decimal(18, 4)), CAST(0x0000A69E01185DFF AS DateTime), N'TGBH', N'MGP', 1, N'aaa111', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'提供帮助需100个排单币', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (822, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A462C9 AS DateTime), N'CZ', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (823, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A467D6 AS DateTime), N'CZ', N'MJB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (824, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A48246 AS DateTime), N'CZ', N'MJB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (825, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A4F74A AS DateTime), N'CZ', N'MJB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (826, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A56CC7 AS DateTime), N'CZ', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (827, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A57C4C AS DateTime), N'CZ', N'MJB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (828, N'admin', N'bbb111', CAST(100000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A5AA30 AS DateTime), N'CZ', N'MJB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (831, N'bbb111', N'admin', CAST(2000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00A8825B AS DateTime), N'GET', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'bbb111申请获得2000的帮助', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (832, N'aaa111', N'admin', CAST(100.0000 AS Decimal(18, 4)), CAST(0x0000A69F00B67805 AS DateTime), N'TGBH', N'MGP', 1, N'aaa111', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'提供帮助需100个排单币', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (833, N'bbb111', N'admin', CAST(2000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00B680F9 AS DateTime), N'GET', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'bbb111申请获得2000的帮助', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (834, N'aaa111', N'admin', CAST(100.0000 AS Decimal(18, 4)), CAST(0x0000A69F00E21999 AS DateTime), N'TGBH', N'MGP', 1, N'aaa111', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'提供帮助需100个排单币', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (835, N'aaa111', N'admin', CAST(2000.0000 AS Decimal(18, 4)), CAST(0x0000A69F00F7E535 AS DateTime), N'GET', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'aaa111申请获得2000的帮助', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (836, N'admin', N'aaa111', CAST(2400.0000 AS Decimal(18, 4)), CAST(0x0000A69F00FBF0C0 AS DateTime), N'TGBZ', N'MHB', 1, N'aaa111', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'提供帮助(C139F7372722428)本金加利息', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (837, N'aaa111', N'admin', CAST(2000.0000 AS Decimal(18, 4)), CAST(0x0000A69F010004DE AS DateTime), N'GET', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'aaa111申请获得2000的帮助', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (838, N'aaa111', N'admin', CAST(100.0000 AS Decimal(18, 4)), CAST(0x0000A69F0111CE53 AS DateTime), N'TGBH', N'MGP', 1, N'aaa111', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'提供帮助需100个排单币', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (839, N'bbb111', N'admin', CAST(2000.0000 AS Decimal(18, 4)), CAST(0x0000A69F0111DA27 AS DateTime), N'GET', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'bbb111申请获得2000的帮助', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (840, N'admin', N'bbb111', CAST(2400.0000 AS Decimal(18, 4)), CAST(0x0000A69F012AB29F AS DateTime), N'TGBZ', N'MHB', 1, N'bbb111', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'提供帮助(F223461AA4544F1)本金加利息', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
INSERT [dbo].[ChangeMoney] ([CID], [FromMID], [ToMID], [Money], [ChangeDate], [ChangeType], [MoneyType], [CState], [SHMID], [TakeOffMoney], [ReBuyMoney], [MCWMoney], [CRemarks], [CFileds], [CFileds2], [OrderState], [CompleteTime]) VALUES (841, N'bbb111', N'admin', CAST(2000.0000 AS Decimal(18, 4)), CAST(0x0000A6A000C406EF AS DateTime), N'GET', N'MHB', 1, N'', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'bbb111申请获得2000的帮助', NULL, NULL, 0, CAST(0x002D247F018B81FF AS DateTime))
SET IDENTITY_INSERT [dbo].[ChangeMoney] OFF
/****** Object:  Table [dbo].[BuyActiveCode]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BuyActiveCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodeCount] [int] NULL,
	[FromMID] [varchar](50) NULL,
	[ToMID] [varchar](50) NULL,
	[PayTime] [datetime] NULL,
	[ConfirmTime] [datetime] NULL,
	[PicUrl] [varchar](500) NULL,
	[Remark] [varchar](500) NULL,
	[State] [int] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_BuyActiveCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BMember]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BMember](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AMID] [varchar](20) NOT NULL,
	[BMID] [varchar](20) NULL,
	[BMBD] [varchar](20) NULL,
	[BMCreateDate] [datetime] NULL,
	[BMDate] [datetime] NULL,
	[BMState] [bit] NULL,
	[BIsClock] [bit] NULL,
	[YJCount] [decimal](18, 2) NULL,
	[YJMoney] [decimal](18, 2) NULL,
	[BCount] [decimal](18, 2) NULL,
	[BOutMoney] [decimal](18, 2) NULL,
	[FHDays] [int] NULL,
 CONSTRAINT [PK_BMember_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCenter]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCenter](
	[MID] [varchar](20) NOT NULL,
	[MName] [varchar](20) NULL,
	[Des] [varchar](100) NULL,
	[AddDate] [datetime] NULL,
	[Flag] [varchar](10) NULL,
 CONSTRAINT [PK_BCenter] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BankModel]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankModel](
	[BankCode] [varchar](36) NOT NULL,
	[Bank] [varchar](50) NULL,
	[Branch] [varchar](50) NULL,
	[BankNumber] [varchar](30) NULL,
	[BankCardName] [varchar](20) NULL,
	[MID] [varchar](20) NULL,
	[IsPrimary] [bit] NULL,
	[BankCreateDate] [datetime] NULL,
 CONSTRAINT [PK_BankModel] PRIMARY KEY CLUSTERED 
(
	[BankCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActiveCode]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActiveCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NOT NULL,
	[MID] [varchar](40) NULL,
	[UseState] [int] NULL,
	[CreateTime] [datetime] NULL,
	[UseMID] [varchar](40) NULL,
	[UseTime] [datetime] NULL,
	[switchType] [nvarchar](50) NULL,
 CONSTRAINT [PK_ActiveCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ActiveCode] ON
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (301, N'53DB61188F', N'admin', 2, CAST(0x0000A69E00A69938 AS DateTime), N'aaa111', CAST(0x0000A69E0102CE54 AS DateTime), N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (302, N'9D5748B1FC', N'admin', 2, CAST(0x0000A69E00A69938 AS DateTime), N'bbb111', CAST(0x0000A69E01191013 AS DateTime), N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (303, N'F975E7DA6D', N'admin', 0, CAST(0x0000A69E00A69A39 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (304, N'0C508D8951', N'admin', 0, CAST(0x0000A69E00A69A3C AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (305, N'CA37D48335', N'admin', 0, CAST(0x0000A69E00A69A3C AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (306, N'DDCD1C0910', N'admin', 0, CAST(0x0000A69E00A69A3F AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (307, N'BB498F1E82', N'admin', 0, CAST(0x0000A69E00A69A42 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (308, N'D4D775E6E6', N'admin', 0, CAST(0x0000A69E00A69A45 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (309, N'A490768E8A', N'admin', 0, CAST(0x0000A69E00A69A48 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (310, N'7E703BA965', N'admin', 0, CAST(0x0000A69E00A69A48 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (311, N'D1F763FE74', N'admin', 0, CAST(0x0000A69E00A69A4B AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (312, N'D310463AE6', N'admin', 0, CAST(0x0000A69E00A69A4E AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (313, N'F948551F67', N'admin', 0, CAST(0x0000A69E00A69A51 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (314, N'12999D9AF4', N'admin', 0, CAST(0x0000A69E00A69A54 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (315, N'7E124D30A9', N'admin', 0, CAST(0x0000A69E00A69A54 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (316, N'0EFBE117DD', N'admin', 0, CAST(0x0000A69E00A69A57 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (317, N'B8093DDEAA', N'admin', 0, CAST(0x0000A69E00A69A5A AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (318, N'D0804FB692', N'admin', 0, CAST(0x0000A69E00A69A5D AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (319, N'6CB78629FC', N'admin', 0, CAST(0x0000A69E00A69A60 AS DateTime), NULL, NULL, N'生成')
INSERT [dbo].[ActiveCode] ([Id], [Code], [MID], [UseState], [CreateTime], [UseMID], [UseTime], [switchType]) VALUES (320, N'5F46863D2A', N'admin', 0, CAST(0x0000A69E00A69A60 AS DateTime), NULL, NULL, N'生成')
SET IDENTITY_INSERT [dbo].[ActiveCode] OFF
/****** Object:  Table [dbo].[Accounts]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ACode] [varchar](36) NOT NULL,
	[PCode] [varchar](10) NULL,
	[AccountsDate] [datetime] NULL,
	[TotalFHMoney] [decimal](18, 2) NULL,
	[FHCount] [int] NULL,
	[IsAuto] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[IfAccount] [bit] NULL,
	[ARemark] [varchar](20) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ACode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON
INSERT [dbo].[Accounts] ([ID], [ACode], [PCode], [AccountsDate], [TotalFHMoney], [FHCount], [IsAuto], [CreateDate], [IfAccount], [ARemark]) VALUES (19, N'aaa111_20161013154217', N'005', CAST(0x0000A69E0102CE59 AS DateTime), CAST(0.00 AS Decimal(18, 2)), 0, 1, CAST(0x0000A69E0102CE57 AS DateTime), 1, N'aaa111')
INSERT [dbo].[Accounts] ([ID], [ACode], [PCode], [AccountsDate], [TotalFHMoney], [FHCount], [IsAuto], [CreateDate], [IfAccount], [ARemark]) VALUES (20, N'bbb111_20161013170319', N'005', CAST(0x0000A69E01191017 AS DateTime), CAST(0.00 AS Decimal(18, 2)), 0, 1, CAST(0x0000A69E01191016 AS DateTime), 1, N'bbb111')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
/****** Object:  Table [dbo].[FHList]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FHList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SumFHMoney] [int] NULL,
	[FHFloat] [decimal](18, 4) NULL,
	[FHTotal] [int] NULL,
	[FHDate] [datetime] NULL,
	[FHType] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FDSellList]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FDSellList](
	[SellID] [int] IDENTITY(1,1) NOT NULL,
	[SellMID] [varchar](50) NULL,
	[SellTotalCount] [int] NULL,
	[SellCount] [int] NULL,
	[SellPrice] [decimal](18, 4) NULL,
	[SellMoney] [decimal](18, 4) NULL,
	[SellDate] [datetime] NULL,
	[LastSellDate] [datetime] NULL,
	[SellState] [int] NULL,
	[BuyID] [int] NULL,
	[SellFDName] [varchar](10) NULL,
	[BuyDate] [datetime] NULL,
	[ChaiFenCode] [int] NULL,
 CONSTRAINT [PK_FDSellList] PRIMARY KEY CLUSTERED 
(
	[SellID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FDConfig]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FDConfig](
	[FDName] [varchar](10) NOT NULL,
	[FDCFFloat] [decimal](18, 4) NULL,
	[FDMHBFloat] [decimal](18, 4) NULL,
	[FDMGPFloat] [decimal](18, 4) NULL,
	[FDMCWFloat] [decimal](18, 4) NULL,
	[FDSellCount] [int] NULL,
	[FDPrice] [decimal](18, 4) NULL,
	[FDStartTime] [datetime] NULL,
	[FDEndTime] [datetime] NULL,
	[FDCloseRemark] [varchar](200) NULL,
	[FDState] [bit] NULL,
 CONSTRAINT [PK_FDConfig] PRIMARY KEY CLUSTERED 
(
	[FDName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[FDConfig] ([FDName], [FDCFFloat], [FDMHBFloat], [FDMGPFloat], [FDMCWFloat], [FDSellCount], [FDPrice], [FDStartTime], [FDEndTime], [FDCloseRemark], [FDState]) VALUES (N'A', CAST(1.8000 AS Decimal(18, 4)), CAST(0.4200 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.3800 AS Decimal(18, 4)), 700000, CAST(0.1000 AS Decimal(18, 4)), CAST(0x0000A4F000000000 AS DateTime), CAST(0x0000A4F0018B3BB0 AS DateTime), N'开放时间', 1)
INSERT [dbo].[FDConfig] ([FDName], [FDCFFloat], [FDMHBFloat], [FDMGPFloat], [FDMCWFloat], [FDSellCount], [FDPrice], [FDStartTime], [FDEndTime], [FDCloseRemark], [FDState]) VALUES (N'B', CAST(1.8000 AS Decimal(18, 4)), CAST(0.4200 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.3800 AS Decimal(18, 4)), 700000, CAST(0.1000 AS Decimal(18, 4)), CAST(0x0000A4ED00000000 AS DateTime), CAST(0x0000A4ED018B3BB0 AS DateTime), N'开放时间', 1)
INSERT [dbo].[FDConfig] ([FDName], [FDCFFloat], [FDMHBFloat], [FDMGPFloat], [FDMCWFloat], [FDSellCount], [FDPrice], [FDStartTime], [FDEndTime], [FDCloseRemark], [FDState]) VALUES (N'C', CAST(1.8000 AS Decimal(18, 4)), CAST(0.4200 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.3800 AS Decimal(18, 4)), 700000, CAST(0.1000 AS Decimal(18, 4)), CAST(0x0000A4ED00000000 AS DateTime), CAST(0x0000A4ED018B3BB0 AS DateTime), N'开放时间', 1)
INSERT [dbo].[FDConfig] ([FDName], [FDCFFloat], [FDMHBFloat], [FDMGPFloat], [FDMCWFloat], [FDSellCount], [FDPrice], [FDStartTime], [FDEndTime], [FDCloseRemark], [FDState]) VALUES (N'D', CAST(1.8000 AS Decimal(18, 4)), CAST(0.4200 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.3800 AS Decimal(18, 4)), 700000, CAST(0.1000 AS Decimal(18, 4)), CAST(0x0000A4ED00000000 AS DateTime), CAST(0x0000A4ED018B3BB0 AS DateTime), N'开放时间', 1)
/****** Object:  Table [dbo].[FDBuyList]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FDBuyList](
	[BuyID] [int] IDENTITY(1,1) NOT NULL,
	[BuyMID] [varchar](50) NULL,
	[BuyCount] [int] NULL,
	[BuyMoney] [decimal](18, 4) NULL,
	[BuyDate] [datetime] NULL,
	[CFState] [bit] NULL,
	[MoneyType] [varchar](10) NULL,
	[BuyPrice] [decimal](18, 4) NULL,
	[BuyState] [int] NULL,
	[BuyFDName] [varchar](10) NULL,
 CONSTRAINT [PK_FDBuyList] PRIMARY KEY CLUSTERED 
(
	[BuyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EPList]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EPList](
	[EPID] [int] IDENTITY(1,1) NOT NULL,
	[SellMID] [varchar](50) NULL,
	[SellDate] [datetime] NULL,
	[MoneyType] [varchar](20) NULL,
	[Money] [decimal](18, 2) NULL,
	[SellState] [int] NULL,
	[BuyMID] [varchar](50) NULL,
	[BuyDate] [datetime] NULL,
	[LastBuyDate] [datetime] NULL,
	[LastSellDate] [datetime] NULL,
	[TakeOffMoney] [decimal](18, 2) NULL,
 CONSTRAINT [PK_EPList] PRIMARY KEY CLUSTERED 
(
	[EPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EPJX]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EPJX](
	[EPJXTime] [datetime] NULL,
	[JXID] [int] IDENTITY(1,1) NOT NULL,
	[EPJXRemark] [varchar](200) NULL,
	[EPJXMID] [varchar](50) NULL,
 CONSTRAINT [PK_EPJX_1] PRIMARY KEY CLUSTERED 
(
	[JXID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EPConfig]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EPConfig](
	[EPState] [bit] NULL,
	[EPStartTime] [datetime] NULL,
	[EPEndTime] [datetime] NULL,
	[EPJYType] [int] NULL,
	[EPJYMinMoney] [int] NULL,
	[EPJYBaseMoney] [int] NULL,
	[EPMoneyStr] [varchar](100) NULL,
	[EPProtocol] [text] NULL,
	[EPMoneyType] [varchar](50) NULL,
	[EPTimeOut] [int] NULL,
	[EPTimeOutCount] [int] NULL,
	[EPTimeOutJXCount] [int] NULL,
	[EPJYMAgencyTypeStr] [varchar](100) NULL,
	[EPTakeOffMoney] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EPConfig] ([EPState], [EPStartTime], [EPEndTime], [EPJYType], [EPJYMinMoney], [EPJYBaseMoney], [EPMoneyStr], [EPProtocol], [EPMoneyType], [EPTimeOut], [EPTimeOutCount], [EPTimeOutJXCount], [EPJYMAgencyTypeStr], [EPTakeOffMoney]) VALUES (1, CAST(0x0000A50C00000000 AS DateTime), CAST(0x0000A50C018B3BB0 AS DateTime), 1, 300, 1, N'', N'<p><span style="color:#ff0000;">收款后三个小时内请务必点击确认收款，以免影响信誉</span></p>', N'MHB', 120, 10, 1, N'', CAST(0.10 AS Decimal(18, 2)))
INSERT [dbo].[EPConfig] ([EPState], [EPStartTime], [EPEndTime], [EPJYType], [EPJYMinMoney], [EPJYBaseMoney], [EPMoneyStr], [EPProtocol], [EPMoneyType], [EPTimeOut], [EPTimeOutCount], [EPTimeOutJXCount], [EPJYMAgencyTypeStr], [EPTakeOffMoney]) VALUES (1, CAST(0x0000A50C00000000 AS DateTime), CAST(0x0000A50C018B3BB0 AS DateTime), 1, 300, 1, N'', N'<p><span style="color:#ff0000;">收款后三个小时内请务必点击确认收款，以免影响信誉</span></p>', N'MHB', 120, 10, 1, N'', CAST(0.10 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[WriteEmail]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WriteEmail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[WriteTime] [datetime] NULL,
	[WriteBy] [varchar](50) NULL,
	[WriteContent] [ntext] NULL,
	[PublishBy] [varchar](50) NULL,
	[PublishTime] [datetime] NULL,
 CONSTRAINT [PK_WriteEmail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WebSetInfo]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebSetInfo](
	[WebState] [bit] NULL,
	[WebTitle] [nvarchar](255) NULL,
	[WKeyword] [nvarchar](255) NULL,
	[WDescription] [nvarchar](255) NULL,
	[WCopyright] [nvarchar](255) NULL,
	[OpenTimeStr] [varchar](100) NULL,
	[CloseInfo] [nvarchar](255) NULL,
	[TXInfo] [nvarchar](255) NULL,
	[HKInfo] [nvarchar](2550) NULL,
	[PageSize] [int] NULL,
	[RegionalDirectorCondition] [nvarchar](500) NULL,
	[RegionalDirectorTreatment] [nvarchar](500) NULL,
	[ServerCenterCondition] [nvarchar](500) NULL,
	[ServerCenterTreatment] [nvarchar](500) NULL,
	[BTCenterCondition] [nvarchar](500) NULL,
	[BTCenterTreatment] [nvarchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[WebSetInfo] ([WebState], [WebTitle], [WKeyword], [WDescription], [WCopyright], [OpenTimeStr], [CloseInfo], [TXInfo], [HKInfo], [PageSize], [RegionalDirectorCondition], [RegionalDirectorTreatment], [ServerCenterCondition], [ServerCenterTreatment], [BTCenterCondition], [BTCenterTreatment]) VALUES (1, N'汇聚精英', N'汇聚精英', N'汇聚精英', N'Copyright © 2016 - 2026  汇聚精英', N'00:01-23:59;', N'清理会员中', N'192.168.1.11', N'请认真确认汇款信息，避免失误操作造成个人损失！', 20, N'周一至周五 ：8:00-10:30', N'周六至周日 ：8:30-9:30', N'金钥匙：0065-68426547', N'邮箱：jinyaoshivipkefu@163.com', N'youtube：mank', N'根据加入的会员等级不同，可向公司申请保单中心，可获得每单1%的提成
')
INSERT [dbo].[WebSetInfo] ([WebState], [WebTitle], [WKeyword], [WDescription], [WCopyright], [OpenTimeStr], [CloseInfo], [TXInfo], [HKInfo], [PageSize], [RegionalDirectorCondition], [RegionalDirectorTreatment], [ServerCenterCondition], [ServerCenterTreatment], [BTCenterCondition], [BTCenterTreatment]) VALUES (1, N'汇聚精英', N'汇聚精英', N'汇聚精英', N'Copyright © 2016 - 2026  汇聚精英', N'00:01-23:59;', N'清理会员中', N'192.168.1.11', N'请认真确认汇款信息，避免失误操作造成个人损失！', 20, N'周一至周五 ：8:00-10:30', N'周六至周日 ：8:30-9:30', N'金钥匙：0065-68426547', N'邮箱：jinyaoshivipkefu@163.com', N'youtube：mank', N'根据加入的会员等级不同，可向公司申请保单中心，可获得每单1%的提成
')
/****** Object:  Table [dbo].[WebBase]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WebBase](
	[SMSState] [bit] NULL,
	[SMSName] [varchar](50) NULL,
	[SMSPassword] [varchar](50) NULL,
	[TelVerify] [bit] NULL,
	[SMSTitle] [varchar](50) NULL,
	[MonitorTel] [varchar](50) NULL,
	[SMSMinCount] [int] NULL,
	[EmailSmtp] [varchar](50) NULL,
	[EmailName] [varchar](50) NULL,
	[EmailPassword] [varchar](50) NULL,
	[EmailTitle] [varchar](50) NULL,
	[EmailVerify] [bit] NULL,
	[EmailState] [bit] NULL,
	[DaySMSCount] [int] NULL,
	[RandPassword] [bit] NULL,
	[MonitorEmail] [varchar](50) NULL,
	[AutoID] [bit] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[WebBase] ([SMSState], [SMSName], [SMSPassword], [TelVerify], [SMSTitle], [MonitorTel], [SMSMinCount], [EmailSmtp], [EmailName], [EmailPassword], [EmailTitle], [EmailVerify], [EmailState], [DaySMSCount], [RandPassword], [MonitorEmail], [AutoID]) VALUES (1, N'yny', N'yny15818877968yy', 0, N'', N'', 100, N'smtp.qq.com', N'', N'', N'', 0, 1, 100, 0, N'@qq.com', 1)
INSERT [dbo].[WebBase] ([SMSState], [SMSName], [SMSPassword], [TelVerify], [SMSTitle], [MonitorTel], [SMSMinCount], [EmailSmtp], [EmailName], [EmailPassword], [EmailTitle], [EmailVerify], [EmailState], [DaySMSCount], [RandPassword], [MonitorEmail], [AutoID]) VALUES (1, N'yny', N'yny15818877968yy', 0, N'', N'', 100, N'smtp.qq.com', N'', N'', N'', 0, 1, 100, 0, N'@qq.com', 1)
/****** Object:  Table [dbo].[TempMember]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempMember](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [varchar](20) NULL,
 CONSTRAINT [PK_TempMember] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Task]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TFromMID] [varchar](20) NULL,
	[TFromMName] [varchar](20) NULL,
	[TToMID] [varchar](20) NULL,
	[TToMName] [varchar](20) NULL,
	[TDateTime] [datetime] NULL,
	[TContent] [nvarchar](500) NULL,
	[IfRead] [bit] NULL,
	[TType] [varchar](10) NULL,
	[TState] [bit] NULL,
	[PicURL] [nvarchar](1000) NULL,
	[replyid] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_Task] ON [dbo].[Task] 
(
	[TFromMID] ASC,
	[TToMID] ASC,
	[TDateTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_SQ_Answer]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_SQ_Answer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MID] [bigint] NOT NULL,
	[Code] [varchar](40) NOT NULL,
	[Answer] [nvarchar](500) NOT NULL,
	[CreatedBy] [nvarchar](40) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdateBy] [nvarchar](40) NULL,
	[LastUpdateTime] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[QId] [bigint] NOT NULL,
 CONSTRAINT [PK_Sys_SQ_Answer] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sys_SQ_Answer] ON
INSERT [dbo].[Sys_SQ_Answer] ([ID], [MID], [Code], [Answer], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status], [QId]) VALUES (1, 692837, N'2e16868b-7e9a-4ec4-9983-65609fd59e26', N'eeeeee', N'admin', CAST(0x0000A49900E6A870 AS DateTime), N'', NULL, 0, 1, 8)
INSERT [dbo].[Sys_SQ_Answer] ([ID], [MID], [Code], [Answer], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status], [QId]) VALUES (120, 692837, N'15fa8a15-7da7-47bf-be21-4685d81c409f', N'eeeeee', N'admin', CAST(0x0000A51300B10421 AS DateTime), NULL, NULL, 0, 1, 8)
INSERT [dbo].[Sys_SQ_Answer] ([ID], [MID], [Code], [Answer], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status], [QId]) VALUES (121, 694727, N'bebfe097-36aa-4580-b5a0-df03f9baf494', N'', N'aaa111', CAST(0x0000A69E0102A9F8 AS DateTime), N'', NULL, 0, 1, 10)
INSERT [dbo].[Sys_SQ_Answer] ([ID], [MID], [Code], [Answer], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status], [QId]) VALUES (122, 694736, N'fde62800-44b9-4bee-9a6b-053b8f699818', N'', N'bbb111', CAST(0x0000A69E0118EDF8 AS DateTime), N'', NULL, 0, 1, 10)
INSERT [dbo].[Sys_SQ_Answer] ([ID], [MID], [Code], [Answer], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status], [QId]) VALUES (123, 694745, N'9fb598ff-b869-42d0-96c3-b32a7e6ac79d', N'eeeeee', N'frr1111', CAST(0x0000A6AC00DF5777 AS DateTime), NULL, NULL, 0, 1, 10)
SET IDENTITY_INSERT [dbo].[Sys_SQ_Answer] OFF
/****** Object:  Table [dbo].[Sys_SecurityQuestion]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_SecurityQuestion](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](40) NOT NULL,
	[Question] [nvarchar](500) NOT NULL,
	[CreatedBy] [nvarchar](40) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdateBy] [nvarchar](40) NULL,
	[LastUpdateTime] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Sys_SecurityQuestion] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sys_SecurityQuestion] ON
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (10, N'6eeadf5e-3528-4161-ad4e-38e883053e52', N'你爱人的名字是什么？      ', N'admin', CAST(0x0000A4A601289CD0 AS DateTime), N'admin', CAST(0x0000A50B010CBF3A AS DateTime), 0, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (5, N'7e8c5ccd-74fb-49d6-a31d-adeb93db6641', N'你最喜欢的运动是什么？  ', N'admin', CAST(0x0000A4990122F334 AS DateTime), N'admin', CAST(0x0000A4B900C175C1 AS DateTime), 1, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (6, N'c15054ce-1683-4709-8a7e-cf513e448317', N'你最喜欢的歌手是谁？  ', N'admin', CAST(0x0000A49901234E9C AS DateTime), N'admin', CAST(0x0000A4B900C175C1 AS DateTime), 1, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (7, N'420a384f-b64e-4df4-a5bb-49c98e401d07', N'你母亲的名字是什么？    ', N'admin', CAST(0x0000A49901240440 AS DateTime), N'admin', CAST(0x0000A4B900C175C1 AS DateTime), 1, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (8, N'781cadd2-7eaf-4742-995e-d3889bb16a4d', N'你的故乡是哪里？        ', N'admin', CAST(0x0000A49901250610 AS DateTime), N'admin', CAST(0x0000A50B010CBF3B AS DateTime), 0, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (11, N'd6d4e5b2-417e-4325-90b4-f78392c38ba6', N'你的高中是在哪儿上的？      ', N'admin', CAST(0x0000A4B100C2F9AC AS DateTime), N'admin', CAST(0x0000A50B010CBF3A AS DateTime), 0, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (12, N'2e475e36-386d-4def-a85c-2c9df37e3fb7', N'你的小学是在哪里上的？  ', N'admin', CAST(0x0000A4BA00B499FC AS DateTime), N'admin', CAST(0x0000A50B010CBF3A AS DateTime), 0, 1)
INSERT [dbo].[Sys_SecurityQuestion] ([ID], [Code], [Question], [CreatedBy], [CreatedTime], [LastUpdateBy], [LastUpdateTime], [IsDeleted], [Status]) VALUES (13, N'a30ea1e5-4aa3-4834-a726-b1bad78673fa', N'你的身高是多高？', N'admin', CAST(0x0000A50B010CBF3B AS DateTime), NULL, NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[Sys_SecurityQuestion] OFF
/****** Object:  Table [dbo].[Sys_Language]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Language](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[ZHName] [nvarchar](500) NULL,
	[ENName] [nvarchar](500) NULL,
	[Remark] [nvarchar](500) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Sort] [bigint] NULL,
 CONSTRAINT [PK_Sys_Language的] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sys_Language] ON
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (1, N'7604051374ba44fba8194c0e0092120e', N'信息管理', N'Info Management', N'', CAST(0x0000A4B800A4A27C AS DateTime), N'admin', CAST(0x0000A4B901387325 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (2, N'5cb988acf1b8416c85421eca7b986b64', N'会员账号', N'Member ID', NULL, CAST(0x0000A4B800AD6132 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (3, N'e8fc8764f2a04c96b9d2be92ebb3a64e', N'个人资料', N'Personal Info', NULL, CAST(0x0000A4B800AD91DE AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (4, N'af48c60ddf1649dda595e4ae2c40345e', N'花红', N'Bonus', N'', CAST(0x0000A4B800F610F8 AS DateTime), N'admin', CAST(0x0000A4B801120980 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (5, N'08dc1ffb1563448bbdbb1a66b659ff15', N'直推奖', N'Straight tuijiang', NULL, CAST(0x0000A4B800F671C5 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (6, N'a5d766d20b644e81ab5028afec759a29', N'会员升级', N'Member upgrade', NULL, CAST(0x0000A4B800F70A5D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (7, N'7700064a546f4eab920ce55de6a262bd', N'奖金明细', N'Bonus Details', NULL, CAST(0x0000A4B800F73E2F AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (8, N'0be5a3e9e01d4c7db9e434115f5cd31c', N'转出会员', N'Out Member', NULL, CAST(0x0000A4B800FA8937 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (9, N'713c1062d3c1480ca164587f385db7dc', N'会员列表', N'Member list', N'', CAST(0x0000A4B800FC6228 AS DateTime), N'admin', CAST(0x0000A4B800FC7060 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (10, N'4f43161416d142f79daf76665157abe7', N'购买基金', N'Purchase fund', NULL, CAST(0x0000A4B800FC9A37 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (11, N'02d6f01ff84f4776b800be1fbab61497', N'安全中心', N'Safety Center', NULL, CAST(0x0000A4B800FCBBB6 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (12, N'5ce03e75a68a4457ab9589a27f886edb', N'财务管理', N'Financial manage', NULL, CAST(0x0000A4B800FCD6BD AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (13, N'e78538d0950147c0a20cf77a03ced32d', N'奖金结算', N'Bonus settlement', NULL, CAST(0x0000A4B800FCF224 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (14, N'fca11803ad3948778a2583c745f27fd0', N'团队管理', N'Team manage', NULL, CAST(0x0000A4B800FD0CA7 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (15, N'a4fe9168cb27439584d8aa93c5c2a9f3', N'分红管理', N'Dividend manage', NULL, CAST(0x0000A4B800FD2ADA AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (16, N'3e6c6fa9a2ef4ac6bcbcbfaba8662eb0', N'退出', N'Sign out', NULL, CAST(0x0000A4B800FF6E19 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (17, N'031f6ad6f53d4405b824f990445fdb8a', N'会员姓名', N'Member Name', NULL, CAST(0x0000A4B8010770DF AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (18, N'28664ec411124172b3df04b36a21d5d8', N'支付宝', N'Alipay', NULL, CAST(0x0000A4B80107B149 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (19, N'a5dfd0c402a543bba9d408376e4a823f', N'入门', N'Introduction', NULL, CAST(0x0000A4B80107E8F5 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (20, N'3a09798624a140a1af710e0edcaa7fc7', N'业绩花红提成', N'The performance bonus Com', N'', CAST(0x0000A4B801082E14 AS DateTime), N'admin', CAST(0x0000A4B8011302E8 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (21, N'94b22a6dd5bd42898c19087467306a7f', N'语言选择', N'Language', NULL, CAST(0x0000A4B90096536D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (22, N'3c06fb7385b7445689a3022638a700cc', N'安全退出', N'Exit safely', NULL, CAST(0x0000A4B90096B14F AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (23, N'b9e06dda44d04fd7931a3d1156b856b9', N'奖金币', N'Award Coins', NULL, CAST(0x0000A4B900A55042 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (24, N'476266bd16fc41f79d53a2acbd39723b', N'电子币', N'Electronic Icons', NULL, CAST(0x0000A4B900A5D054 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (25, N'592a42b8f3904a52a4a981737097281a', N'收益宝', N'Income treasure', NULL, CAST(0x0000A4B900A6111E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (26, N'91aa2547b353429985572a15fcac3270', N'收益宝管理', N'Income treasure Manage', NULL, CAST(0x0000A4B900A63B4E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (27, N'c22daf2487964eb388b04694d18465ad', N'激活币', N'Activation currency', NULL, CAST(0x0000A4B900A66928 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (28, N'da2d5228c4c74e8a8a4fd09146250d3c', N'修改资料', N'Modify data', NULL, CAST(0x0000A4B900A68B8E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (29, N'59bd108c551e4da78f6ea4036fca7099', N'汇款管理', N'Remittance management', NULL, CAST(0x0000A4B900A6C27E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (30, N'1f386ee99ff4427eb55407b4478519f4', N'团队图谱', N'Team map', NULL, CAST(0x0000A4B900A6E4DD AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (31, N'9c9115e3ac7442c48d3efcc25e789a84', N'公告查看', N'Announcement view', NULL, CAST(0x0000A4B900A6FE4B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (32, N'0999d5b7a3284bd397df9c01e995b04f', N'基金管理', N'Fund management', NULL, CAST(0x0000A4B900A72577 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (33, N'7d52c4fc958042a49c29259b481b7ad0', N'基金结算', N'Fund settlement', NULL, CAST(0x0000A4B900A74E59 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (34, N'7898cf68038c42bda9c6ff7416d8b837', N'公告通知', N'Notice', NULL, CAST(0x0000A4B900A79704 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (35, N'f44d2fc1a8b64b6abebe3896689b9457', N'公告管理', N'Notice Manage', NULL, CAST(0x0000A4B900A7BA41 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (36, N'98f30e652f954826ae3e97ea996af2a2', N'升级管理', N'Upgrade manage', NULL, CAST(0x0000A4B900A7D7A6 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (37, N'6ddfe9b039c1452e9e78a373d20fd3b3', N'升级记录', N'Upgrade record', NULL, CAST(0x0000A4B900A7F0FA AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (38, N'32fcdf9f4d3a4497bd5e99c3e75ec2b4', N'系统设置', N'System setting', NULL, CAST(0x0000A4B900A81420 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (39, N'f2e2dba83cff4f72a48af6202e96ca35', N'网站设置', N'Website setting', NULL, CAST(0x0000A4B900A82BCC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (40, N'a8947c14fcd246a4860a8b383bb22df7', N'奖金参数', N'Bonus parameter', NULL, CAST(0x0000A4B900A847EC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (41, N'5c7fd9c8ef74478394346c202ab35f7e', N'权限管理', N'Authority manage', NULL, CAST(0x0000A4B900A86567 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (42, N'84e26cb0ba6f42e0a25bd0f3ce5b1370', N'页面验证', N'Page verification', NULL, CAST(0x0000A4B900A880CA AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (43, N'4db5e5f0b51440e9bceb94bbf84cc9f1', N'模拟器', N'Simulator', NULL, CAST(0x0000A4B900A89584 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (44, N'a39098c0e3674579a27831a82742113d', N'银行管理', N'Bank manage', NULL, CAST(0x0000A4B900A8B929 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (45, N'755fb1610f5b4e9d8ce743d3513bde3a', N'语言配置', N'Language', NULL, CAST(0x0000A4B900A8DC59 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (46, N'8f1c8c44e55c47b78d708928b312dec5', N'收益宝结算', N'Income Po settlement', NULL, CAST(0x0000A4B900A93B62 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (47, N'575dff1d47c94203b34e36c19f558186', N'银行卡管理', N'Bank card manage', NULL, CAST(0x0000A4B900A967A2 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (48, N'682bc45b9d27456ba549d5f0fb721ec2', N'转账查询', N'Transfer inquiry', NULL, CAST(0x0000A4B900A9A857 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (49, N'6cf19e3987de49efa561316930fe9f91', N'充值查询', N'Recharge Query', NULL, CAST(0x0000A4B900A9C4C3 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (50, N'326d68a8f876476a9c0818f65a41a1ea', N'提现管理', N'Present management', NULL, CAST(0x0000A4B900A9DBC0 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (51, N'ecd9d1b6b0304ed5873a71c697ec62ec', N'奖金查询', N'Bonus Query', NULL, CAST(0x0000A4B900A9FA08 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (52, N'e8374bb6da164aed94c08d9d45cdb681', N'拨比流水', N'Finance Running', NULL, CAST(0x0000A4B900AA4D99 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (53, N'e81b90d30f014cf2adceebca8a2febfb', N'财务总账', N'General ledger', NULL, CAST(0x0000A4B900AA6644 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (54, N'3b1263ad241a407fb2348a80e124b034', N'在线充值', N'Online recharge', NULL, CAST(0x0000A4B900AA7D32 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (55, N'7afdd83ec6f14a80ad3cd8e650f1a844', N'货币转换', N'Currency conversion', NULL, CAST(0x0000A4B900AA9665 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (56, N'd19919cf59664cde91ea0d36187df9db', N'结算明细', N'Settlement details', NULL, CAST(0x0000A4B900AAB19F AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (57, N'15b01243758b4a6dac99971aee1fc723', N'日分红结算', N'Day bonus settlement', NULL, CAST(0x0000A4B900AAFC9A AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (58, N'afd34b36713e4b46bb94f28593be8229', N'登录密码修改', N'Change Login password', NULL, CAST(0x0000A4B900AB461A AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (59, N'0951530578c544cb88be2422a6100bfc', N'二级密码修改', N'Change Second password', N'', CAST(0x0000A4B900AB82A4 AS DateTime), N'admin', CAST(0x0000A4C000A4362B AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (60, N'4036686685f9455a95de3114f6ecfc1e', N'密保问题', N'Security question', N'', CAST(0x0000A4B900AB9690 AS DateTime), N'admin', CAST(0x0000A4B9011244A1 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (61, N'53d520ff4f1446949466b1b121e68a09', N'我的市场', N'My market', NULL, CAST(0x0000A4B900ABB9C6 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (62, N'27459604c9a3416cba04a6d4c0a54b58', N'推荐图谱', N'Recommended map', NULL, CAST(0x0000A4B900ABD2EA AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (63, N'5e462dda7add467aa3b059bcea35296d', N'注册会员', N'Registered member', NULL, CAST(0x0000A4B900ABEC06 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (64, N'4d6641a199df4610913902ba3e03d07f', N'推荐列表', N'Recommended list', NULL, CAST(0x0000A4B900AC07F0 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (65, N'e7928666907e45968381feb1852d8559', N'收入统计', N'Income statistics', NULL, CAST(0x0000A4B900AC1DD2 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (66, N'c3ada3929b0041f69a0c60b0fc2921ac', N'基金收益结算', N'Fund income settlement', NULL, CAST(0x0000A4B900AC3FF7 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (67, N'3014fa155dd04c7a9281cae72dc4cafc', N'推广链接', N'Promotion link', N'', CAST(0x0000A4B900AC821C AS DateTime), N'admin', CAST(0x0000A4B900ACD963 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (68, N'ba0e6a1dd97f497b999f89f3b72c998e', N'复制', N'Copy', NULL, CAST(0x0000A4B900AC9B53 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (69, N'3063862ecfc246a0b1966d7669b2f2cc', N'手机号码', N'Phone number', NULL, CAST(0x0000A4B900AD0C65 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (70, N'c36e4a55cca04013810c7f5cc82e8dd2', N'QQ号码', N'QQ number', NULL, CAST(0x0000A4B900AD3151 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (71, N'a536250d47434a4e99f4c3d7bca591dd', N'开户银行', N'Bank', NULL, CAST(0x0000A4B900AD5101 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (72, N'e071ef402584459d87a3c27e19d0d005', N'开户支行', N'Account branch', NULL, CAST(0x0000A4B900AD7160 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (73, N'819d617ee1364cf08a2dd4e18028a9d1', N'开户姓名', N'Account Name', NULL, CAST(0x0000A4B900AD9619 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (74, N'2a9a197785ad4882ad78d40c228d2e2e', N'卡号', N'Card number', N'', CAST(0x0000A4B900ADA840 AS DateTime), N'admin', CAST(0x0000A4B900AF880D AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (75, N'04aa87554f6244c8aec7b35429e0f35a', N'提交', N'Submit', NULL, CAST(0x0000A4B900ADCC01 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (76, N'8bb1fca4d2d145faad8007da425ec6cf', N'添加', N'Add', NULL, CAST(0x0000A4B900ADE965 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (77, N'90eb5982730f4a6f8a0cecf12e3b03e6', N'修改', N'Modify', NULL, CAST(0x0000A4B900AE06B8 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (78, N'55cc820d4e4f4756b81fb3c63a41fcc7', N'会员级别', N'Member level', NULL, CAST(0x0000A4B900AE3654 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (79, N'835d59b0d6854a0a8394d652b912e360', N'电子邮箱', N'Email', NULL, CAST(0x0000A4B900AE4C81 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (80, N'a4e0ae9919364e7dbcd37406becd0536', N'报单中心', N'Declaration Center', NULL, CAST(0x0000A4B900AE66ED AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (81, N'e2745c31e0c84455ac988050ad9b5ae0', N'推荐人', N'Recommend', NULL, CAST(0x0000A4B900AE81F1 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (82, N'31b931eceb134993b804ecfa58435a11', N'安置位置', N'Placement position', NULL, CAST(0x0000A4B900AE9AC3 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (83, N'd2ee930dd736496097cede418fedc5ca', N'激活日期', N'Activation date', NULL, CAST(0x0000A4B900AEAE79 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (84, N'39130a13a07e4845bfcba16cc6d740c7', N'提现信息 ', N'Present information', NULL, CAST(0x0000A4B900AEC0D0 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (85, N'b6a04b20d9f8426ea3ce2c343c691b61', N'户主姓名', N'Name Of Card', NULL, CAST(0x0000A4B900AF6C95 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (86, N'f9035b77d0a5468cbdd125a6a665b698', N'账户信息', N'Account information', NULL, CAST(0x0000A4B900AFA963 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (87, N'7c8edb75795a4cb5a77342b38c0bfd97', N'序号', N'Serial number', NULL, CAST(0x0000A4B900AFCE9D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (88, N'd836208ffbb64f82b1b85bebfeb65f6c', N'管理员', N'Manage', NULL, CAST(0x0000A4B900B05F8B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (89, N'3200bd02350f4db3ba102860de821304', N'工商银行', N'ICBC', NULL, CAST(0x0000A4B900B07A35 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (90, N'0c11139cb9d8482d89d26cd72d515d67', N'财付通 ', N'Tentent Pay', NULL, CAST(0x0000A4B900B0A27E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (91, N'4e83247ff0ca4f3bb3503535738f00fc', N'转出记录', N'Roll out record', NULL, CAST(0x0000A4B900B0D7AA AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (92, N'8f987f269e714ab4a951eeb010d2e0f8', N'转入记录', N'Transfer to record', NULL, CAST(0x0000A4B900B0EE7C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (93, N'eee77946d585407a9a850349c60eef96', N'转换记录', N'Conversion record', NULL, CAST(0x0000A4B900B100D7 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (94, N'23acf2f299654ec1bce0a29a77f10b1e', N'金额', N'Amount', NULL, CAST(0x0000A4B900B11EA0 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (95, N'31c62074cd2b4ab09b3dbaec2f3d1860', N'状态', N'State', N'', CAST(0x0000A4B900B13348 AS DateTime), N'admin', CAST(0x0000A4B9010BF7A9 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (96, N'ee6fbbe309d44b7daeb1530cda94ef42', N'备注', N'Remarks', NULL, CAST(0x0000A4B900B14A06 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (97, N'bd707e8fda514e87b47ff36c2c5699bf', N'日期', N'Date', NULL, CAST(0x0000A4B900B15F47 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (98, N'b0a09531cf994e6592094305a851e0eb', N'创建日期', N'Setup Date', NULL, CAST(0x0000A4B900B1C4CE AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (99, N'24d3dbf3294c4d38bdd22ec0c98bf3db', N'查询', N'Query', NULL, CAST(0x0000A4B900B1EEDF AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (100, N'331be38e8df84360bd4e2c1ad93668e8', N'修&nbsp;&nbsp;改', N'Modify', NULL, CAST(0x0000A4B900B27557 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
GO
print 'Processed 100 total records'
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (101, N'9d52c8e30a3b4a488e38c9f3fe33516b', N'添&nbsp;&nbsp;加', N'Add', NULL, CAST(0x0000A4B900B284BE AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (102, N'f8db08a85e7444969bd4d44098a9dd40', N'全选', N'All', NULL, CAST(0x0000A4B900B2B887 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (103, N'702245b796c942368734800ecc0fa7b2', N'上一页', N'Previous', NULL, CAST(0x0000A4B900B37373 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (104, N'256000445afb4ac9bab1ab854edea410', N'下一页', N'Next', NULL, CAST(0x0000A4B900B385BE AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (105, N'256000445afb4ac9baasb854edea410', N'删除', N'Delete', NULL, CAST(0x0000A4B900B385BE AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (106, N'27fbbb45c9d648aab70cdc4f9b192078', N'未审核', N'Not audit', NULL, CAST(0x0000A4B900B41A5F AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (107, N'e5a1dc61acaa4c499d532f1e46632ada', N'已审核', N'Audit', NULL, CAST(0x0000A4B900B42CE8 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (108, N'2809a63aee7a44f3a6b9fa53fc3d63af', N'人民币', N'RMB', NULL, CAST(0x0000A4B900B44181 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (109, N'7ba4ef82c4094e819abe6b144ee9a75d', N'实发', N'Real Pay', NULL, CAST(0x0000A4B900B45D51 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (110, N'02e716da21ba48549931a0fb2672e8da', N'开户行', N'Account Bank', NULL, CAST(0x0000A4B900B47FBC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (111, N'dd33b1dc851c4744b6d84586341b7e18', N'支行', N'Branch Bank', NULL, CAST(0x0000A4B900B49BB2 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (112, N'd8a86fbae15e48efa8e4db8b4e56b68d', N'奖金合计', N'Bonus total', NULL, CAST(0x0000A4B900B4CAF7 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (113, N'4d3646cccadf4b0dadad9723ca1823ac', N'奖励类型', N'Award type', NULL, CAST(0x0000A4B900B4E30D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (114, N'7fe0cfdbe52e496c971133c1acb5e70b', N'直推奖', N'Straight Reward', NULL, CAST(0x0000A4B900B5117C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (115, N'346ab47d24c74bc29957fadd5c19b9df', N'组织奖', N'Organization Award', NULL, CAST(0x0000A4B900B5390C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (116, N'6a0a40d6afd34d5893c7b3a1746fbba2', N'层点奖', N'Layer point Award', NULL, CAST(0x0000A4B900B557A1 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (117, N'03f35d7363c04563a9859b1d9800177d', N'花红补贴', N'Bonus subsidy', NULL, CAST(0x0000A4B900B58360 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (118, N'6f8db470d53049b6a8c9e217dceacb8b', N'月分红', N'Monthly dividends', NULL, CAST(0x0000A4B900B5A445 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (119, N'73c355ee0b4d4092a84329b58d068cfa', N'基金收益', N'Fund income', N'', CAST(0x0000A4B900B5BA44 AS DateTime), N'admin', CAST(0x0000A4B9010C95F8 AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (120, N'936de0f7bfb24a3d8a0d6e9447074091', N'报单奖', N'Declaration Award', NULL, CAST(0x0000A4B900B5CF98 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (121, N'c210619dd35e4db9b411bc15dad6cd63', N'开始日期', N'Begin Date', NULL, CAST(0x0000A4B900B62005 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (122, N'a7a8f18bdd3a4e74976c780687659b3e', N'截止日期', N'End Date', NULL, CAST(0x0000A4B900B65A4B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (123, N'fb54ea2895d741f5b3558123241796d0', N'请输入奖金来源', N'Please enter a bonus sour', NULL, CAST(0x0000A4B900B67B72 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (124, N'954d9e81a2be4dee862d41363443f9b6', N'请输入会员账号', N'Please enter member Id', NULL, CAST(0x0000A4B900B6B292 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (125, N'50d581465987440880b9a8e8478938c9', N'是否生效', N'Is effective', NULL, CAST(0x0000A4B900B709BD AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (126, N'c08537d04cce41b88585bcda033c3c9f', N'充值钱包', N'Recharge Wallet', NULL, CAST(0x0000A4B900B71F54 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (127, N'c0b990b50e9c49fea59229c23b797bbf', N'标题', N'Title', NULL, CAST(0x0000A4B9010A6AC1 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (128, N'ed7594d1f7804e5fba4704880f39bc6b', N'所有', N'ALL', NULL, CAST(0x0000A4B9010A8601 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (129, N'd3db1c4ffd6c4501ba7b7acdd0329262', N'正常', N'Normal', NULL, CAST(0x0000A4B9010AA46D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (130, N'f5f32144b6ef435da9951bc00bfcdc4d', N'已作废', N'Void', NULL, CAST(0x0000A4B9010ADAE5 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (131, N'58c5760019a64c778d10e462af205952', N'发布公告', N'Announcement', NULL, CAST(0x0000A4B9010AFAFC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (132, N'd48eab3743a842af9b2cdffa1f2aa087', N'修改公告', N'Modify', NULL, CAST(0x0000A4B9010B33A6 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (133, N'7e6bc2645882411abef71098d1872641', N'基金持有量', N'Fund holding capacity', NULL, CAST(0x0000A4B9010B5632 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (134, N'786e5b5261c64f5896be8f0c93b5b018', N'购买总额', N'Total purchase', NULL, CAST(0x0000A4B9010B7222 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (135, N'f82b64684766446f9aec3a216e422b24', N'电子币余额', N'Electronic currency balance', NULL, CAST(0x0000A4B9010B8E79 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (136, N'db301e2533f848fd8ba7d21384ea64cb', N'购买数量', N'Purchase quantity', NULL, CAST(0x0000A4B9010BA5F2 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (137, N'2f979953edba4eb496976fd5c821c6b3', N'购买时间', N'Purchase time', NULL, CAST(0x0000A4B9010BB8E0 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (138, N'30b1857591414d409ed4fbdaf2e361b8', N'成交状态', N'Turnover status', NULL, CAST(0x0000A4B9010BDD45 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (139, N'98f49e637ef84e678aba16f27835b1ec', N'会员人数', N'Member Count', NULL, CAST(0x0000A4B9010C21D7 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (140, N'6c55e76b1ef54810af93d9779c7d4742', N'每份收益', N'Each gain', NULL, CAST(0x0000A4B9010C37DC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (141, N'8bb67c9fa5d94537a936a6b8a134b9fa', N'基金总额', N'Total fund', NULL, CAST(0x0000A4B9010C4A7A AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (142, N'7b71eb87c7994111b6147f5d52ee3417', N'基金收益总额', N'Total fund income', NULL, CAST(0x0000A4B9010C7E61 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (143, N'aae161f601ed4abba58d5426715e327e', N'为空则按照默认', N'For the null, by default', NULL, CAST(0x0000A4B9010F0980 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (144, N'e64627923d8446acac50281b76963bab', N'上次分红信息', N'Last time dividends', NULL, CAST(0x0000A4B9010F250B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (145, N'd5703465b6224d2f8fcad6c33215d756', N'分红方式', N'Dividend Mode', NULL, CAST(0x0000A4B9010F4208 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (146, N'978e2ce9d67345aba5dc32856456a8a7', N'手动', N'Manual', NULL, CAST(0x0000A4B9010F5930 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (147, N'6656be04158e49ac87e7ddbe816d4e37', N'自动', N'Automatic', NULL, CAST(0x0000A4B9010F6E4B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (148, N'b6e051dd5ff549a596b47e38935ea8c6', N'返回', N'Return', NULL, CAST(0x0000A4B9010F81B5 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (149, N'a74e840eef144ef78950cdada6f36509', N'原登录密码', N'Original login password', NULL, CAST(0x0000A4B90111C3A6 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (150, N'6b01b9f079c84661b037ed1600bae804', N'新登录密码', N'New login password', NULL, CAST(0x0000A4B90111DF6D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (151, N'4a7d8f50cd984ee08bd375aca8ad6c95', N'确认登录密码', N'Confirm login password', NULL, CAST(0x0000A4B901120DA8 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (152, N'7996d52ca8274210a9acd4105d9a2e66', N' 密保问题答案', N'Security question answer', NULL, CAST(0x0000A4B90112631C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (153, N'53d191650bd54a0dab365437cdd59ddc', N'新二级密码', N'New two password', NULL, CAST(0x0000A4B90112B717 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (154, N'49ea4eb087ad4aa8bf8cadb2dbe86d37', N'确认二级密码', N'Confirm two password', NULL, CAST(0x0000A4B90112EF11 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (155, N'a65b24f7624641b49043e15b9d40c7cc', N'保存', N'Save', NULL, CAST(0x0000A4B901133300 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (156, N'88239d8a418e4b8fbe72889602d1c4fc', N'当前级别', N'Current level', NULL, CAST(0x0000A4B901135595 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (157, N'd564f4e0fa8a4bf895733190e8da0385', N'入门代理', N'Introduction agent', NULL, CAST(0x0000A4B901138EEC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (158, N'a5bbbdbcda1a4ba79fe582781759a24e', N'初级代理', N'Primary agent', NULL, CAST(0x0000A4B90113A45C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (159, N'04d40670212a4a529511a80233322c50', N'高级代理', N'Senior agency', NULL, CAST(0x0000A4B90113CD50 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (160, N'e899e38aee77429c81e819f7a6d5ebf5', N'代理主任', N'Deputy director', NULL, CAST(0x0000A4B90113EB4D AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (161, N'6b292cbaa9dc4a9cb856a191e17aa13e', N'经销商', N'Distributor', NULL, CAST(0x0000A4B901140995 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (162, N'87052e1e74904f8b9e3e07dfba3825bf', N'总经销', N'Total distribution', NULL, CAST(0x0000A4B901141C38 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (163, N'f37cf05db29346bfb774d25c29e0ea0d', N'级别', N'Level', NULL, CAST(0x0000A4B901145FAC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (164, N'fe9274cab27d4111a1fb00213c23ca56', N'升级', N'Upgrade', NULL, CAST(0x0000A4B901147200 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (165, N'f5914a3eb8264b93bb42515881a9c6ae', N'离线', N'Off-line', NULL, CAST(0x0000A4B9011496FE AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (166, N'43e25ca7292f412485e4e51d06801d99', N'在线', N'On-line', NULL, CAST(0x0000A4B90114A944 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (167, N'83779d57591b45a7b63fe12d82c7b52d', N'会员角色', N'Member role', NULL, CAST(0x0000A4B90114C965 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (168, N'02e11fce8fdc474088c0856a54f1cfd2', N'已激活会员', N'Activated member', NULL, CAST(0x0000A4B90114E40A AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (169, N'f7f02df3bffd4c3cafda158b2a6ea14a', N'未激活会员', N'No Activated member', NULL, CAST(0x0000A4B90114F649 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (170, N'd0c4c72a3acd4b029a81b8e39d7e4ba5', N'报单费', N'Declaration fee', NULL, CAST(0x0000A4B90115156B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (171, N'a8a668fd540c4d2aba2f4cab54a2426a', N'体验', N'Experience', NULL, CAST(0x0000A4B901152BCC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (172, N'4c669e2d21ff452481a724eac3895662', N'冻结状态', N'Freeze state', NULL, CAST(0x0000A4B9011555D7 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (173, N'1d5752175d1e4f4c8a357bc83a611fac', N'锁定状态', N'Lock state', NULL, CAST(0x0000A4B90115698F AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (174, N'0059dccd89cc40b2b7a30ae301f0f178', N'分红花红点数', N'Bonus bonus points', NULL, CAST(0x0000A4B90115A534 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (175, N'b0f3e8a3cd5f4007b98ea756c8d946e7', N'分红金额', N'Dividend amount', NULL, CAST(0x0000A4B9011601E2 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (176, N'315798e41a1947b78229c77dc1cf43fb', N'红利状态', N'Dividend status', NULL, CAST(0x0000A4B901162A89 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (177, N'cbba8c62c91e4137a36bbd355017396c', N'红利日期', N'Dividend date', NULL, CAST(0x0000A4B9011640B9 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (178, N'20f07471dade42f3aebb649d47848270', N'分红比例', N'Dividend ratio', NULL, CAST(0x0000A4B901165A5B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (179, N'90b19d2417aa4856be407757d9ed8430', N'分红日期', N'Dividend date', NULL, CAST(0x0000A4B90116930A AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (180, N'79443cda32a24b47970f64ccb3903348', N'当前利息', N'Current interest', NULL, CAST(0x0000A4B90116CD44 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (181, N'3107de02713247e5b9bbcea8401ccd66', N'利息总额', N'Total interest', NULL, CAST(0x0000A4B90116E966 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (182, N'256e70c42fc0473da8c989645e76328f', N'收益宝总额', N'Total income treasure', NULL, CAST(0x0000A4B901170B13 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (183, N'0f0478f6f15f452e8a835c2e852a39e3', N'交易时间', N'Trading time', NULL, CAST(0x0000A4B9011741A8 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (184, N'affd6edae4774de0914181c7422e918a', N'备注说明', N'Remarks', NULL, CAST(0x0000A4B901175E58 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (185, N'b22891ad490c4feda16035e18b51e7e1', N'奖金余额', N'Bonus balance', NULL, CAST(0x0000A4B901177AAA AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (186, N'0c2506edca1c49ef8bcb5e107b995992', N'账户余额', N'Balance of account', NULL, CAST(0x0000A4B901179029 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (187, N'43c6f9daecb54578abb74fe8b96bc52e', N'累计收益', N'Cumulative gain', NULL, CAST(0x0000A4B90117A484 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (188, N'887f3ca47a8749cc9d85ba61262ec61f', N'奖金转入收益宝', N'Bonus into treasure', NULL, CAST(0x0000A4B90117CAE5 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (189, N'5dbd1c5bb3574029ac438eab3cfaff74', N'收益宝转出现金币', N'Proceeds treasure turn gold', NULL, CAST(0x0000A4B90118295C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (190, N'af2b61d2199f403f93f809318b9bb648', N'转移金额', N'Transfer amount', NULL, CAST(0x0000A4B901185267 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (191, N'6fb6190467f049b6a3ce3412c067f123', N'交易时间', N'Charge Date', NULL, CAST(0x0000A4B901189287 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (192, N'45b4064fb23843359463ed1fb204af2d', N'已成交', N'Turnover', NULL, CAST(0x0000A4B90118C141 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (193, N'e09200907e3a4bae9b4e07c2a624be2d', N'交易金额', N'Change Moeney', NULL, CAST(0x0000A4B901190498 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (194, N'502873aff9cb4edb928389035a890de4', N'网站标题', N'Website title', NULL, CAST(0x0000A4B901194F4B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (195, N'747633106bc041cab4f498a1f4d63438', N'SEO关键字', N'SEO keyword', NULL, CAST(0x0000A4B9011977BC AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (196, N'9dbf8455668944f8ae6359351615decf', N'SEO描述', N'SEO Remarks', NULL, CAST(0x0000A4B90119A05C AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (197, N'12adc41dc20b4a49893c19de6292b847', N'版权信息', N'Copyright information', NULL, CAST(0x0000A4B90119CC05 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (198, N'3bc44f993810490293b231e6a059329d', N'开放时间', N'Opening Hours', NULL, CAST(0x0000A4B90119ED4A AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (199, N'e8d47f6b191849eea173f49674a67a7c', N'关闭信息', N'Close information', NULL, CAST(0x0000A4B9011A0736 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (200, N'18fb46c536c2467da8a3fead16b27a25', N'提现提示', N'Mention current tips', NULL, CAST(0x0000A4B9011A2F59 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (201, N'030e4ddc05664d1ca44008eaa59f35e8', N'汇款提示', N'Remittance tips', NULL, CAST(0x0000A4B9011A619B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
GO
print 'Processed 200 total records'
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (202, N'cd2fc46af5624d4c99c60142278ed8b6', N'单页行数', N'Single page Num', NULL, CAST(0x0000A4B9011A8DC3 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (203, N'43e663c360e34e18b860004703d38dd9', N'网站状态', N'Website status', NULL, CAST(0x0000A4B9011AA8CD AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (204, N'eb4e59aeba4141fe93c6ad2d86f0add4', N'开放', N'Open', NULL, CAST(0x0000A4B9011ABD38 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (205, N'087e46e8f9f5405fb2f635843b24198f', N'关闭', N'Close', NULL, CAST(0x0000A4B9011ACA10 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (206, N'f98d92b558f2492a9ff2ed62edaf1751', N'网络管理费', N'Network manage fee', NULL, CAST(0x0000A4B9011AEE49 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (207, N'd34db16bd18847a1bf70df406f6f91d2', N'入账汇率', N'For the exchange rate', NULL, CAST(0x0000A4B9011B0A16 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (368, N'97d4b66a795447dc83865986a65e927d', N'入门代理', N'rumen', NULL, CAST(0x0000A4BD0005E7CC AS DateTime), N'admin', NULL, NULL, 1, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (369, N'72bc2f63e23b426ebc9c97b3628cbce8', N'投资配套', N'touzi', NULL, CAST(0x0000A4BD0019BE9B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (370, N'acac1771b2e24d09ac3f7047793d233f', N'转出', N'Out', NULL, CAST(0x0000A4BD001AAE1E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (371, N'5121fa3bf3064684a3fe69ee77c74f9c', N'转入', N'Turn In', NULL, CAST(0x0000A4BD001C553B AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (372, N'7e2e86f1683049329c425dbb2512e83f', N'资产管理', N'Asset management', NULL, CAST(0x0000A4C000A595AB AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (373, N'5ebc956e7a384955b94c57942f19e490', N'兑换钱包', N'Exchange Wallet', NULL, CAST(0x0000A4C000A595AB AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (374, N'80b49796542b44bda841aad9acad6bda', N'推 荐 人', N'Recommended', NULL, CAST(0x0000A4C00114D124 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (375, N'2b50cfa1808c4cfeb8bf3ff9f3b50df0', N'安全秘钥', N'Security key', NULL, CAST(0x0000A4C00114D124 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (376, N'ebc851e9c6f64a339bdee6831e4cdf71', N'密保答案', N'Secret answer', NULL, CAST(0x0000A4C001157A99 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (377, N'2ab3dd213a374b0d83d38153119c51f0', N'确认二级安全秘钥', N'Confirm two security key', NULL, CAST(0x0000A4C00115EB20 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (378, N'a91ced3949244862bd68c229e4c41ee6', N'二级安全秘钥', N'two security key', NULL, CAST(0x0000A4C00115EB20 AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (379, N'bd5f0acdda7649259eb0821585d55190', N'正在建设中，敬请期待', N'Under construction, please look forward to', N'', CAST(0x0000A4C101126B90 AS DateTime), N'admin', CAST(0x0000A50000BE65BD AS DateTime), N'admin', 0, 1, 1)
INSERT [dbo].[Sys_Language] ([Id], [Code], [ZHName], [ENName], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status], [Sort]) VALUES (380, N'c0fca5f527864b0cbe4dfb54280caabd', N'金盾交易', N'KINGSTON', NULL, CAST(0x0000A50000BE6B0E AS DateTime), N'admin', NULL, NULL, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Sys_Language] OFF
/****** Object:  Table [dbo].[Sys_BankInfo]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_BankInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](40) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[PicUrl] [varchar](100) NULL,
	[LinkUrl] [varchar](100) NULL,
	[Remark] [varchar](1000) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](40) NOT NULL,
	[UpdatedTime] [datetime] NULL,
	[UpdatedBy] [varchar](40) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Sys_BankInfo] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Sys_BankInfo] ON
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (2, N'ICBC', N'中国工商银行', N'201562114015803.gif', N'http://www.icbc.com', N'工商银行', CAST(0x0000A503016D52A8 AS DateTime), N'admin', CAST(0x0000A4FC010ABC07 AS DateTime), N'admin', 0, 1)
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (3, N'ZFB', N'支付宝', N'201582216396487.png', N'https://auth.alipay.com', N'支付宝', CAST(0x0000A4AB0108D350 AS DateTime), N'admin', CAST(0x0000A4FC010ABC07 AS DateTime), N'admin', 0, 0)
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (4, N'weipay', N'微信支付', N'201582216146148.png', N'http://weixin.qq.com/', N'Visa卡支付', CAST(0x0000A4BC00BE116C AS DateTime), N'admin', CAST(0x0000A4FC010ABC07 AS DateTime), N'admin', 0, 0)
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (5, N'CFT', N'财付通', N'201582216211842.png', N'https://www.tenpay.com/v2/', N'财付通', CAST(0x0000A4FC010ABC07 AS DateTime), N'admin', NULL, NULL, 0, 0)
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (6, N'CBC', N'中国建设银行', N'20158221619473.gif', N'http://www.ccb.com/cn/home/index.html', N'中国建设银行', CAST(0x0000A503010ABBFC AS DateTime), N'admin', NULL, NULL, 0, 1)
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (7, N'BOC', N'中国银行', N'201582216579970.gif', N'http://www.boc.cn/', N'中国银行', CAST(0x0000A4FC010ABC07 AS DateTime), N'admin', NULL, NULL, 0, 1)
INSERT [dbo].[Sys_BankInfo] ([Id], [Code], [Name], [PicUrl], [LinkUrl], [Remark], [CreatedTime], [CreatedBy], [UpdatedTime], [UpdatedBy], [IsDeleted], [Status]) VALUES (8, N'ABC', N'中国农业银行', N'20158221608296.gif', N'http://www.abchina.com/cn/', N'中国农业银行', CAST(0x0000A503010ABBFC AS DateTime), N'admin', NULL, NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[Sys_BankInfo] OFF
/****** Object:  Table [dbo].[SMS]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SMS](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[SType] [varchar](10) NOT NULL,
	[SContent] [text] NULL,
	[Tel] [varchar](20) NULL,
	[SMSKey] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[MID] [varchar](50) NULL,
	[SendState] [bit] NULL,
	[Email] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SMS] ON
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (452, N'ZCYZ', N'尊敬的会员您好！您订单号C139F7372722428提供帮助的订单已经匹配成功(匹配编号[814C29EB57494E3])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B57C43 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (453, N'ZCYZ', N'尊敬的会员您好！您订单号3D8689FD2CA24AA得到帮助的订单对方已汇款(匹配编号[814C29EB57494E3])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B64F35 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (455, N'ZCYZ', N'尊敬的会员您好！您订单号F18910267455470提供帮助的订单已经匹配成功(匹配编号[F971A1CC9D7845A])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B82C7B AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (457, N'QT', N'尊敬的会员您好！您订单号F18910267455470提供帮助的订单已经确认收款(匹配编号[F971A1CC9D7845A])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00C84C52 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (458, N'ZCYZ', N'尊敬的会员您好！您订单号7A4559EC361442B提供帮助的订单已经匹配成功(匹配编号[B557FB231F7E454])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00F82C45 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (459, N'ZCYZ', N'尊敬的会员您好！您订单号3554B4AEA36040F得到帮助的订单对方已汇款(匹配编号[B557FB231F7E454])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00FA8C99 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (463, N'QT', N'尊敬的会员您好！您订单号F223461AA4544F1提供帮助的订单已经确认收款(匹配编号[9C7AFFE7DE334E1])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F010EC7D4 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (464, N'ZCYZ', N'尊敬的会员您好！您订单号9501F869DF764B1提供帮助的订单已经匹配成功(匹配编号[FF356A2ADDFA429])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F011213C8 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (466, N'ZCYZ', N'尊敬的会员您好！您订单号1A4F46260FBE4BD提供帮助的订单已经匹配成功(匹配编号[A767DD3F173B40E])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A6A000C40CD2 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (468, N'QT', N'尊敬的会员您好！您订单号1A4F46260FBE4BD提供帮助的订单已经确认收款(匹配编号[A767DD3F173B40E])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A6AA00BE4520 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (454, N'QT', N'尊敬的会员您好！您订单号C139F7372722428提供帮助的订单已经确认收款(匹配编号[814C29EB57494E3])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B65892 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (460, N'QT', N'尊敬的会员您好！您订单号7A4559EC361442B提供帮助的订单已经确认收款(匹配编号[B557FB231F7E454])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00FA9618 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (461, N'ZCYZ', N'尊敬的会员您好！您订单号F223461AA4544F1提供帮助的订单已经匹配成功(匹配编号[9C7AFFE7DE334E1])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F0103CB8E AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (465, N'QT', N'尊敬的会员您好！您订单号9501F869DF764B1提供帮助的订单已经确认收款(匹配编号[FF356A2ADDFA429])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F0112735E AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (452, N'ZCYZ', N'尊敬的会员您好！您订单号C139F7372722428提供帮助的订单已经匹配成功(匹配编号[814C29EB57494E3])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B57C43 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (453, N'ZCYZ', N'尊敬的会员您好！您订单号3D8689FD2CA24AA得到帮助的订单对方已汇款(匹配编号[814C29EB57494E3])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B64F35 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (455, N'ZCYZ', N'尊敬的会员您好！您订单号F18910267455470提供帮助的订单已经匹配成功(匹配编号[F971A1CC9D7845A])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B82C7B AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (457, N'QT', N'尊敬的会员您好！您订单号F18910267455470提供帮助的订单已经确认收款(匹配编号[F971A1CC9D7845A])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00C84C52 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (458, N'ZCYZ', N'尊敬的会员您好！您订单号7A4559EC361442B提供帮助的订单已经匹配成功(匹配编号[B557FB231F7E454])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00F82C45 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (459, N'ZCYZ', N'尊敬的会员您好！您订单号3554B4AEA36040F得到帮助的订单对方已汇款(匹配编号[B557FB231F7E454])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00FA8C99 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (463, N'QT', N'尊敬的会员您好！您订单号F223461AA4544F1提供帮助的订单已经确认收款(匹配编号[9C7AFFE7DE334E1])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F010EC7D4 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (464, N'ZCYZ', N'尊敬的会员您好！您订单号9501F869DF764B1提供帮助的订单已经匹配成功(匹配编号[FF356A2ADDFA429])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F011213C8 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (466, N'ZCYZ', N'尊敬的会员您好！您订单号1A4F46260FBE4BD提供帮助的订单已经匹配成功(匹配编号[A767DD3F173B40E])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A6A000C40CD2 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (454, N'QT', N'尊敬的会员您好！您订单号C139F7372722428提供帮助的订单已经确认收款(匹配编号[814C29EB57494E3])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00B65892 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (460, N'QT', N'尊敬的会员您好！您订单号7A4559EC361442B提供帮助的订单已经确认收款(匹配编号[B557FB231F7E454])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00FA9618 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (461, N'ZCYZ', N'尊敬的会员您好！您订单号F223461AA4544F1提供帮助的订单已经匹配成功(匹配编号[9C7AFFE7DE334E1])，请在规定时间内完成，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F0103CB8E AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (465, N'QT', N'尊敬的会员您好！您订单号9501F869DF764B1提供帮助的订单已经确认收款(匹配编号[FF356A2ADDFA429])，请注意查看，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F0112735E AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (456, N'ZCYZ', N'尊敬的会员您好！您订单号1CC226454F0249F得到帮助的订单对方已汇款(匹配编号[F971A1CC9D7845A])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00C740BC AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (462, N'ZCYZ', N'尊敬的会员您好！您订单号01A9D41F14D34E2得到帮助的订单对方已汇款(匹配编号[9C7AFFE7DE334E1])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F010AE223 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (467, N'ZCYZ', N'尊敬的会员您好！您订单号87768986155E48E得到帮助的订单对方已汇款(匹配编号[A767DD3F173B40E])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A6AA00BE31D4 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (456, N'ZCYZ', N'尊敬的会员您好！您订单号1CC226454F0249F得到帮助的订单对方已汇款(匹配编号[F971A1CC9D7845A])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F00C740BC AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (462, N'ZCYZ', N'尊敬的会员您好！您订单号01A9D41F14D34E2得到帮助的订单对方已汇款(匹配编号[9C7AFFE7DE334E1])，核实无误后请确认，感谢您的参与！祝您生活愉快！', N'15012345678', NULL, CAST(0x0000A69F010AE223 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (469, N'ZCYZ', N'您的注册验证码是[711104]，欢迎携手皇家国际，祝您生活愉快！', N'15617926640', N'711104', CAST(0x0000A6AC00ED6139 AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (470, N'ZCYZ', N'您的注册验证码是[644495]，欢迎携手皇家国际，祝您生活愉快！', N'15617926640', N'644495', CAST(0x0000A6AC00EE458D AS DateTime), NULL, 1, NULL)
INSERT [dbo].[SMS] ([SID], [SType], [SContent], [Tel], [SMSKey], [CreateDate], [MID], [SendState], [Email]) VALUES (471, N'ZCYZ', N'您的注册验证码是[923221]，欢迎携手皇家国际，祝您生活愉快！', N'15617926640', N'923221', CAST(0x0000A6AC00F537FC AS DateTime), NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[SMS] OFF
/****** Object:  Table [dbo].[SHMoney]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SHMoney](
	[MAgencyType] [varchar](10) NOT NULL,
	[MAgencyName] [varchar](20) NULL,
	[Money] [varchar](50) NULL,
	[BTFloat] [decimal](18, 4) NULL,
	[TJFloat] [decimal](18, 4) NULL,
	[TXFloat] [decimal](18, 4) NULL,
	[TakeOffFloat] [decimal](18, 4) NULL,
	[ReBuyFloat] [decimal](18, 4) NULL,
	[MCWFloat] [decimal](18, 4) NULL,
	[MColor] [varchar](10) NULL,
	[ViewLevel] [int] NULL,
	[TJCount] [int] NULL,
	[TJAgency] [varchar](10) NULL,
	[TemaCount] [int] NULL,
	[DTopMoney] [decimal](18, 2) NULL,
	[SQHelpCount] [int] NULL,
	[XYLastMemberCount] [int] NULL,
	[XFMouthMinHelpMoney] [decimal](18, 2) NULL,
	[XFMounthMoney] [decimal](18, 2) NULL,
	[InitMaxTZ] [int] NULL,
	[XYFloat] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SHMoney] PRIMARY KEY CLUSTERED 
(
	[MAgencyType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SHMoney', @level2type=N'COLUMN',@level2name=N'TakeOffFloat'
GO
INSERT [dbo].[SHMoney] ([MAgencyType], [MAgencyName], [Money], [BTFloat], [TJFloat], [TXFloat], [TakeOffFloat], [ReBuyFloat], [MCWFloat], [MColor], [ViewLevel], [TJCount], [TJAgency], [TemaCount], [DTopMoney], [SQHelpCount], [XYLastMemberCount], [XFMouthMinHelpMoney], [XFMounthMoney], [InitMaxTZ], [XYFloat]) VALUES (N'001', N'未激活会员', N'0', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'#000000', 99999, 0, NULL, 0, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[SHMoney] ([MAgencyType], [MAgencyName], [Money], [BTFloat], [TJFloat], [TXFloat], [TakeOffFloat], [ReBuyFloat], [MCWFloat], [MColor], [ViewLevel], [TJCount], [TJAgency], [TemaCount], [DTopMoney], [SQHelpCount], [XYLastMemberCount], [XFMouthMinHelpMoney], [XFMounthMoney], [InitMaxTZ], [XYFloat]) VALUES (N'002', N'正式会员', N'0', CAST(0.0000 AS Decimal(18, 4)), CAST(0.0500 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'#red', 99999, 0, NULL, 0, CAST(0.00 AS Decimal(18, 2)), 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, CAST(0.00 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[Roles]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[RType] [varchar](10) NOT NULL,
	[RName] [varchar](20) NOT NULL,
	[RIndex] [int] IDENTITY(1,1) NOT NULL,
	[CMessage] [bit] NOT NULL,
	[IsAdmin] [bit] NULL,
	[CanSH] [bit] NULL,
	[CanLogin] [bit] NULL,
	[VState] [bit] NULL,
	[Super] [bit] NULL,
	[RColor] [varchar](10) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RType], [RName], [RIndex], [CMessage], [IsAdmin], [CanSH], [CanLogin], [VState], [Super], [RColor]) VALUES (N'Activation', N'激活中心', 4, 0, 0, 0, 0, 0, 0, N'#192833')
INSERT [dbo].[Roles] ([RType], [RName], [RIndex], [CMessage], [IsAdmin], [CanSH], [CanLogin], [VState], [Super], [RColor]) VALUES (N'Manage', N'管理员', 3, 0, 1, 1, 1, 1, 1, N'#1ff859')
INSERT [dbo].[Roles] ([RType], [RName], [RIndex], [CMessage], [IsAdmin], [CanSH], [CanLogin], [VState], [Super], [RColor]) VALUES (N'Nomal', N'已激活会员', 1, 1, 0, 0, 1, 1, 0, N'#177859')
INSERT [dbo].[Roles] ([RType], [RName], [RIndex], [CMessage], [IsAdmin], [CanSH], [CanLogin], [VState], [Super], [RColor]) VALUES (N'Notactive', N'未激活会员', 6, 1, 0, 0, 1, 1, 0, N'#333859')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[RolePowers]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RolePowers](
	[RID] [int] IDENTITY(1,1) NOT NULL,
	[RType] [varchar](10) NOT NULL,
	[CID] [varchar](10) NOT NULL,
	[IFVerify] [bit] NULL,
 CONSTRAINT [PK_ZxResource] PRIMARY KEY CLUSTERED 
(
	[RType] ASC,
	[CID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RolePowers] ON
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (7734, N'Activation', N'002027', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (7738, N'Activation', N'002029', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (8541, N'Activation', N'00248', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9412, N'Activation', N'00318', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9333, N'Activation', N'007001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9324, N'Activation', N'0166', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (4239, N'Initial', N'001008', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (4240, N'Initial', N'001009', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (4246, N'Initial', N'002003', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (4243, N'Initial', N'002014', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (4251, N'Initial', N'003009', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11049, N'Manage', N'000', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10965, N'Manage', N'001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10966, N'Manage', N'001001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10967, N'Manage', N'001002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10968, N'Manage', N'001005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10969, N'Manage', N'001102', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10970, N'Manage', N'001103', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10971, N'Manage', N'002005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10972, N'Manage', N'002006', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11040, N'Manage', N'002021', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10973, N'Manage', N'003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10975, N'Manage', N'003003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10974, N'Manage', N'003004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10976, N'Manage', N'003007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10977, N'Manage', N'003008', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10978, N'Manage', N'003009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10979, N'Manage', N'003019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10982, N'Manage', N'00317', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10980, N'Manage', N'00318', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10981, N'Manage', N'00319', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10983, N'Manage', N'004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10986, N'Manage', N'004001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10987, N'Manage', N'004002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10988, N'Manage', N'004003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10989, N'Manage', N'004004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10990, N'Manage', N'004005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10991, N'Manage', N'004006', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10984, N'Manage', N'004008', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10985, N'Manage', N'004010', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11029, N'Manage', N'004015', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10993, N'Manage', N'005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10996, N'Manage', N'005001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10997, N'Manage', N'005002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10995, N'Manage', N'005003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10998, N'Manage', N'005006', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10994, N'Manage', N'005007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10999, N'Manage', N'00519', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11001, N'Manage', N'007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11002, N'Manage', N'007001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11003, N'Manage', N'007002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11004, N'Manage', N'009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11005, N'Manage', N'009001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11006, N'Manage', N'009002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11007, N'Manage', N'009003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11008, N'Manage', N'009004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11058, N'Manage', N'009005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11051, N'Manage', N'009007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11052, N'Manage', N'009008', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11009, N'Manage', N'009017', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11010, N'Manage', N'009018', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11011, N'Manage', N'009019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11012, N'Manage', N'009020', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11013, N'Manage', N'009021', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11014, N'Manage', N'009022', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11015, N'Manage', N'009023', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11016, N'Manage', N'009024', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11017, N'Manage', N'009025', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11018, N'Manage', N'009026', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11045, N'Manage', N'009027', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11034, N'Manage', N'019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11036, N'Manage', N'019001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11038, N'Manage', N'019002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11019, N'Manage', N'020', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11022, N'Manage', N'020002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11020, N'Manage', N'020011', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11021, N'Manage', N'020018', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11046, N'Manage', N'02010', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11024, N'Manage', N'02011', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11026, N'Manage', N'02043', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11027, N'Manage', N'02044', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11025, N'Manage', N'02045', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11048, N'Nomal', N'000', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10864, N'Nomal', N'001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10865, N'Nomal', N'001001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10866, N'Nomal', N'001002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10867, N'Nomal', N'001005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10868, N'Nomal', N'001102', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10869, N'Nomal', N'001103', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10870, N'Nomal', N'002005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10871, N'Nomal', N'002006', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11039, N'Nomal', N'002021', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10872, N'Nomal', N'003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10873, N'Nomal', N'003008', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10874, N'Nomal', N'003009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10875, N'Nomal', N'003019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10878, N'Nomal', N'00317', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10876, N'Nomal', N'00318', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10877, N'Nomal', N'00319', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10879, N'Nomal', N'004', 1)
GO
print 'Processed 100 total records'
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10880, N'Nomal', N'004001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10881, N'Nomal', N'004003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10882, N'Nomal', N'004004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10883, N'Nomal', N'004006', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11028, N'Nomal', N'004015', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10885, N'Nomal', N'007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10886, N'Nomal', N'007001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10887, N'Nomal', N'007002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10888, N'Nomal', N'009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10889, N'Nomal', N'009001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10890, N'Nomal', N'009002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10891, N'Nomal', N'009003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10892, N'Nomal', N'009004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11057, N'Nomal', N'009005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10893, N'Nomal', N'009017', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10894, N'Nomal', N'009018', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10895, N'Nomal', N'009019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10896, N'Nomal', N'009020', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10897, N'Nomal', N'009022', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10898, N'Nomal', N'009023', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10899, N'Nomal', N'009024', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10900, N'Nomal', N'009026', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11044, N'Nomal', N'009027', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11033, N'Nomal', N'019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11035, N'Nomal', N'019001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11037, N'Nomal', N'019002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11050, N'Notactive', N'000', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10699, N'Notactive', N'001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10700, N'Notactive', N'001001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10701, N'Notactive', N'001002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10703, N'Notactive', N'001003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10704, N'Notactive', N'001004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10714, N'Notactive', N'001005', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (11047, N'Notactive', N'001101', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10705, N'Notactive', N'003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10706, N'Notactive', N'003008', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10707, N'Notactive', N'003009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10709, N'Notactive', N'00317', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10708, N'Notactive', N'00318', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10710, N'Notactive', N'007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10711, N'Notactive', N'007001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10712, N'Notactive', N'007002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10713, N'Notactive', N'016002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (10715, N'Notactive', N'0166', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9252, N'VIP', N'001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9276, N'VIP', N'001001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9269, N'VIP', N'003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9409, N'VIP', N'003008', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9134, N'VIP', N'003009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9426, N'VIP', N'00317', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9414, N'VIP', N'00318', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9255, N'VIP', N'004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9476, N'VIP', N'004001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9378, N'VIP', N'004003', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9263, N'VIP', N'007', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9335, N'VIP', N'007001', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9339, N'VIP', N'007002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9259, N'VIP', N'009', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9471, N'VIP', N'009002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9449, N'VIP', N'009004', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9305, N'VIP', N'009016', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9384, N'VIP', N'009017', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9438, N'VIP', N'009018', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9317, N'VIP', N'009019', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9455, N'VIP', N'009020', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9381, N'VIP', N'016', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9399, N'VIP', N'016002', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (9326, N'VIP', N'0166', 1)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (2086, N'WuLiu', N'001008', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (2087, N'WuLiu', N'001009', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (2062, N'WuLiu', N'002003', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (2071, N'WuLiu', N'003009', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (2076, N'WuLiu', N'0040071', 0)
INSERT [dbo].[RolePowers] ([RID], [RType], [CID], [IFVerify]) VALUES (2077, N'WuLiu', N'006', 0)
SET IDENTITY_INSERT [dbo].[RolePowers] OFF
/****** Object:  StoredProcedure [dbo].[GetLevelForView]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLevelForView]
@mid varchar(20),
@viewmid varchar(20),
@viewtype bit
AS
BEGIN
declare @tempmid varchar(20);
declare @level int;
set @level=0;
if(@viewtype='1')
begin
set @tempmid=(select MBD from Member where MID=@viewmid and MBD<>@viewmid);
while(@tempmid is not null and @tempmid<>@mid)
begin
set @level=@level+1;
set @viewmid=@tempmid;
set @tempmid=(select MBD from Member where MID=@viewmid and MBD<>@viewmid);
end
end
else
begin
set @tempmid=(select MTJ from Member where MID=@viewmid and MTJ<>@viewmid);
while(@tempmid is not null and @tempmid<>@mid)
begin
set @level=@level+1;
set @viewmid=@tempmid;
set @tempmid=(select MTJ from Member where MID=@viewmid and MTJ<>@viewmid);
end
end

if(@tempmid=@mid)
select @level+1;
else
select 0;
END
GO
/****** Object:  UserDefinedFunction [dbo].[getjxtype]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[getjxtype]
(	
	-- Add the parameters for the function here
	@mid varchar(20),@jxtype varchar(10),@jxuptype varchar(10)
)
RETURNS --@tempjxcounttable table (jxtype varchar(10),jxcount int) 
@tempjxtypetable table (jxmid varchar(20),jxtype varchar(10)) 
AS
begin
--declare @tempjxtypetable table (jxmid varchar(20),jxtype varchar(10)) 
declare test_Cursor CURSOR local for select mid from member where mbd=@mid;--定义游标
declare @tempmid varchar(20);
OPEN test_Cursor
 WHILE @@FETCH_STATUS = 0
     BEGIN  
         FETCH NEXT FROM test_Cursor INTO @tempmid
         if(@@FETCH_STATUS = 0)
         begin
         insert into @tempjxtypetable 
         select top 1 mid,jxtype from dbo.GetLevelTree(@tempmid,99999999) where jxtype>=@jxtype order by jxtype desc; 
         end
     END 
 CLOSE test_Cursor
 DEALLOCATE test_Cursor
 if((select count(1) from @tempjxtypetable where jxtype=@jxuptype)<2)--如果小于高一级的绩效2个则删除
 delete from @tempjxtypetable
 --insert into @tempjxcounttable values (@jxtype,(select count(*) from @tempjxtypetable where jxtype>=@jxtype));
 --insert into @tempjxcounttable values (@jxuptype,(select count(*) from @tempjxtypetable where jxtype=@jxuptype));
return;
end
GO
/****** Object:  StoredProcedure [dbo].[GetAutoMbdByMtjToMin]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAutoMbdByMtjToMin]
	@mtj varchar(20),
	@mbdcount int
AS
BEGIN
	declare @count int;
	set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
	while(@count>=@mbdcount)
	begin
	set @mtj=(select top 1 Member.MID from Member inner join MemberConfig on Member.MID=MemberConfig.MID where MBD=@mtj and MState='1' order by YJMoney)
	set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
	end
	select @mtj;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAutoMbdByMtjToLR]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetAutoMbdByMtjToLR]
	@mtj varchar(20),
	@mbdcount int
AS
BEGIN
	declare @count int;
	declare @mbdindex int;
	set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
	if(@count>=@mbdcount)
	begin
		set @mtj=(select top 1 Member.MID from Member inner join MemberConfig on Member.MID=MemberConfig.MID where MBD=@mtj and MState='1' order by YJMoney)
		set @mbdindex=(select MBDIndex from Member where MID=@mtj);
		if(@mbdindex=1)
			begin
				set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
				while(@count>0)
					begin
					set @mtj=(select top 1 MID from Member where MBD=@mtj and MState='1' order by MBDIndex);
					set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
					end
				select @mtj;
			end
		else
			begin
				set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
				while(@count>0)
					begin
					set @mtj=(select top 1 MID from Member where MBD=@mtj and MState='1' order by MBDIndex desc);
					set @count=(select COUNT(1) from Member where MBD=@mtj and MState='1');
					end
				select @mtj;
			end
	end
	else
	begin
		select @mtj;
	end
END
GO
/****** Object:  StoredProcedure [dbo].[GetAutoMbdByMtj2]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetAutoMbdByMtj2]
	-- Add the parameters for the stored procedure here
	@mtj varchar(20),
	@mbdcount int
AS
BEGIN
declare @count int;
	declare @mbdtable table(bmid varchar(20),bdindex int,mdate datetime);
	declare @mbdtable2 table(bmid varchar(20),bdindex int,mdate datetime);
	insert into @mbdtable select mid,MBDIndex,MDate from Member where MID=@mtj and mstate='1';
	set @count=(select COUNT(1) from Member where MBD=@mtj and MID<>@mtj and mstate='1');
	while(@count>=@mbdcount)
	begin
	delete from @mbdtable2;
	insert into @mbdtable2 select mid,MBDIndex,mdate from Member where MBD in (select top 1 bmid from @mbdtable order by bdindex) and MBD<>MID and mstate='1';
	--update @mbdtable2 set bdcount=(select COUNT(1) from Member where MBD=bmid and mstate='1')
	delete from @mbdtable;
	set @mtj=(select top 1 bmid from @mbdtable2 order by bdindex, mdate);
	if(@mtj is not null and @mtj<>'')
	begin
		set @count=(select COUNT(1) from Member where MBD=@mtj and MID<>@mtj and mstate='1');
		insert into @mbdtable select mid,MBDIndex,MDate from Member where MID=@mtj and mstate='1';
	end
	else
		insert into @mbdtable select * from @mbdtable2;
	end
	select @mtj;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAutoMbdByMtj]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAutoMbdByMtj]
	-- Add the parameters for the stored procedure here
	@mtj varchar(20),
	@mbdcount int
AS
BEGIN
declare @count int;
	declare @mbdtable table(bmid varchar(20),bdcount int,mdate datetime);
	declare @mbdtable2 table(bmid varchar(20),bdcount int,mdate datetime);
	insert into @mbdtable select mid,0,MDate from Member where MID=@mtj and mstate='1';
	set @count=(select COUNT(1) from Member where MBD=@mtj and MID<>@mtj and mstate='1');
	while(@count>=@mbdcount)
	begin
	delete from @mbdtable2;
	insert into @mbdtable2 select mid,0,mdate from Member where MBD in (select bmid from @mbdtable) and MBD<>MID and mstate='1';
	update @mbdtable2 set bdcount=(select COUNT(1) from Member where MBD=bmid and mstate='1')
	delete from @mbdtable;
	set @mtj=(select top 1 bmid from @mbdtable2 where bdcount<@mbdcount order by bdcount desc,mdate);
	if(@mtj is not null and @mtj<>'')
		set @count=(select COUNT(1) from Member where MBD=@mtj and MID<>@mtj and mstate='1');
	else
		insert into @mbdtable select * from @mbdtable2;
	end
	select @mtj;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAutoMbdByMBD2]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tns_pop
-- Create date: 2014-2-25
-- Description:	公排，根据接点位从上到下，从左到右公排
-- =============================================
CREATE PROCEDURE [dbo].[GetAutoMbdByMBD2]
	-- Add the parameters for the stored procedure here
	@bdmid varchar(20),
	@bdcount int
AS
BEGIN
	declare @count int;
	declare @mbdtable table([ID] [int],bmid varchar(20),bdcount int,mdate datetime);
	declare @mbdtable2 table([ID] [int] IDENTITY(1,1) NOT NULL,bmid varchar(20),bdcount int,mdate datetime);
	insert into @mbdtable select 1,bmid,0,BMDate from BMember where BMID=@bdmid;
	set @count=(select COUNT(1) from BMember where BMBD=@bdmid and BMID<>@bdmid);
	while(@count>=@bdcount)
	begin
	delete from @mbdtable2;
	insert into @mbdtable2 select a.BMID,(select count(1) from BMember where BMBD=a.BMID),bmdate from BMember a inner join @mbdtable b on a.BMBD=b.bmid and a.BMBD<>a.BMID order by b.id,BMDate;
	delete from @mbdtable;
--加接点人数,会造成不是从右到或,所以选择按日期排序.
	set @bdmid=(select top 1 bmid from @mbdtable2 where bdcount<@bdcount order by ID,mdate);
	--set @bdmid=(select top 1 bmid from @mbdtable2 order by mdate);
--print @bdmid;
	if(@bdmid is not null and @bdmid<>'')
--begin
		set @count=(select COUNT(1) from BMember where BMBD=@bdmid and BMID<>@bdmid);
	--else
		insert into @mbdtable select * from @mbdtable2;
--end
	end
	select @bdmid;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAutoMbdByMBD1]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tns_pop
-- Create date: 2014-2-25
-- Description:	公排，根据接点位从上到下，从左到右公排,按小区市场
-- =============================================
CREATE PROCEDURE [dbo].[GetAutoMbdByMBD1]
	-- Add the parameters for the stored procedure here
	@bdmid varchar(20),
	@bdcount int
AS
BEGIN
	declare @count int;
	set @count=(select COUNT(1) from Member where MBD=@bdmid and MID<>@bdmid);
	while(@count>=@bdcount)
	begin
	set @bdmid=(select top 1 Member.MID from Member inner join MemberConfig on Member.MID=MemberConfig.MID where MBD=@bdmid and Member.MID<>@bdmid order by YJCount);
	set @count=(select COUNT(1) from Member where MBD=@bdmid);
	end
	select @bdmid;
END
GO
/****** Object:  StoredProcedure [dbo].[CountTotalMemberByMBD]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,zhuxy>
-- Create date: <Create Date,2015-9-17,>
-- Description:	<Description,统计某个会员的伞下总计有多少会员,>
-- =============================================
CREATE PROCEDURE [dbo].[CountTotalMemberByMBD] 
	-- Add the parameters for the stored procedure here
	@MID VARCHAR(40),
	@IsNoActive int
AS
BEGIN
	 
declare @cursor cursor;--游标
declare  @CMID varchar(20),@MTJ varchar(20) 
set @cursor=cursor for 
select MID,MTJ from Member where MTJ=@MID
open @cursor
fetch next from @cursor into @CMID,@MTJ;
while @@FETCH_STATUS=0
begin
if(@IsNoActive=1)
    select COUNT(1) from Member where MTJ=@CMID and IsClock=0 and IsClose=0 
else
    select COUNT(1) from Member where MTJ=@CMID and IsClock=0 and IsClose=0 and MState=1
  fetch next from @cursor into @CMID,@MTJ;
end
close @cursor
deallocate @cursor
 
END
GO
/****** Object:  UserDefinedFunction [dbo].[getTreeBuyMID]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getTreeBuyMID]
(
@mid varchar(20)
)
RETURNS @temptable table(mid varchar(20),mbd varchar(20))
AS
begin 
insert into @temptable (mid) values (@mid);
while(@@Rowcount>0)
begin
insert into @temptable select member.mid,member.mbd from member where mbd in (
select mid from @temptable
) and mid not in (
select mid from @temptable
)
end
delete from @temptable where mid=@mid;
return;
end
GO
/****** Object:  StoredProcedure [dbo].[GetTask]    Script Date: 02/04/2017 11:32:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetTask]
@TToMID varchar(20),
@TFromMID varchar(20),
@ID int
as
if(@TFromMID='')
select * from Task where TToMID=@TToMID and IfRead='0' and ID>@ID and TState='1' order by ID
else
select * from Task where TFromMID=@TFromMID and TToMID=@TToMID and IfRead='0' and TState='1' and ID>@ID order by ID
GO
/****** Object:  Default [DF_Notice_NCreateTime]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Notice] ADD  CONSTRAINT [DF_Notice_NCreateTime]  DEFAULT (getdate()) FOR [NCreateTime]
GO
/****** Object:  Default [DF_Notice_NClicks]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Notice] ADD  CONSTRAINT [DF_Notice_NClicks]  DEFAULT ((0)) FOR [NClicks]
GO
/****** Object:  Default [DF_Notice_NState]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Notice] ADD  CONSTRAINT [DF_Notice_NState]  DEFAULT ((1)) FOR [NState]
GO
/****** Object:  Default [DF_MHelpMatch_ChangeCount]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[MHelpMatch] ADD  CONSTRAINT [DF_MHelpMatch_ChangeCount]  DEFAULT ((0)) FOR [ChangeCount]
GO
/****** Object:  Default [DF__MemberCon__TXSta__72C60C4A]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[MemberConfig] ADD  CONSTRAINT [DF__MemberCon__TXSta__72C60C4A]  DEFAULT ('TRUE') FOR [TXStatus]
GO
/****** Object:  Default [DF__MemberCon__ZZSta__73BA3083]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[MemberConfig] ADD  CONSTRAINT [DF__MemberCon__ZZSta__73BA3083]  DEFAULT ('TRUE') FOR [ZZStatus]
GO
/****** Object:  Default [DF_Configuration_BDCount]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Configuration] ADD  CONSTRAINT [DF_Configuration_BDCount]  DEFAULT ((2)) FOR [BDCount]
GO
/****** Object:  Default [DF_ConfigDictionary_DCount]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[ConfigDictionary] ADD  CONSTRAINT [DF_ConfigDictionary_DCount]  DEFAULT ((1)) FOR [DKey]
GO
/****** Object:  Default [DF_FHList_FHDate]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[FHList] ADD  CONSTRAINT [DF_FHList_FHDate]  DEFAULT (getdate()) FOR [FHDate]
GO
/****** Object:  Default [DF_Task_TDateTime]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_TDateTime]  DEFAULT (getdate()) FOR [TDateTime]
GO
/****** Object:  Default [DF_Task_IsReply]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_IsReply]  DEFAULT ((0)) FOR [IfRead]
GO
/****** Object:  Default [DF__Sys_SQ_An__IsDel__52593CB8]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Sys_SQ_Answer] ADD  CONSTRAINT [DF__Sys_SQ_An__IsDel__52593CB8]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF__Sys_SQ_An__STATU__534D60F1]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Sys_SQ_Answer] ADD  CONSTRAINT [DF__Sys_SQ_An__STATU__534D60F1]  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  Default [DF__Sys_Secur__IsDel__6C190EBB]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Sys_SecurityQuestion] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF__Sys_Secur__Statu__6D0D32F4]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[Sys_SecurityQuestion] ADD  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  ForeignKey [FK_RolePowers_Contents]    Script Date: 02/04/2017 11:32:54 ******/
ALTER TABLE [dbo].[RolePowers]  WITH NOCHECK ADD  CONSTRAINT [FK_RolePowers_Contents] FOREIGN KEY([CID])
REFERENCES [dbo].[Contents] ([CID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePowers] CHECK CONSTRAINT [FK_RolePowers_Contents]
GO
