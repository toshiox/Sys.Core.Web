If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_ACESS_LIST001]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_ACESS_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_ACESS_LIST001](
    @FK_USR int
)
As
Begin
 SELECT [PK_ACESS]
      ,[FK_USR]
      ,[FK_MENU]
      ,[DT_CAD]
  FROM [dbSyS].[Usuarios].[ACESS]
  WHERE [FK_USER] = @FK_USR
End;
GO

