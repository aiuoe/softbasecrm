<#
It is necessary to have installer the following tools:
- https://nodejs.org/
- https://angular.io/cli
- https://gulpjs.com/docs/en/getting-started/quick-start/
- https://classic.yarnpkg.com/lang/en/docs/install/#windows-stable
#>

$projectWorkspace = pwd
$projectWorkspaceBackend = "$projectWorkspace\aspnet-core"
$projectWorkspaceFrontend = "$projectWorkspace\angular"
$sourceBackendRoot = "$projectWorkspaceBackend\src\SBCRM.Web.Host\bin\Release\net5.0\publish"
$sourceBackendRootAll = "$sourceBackendRoot\*"
$destinationFrontendFolder = "crm-prod"
$destinationBackendFolder = "crm-prod-api"
$destinationBackendRoot = "C:\CRMFiles\$destinationBackendFolder\"
$sourceFrontendRoot = "$projectWorkspaceFrontend\dist"
$destinationFrontendRoot = "C:\CRMFiles\$destinationFrontendFolder\"
$connectionString = "Server=;Database=;User Id=;Password=;MultipleActiveResultSets=True;"


Write-Output "-----------------------------------------------------"
Write-Output "01. Build backend"
Write-Output "-----------------------------------------------------"

cd $projectWorkspace
dotnet build aspnet-core\SBCRM.Web.sln


Write-Output "-----------------------------------------------------"
Write-Output "02. Publish backend"
Write-Output "-----------------------------------------------------"

dotnet publish -c Release aspnet-core\SBCRM.Web.sln --no-restore

$jsonFile = "$sourceBackendRoot\appsettings.Production.json"
$json = Get-Content $jsonFile | ConvertFrom-Json
$json.ConnectionStrings.Default=$connectionString
$json | ConvertTo-Json | Out-File $jsonFile
Write-Output $jsonFile


Write-Output "-----------------------------------------------------"
Write-Output "04. Update Backend published files in IIS"
Write-Output "-----------------------------------------------------"

If(!(test-path $destinationBackendRoot))
{
      New-Item -ItemType Directory -Force -Path $destinationBackendRoot
}

Copy-Item -Path $sourceBackendRootAll -Destination $destinationBackendRoot -Force -Recurse



Write-Output "-----------------------------------------------------"
Write-Output "05. Publish frontend"
Write-Output "-----------------------------------------------------"

cd $projectWorkspaceFrontend

$jsonFile = "src\assets\appconfig.production.json"
$json = Get-Content $jsonFile | ConvertFrom-Json
$json.appBaseUrl=""
$json.remoteServiceBaseUrl="/service"
$json | ConvertTo-Json | Out-File $jsonFile

yarn
gulp build
ng build --configuration production --deleteOutputPath=false
Copy-Item -Path $projectWorkspaceFrontend\web.config -Destination $sourceFrontendRoot


Write-Output "-----------------------------------------------------"
Write-Output "06. Update Frontend published files in IIS"
Write-Output "-----------------------------------------------------"

If(!(test-path $destinationFrontendRoot))
{
      New-Item -ItemType Directory -Force -Path $destinationFrontendRoot
}

Copy-Item -Path $sourceFrontendRoot\* -Destination $destinationFrontendRoot -Force -Recurse

cd $projectWorkspace


Write-Output "-----------------------------------------------------"
Write-Output "Build Complete!!"
Write-Output "-----------------------------------------------------"

pause