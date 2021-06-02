If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Front].[Pr_GRP_LIST001]'))
    exec sp_executesql N'Create Procedure[Front].[Pr_GRP_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Front].[Pr_GRP_LIST001](
	@PK_GRP int
)
As
Begin
	SELECT 
		[PK_GRP]
		,[DS_NAME]
		,[DS_ICON]
		,[DS_ROUTE]
		,[DT_CAD]
	FROM [dbSyS].[Front].[GRP]
	WHERE [PK_GRP] = @PK_GRP
End;
GO

