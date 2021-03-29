If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_CRED_DELETE]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_CRED_DELETE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_CRED_DELETE](
     @FK_USR     int
)
As
Begin
    DELETE FROM [Usuarios].[CRED]
    WHERE [FK_USR]    =   @FK_USR
End;
GO

