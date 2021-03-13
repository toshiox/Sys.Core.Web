If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLIT_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLIT_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLIT_INSERT]
(
    @UNIQ_KEY	 varchar(50)
    ,@NOME		 varchar(50)
    ,@DESC		 varchar(50)
    ,@ATV		 bit
    ,@DT_CAD	 datetime
)
As
Begin
   INSERT INTO [Aplicativos].[CLIT]
           ([UNIQ_KEY]
           ,[NOME]
           ,[DESC]
           ,[ATV]
           ,[DT_CAD]
           ,[DT_EXC])
     VALUES
           (
            @UNIQ_KEY
           ,@NOME	
           ,@DESC	
           ,@ATV	
           ,@DT_CAD
           ,null
           )
End;
GO

