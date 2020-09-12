for /F "tokens=3 delims=: " %%H in ('sc query "MyLocalService" ^| findstr "        STATE"') do (
  if /I "%%H"=="RUNNING" (
  @ECHO Stopping Service...
   net stop "MyLocalService"
  )
)

xcopy /E /Y "F:\CSharpProjects\MyLocalService\MyLocalServiceHost\bin\Debug\" "F:\HomeDeploy\MyLocalService\bin"