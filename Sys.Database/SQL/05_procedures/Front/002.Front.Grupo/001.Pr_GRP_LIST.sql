If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Front].[Pr_GRP_LIST]'))
    exec sp_executesql N'Create Procedure[Front].[Pr_GRP_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Front].[Pr_GRP_LIST]
As
Begin
  SELECT 
	[PK_GRP]
	,[DS_NAME]
	,[DS_ICON]
	,[DS_ROUTE]
	,[DT_CAD]
FROM [dbSyS].[Front].[GRP]
End;
GO

