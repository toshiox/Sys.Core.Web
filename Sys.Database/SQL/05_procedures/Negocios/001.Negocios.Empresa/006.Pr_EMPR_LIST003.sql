If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_EMPR_LIST003]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_EMPR_LIST003] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_EMPR_LIST003](
    @NOME_FATS    varchar(100) 
)
As
Begin
    SELECT [PK_EMPR]
          ,[NOME_FATS]
          ,[RAZ_SOC]
          ,[CNPJ]
          ,[CCM]
          ,[OCUP_PRIN]
          ,[ATIV_PRIN]
          ,[END_LOG]
          ,[END_NUM]
          ,[END_BAR]
          ,[END_MUN]
          ,[END_UF]
          ,[END_CEP]
          ,[DT_CAD]
    FROM [Negocios].[EMPR]
    WHERE [NOME_FATS] = @NOME_FATS
End;
GO

