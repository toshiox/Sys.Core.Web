﻿USE master;  
GO  

CREATE LOGIN SYSSWS
    WITH PASSWORD = '8$2e_f3d$9f51_088e@57960$850.4be!1f_X',
    DEFAULT_DATABASE=dbSyS;
    
USE dbSyS;
GO

CREATE USER SYSSWS
    FOR LOGIN SYSSWS
        
GRANT CONNECT TO SYSSWS

exec sp_addrolemember 'db_owner', 'SYSSWS';