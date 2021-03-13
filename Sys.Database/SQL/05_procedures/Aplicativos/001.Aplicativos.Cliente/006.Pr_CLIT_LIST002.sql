If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLIT_LIST002]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLIT_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLIT_LIST002](
    @UNIQ_KEY varchar(100)
)
As
Begin
    SELECT  
             [PK_APP]	
            ,[UNIQ_KEY]	
            ,[NOME]		
            ,[DESC]		
            ,[ATV]		
            ,[DT_CAD]	
            ,[DT_EXC]	
    FROM    [Aplicativos].[CLIT]
    WHERE   [UNIQ_KEY]	= @UNIQ_KEY
End;
GO
