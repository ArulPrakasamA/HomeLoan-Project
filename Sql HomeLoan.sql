USE [master]
GO
/****** Object:  Database [HomeLoan]    Script Date: 20-11-2021 15:35:49 ******/
CREATE DATABASE [HomeLoan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeLoan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HomeLoan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HomeLoan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HomeLoan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HomeLoan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeLoan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeLoan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeLoan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeLoan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeLoan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeLoan] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeLoan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HomeLoan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeLoan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeLoan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeLoan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeLoan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeLoan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeLoan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeLoan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeLoan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HomeLoan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeLoan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeLoan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeLoan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeLoan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeLoan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeLoan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeLoan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HomeLoan] SET  MULTI_USER 
GO
ALTER DATABASE [HomeLoan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeLoan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeLoan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeLoan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HomeLoan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HomeLoan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HomeLoan] SET QUERY_STORE = OFF
GO
USE [HomeLoan]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Admin_ID] [int] NOT NULL,
	[Admin_Password] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Admin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income_Details]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income_Details](
	[Income_ID] [int] NOT NULL,
	[Type_Of_Employment] [varchar](30) NULL,
	[Organization_Type] [varchar](30) NULL,
	[Organization_Name] [varchar](30) NULL,
	[Salary] [float] NULL,
	[Retirement_Age] [int] NULL,
	[Application_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Income_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan_Details]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan_Details](
	[Loan_ID] [int] NOT NULL,
	[Amount] [float] NULL,
	[Max_amount_grantable] [float] NULL,
	[Interest_rate] [float] NULL,
	[Tenure] [float] NULL,
	[Loan_Date] [date] NULL,
	[Application_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Loan_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan_Status]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan_Status](
	[Status_ID] [int] NOT NULL,
	[Track_Status] [varchar](30) NULL,
	[Application_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Status_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Property_ID] [int] NOT NULL,
	[Property_Number] [int] NULL,
	[Property_Area] [varchar](30) NULL,
	[Pincode] [int] NULL,
	[Type_Of_Property] [varchar](30) NULL,
	[Estimated_Cost] [float] NULL,
	[Application_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Property_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uploaded_Documents]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uploaded_Documents](
	[Document_ID] [int] NOT NULL,
	[Pan_Card] [varchar](70) NULL,
	[Aadhar_Card] [varchar](70) NULL,
	[Salary_Slip] [varchar](70) NULL,
	[Loa] [varchar](70) NULL,
	[Noc] [varchar](70) NULL,
	[Agreement] [varchar](70) NULL,
	[Documentverified_status] [varchar](30) NULL,
	[Application_ID] [int] NULL,
	[LoanApprovalStatus] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Document_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Details]    Script Date: 20-11-2021 15:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Details](
	[Application_ID] [int] NOT NULL,
	[User_Password] [varchar](30) NULL,
	[First_Name] [varchar](30) NULL,
	[Middle_Name] [varchar](30) NULL,
	[Last_Name] [varchar](30) NULL,
	[Email] [varchar](50) NULL,
	[Phone_Number] [varchar](12) NULL,
	[Date_Of_Birth] [date] NULL,
	[Gender] [varchar](30) NULL,
	[Nationality] [varchar](30) NULL,
	[Aadhar_Number] [varchar](12) NULL,
	[Pan_Number] [varchar](10) NULL,
	[Bank_Account_Number] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[Application_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([Admin_ID], [Admin_Password]) VALUES (123, N'password')
INSERT [dbo].[Admin] ([Admin_ID], [Admin_Password]) VALUES (321, N'321')
GO
INSERT [dbo].[Income_Details] ([Income_ID], [Type_Of_Employment], [Organization_Type], [Organization_Name], [Salary], [Retirement_Age], [Application_ID]) VALUES (1000, N'Salaried', N'Public', N'span', 20000, 55, 1)
INSERT [dbo].[Income_Details] ([Income_ID], [Type_Of_Employment], [Organization_Type], [Organization_Name], [Salary], [Retirement_Age], [Application_ID]) VALUES (1001, N'Salaried', N'Public', N'span', 20000, 60, 2)
INSERT [dbo].[Income_Details] ([Income_ID], [Type_Of_Employment], [Organization_Type], [Organization_Name], [Salary], [Retirement_Age], [Application_ID]) VALUES (1002, NULL, N'Public', NULL, NULL, NULL, 4)
INSERT [dbo].[Income_Details] ([Income_ID], [Type_Of_Employment], [Organization_Type], [Organization_Name], [Salary], [Retirement_Age], [Application_ID]) VALUES (1003, N'Salaried', N'Public', N'world', 50000, 65, 5)
INSERT [dbo].[Income_Details] ([Income_ID], [Type_Of_Employment], [Organization_Type], [Organization_Name], [Salary], [Retirement_Age], [Application_ID]) VALUES (1004, N'Salaried', N'Private', N'world', 50000, 60, 6)
GO
INSERT [dbo].[Loan_Details] ([Loan_ID], [Amount], [Max_amount_grantable], [Interest_rate], [Tenure], [Loan_Date], [Application_ID]) VALUES (3000, 20000, 20000, 8.5, 2, CAST(N'2021-11-21' AS Date), 1)
INSERT [dbo].[Loan_Details] ([Loan_ID], [Amount], [Max_amount_grantable], [Interest_rate], [Tenure], [Loan_Date], [Application_ID]) VALUES (3001, 20000, 25000, 8.5, 2, CAST(N'2021-11-26' AS Date), 2)
INSERT [dbo].[Loan_Details] ([Loan_ID], [Amount], [Max_amount_grantable], [Interest_rate], [Tenure], [Loan_Date], [Application_ID]) VALUES (3002, 40000, 40000, 8.5, 24, CAST(N'2021-11-20' AS Date), 5)
GO
INSERT [dbo].[Property] ([Property_ID], [Property_Number], [Property_Area], [Pincode], [Type_Of_Property], [Estimated_Cost], [Application_ID]) VALUES (5000, 123456, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Property] ([Property_ID], [Property_Number], [Property_Area], [Pincode], [Type_Of_Property], [Estimated_Cost], [Application_ID]) VALUES (5001, 123, N'55', 600001, N'land', 120000000, 2)
INSERT [dbo].[Property] ([Property_ID], [Property_Number], [Property_Area], [Pincode], [Type_Of_Property], [Estimated_Cost], [Application_ID]) VALUES (5002, 12345, N'500', 600001, N'land', 1000000, 5)
INSERT [dbo].[Property] ([Property_ID], [Property_Number], [Property_Area], [Pincode], [Type_Of_Property], [Estimated_Cost], [Application_ID]) VALUES (5003, 1234567, N'1000', 600001, N'land', 12345678, 6)
GO
INSERT [dbo].[Uploaded_Documents] ([Document_ID], [Pan_Card], [Aadhar_Card], [Salary_Slip], [Loa], [Noc], [Agreement], [Documentverified_status], [Application_ID], [LoanApprovalStatus]) VALUES (9000, N'~/Upload/1PAN.png', N'~/Upload/1Aadhar.png', N'~/Upload/1Salary.png', N'~/Upload/1Loa.png', N'~/Upload/1Noc.png', N'~/Upload/1Agreement.png', N'Document Verified', 1, N'Loan Approved')
INSERT [dbo].[Uploaded_Documents] ([Document_ID], [Pan_Card], [Aadhar_Card], [Salary_Slip], [Loa], [Noc], [Agreement], [Documentverified_status], [Application_ID], [LoanApprovalStatus]) VALUES (9001, N'~/Upload/2PAN.png', N'~/Upload/2Aadhar.png', N'~/Upload/2Salary.png', N'~/Upload/2Loa.png', N'~/Upload/2Noc.png', N'~/Upload/2Agreement.png', N'Document Verified', 2, N'Loan Approved')
INSERT [dbo].[Uploaded_Documents] ([Document_ID], [Pan_Card], [Aadhar_Card], [Salary_Slip], [Loa], [Noc], [Agreement], [Documentverified_status], [Application_ID], [LoanApprovalStatus]) VALUES (9002, N'~/Upload/5PAN.png', N'~/Upload/5Aadhar.png', N'~/Upload/5Salary.png', N'~/Upload/5Loa.png', N'~/Upload/5Noc.png', N'~/Upload/5Agreement.png', N'Sent for Verification', 5, N'Sent for Approval')
INSERT [dbo].[Uploaded_Documents] ([Document_ID], [Pan_Card], [Aadhar_Card], [Salary_Slip], [Loa], [Noc], [Agreement], [Documentverified_status], [Application_ID], [LoanApprovalStatus]) VALUES (9003, N'~/Upload/6PAN.png', N'~/Upload/6Aadhar.png', N'~/Upload/6Salary.png', N'~/Upload/6Loa.png', N'~/Upload/6Noc.png', N'~/Upload/6Agreement.png', N'Sent for Verification', 6, N'Sent for Approval')
GO
INSERT [dbo].[User_Details] ([Application_ID], [User_Password], [First_Name], [Middle_Name], [Last_Name], [Email], [Phone_Number], [Date_Of_Birth], [Gender], [Nationality], [Aadhar_Number], [Pan_Number], [Bank_Account_Number]) VALUES (1, N'123', N'jack', NULL, N'jill', N'user@gmail.com', N'1234567890', CAST(N'2021-11-04' AS Date), N'Male', N'indian', N'123456789012', N'1234567890', N'123456789012')
INSERT [dbo].[User_Details] ([Application_ID], [User_Password], [First_Name], [Middle_Name], [Last_Name], [Email], [Phone_Number], [Date_Of_Birth], [Gender], [Nationality], [Aadhar_Number], [Pan_Number], [Bank_Account_Number]) VALUES (2, N'123', N'jack', NULL, N'sdf', N'customer@gmail.com', N'1234567890', CAST(N'2021-11-13' AS Date), N'Male', N'indian', N'123456789012', N'AYTM123456', N'123456789012')
INSERT [dbo].[User_Details] ([Application_ID], [User_Password], [First_Name], [Middle_Name], [Last_Name], [Email], [Phone_Number], [Date_Of_Birth], [Gender], [Nationality], [Aadhar_Number], [Pan_Number], [Bank_Account_Number]) VALUES (3, N'123', N'jack', NULL, N'jill', N'wer@gmail.com', N'1234567890', CAST(N'2021-11-05' AS Date), N'Male', N'indian', N'123456789012', N'AYTM123456', N'1234567890123')
INSERT [dbo].[User_Details] ([Application_ID], [User_Password], [First_Name], [Middle_Name], [Last_Name], [Email], [Phone_Number], [Date_Of_Birth], [Gender], [Nationality], [Aadhar_Number], [Pan_Number], [Bank_Account_Number]) VALUES (4, N'123', N'jack', NULL, N'jill', N'abc@gmail.com', N'1234567899', CAST(N'2021-11-01' AS Date), N'Male', N'indian', N'123456789011', N'1234567899', N'1234567890122')
INSERT [dbo].[User_Details] ([Application_ID], [User_Password], [First_Name], [Middle_Name], [Last_Name], [Email], [Phone_Number], [Date_Of_Birth], [Gender], [Nationality], [Aadhar_Number], [Pan_Number], [Bank_Account_Number]) VALUES (5, N'123', N'MS', NULL, N'Dhoni', N'dhoni@gmalil.com', N'1234567893', CAST(N'2021-11-07' AS Date), N'Male', N'indian', N'123456789017', N'AYTM123458', N'1234567890124')
INSERT [dbo].[User_Details] ([Application_ID], [User_Password], [First_Name], [Middle_Name], [Last_Name], [Email], [Phone_Number], [Date_Of_Birth], [Gender], [Nationality], [Aadhar_Number], [Pan_Number], [Bank_Account_Number]) VALUES (6, N'123', N'Cristiano', NULL, N'Ronaldo', N'ronaldo@gmail.com', N'9876543210', CAST(N'2021-11-03' AS Date), N'Male', N'indian', N'987654321123', N'1234565612', N'12345678908')
GO
ALTER TABLE [dbo].[Income_Details]  WITH CHECK ADD FOREIGN KEY([Application_ID])
REFERENCES [dbo].[User_Details] ([Application_ID])
GO
ALTER TABLE [dbo].[Loan_Details]  WITH CHECK ADD FOREIGN KEY([Application_ID])
REFERENCES [dbo].[User_Details] ([Application_ID])
GO
ALTER TABLE [dbo].[Loan_Status]  WITH CHECK ADD FOREIGN KEY([Application_ID])
REFERENCES [dbo].[User_Details] ([Application_ID])
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD FOREIGN KEY([Application_ID])
REFERENCES [dbo].[User_Details] ([Application_ID])
GO
ALTER TABLE [dbo].[Uploaded_Documents]  WITH CHECK ADD FOREIGN KEY([Application_ID])
REFERENCES [dbo].[User_Details] ([Application_ID])
GO
USE [master]
GO
ALTER DATABASE [HomeLoan] SET  READ_WRITE 
GO
