If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_CLITGRANTYPE_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_CLITGRANTYPE_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_CLITGRANTYPE_INSERT]
(
     @FK_APP      	 varchar(50)
    ,@FK_GRANTYPE       int 
    ,@DataRegister	 datetime
)
As
Begin
 
INSERT INTO [Aplicativos].[CLITGRANTYPE]
           ([FK_APP]
           ,[FK_GRANTYPE]
           ,[DT_CAD])
     VALUES
           (@FK_APP
           ,@FK_GRANTYPE
           ,@DataRegister)
End;
GO


