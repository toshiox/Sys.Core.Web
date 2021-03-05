If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_GRANTYPE_LIST002]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_GRANTYPE_LIST002] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_GRANTYPE_LIST002](
    @GRANTYPE varchar(50)
)
As
Begin
    SELECT 
         [PK_GRANTYPE]
        ,[GRANTYPE]
        ,[DT_CAD]
    FROM [dbSyS].[Aplicativos].[GRANTYPE]
    WHERE [GRANTYPE] = @GRANTYPE
End;
GO

