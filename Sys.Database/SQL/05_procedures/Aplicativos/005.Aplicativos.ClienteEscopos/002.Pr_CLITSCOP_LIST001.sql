If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLITSCOP_LIST001]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLITSCOP_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLITSCOP_LIST001](
    @FK_APP varchar(50)
)
As
Begin
    SELECT 
       [PK_CLITSCOP]
      ,[FK_APP]
      ,[FK_SCOP]
      ,[DT_CAD]
  FROM [dbSyS].[Aplicativos].[CLITSCOPES]
  WHERE [FK_APP] = @FK_APP
End;
GO

