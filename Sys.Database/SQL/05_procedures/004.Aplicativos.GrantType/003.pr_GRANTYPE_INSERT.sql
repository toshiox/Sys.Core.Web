If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_GRANTYPE_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_GRANTYPE_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_GRANTYPE_INSERT]
(
     @GRANTYPE  	 varchar(100)
    ,@DataRegister	 datetime
)
As
Begin
 
INSERT INTO [Aplicativos].[GRANTYPE]
           ([GRANTYPE]
           ,[DT_CAD])
     VALUES
           (@GRANTYPE
           ,@DataRegister)
End;
GO