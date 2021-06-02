If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_CRED_LIST001]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_CRED_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_CRED_LIST001](
    @FK_USR int
)
As
Begin
 SELECT  
        [PK_CRED]
        ,[FK_USR]
        ,[LOGIN]
        ,[PASSW]
        ,[DT_CAD]
  FROM 
        [dbSyS].[Usuarios].[CRED]
  WHERE
        [FK_USR] = @FK_USR
End;
GO

