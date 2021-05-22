If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Usuarios].[Pr_ACESS_INSERT]'))
    exec sp_executesql N'Create Procedure[Usuarios].[Pr_ACESS_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Usuarios].[Pr_ACESS_INSERT](
    @FK_USR int,
    @FK_MENU int,
    @DT_CAD datetime
)
As
Begin

INSERT INTO [Usuarios].[ACESS]
           ([FK_USR]
           ,[FK_MENU]
           ,[DT_CAD])
     VALUES
           (@FK_USR
           ,@FK_MENU
           ,@DT_CAD)

SELECT TOP 1 * FROM [Usuarios].[ACESS] ORDER BY [DT_CAD] DESC;

End;
GO

