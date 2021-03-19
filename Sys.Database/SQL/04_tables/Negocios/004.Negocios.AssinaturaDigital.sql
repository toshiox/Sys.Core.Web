USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Negocios].[ASSDIG]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Negocios].[ASSDIG]
GO

CREATE TABLE [Negocios].[ASSDIG]
(
	PK_ASSDIG		numeric(4) NOT NULL IDENTITY (1, 1),
	FK_EMPR			int not null,
	ASSDIG			varchar(300),
	DT_CAD			datetime
)
GO