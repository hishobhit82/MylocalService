for /F "tokens=3 delims=: " %%H in ('sc query "MyLocalService" ^| findstr "        STATE"') do (
  if /I "%%H"=="RUNNING" (
  @ECHO Stopping Service...
   net stop "MyLocalService"
  )
)

xcopy /E /Y "C:\Users\hisho\source\repos\MyLocalServiceHost\bin\Debug" "E:\HomeDeploy\MyLocalService\bin"