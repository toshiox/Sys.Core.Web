If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Front].[Pr_MENU_INSERT]'))
    exec sp_executesql N'Create Procedure[Front].[Pr_MENU_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Front].[Pr_MENU_INSERT](
    @FK_GRP int
	,@DS_NAME varchar(100)
    ,@DS_ICON varchar(100)
    ,@DS_ROUTE varchar(100)
    ,@DT_CAD datetime
)
As
Begin
  INSERT INTO [Front].[MENU]
           ([FK_GRP]
           ,[DS_NAME]
           ,[DS_ICON]
           ,[DS_ROUTE]
           ,[DT_CAD])
     VALUES
           (@FK_GRP
           ,@DS_NAME
           ,@DS_ICON
           ,@DS_ROUTE
           ,@DT_CAD);

    select top 1 * from  [Front].[MENU] order by [DT_CAD] desc;
End;
GO

