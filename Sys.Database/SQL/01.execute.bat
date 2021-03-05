Set Database=dbSyS
Set Server=(localdb)\MSSQLLocalDB
Set Program=sqlcmd 
Set User=SYSSWS
Set Password="8$2e_f3d$9f51_088e@57960$850.4be!1f_X"

Echo ***************************************************
Echo Table
Echo ***************************************************

cd 04_tables
 
For %%A In (*.sql) Do ( 
    echo %%A 
REM %Program% -S %Server% -d %Database% -U %User% -P %Password% -i %%A -o Log\%%A.log 

)
pause
