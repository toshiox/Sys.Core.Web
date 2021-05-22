If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Front].[Pr_MENU_DELETE]'))
    exec sp_executesql N'Create Procedure[Front].[Pr_MENU_DELETE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Front].[Pr_MENU_DELETE](
    @PK_MENU int
)
As
Begin
    DELETE FROM [Front].[MENU]
    WHERE [PK_MENU]= @PK_MENU;
End;
GO
