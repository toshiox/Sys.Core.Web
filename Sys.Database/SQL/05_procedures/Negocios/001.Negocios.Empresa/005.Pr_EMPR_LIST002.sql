If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_EMPR_LIST002]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_EMPR_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_EMPR_LIST002](
    @PK_EMPR    int 
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
    WHERE [PK_EMPR] = @PK_EMPR
End;
GO

