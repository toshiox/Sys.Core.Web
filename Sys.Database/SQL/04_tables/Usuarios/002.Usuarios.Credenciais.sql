USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Usuarios].[CREDTN]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Usuarios].[CREDTN]
GO

CREATE TABLE [Usuarios].[CRED]
(
	PK_CRED  		numeric(4) NOT NULL IDENTITY (1, 1),
	FK_USR			int not null,
	LOGIN			varchar(100),
	PASSW			varchar(200),
	DT_CAD			datetime
)
GO