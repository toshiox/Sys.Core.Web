If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_ASSDIG_INSERT]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_ASSDIG_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_ASSDIG_INSERT](
     @FK_EMPR int
    ,@ASSDIG varchar(300)
    ,@DT_CAD datetime
)
As
Begin
 INSERT INTO [Negocios].[ASSDIG]
           ([FK_EMPR]
           ,[ASSDIG]
           ,[DT_CAD])
     VALUES
           (@FK_EMPR
           ,@ASSDIG
           ,@DT_CAD)
End;