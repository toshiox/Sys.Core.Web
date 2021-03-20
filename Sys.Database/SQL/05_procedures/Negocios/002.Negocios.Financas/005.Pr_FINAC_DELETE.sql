If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_FINAC_DELETE]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_FINAC_DELETE] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_FINAC_DELETE](
    @PK_FINAC int
)
As
Begin
  DELETE FROM [dbSyS].[Negocios].[FINAC]
  WHERE [PK_FINAC] = @PK_FINAC
End;
GO

