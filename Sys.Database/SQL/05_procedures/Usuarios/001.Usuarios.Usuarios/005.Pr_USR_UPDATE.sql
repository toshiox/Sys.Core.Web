If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_USR_UPDATE]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_USR_UPDATE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_USR_UPDATE](
     @UNIQKEY   varchar(100)
    ,@NAME      varchar(400)
    ,@CPF       varchar(14)
    ,@GEN       varchar(10)
    ,@DT_NAS    datetime
    ,@DT_CAD    datetime

)
As
Begin
    UPDATE  [Usuarios].[USR]
        SET
            [NAME]          = @NAME  
            ,[CPF]           = @CPF   
            ,[GEN]           = @GEN   
            ,[DT_NAS]        = @DT_NAS
            ,[DT_CAD]        = @DT_CAD
    WHERE 
            [UNIQKEY] = @UNIQKEY;
End;
GO

