USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Front].[GRP]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Front].[GRP]
GO

CREATE TABLE [Front].[GRP]
(
	PK_GRP  		numeric(4) NOT NULL IDENTITY (1, 1),
	DS_NAME			varchar(100),
	DS_ICON			varchar(100),
	DS_ROUTE		varchar(100),
	DT_CAD			datetime
)
GO