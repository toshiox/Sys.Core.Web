If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_TYPFLX_LIST001]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_TYPFLX_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_TYPFLX_LIST001](
    @PK_TYPFLX int
)
As
Begin
  SELECT 
      PK_TYPFLX	
      ,TYPFLX		
      ,DT_CAD		
  FROM [Negocios].[TYPFLX]
  WHERE PK_TYPFLX = @PK_TYPFLX
End;

