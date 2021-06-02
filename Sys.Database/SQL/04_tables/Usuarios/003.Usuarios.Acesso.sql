USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Usuarios].[ACESS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Usuarios].[ACESS]
GO

CREATE TABLE [Usuarios].[ACESS]
(
	PK_ACESS  		numeric(4) NOT NULL IDENTITY (1, 1),
	FK_USR			int not null,
	FK_MENU			int not null,
	DT_CAD			datetime
)
GO