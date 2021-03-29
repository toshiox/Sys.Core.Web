If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_USR_LIST002]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_USR_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_USR_LIST002](
    @CPF varchar(14)
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
  WHERE [CPF] = @CPF
End;
GO

