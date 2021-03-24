If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_TAX_LIST001]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_TAX_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_TAX_LIST001](
    @FK_EMPR int
)
As
Begin
   SELECT [PK_TAX]
      ,[FK_EMPR]
      ,[ISS]
      ,[IRRF]
      ,[PIS]
      ,[COFINS]
      ,[CSLL]
      ,[INSS]
      ,[ALIQSMP]
      ,[DT_CAD]
  FROM [dbSyS].[Negocios].[TAX]
  WHERE [FK_EMPR] = @FK_EMPR
End;

