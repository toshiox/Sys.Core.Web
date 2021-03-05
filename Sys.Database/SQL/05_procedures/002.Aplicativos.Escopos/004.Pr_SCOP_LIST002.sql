If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCOP_LIST002]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCOP_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCOP_LIST002](
    @PK_SCOP int
)
As
Begin
   SELECT 
       [PK_SCOP]
      ,[NOME]
      ,[DESCR]
      ,[DT_CAD]
  FROM [Aplicativos].[SCOPES]
  WHERE [PK_SCOP] = @PK_SCOP
End;
GO

