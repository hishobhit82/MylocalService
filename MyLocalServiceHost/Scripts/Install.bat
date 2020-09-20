@ECHO off
sc query "MyLocalService" | findstr "FAILED"

if %ERRORLEVEL%==0 (
	@ECHO Installing Service...
	"C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" -i "F:\HomeDeploy\MyLocalService\bin\MyLocalServiceHost.exe"
	@ECHO Install Done.
)

@ECHO Registering url with the port
netsh http add urlacl url=http://+:8081/MyLocalService user=DESKTOP\hisho
@ECHO url reservation complete
@pause