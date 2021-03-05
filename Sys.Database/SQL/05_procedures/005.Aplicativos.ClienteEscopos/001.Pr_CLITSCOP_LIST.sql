If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLITSCOP_LIST]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLITSCOP_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLITSCOP_LIST]
As
Begin
    SELECT 
       [PK_CLITSCOP]
      ,[FK_APP]
      ,[FK_SCOP]
      ,[DT_CAD]
  FROM [dbSyS].[Aplicativos].[CLITSCOPES]
End;
GO

