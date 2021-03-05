If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCOP_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCOP_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCOP_INSERT]
(
    @NOME	     varchar(100)
    ,@DESC		 varchar(100)
    ,@DT_CAD	 datetime
)
As
Begin
 
INSERT INTO [Aplicativos].[SCOPES]
           ([NOME]
           ,[DESCR]
           ,[DT_CAD])
     VALUES
           (@NOME
           ,@DESC
           ,@DT_CAD)
End;
GO