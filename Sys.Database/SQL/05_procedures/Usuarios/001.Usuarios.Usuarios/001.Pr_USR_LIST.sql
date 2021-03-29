If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_USR_LIST]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_USR_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_USR_LIST]
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
End;
GO

