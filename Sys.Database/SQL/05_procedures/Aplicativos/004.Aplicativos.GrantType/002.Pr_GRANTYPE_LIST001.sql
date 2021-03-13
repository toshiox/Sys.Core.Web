If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_GRANTYPE_LIST001]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_GRANTYPE_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_GRANTYPE_LIST001](
    @PK_GRANTYPE int 
)
As
Begin
    SELECT 
         [PK_GRANTYPE]
        ,[GRANTYPE]
        ,[DT_CAD]
    FROM [dbSyS].[Aplicativos].[GRANTYPE]
    WHERE [PK_GRANTYPE] = @PK_GRANTYPE
End;
GO

