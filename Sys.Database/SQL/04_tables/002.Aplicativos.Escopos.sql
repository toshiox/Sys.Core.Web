USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Aplicativos].[SCOPES]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Aplicativos].[SCOPES]
GO

CREATE TABLE [Aplicativos].[SCOPES]
(
	PK_SCOP numeric(4) NOT NULL IDENTITY (1, 1),
    NOME varchar(100) NOT NULL,
    DESCR varchar(100) NOT NULL,
    DT_CAD datetime
)
GO
