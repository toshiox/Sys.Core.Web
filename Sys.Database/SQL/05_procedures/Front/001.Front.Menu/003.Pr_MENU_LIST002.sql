If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Front].[Pr_MENU_LIST002]'))
    exec sp_executesql N'Create Procedure[Front].[Pr_MENU_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Front].[Pr_MENU_LIST002](
	@DS_NAME varchar(100)
)
As
Begin
  SELECT [PK_MENU]
      ,[FK_GRP]
      ,[DS_NAME]
      ,[DS_ICON]
      ,[DS_ROUTE]
      ,[DT_CAD]
  FROM [dbSyS].[Front].[MENU]
  WHERE [DS_NAME] = @DS_NAME
End;
GO

