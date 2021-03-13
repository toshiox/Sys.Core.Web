If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_SCRT_LIST001]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_SCRT_LIST001] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_SCRT_LIST001](
    @UNIQ_KEY varchar(100)
)
As
Begin
    SELECT 
       [PK_SCRT]
      ,[FK_APP]
      ,[SCRT]
      ,[DT_CAD]
    FROM [dbSyS].[Aplicativos].[SCRT]
    WHERE   [FK_APP]	= @UNIQ_KEY
End;
GO

