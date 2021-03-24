If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_TYPFLX_LIST002]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_TYPFLX_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_TYPFLX_LIST002](
    @TYPFLX varchar(300)
)
As
Begin
  SELECT 
      PK_TYPFLX	
      ,TYPFLX		
      ,DT_CAD		
  FROM [Negocios].[TYPFLX]
  WHERE TYPFLX = @TYPFLX
End;

