If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Aplicativos].[Pr_EMPR_INSERT]'))
    exec sp_executesql N'Create Procedure[Aplicativos].[Pr_EMPR_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Aplicativos].[Pr_EMPR_INSERT]
(
    @NOME_FATS       varchar(200)
   ,@RAZ_SOC        varchar(200)
   ,@CNPJ           varchar(20)
   ,@CCM            varchar(20)
   ,@OCUP_PRIN      varchar(300)
   ,@ATIV_PRIN      varchar(300)
   ,@END_LOG        varchar(100)
   ,@END_NUM        varchar(20)
   ,@END_BAR        varchar(100)
   ,@END_MUN        varchar(100)
   ,@END_UF         varchar(10)
   ,@END_CEP        varchar(10)
   ,@DT_CAD		    datetime
)
As
Begin
 
UPDATE [Negocios].[EMPR]
SET
     [NOME_FATS]     =       @NOME_FATS  
    ,[RAZ_SOC]      =       @RAZ_SOC    
    ,[CCM]          =       @CCM        
    ,[OCUP_PRIN]    =       @OCUP_PRIN  
    ,[ATIV_PRIN]    =       @ATIV_PRIN  
    ,[END_LOG]      =       @END_LOG    
    ,[END_NUM]      =       @END_NUM    
    ,[END_BAR]      =       @END_BAR    
    ,[END_MUN]      =       @END_MUN    
    ,[END_UF]       =       @END_UF     
    ,[END_CEP]      =       @END_CEP    
    ,[DT_CAD]       =       @DT_CAD		
WHERE
    [CNPJ]  =   @CNPJ
End;
GO