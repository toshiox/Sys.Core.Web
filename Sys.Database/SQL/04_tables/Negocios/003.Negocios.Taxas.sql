USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Negocios].[TAX]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Negocios].[TAX]
GO

CREATE TABLE [Negocios].[TAX]
(
	PK_TAX		numeric(4) NOT NULL IDENTITY (1, 1),
	FK_EMPR		int not null,
	ISS			float,
	IRRF		float,
	PIS			float,
	COFINS		float,
	CSLL		float,
	INSS		float,
	ALIQSMP		float,
	DT_CAD		datetime
)
GO