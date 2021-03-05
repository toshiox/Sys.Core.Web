If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCRT_LIST]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCRT_LIST] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCRT_LIST]
As
Begin
    SELECT 
       [PK_SCRT]
      ,[FK_APP]
      ,[SCRT]
      ,[DT_CAD]
    FROM [dbSyS].[Aplicativos].[SCRT]
End;
GO

