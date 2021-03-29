If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_USR_DELETE]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_USR_DELETE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_USR_DELETE](
     @UNIQKEY   varchar(100)
)
As
Begin
    DELETE FROM 
        [Usuarios].[USR]
    WHERE 
        [UNIQKEY] = @UNIQKEY;
End;
GO

