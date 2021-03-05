USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Aplicativos].[SCRT]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Aplicativos].[SCRT]
GO

CREATE TABLE [Aplicativos].[SCRT]
(
	PK_SCRT  numeric(4) NOT NULL IDENTITY (1, 1),
    FK_APP   varchar(50),
    SCRT     varchar(100) NOT NULL,
    DT_CAD   datetime
)
GO
    