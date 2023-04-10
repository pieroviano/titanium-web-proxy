del ..\..\WhenTheVersion\Packages\Net4x.Titanium.Web.Proxy.*
rmdir /s /q %userprofile%\.nuget\Packages\Net4x.Titanium.Web.Proxy
MSBuild.exe Titanium.Web.Proxy.sln -t:restore -p:RestorePackagesConfig=true
MSBuild.exe Titanium.Web.Proxy.sln -m /property:Configuration=%Configuration% 
copy "Titanium.Web.Proxy\bin\%Configuration%\Net4x.Titanium.Web.Proxy.*.nupkg" ..\..\WhenTheVersion\Packages\
git push
git add -A
git commit -a --allow-empty-message -m ''
git push
