If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_CRED_LIST]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_CRED_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_CRED_LIST]
As
Begin
 SELECT  
       [PK_CRED]
      ,[FK_USR]
      ,[LOGIN]
      ,[PASSW]
      ,[DT_CAD]
  FROM [dbSyS].[Usuarios].[CRED]
End;
GO

