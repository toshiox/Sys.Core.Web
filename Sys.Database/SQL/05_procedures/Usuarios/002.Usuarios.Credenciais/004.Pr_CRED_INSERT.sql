If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_CRED_INSERT]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_CRED_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_CRED_INSERT](
    @FK_USR     int
    ,@LOGIN     varchar(100)
    ,@PASSW     varchar(200)
    ,@DT_CAD    datetime


)
As
Begin
    INSERT INTO [Usuarios].[CRED]
               ([FK_USR]
               ,[LOGIN]
               ,[PASSW]
               ,[DT_CAD])
         VALUES
               (@FK_USR   
                ,@LOGIN   
                ,@PASSW   
                ,@DT_CAD);

    SELECT TOP 1 * FROM [Usuarios].[CRED] ORDER BY [DT_CAD] DESC;
End;
GO

