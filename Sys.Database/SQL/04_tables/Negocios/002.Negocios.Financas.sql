USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Negocios].[FINAC]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Negocios].[FINAC]
GO

CREATE TABLE [Negocios].[FINAC]
(
	PK_FINAC		numeric(4) NOT NULL IDENTITY (1, 1),
	FK_EMPR			int not null,
	FK_TYPFLX		int not null,
	DESC_VLR		varchar(300),
	VLR				float,
	DT_CAD			datetime
)
GO