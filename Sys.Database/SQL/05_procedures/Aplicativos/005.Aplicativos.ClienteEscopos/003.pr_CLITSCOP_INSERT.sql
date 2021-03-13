If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLITSCOPES_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLITSCOPES_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLITSCOPES_INSERT]
(
     @FK_APP      	 varchar(50)
    ,@FK_SCOP        int 
    ,@DataRegister	 datetime
)
As
Begin
 
INSERT INTO [Aplicativos].[CLITSCOPES]
           ([FK_APP]
           ,[FK_SCOP]
           ,[DT_CAD])
     VALUES
           (@FK_APP
           ,@FK_SCOP
           ,@DataRegister)
End;
GO