If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_FINAC_LIST]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_FINAC_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_FINAC_LIST]
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
End;
GO

