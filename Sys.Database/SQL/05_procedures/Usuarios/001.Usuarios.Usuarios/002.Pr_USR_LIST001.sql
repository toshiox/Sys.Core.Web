If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_USR_LIST001]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_USR_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_USR_LIST001](
    @PK_USR int
)
As
Begin
    SELECT
       [PK_USR]
      ,[UNIQKEY]
      ,[NAME]
      ,[CPF]
      ,[GEN]
      ,[DT_NAS]
      ,[DT_CAD]
  FROM [dbSyS].[Usuarios].[USR]
  WHERE [PK_USR] = @PK_USR
End;
GO

