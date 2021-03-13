If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_GRANTYPE_LIST]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_GRANTYPE_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_GRANTYPE_LIST]
As
Begin
    SELECT 
         [PK_GRANTYPE]
        ,[GRANTYPE]
        ,[DT_CAD]
    FROM [dbSyS].[Aplicativos].[GRANTYPE]
End;
GO

