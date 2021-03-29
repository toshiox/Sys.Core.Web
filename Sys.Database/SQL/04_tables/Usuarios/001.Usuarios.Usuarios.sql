USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Usuarios].[USR]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Usuarios].[USR]
GO

CREATE TABLE [Usuarios].[USR]
(
	PK_USR			numeric(4) NOT NULL IDENTITY (1, 1),
	UNIQKEY			varchar(100),
	NAME			varchar(400),
	CPF				varchar(14),
	GEN				varchar(10),
	DT_NAS			datetime,
	DT_CAD			datetime
)
GO