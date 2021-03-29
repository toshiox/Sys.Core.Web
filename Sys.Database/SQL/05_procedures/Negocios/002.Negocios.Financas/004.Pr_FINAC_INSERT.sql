If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_FINAC_INSERT]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_FINAC_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_FINAC_INSERT](
    @FK_EMPR    int,
    @FK_TYPFLX  int,
    @DESC_VLR   varchar(300),
    @VLR        float,
    @MES_REF    varchar(20),
    @DT_CAD     datetime
)
As
Begin
INSERT INTO [Negocios].[FINAC]
           ([FK_EMPR]
           ,[FK_TYPFLX]
           ,[DESC_VLR]
           ,[VLR]
           ,[MES_REF]
           ,[DT_CAD])
     VALUES
           (@FK_EMPR
           ,@FK_TYPFLX
           ,@DESC_VLR
           ,@VLR     
           ,@MES_REF
           ,@DT_CAD  )

SELECT TOP 1 * FROM [Negocios].[FINAC] ORDER BY [DT_CAD] DESC
End;
GO