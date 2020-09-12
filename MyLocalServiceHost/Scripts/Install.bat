@ECHO off
sc query "MyLocalService" | findstr "FAILED"

if %ERRORLEVEL%==0 (
	@ECHO Installing Service...
	"C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" -i "E:\HomeDeploy\MyLocalService\bin\MyLocalServiceHost.exe"
	@ECHO Install Done.
)

@ECHO Registering url with the port
netsh http add urlacl url=http://+:8080/Service user=DESKTOP\hi.shobhit76@gmail.com
@ECHO url reservation complete
@pause