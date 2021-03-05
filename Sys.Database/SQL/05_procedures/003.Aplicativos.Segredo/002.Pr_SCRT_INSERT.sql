If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCRT_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCRT_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCRT_INSERT]
(
     @Name  	     varchar(50)
    ,@Desc		     varchar(100)
    ,@DataRegister	 datetime
)
As
Begin
 
 INSERT INTO [Aplicativos].[SCOPES]
           ([NOME]
           ,[DESCR]
           ,[DT_CAD])
     VALUES
           (@Name
           ,@Desc
           ,@DataRegister)
End;
GO