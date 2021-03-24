If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_ASSDIG_LIST001]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_ASSDIG_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_ASSDIG_LIST001](
    @FK_EMPR int
)
As
Begin
  SELECT 
       [PK_ASSDIG]
      ,[FK_EMPR]
      ,[ASSDIG]
      ,[DT_CAD]
  FROM [Negocios].[ASSDIG]
  WHERE [FK_EMPR] = @FK_EMPR
End;