USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Aplicativos].[CLIT]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Aplicativos].[CLIT]
GO

CREATE TABLE [Aplicativos].[CLIT]
(
	[PK_APP]	numeric(4) NOT NULL IDENTITY (1, 1),
	[UNIQ_KEY]	varchar(50) NOT NULL,
	[NOME]		varchar(50) NOT NULL,
	[DESC]		varchar(50) NOT NULL,
	[ATV]		bit,
	[DT_CAD]	datetime NOT NULL,
	[DT_EXC]	datetime
)
GO
