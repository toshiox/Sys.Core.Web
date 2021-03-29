If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_FINAC_LIST001]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_FINAC_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_FINAC_LIST001](
    @PK_FINAC int
)
As
Begin
   SELECT 
       [PK_FINAC]
      ,[FK_EMPR]
      ,[FK_TYPFLX]
      ,[DESC_VLR]
      ,[VLR]
      ,[MES_REF]
      ,[DT_CAD]
  FROM [dbSyS].[Negocios].[FINAC]
  WHERE [PK_FINAC] = @PK_FINAC
End;
GO

