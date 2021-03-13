USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Aplicativos].[GRANTYPE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Aplicativos].[GRANTYPE]
GO

CREATE TABLE [Aplicativos].[GRANTYPE]
(
	PK_GRANTYPE  numeric(4) NOT NULL IDENTITY (1, 1),
    GRANTYPE     varchar(100) NOT NULL,
    DT_CAD       datetime
)
GO
