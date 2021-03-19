If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_FINAC_LIST002]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_FINAC_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_FINAC_LIST002](
    @PK_EMPR int
)
As
Begin
   SELECT 
       [PK_FINAC]
      ,[FK_EMPR]
      ,[FK_TYPFLX]
      ,[DESC_VLR]
      ,[VLR]
      ,[DT_CAD]
  FROM [dbSyS].[Negocios].[FINAC]
  WHERE [FK_EMPR] = @PK_EMPR
End;
GO