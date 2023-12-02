cd src
del ..\..\WhenTheVersion\Packages\Titanium.Web.Proxy.PieroViano.*
rmdir /s /q %userprofile%\.nuget\Packages\Titanium.Web.Proxy.PieroViano
MSBuild.exe Titanium.Web.Proxy.sln -t:restore -p:RestorePackagesConfig=true
MSBuild.exe Titanium.Web.Proxy.sln -m /property:Configuration=%Configuration% 
copy "Titanium.Web.Proxy\bin\%Configuration%\Titanium.Web.Proxy.PieroViano.*.nupkg" ..\..\WhenTheVersion\Packages\
git push
git add -A
git commit -a --allow-empty-message -m ''
git push
cd ..\
