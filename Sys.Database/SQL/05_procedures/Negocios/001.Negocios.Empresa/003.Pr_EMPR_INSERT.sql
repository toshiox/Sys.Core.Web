If Not Exists (SELECT 'S' FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID('[Negocios].[Pr_EMPR_INSERT]'))
    exec sp_executesql N'Create Procedure[Negocios].[Pr_EMPR_INSERT] As Begin SET NOCOUNT ON; End'
GO
--*
Alter Procedure [Negocios].[Pr_EMPR_INSERT]
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
 
INSERT INTO [Negocios].[EMPR]
           ([NOME_FATS]
           ,[RAZ_SOC]
           ,[CNPJ]
           ,[CCM]
           ,[OCUP_PRIN]
           ,[ATIV_PRIN]
           ,[END_LOG]
           ,[END_NUM]
           ,[END_BAR]
           ,[END_MUN]
           ,[END_UF]
           ,[END_CEP]
           ,[DT_CAD])
     VALUES
           (
           @NOME_FATS   
           ,@RAZ_SOC    
           ,@CNPJ       
           ,@CCM        
           ,@OCUP_PRIN  
           ,@ATIV_PRIN  
           ,@END_LOG    
           ,@END_NUM    
           ,@END_BAR    
           ,@END_MUN    
           ,@END_UF     
           ,@END_CEP    
           ,@DT_CAD		
           );
    SELECT * FROM [Negocios].[EMPR] WHERE [CNPJ] = @CNPJ;
End;
GO