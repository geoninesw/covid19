USE [covid19_db]
GO
/****** Object:  Table [dbo].[AUTH_USER]    Script Date: 3/25/2020 11:06:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTH_USER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](32) NOT NULL,
	[PASSWORD] [nvarchar](200) NOT NULL,
	[SALT] [nvarchar](100) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
 CONSTRAINT [PK_AUTH_USER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COVID_HEALTHCHECK]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COVID_HEALTHCHECK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TRAVEL_IN_14_DAYS_FLAG] [bit] NULL,
	[TRAVEL_IN_14_DAYS_COUNTRY] [int] NULL,
	[CLOSE_TO_FOREIGNER_FLAG] [bit] NULL,
	[OCCUPATION_ID] [int] NULL,
	[CLOSE_TO_PATIENT_FLAG] [bit] NULL,
	[TRAVEL_IN_14_DAYS_OTHER_FLAG] [bit] NULL,
	[TRAVEL_IN_14_DAYS_COUNTRY_OTHER] [int] NULL,
	[MEDICAL_STAFF_FLAG] [bit] NULL,
	[AGE] [int] NULL,
	[AMPHUR_ID] [bigint] NULL,
	[FRIENT_HAS_FLU_FLAG] [bit] NULL,
	[LOCATION_TYPE_ID] [int] NULL,
	[CREATED_DT] [datetime] NULL,
 CONSTRAINT [PK_COVID_HEALTH_CHECK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COVID_HEALTHCHECK_COUNTRY]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COVID_HEALTHCHECK_COUNTRY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REPORTER_ID] [int] NOT NULL,
	[COUNTRY_ID] [int] NULL,
 CONSTRAINT [PK_COVID_HEALTHCHECK_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COVID_HEALTHCHECK_SYMTOMS]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COVID_HEALTHCHECK_SYMTOMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REPORTER_ID] [int] NOT NULL,
	[SYMTOMS_ID] [int] NULL,
 CONSTRAINT [PK_COVID_HEALTHCHECK_SYMTOMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[PERSON_ID] [varchar](20) NOT NULL,
	[FULLNAME] [varchar](255) NULL,
	[FIRSTNAME] [varchar](255) NULL,
	[LASTNAME] [varchar](255) NULL,
	[ORGDESC] [varchar](255) NULL,
	[JOBDESC] [varchar](255) NULL,
	[EMAIL] [varchar](50) NULL,
	[TEL] [varchar](50) NULL,
	[BIRTHDATE] [date] NULL,
	[NATIONALITY] [int] NULL,
	[HOUSE_NO] [nvarchar](50) NULL,
	[MOO] [nvarchar](10) NULL,
	[PROV_CODE] [nchar](2) NULL,
	[AMP_CODE] [nchar](2) NULL,
	[TAM_CODE] [nchar](2) NULL,
	[JOURNEY_DESCR] [varchar](255) NULL,
	[DEPARTURE_DT] [date] NULL,
	[ARRIVAL_DT] [date] NULL,
	[REPORT_DT] [date] NULL,
	[RESPONSIBLE_BY] [varchar](200) NULL,
	[CREATED_DT] [datetime] NULL,
 CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[PERSON_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_COUNTRY]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_COUNTRY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[COUNTRY_CODE] [nvarchar](10) NULL,
	[COUNTRY_SH_CODE] [nchar](2) NULL,
	[COUNTRY_NAME] [nvarchar](100) NULL,
	[COUNTRY_NAMT] [nvarchar](100) NULL,
	[DISPLAY_FLAG] [bit] NULL,
	[WATCH_OUT_FLAG] [bit] NULL,
 CONSTRAINT [PK_LUT_COVID_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_COVID_RELATION]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_COVID_RELATION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCR] [nvarchar](50) NULL,
 CONSTRAINT [PK_LUT_COVID_RELATION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_COVID_REPORTER]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_COVID_REPORTER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REPORTER] [nvarchar](50) NULL,
 CONSTRAINT [PK_LUT_COVID_REPORTER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_COVID_SYMTOM]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_COVID_SYMTOM](
	[ID] [int] NOT NULL,
	[SYMTOM] [nvarchar](50) NULL,
	[ORDER_DISPLAY] [int] NULL,
 CONSTRAINT [PK_LUT_SYMTOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_HEALTH_SYMTOM]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_HEALTH_SYMTOM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SYMTOM] [nvarchar](200) NULL,
 CONSTRAINT [PK_LUT_HEALTH_SYMTOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_HEALTHCHECK_ALGORITHM]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_HEALTHCHECK_ALGORITHM](
	[ID] [int] NOT NULL,
	[FEVER] [tinyint] NULL,
	[ONE_URI_SYMP] [tinyint] NULL,
	[TRAVEL_RISK_COUNTRY] [tinyint] NULL,
	[COVID19_CONTACT] [tinyint] NULL,
	[CLOSE_RISK_COUNTRY] [tinyint] NULL,
	[INT_CONTACT] [tinyint] NULL,
	[MED_PROF] [tinyint] NULL,
	[CLOSE_CON] [tinyint] NULL,
	[RISK_LEVEL] [tinyint] NULL,
	[GEN_ACTION] [varchar](max) NULL,
	[SPEC_ACTION] [varchar](max) NULL,
 CONSTRAINT [PK_HEALTHCHECK_ALGORITHM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_HEALTHCHECK_ALGORITHM_DD]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_HEALTHCHECK_ALGORITHM_DD](
	[ID] [int] NOT NULL,
	[ATTRIBUTE] [varchar](255) NULL,
	[DATA_TYPE] [varchar](255) NULL,
	[DESCRIPTION] [varchar](max) NULL,
	[DATA_SCOPE] [varchar](max) NULL,
	[DATA_SIZE] [varchar](255) NULL,
	[MANDATORY_FIELD] [tinyint] NOT NULL,
	[CHARACTERISTIC] [varchar](max) NULL,
	[DATA_FORMAT] [varchar](max) NULL,
 CONSTRAINT [PK_HEALTHCHECK_ALGORITHM_DD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_LOCATION_TYPE]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_LOCATION_TYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SHORT_DESCR] [nvarchar](100) NULL,
	[DESCR] [nvarchar](200) NULL,
 CONSTRAINT [PK_LUT_LOCATION_TYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_OCCUPATION]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_OCCUPATION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SHORT_DESCR] [nvarchar](100) NULL,
	[DESCR] [nvarchar](200) NULL,
 CONSTRAINT [PK_LUT_OCCUPATION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUT_PROVINCE]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUT_PROVINCE](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PROV_CODE] [nchar](2) NOT NULL,
	[AMP_CODE] [nchar](2) NOT NULL,
	[TAM_CODE] [nchar](2) NOT NULL,
	[PROV_NAMT] [nvarchar](80) NULL,
	[PROV_NAME] [nvarchar](80) NULL,
	[AMP_NAMT] [nvarchar](80) NULL,
	[AMP_NAME] [nvarchar](80) NULL,
	[TAM_NAMT] [nvarchar](80) NULL,
	[TAM_NAME] [nvarchar](80) NULL,
	[POSTCODE] [nvarchar](5) NULL,
 CONSTRAINT [PK_LUT_AREA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RPT_COVID19EX]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPT_COVID19EX](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PERSON_ID] [nvarchar](20) NOT NULL,
	[REPORTER] [int] NULL,
	[TRAVEL_FLAG] [bit] NULL,
	[DEPARTURE_DT] [date] NULL,
	[DEPARTURE_FLIGHT] [nvarchar](10) NULL,
	[ARRIVAL_DT] [date] NULL,
	[ARRIVAL_FLIGHT] [nvarchar](10) NULL,
	[HAS_FLU] [nvarchar](10) NULL,
	[HAS_FLU_OTHER] [nvarchar](10) NULL,
	[COMPANION_NAME1] [nvarchar](100) NULL,
	[COMPANION_RELATION1] [nvarchar](100) NULL,
	[COMPANION_NAME2] [nvarchar](100) NULL,
	[COMPANION_RELATION2] [nvarchar](100) NULL,
	[COMPANION_NAME3] [nvarchar](100) NULL,
	[COMPANION_RELATION3] [nvarchar](100) NULL,
	[TRAVEL_TOGETHER] [bit] NULL,
	[TEMPERATURE] [decimal](3, 1) NULL,
	[TEMPERATURE_OTHER] [decimal](3, 1) NULL,
	[CLOSE_PATIENT_FLAG] [bit] NULL,
	[CLOSE_PATIENT_DETAIL] [nvarchar](500) NULL,
	[CREATED_DT] [datetime] NULL,
 CONSTRAINT [PK_RPT_COVID19_OUTSOURCE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RPT_COVID19EX_COUNTRY]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPT_COVID19EX_COUNTRY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REPORTER_ID] [int] NOT NULL,
	[COUNTRY_ID] [int] NULL,
	[PERSON_TYPE_ID] [int] NULL,
 CONSTRAINT [PK_RPT_COVID19EX_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RPT_COVID19EX_SYMTOMS]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPT_COVID19EX_SYMTOMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REPORTER_ID] [int] NOT NULL,
	[SYMTOMS_ID] [int] NOT NULL,
	[PERSON_TYPE_ID] [int] NULL,
	[SYMTOMS_OTHER] [nvarchar](200) NULL,
 CONSTRAINT [PK_RPT_COVID19EX_SYMTOMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RPT_COVID19EX_SYMTOMS_OTHER]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPT_COVID19EX_SYMTOMS_OTHER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REPORTER_ID] [int] NOT NULL,
	[SYMTOMS_ID] [int] NULL,
	[PERSON_TYPE_ID] [int] NULL,
	[SYMTOMS_OTHER] [nvarchar](200) NULL,
 CONSTRAINT [PK_RPT_COVID19EX_SYMTOMS_OTHER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK]  WITH CHECK ADD  CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_COUNTRY] FOREIGN KEY([TRAVEL_IN_14_DAYS_COUNTRY])
REFERENCES [dbo].[LUT_COUNTRY] ([ID])
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK] CHECK CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_COUNTRY]
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK]  WITH CHECK ADD  CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_COUNTRY1] FOREIGN KEY([TRAVEL_IN_14_DAYS_COUNTRY_OTHER])
REFERENCES [dbo].[LUT_COUNTRY] ([ID])
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK] CHECK CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_COUNTRY1]
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK]  WITH CHECK ADD  CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_LOCATION_TYPE] FOREIGN KEY([LOCATION_TYPE_ID])
REFERENCES [dbo].[LUT_LOCATION_TYPE] ([ID])
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK] CHECK CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_LOCATION_TYPE]
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK]  WITH CHECK ADD  CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_OCCUPATION] FOREIGN KEY([OCCUPATION_ID])
REFERENCES [dbo].[LUT_OCCUPATION] ([ID])
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK] CHECK CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_OCCUPATION]
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK]  WITH CHECK ADD  CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_PROVINCE] FOREIGN KEY([AMPHUR_ID])
REFERENCES [dbo].[LUT_PROVINCE] ([ID])
GO
ALTER TABLE [dbo].[COVID_HEALTHCHECK] CHECK CONSTRAINT [FK_COVID_HEALTHCHECK_LUT_PROVINCE]
GO
ALTER TABLE [dbo].[RPT_COVID19EX_COUNTRY]  WITH CHECK ADD  CONSTRAINT [FK__RPT_COVIDEX__REPOR__361203C5] FOREIGN KEY([REPORTER_ID])
REFERENCES [dbo].[RPT_COVID19EX] ([ID])
GO
ALTER TABLE [dbo].[RPT_COVID19EX_COUNTRY] CHECK CONSTRAINT [FK__RPT_COVIDEX__REPOR__361203C5]
GO
ALTER TABLE [dbo].[RPT_COVID19EX_SYMTOMS]  WITH CHECK ADD  CONSTRAINT [FK__RPT_COVIDEX__REPOR__3429BB53] FOREIGN KEY([REPORTER_ID])
REFERENCES [dbo].[RPT_COVID19EX] ([ID])
GO
ALTER TABLE [dbo].[RPT_COVID19EX_SYMTOMS] CHECK CONSTRAINT [FK__RPT_COVIDEX__REPOR__3429BB53]
GO
ALTER TABLE [dbo].[RPT_COVID19EX_SYMTOMS_OTHER]  WITH CHECK ADD  CONSTRAINT [FK__RPT_COVIDEX__REPOR__351DDF8C] FOREIGN KEY([REPORTER_ID])
REFERENCES [dbo].[RPT_COVID19EX] ([ID])
GO
ALTER TABLE [dbo].[RPT_COVID19EX_SYMTOMS_OTHER] CHECK CONSTRAINT [FK__RPT_COVIDEX__REPOR__351DDF8C]
GO
/****** Object:  StoredProcedure [dbo].[RPT_COVID19_DAILY]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sirinrat (migrate)
-- Create date: 18/3/2563
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RPT_COVID19_DAILY]
	-- Add the parameters for the stored procedure here
	-- @pBranch_code nvarchar(20),
	@pType int , --1=ประจำวัน , 2= สรุป
	@START_DT DATE = null,
	@END_DT	DATE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @REPORT_NUM INT
	DECLARE @TRAVEL_NUM INT

	IF (@pType = 1) --1=ประจำวัน
	BEGIN
		--หาจำนวนผู้ที่รายงาน
		SELECT @REPORT_NUM=COUNT(*)
		FROM 
		(SELECT RC.PERSON_ID 
		FROM RPT_COVID19EX RC
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE CAST(RC.CREATED_DT AS DATE) = CAST(GETDATE() AS DATE)
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RC.PERSON_ID) DATA

		SELECT @TRAVEL_NUM=COUNT(*)
		FROM (SELECT DISTINCT RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT 
				FROM RPT_COVID19EX RC2
				LEFT JOIN 
					(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
					FROM RPT_COVID19EX RC2
					GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
				WHERE RC2.CREATED_DT = MRC.CREATED_DT) RC
		LEFT JOIN LUT_COVID_REPORTER LR ON RC.REPORTER = LR.ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE CAST(RC.CREATED_DT AS DATE)  = CAST(GETDATE() AS DATE)
		AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RC.REPORTER , LR.REPORTER  

		-- หาจำนวนผู้เดินทางตาม type
		IF @TRAVEL_NUM > 0 
			SELECT @REPORT_NUM AS REPORT_NUM ,RC.REPORTER AS ID , LR.REPORTER AS LABEL, COUNT(*) AS AMOUNT
			FROM (SELECT DISTINCT RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT 
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT) RC
			LEFT JOIN LUT_COVID_REPORTER LR ON RC.REPORTER = LR.ID
			LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
			WHERE CAST(RC.CREATED_DT AS DATE)  = CAST(GETDATE() AS DATE)
			AND RC.TRAVEL_FLAG = 1
			-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
			GROUP BY RC.REPORTER , LR.REPORTER 
		ELSE 
			SELECT @REPORT_NUM AS REPORT_NUM , LC.ID AS ID , LC.REPORTER AS LABEL , 0 AS AMOUNT
			FROM LUT_COVID_REPORTER LC


	END
	ELSE --2= สรุป
	BEGIN
		--หาจำนวนผู้ที่รายงาน
		SELECT @REPORT_NUM=COUNT(*)
		FROM 
		(SELECT RC.PERSON_ID 
		FROM RPT_COVID19EX RC
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC.CREATED_DT))) and
		 (@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC.CREATED_DT)))
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RC.PERSON_ID) DATA

		SELECT @TRAVEL_NUM=COUNT(*)
		FROM (SELECT DISTINCT RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT 
				FROM RPT_COVID19EX RC2
				LEFT JOIN 
					(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
					FROM RPT_COVID19EX RC2
					WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
					GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
				WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN LUT_COVID_REPORTER LR ON RC.REPORTER = LR.ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC.CREATED_DT))) and
		 (@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC.CREATED_DT)))
		AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RC.REPORTER , LR.REPORTER 
		-- หาจำนวนผู้เดินทางตาม type
		IF @TRAVEL_NUM > 0 
		SELECT @REPORT_NUM AS REPORT_NUM ,RC.REPORTER AS ID , LR.REPORTER AS LABEL, COUNT(*) AS AMOUNT
		FROM (SELECT DISTINCT RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT 
				FROM RPT_COVID19EX RC2
				LEFT JOIN 
					(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
					FROM RPT_COVID19EX RC2
					WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
					GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
				WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN LUT_COVID_REPORTER LR ON RC.REPORTER = LR.ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC.CREATED_DT))) and
		 (@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC.CREATED_DT)))
		AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RC.REPORTER , LR.REPORTER 
		ELSE 
			SELECT @REPORT_NUM AS REPORT_NUM , LC.ID AS ID , LC.REPORTER AS LABEL , 0 AS AMOUNT
			FROM LUT_COVID_REPORTER LC
	END

END
GO
/****** Object:  StoredProcedure [dbo].[RPT_COVID19_DAILY_COUNTRY]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sirinrat (migrate)
-- Create date: 18/3/2563
-- Description:	สำหรับหาประเทศที่ไป
-- =============================================
CREATE PROCEDURE [dbo].[RPT_COVID19_DAILY_COUNTRY]
	-- Add the parameters for the stored procedure here
	-- @pBranch_code nvarchar(20),
	@pType int , --1=ประจำวัน , 2= สรุป
	@START_DT DATE = null,
	@END_DT	DATE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @pType = 1
		SELECT RCC.COUNTRY_ID , LCC.COUNTRY_NAMT AS LABEL, RCC.PERSON_TYPE_ID , COUNT(*) AMOUNT
		FROM (SELECT DISTINCT RC2.ID , RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT 
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN RPT_COVID19EX_COUNTRY RCC ON RC.ID = RCC.REPORTER_ID
		LEFT JOIN LUT_COUNTRY LCC ON LCC.ID = RCC.COUNTRY_ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE CAST(RC.CREATED_DT AS DATE)  = CAST(GETDATE() AS DATE)
		AND LCC.COUNTRY_NAMT IS NOT NULL
		AND RCC.PERSON_TYPE_ID IS NOT NULL
		AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RCC.COUNTRY_ID , PERSON_TYPE_ID , LCC.COUNTRY_NAMT 
		ORDER BY PERSON_TYPE_ID , COUNT(*) DESC
	ELSE 
		SELECT RCC.COUNTRY_ID , LCC.COUNTRY_NAMT AS LABEL, RCC.PERSON_TYPE_ID , COUNT(*) AMOUNT
		FROM (SELECT DISTINCT RC2.ID , RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT 
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN RPT_COVID19EX_COUNTRY RCC ON RC.ID = RCC.REPORTER_ID
		LEFT JOIN LUT_COUNTRY LCC ON LCC.ID = RCC.COUNTRY_ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC.CREATED_DT))) and
		 (@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC.CREATED_DT)))
		AND LCC.COUNTRY_NAMT IS NOT NULL
		AND RCC.PERSON_TYPE_ID IS NOT NULL
		AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RCC.COUNTRY_ID , PERSON_TYPE_ID , LCC.COUNTRY_NAMT 
		ORDER BY PERSON_TYPE_ID , COUNT(*) DESC

END
GO
/****** Object:  StoredProcedure [dbo].[RPT_COVID19_DAILY_FLU]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sirinrat (migrate)
-- Create date: 18/3/2563
-- Description:	สำหรับหาอาการไข้
-- =============================================
CREATE PROCEDURE [dbo].[RPT_COVID19_DAILY_FLU]
	-- Add the parameters for the stored procedure here
	-- @pBranch_code nvarchar(20),
	@pType int , --1=ประจำวัน , 2= สรุป
	@START_DT DATE = null,
	@END_DT	DATE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @pType=1
		SELECT REPORTER AS PERSON_TYPE_ID , HAS_FLU AS LABEL , COUNT(*) AS AMOUNT
		FROM (SELECT DISTINCT RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT , RC2.HAS_FLU
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE CAST(RC.CREATED_DT AS DATE)  = CAST(GETDATE() AS DATE)
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		--AND RC.TRAVEL_FLAG = 1
		GROUP BY REPORTER ,HAS_FLU
		ORDER BY REPORTER , HAS_FLU
	ELSE 
		SELECT REPORTER AS PERSON_TYPE_ID , HAS_FLU AS LABEL , COUNT(*) AS AMOUNT
		FROM (SELECT  DISTINCT RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT , RC2.HAS_FLU
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC.CREATED_DT))) and
		 (@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC.CREATED_DT)))
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		--AND RC.TRAVEL_FLAG = 1
		GROUP BY REPORTER ,HAS_FLU
		ORDER BY REPORTER , HAS_FLU
END
GO
/****** Object:  StoredProcedure [dbo].[RPT_COVID19_DAILY_FLU_DETAIL]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sirinrat (migrate)
-- Create date: 18/3/2563
-- Description:	สำหรับหาอาการไข้
-- =============================================
CREATE PROCEDURE [dbo].[RPT_COVID19_DAILY_FLU_DETAIL]
	-- Add the parameters for the stored procedure here
	-- @pBranch_code nvarchar(20),
	@pType int , --1=ประจำวัน , 2= สรุป
	@START_DT DATE = null,
	@END_DT	DATE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @pType=1
		SELECT DISTINCT RC2.PERSON_ID , ME.FULLNAME , RC2.REPORTER AS PERSON_TYPE_ID -- , LB.BRANCH_SH_NAMT
		, RC2.CREATED_DT , RC2.HAS_FLU
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					LEFT JOIN EMPLOYEE ME ON ME.PERSON_ID = RC2.PERSON_ID
					-- LEFT JOIN LUT_BRANCH LB ON LB.BRANCH_CODE = ME.BRANCH_CODE
					WHERE RC2.CREATED_DT = MRC.CREATED_DT
					AND HAS_FLU = 'มีไข้'
					AND CAST(RC2.CREATED_DT AS DATE)  = CAST(GETDATE() AS DATE)
					-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
	ELSE 
		SELECT  DISTINCT RC2.PERSON_ID , ME.FULLNAME , RC2.REPORTER AS PERSON_TYPE_ID -- , LB.BRANCH_SH_NAMT
		, RC2.CREATED_DT , RC2.HAS_FLU
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					LEFT JOIN EMPLOYEE ME ON ME.PERSON_ID = RC2.PERSON_ID
					-- LEFT JOIN LUT_BRANCH LB ON LB.BRANCH_CODE = ME.BRANCH_CODE
					WHERE RC2.CREATED_DT = MRC.CREATED_DT
					AND HAS_FLU = 'มีไข้'
					-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
					
END
GO
/****** Object:  StoredProcedure [dbo].[RPT_COVID19_DAILY_SYMTOM]    Script Date: 3/25/2020 11:06:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sirinrat (migrate)
-- Create date: 18/3/2563
-- Description:	สำหรับหาอาการ
-- =============================================
CREATE PROCEDURE [dbo].[RPT_COVID19_DAILY_SYMTOM]
	-- Add the parameters for the stored procedure here
	-- @pBranch_code nvarchar(20),
	@pType int , --1=ประจำวัน , 2= สรุป
	@START_DT DATE = null,
	@END_DT	DATE = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @pType = 1
		SELECT RCC.SYMTOMS_ID , LCC.SYMTOM as LABEL, RCC.PERSON_TYPE_ID , COUNT(*) AMOUNT
		FROM (SELECT DISTINCT RC2.ID,RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT  
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN RPT_COVID19EX_SYMTOMS RCC ON RC.ID = RCC.REPORTER_ID
		LEFT JOIN LUT_COVID_SYMTOM LCC ON LCC.ID = RCC.SYMTOMS_ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE CAST(RC.CREATED_DT AS DATE)  = CAST(GETDATE() AS DATE)
		AND LCC.SYMTOM IS NOT NULL
		AND RCC.PERSON_TYPE_ID IS NOT NULL
		--AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RCC.SYMTOMS_ID , PERSON_TYPE_ID , LCC.SYMTOM
		ORDER BY PERSON_TYPE_ID , SYMTOMS_ID 
	ELSE
			SELECT RCC.SYMTOMS_ID , LCC.SYMTOM as LABEL, RCC.PERSON_TYPE_ID , COUNT(*) AMOUNT
		FROM (SELECT DISTINCT RC2.ID,RC2.PERSON_ID , RC2.REPORTER , rc2.TRAVEL_FLAG , RC2.CREATED_DT  
					FROM RPT_COVID19EX RC2
					LEFT JOIN 
						(SELECT PERSON_ID , REPORTER , MAX(CREATED_DT) CREATED_DT
						FROM RPT_COVID19EX RC2
						WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC2.CREATED_DT))) and
						(@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC2.CREATED_DT)))
						GROUP BY PERSON_ID , REPORTER) MRC ON RC2.PERSON_ID = MRC.PERSON_ID AND RC2.REPORTER = MRC.REPORTER
					WHERE RC2.CREATED_DT = MRC.CREATED_DT)  RC
		LEFT JOIN RPT_COVID19EX_SYMTOMS RCC ON RC.ID = RCC.REPORTER_ID
		LEFT JOIN LUT_COVID_SYMTOM LCC ON LCC.ID = RCC.SYMTOMS_ID
		LEFT JOIN EMPLOYEE ME ON RC.PERSON_ID = ME.PERSON_ID
		WHERE (@START_DT is null or (@START_DT is not null and @START_DT <= CONVERT (date, RC.CREATED_DT))) and
		 (@END_DT  is null or (@END_DT is not null and @END_DT >= CONVERT (date, RC.CREATED_DT)))
		AND LCC.SYMTOM IS NOT NULL
		AND RCC.PERSON_TYPE_ID IS NOT NULL
		--AND RC.TRAVEL_FLAG = 1
		-- AND (ME.BRANCH_CODE = @pBranch_code OR @pBranch_code IS NULL)
		GROUP BY RCC.SYMTOMS_ID , PERSON_TYPE_ID , LCC.SYMTOM
		ORDER BY PERSON_TYPE_ID , SYMTOMS_ID 
	
	


END
GO
