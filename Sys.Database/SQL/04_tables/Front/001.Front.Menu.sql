USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Front].[MENU]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Front].[MENU]
GO

CREATE TABLE [Front].[MENU]
(
	PK_MENU			numeric(4) NOT NULL IDENTITY (1, 1),
	FK_GRP			int not null,
	DS_NAME			varchar(100),
	DS_ICON			varchar(100),
	DS_ROUTE		varchar(100),
	DT_CAD			datetime
)
GO