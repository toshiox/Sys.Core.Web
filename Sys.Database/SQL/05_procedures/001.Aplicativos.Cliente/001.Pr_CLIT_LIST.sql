If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLIT_LIST]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLIT_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLIT_LIST]
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
End;
GO

GRANT EXECUTE ON [Aplicativos].[Pr_CLIT_LIST] TO SYSSWS;