If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLIT_UPDATE]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLIT_UPDATE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLIT_UPDATE](
    @UNIQ_KEY varchar(50)
    ,@NOME		 varchar(10)
    ,@DESC		 varchar(50)
    ,@ATV		 bit
)
As
Begin
    UPDATE [Aplicativos].[CLIT]
        SET
            [NOME]     =   @NOME
            ,[DESC]     =   @DESC		
            ,[ATV]      =	@ATV	
    FROM    [Aplicativos].[CLIT]
    WHERE   [UNIQ_KEY]	= @UNIQ_KEY
End;
GO

GRANT EXECUTE ON [Aplicativos].[Pr_CLIT_UPDATE] TO SYSSWS;