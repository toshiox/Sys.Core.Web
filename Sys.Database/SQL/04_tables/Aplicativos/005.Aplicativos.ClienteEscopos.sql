USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Aplicativos].[CLITSCOPES]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Aplicativos].[CLITSCOPES]
GO

CREATE TABLE [Aplicativos].[CLITSCOPES]
(
	PK_CLITSCOP numeric(4) NOT NULL IDENTITY (1, 1),
	FK_APP      varchar(50),
    FK_SCOP     int not null,
    DT_CAD      datetime
)
GO
