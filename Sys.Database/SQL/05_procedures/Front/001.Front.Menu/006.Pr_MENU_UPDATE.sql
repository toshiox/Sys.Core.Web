If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Front].[Pr_MENU_UPDATE]'))
    exec sp_executesql N'Create Procedure[Front].[Pr_MENU_UPDATE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Front].[Pr_MENU_UPDATE](
    @PK_MENU int
	,@DS_NAME varchar(100)
    ,@DS_ICON varchar(100)
)
As
Begin
  UPDATE [Front].[MENU]
    SET
          [DS_ICON]    = @DS_NAME
          ,[DT_CAD]     = @DS_ICON
    WHERE
        [PK_MENU]= @PK_MENU;
End;
GO

