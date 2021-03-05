If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCOP_LIST001]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCOP_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCOP_LIST001](
    @NOME varchar(100)
)
As
Begin
   SELECT 
       [PK_SCOP]
      ,[NOME]
      ,[DESCR]
      ,[DT_CAD]
  FROM [Aplicativos].[SCOPES]
  WHERE [NOME] = @NOME
End;
GO

