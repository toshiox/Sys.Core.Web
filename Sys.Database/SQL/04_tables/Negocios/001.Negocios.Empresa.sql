USE [dbSyS]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Negocios].[EMPR]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	DROP TABLE [Negocios].[EMPR]
GO

CREATE TABLE [Negocios].[EMPR]
(
	PK_EMPR			numeric(4) NOT NULL IDENTITY (1, 1),
	NOME_FATS		varchar(200),
	RAZ_SOC			varchar(200),
	CNPJ			varchar(20),
	CCM				varchar(20),
	OCUP_PRIN		varchar(300),
	ATIV_PRIN		varchar(300),
	END_LOG			varchar(100),	
	END_NUM			varchar(20),	
	END_BAR			varchar(100),	
	END_MUN			varchar(100),	
	END_UF			varchar(10),	
	END_CEP			varchar(10),	
	DT_CAD			datetime
)
GO