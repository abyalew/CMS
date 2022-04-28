$projectPath = get-location;

.\nuget.exe restore CMS.sln

SqlLocalDb create "CMSInstance"

cd "C:\Program Files (x86)\MSBuild\12.0\Bin\amd64"

.\MSBuild.exe $projectPath"\CMS.sln" /property:Configuration=Release

cd "C:\Program Files (x86)\IIS Express";

.\iisexpress /path:$projectPath"\CMS.Host"