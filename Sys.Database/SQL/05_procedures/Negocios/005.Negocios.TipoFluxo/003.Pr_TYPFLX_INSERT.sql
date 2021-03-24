If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_TYPFLX_INSERT]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_TYPFLX_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_TYPFLX_INSERT](
    @TYPFLX varchar(300),
    @DT_CAD datetime

)
As
Begin
 INSERT INTO [Negocios].[TYPFLX]
           ([TYPFLX]
           ,[DT_CAD])
     VALUES
           (@TYPFLX
           ,@DT_CAD)

  Select * from [Negocios].[TYPFLX] order by [DT_CAD] desc
End;

