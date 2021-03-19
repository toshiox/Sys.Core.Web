USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Negocios].[TYPFLX]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Negocios].[TYPFLX]
GO

CREATE TABLE [Negocios].[TYPFLX]
(
	PK_TYPFLX		numeric(4) NOT NULL IDENTITY (1, 1),
	FK_EMPR			int not null,
	TYPFLX			varchar(300),
	DT_CAD			datetime
)
GO