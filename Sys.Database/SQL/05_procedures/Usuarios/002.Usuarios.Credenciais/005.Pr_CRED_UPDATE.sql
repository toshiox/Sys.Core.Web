If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_CRED_UPDATE]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_CRED_UPDATE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_CRED_UPDATE](
     @FK_USR     int
    ,@LOGIN     varchar(100)
    ,@PASSW     varchar(200)
)
As
Begin
    UPDATE [Usuarios].[CRED]
    SET
        [LOGIN]     =   @LOGIN 
        ,[PASSW]    =   @PASSW 
    WHERE 
        [FK_USR]    =   @FK_USR
End;
GO

