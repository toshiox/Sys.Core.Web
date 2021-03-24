If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_TAX_INSERT]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_TAX_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_TAX_INSERT](
     @FK_EMPR       int
    ,@ISS           float
    ,@IRRF          float
    ,@PIS           float
    ,@COFINS        float
    ,@CSLL          float
    ,@INSS          float
    ,@ALIQSMP       float
    ,@DT_CAD        datetime
)
As
Begin
    INSERT INTO [Negocios].[TAX]
               ([FK_EMPR]
               ,[ISS]
               ,[IRRF]
               ,[PIS]
               ,[COFINS]
               ,[CSLL]
               ,[INSS]
               ,[ALIQSMP]
               ,[DT_CAD]  )
         VALUES
               (@FK_EMPR     
               ,  @ISS       
               ,  @IRRF      
               ,  @PIS       
               ,  @COFINS    
               ,  @CSLL      
               ,  @INSS      
               ,  @ALIQSMP   
               ,  @DT_CAD)

    Select * from [Negocios].[TAX] order by PK_TAX DESC
End;

