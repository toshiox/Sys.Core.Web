USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Aplicativos].[CLITGRANTYPE]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Aplicativos].[CLITGRANTYPE]
GO

CREATE TABLE [Aplicativos].[CLITGRANTYPE]
(
	PK_CLITGRANTYPE numeric(4) NOT NULL IDENTITY (1, 1),
	FK_APP      varchar(50),
    FK_GRANTYPE     int not null,
    DT_CAD      datetime
)
GO