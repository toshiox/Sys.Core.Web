If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLIT_DELETE]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLIT_DELETE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLIT_DELETE](
    @UNIQ_KEY varchar(50)
)
As
Begin
    DELETE FROM [Aplicativos].[CLIT]
    WHERE  [UNIQ_KEY]	= @UNIQ_KEY
End;
GO

GRANT EXECUTE ON [Aplicativos].[Pr_CLIT_DELETE] TO SYSSWS;