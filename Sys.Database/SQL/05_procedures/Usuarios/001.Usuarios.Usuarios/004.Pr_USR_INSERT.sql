If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_USR_INSERT]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_USR_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_USR_INSERT](
     @UNIQKEY   varchar(100)
    ,@NAME      varchar(400)
    ,@CPF       varchar(14)
    ,@GEN       varchar(10)
    ,@DT_NAS    datetime
    ,@DT_CAD    datetime

)
As
Begin
    INSERT INTO [Usuarios].[USR]
               ([UNIQKEY]
               ,[NAME]
               ,[CPF]
               ,[GEN]
               ,[DT_NAS]
               ,[DT_CAD])
         VALUES
               (@UNIQKEY
                ,@NAME   
                ,@CPF    
                ,@GEN    
                ,@DT_NAS 
                ,@DT_CAD)

    SELECT TOP 1 * FROM [Usuarios].[USR] ORDER BY [DT_CAD] DESC;
End;
GO

