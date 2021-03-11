If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCRT_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCRT_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCRT_INSERT]
(
     @UNIQ_KEY  	 varchar(50)
    ,@SCRT		     varchar(100)
    ,@DT_CAD	 datetime
)
As
Begin
 
 INSERT INTO [Aplicativos].[SCRT]
           (FK_APP
           ,SCRT
           ,[DT_CAD])
     VALUES
           (@UNIQ_KEY
           ,@SCRT
           ,@DT_CAD)
End;
GO