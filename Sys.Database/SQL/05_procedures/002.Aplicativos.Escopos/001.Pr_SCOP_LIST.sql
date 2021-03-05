If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCOP_LIST]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCOP_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCOP_LIST]
As
Begin
    SELECT 
       [PK_SCOP]
      ,[NOME]
      ,[DESCR]
      ,[DT_CAD]
  FROM [Aplicativos].[SCOPES]
End;
GO

