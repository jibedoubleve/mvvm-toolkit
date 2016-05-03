param(
    $configFile = "config.xml",
    #=============#
    # Versionning #
    #=============#
    [Parameter(Mandatory=$true)]
    $v,
    $file = "Version.template.txt",
    $destination = "..\src\Version.cs",
    $pattern = "<VERSION>",
    #====================#
    # Compilation params #
    #====================#
    $msbuild = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe",
    $buildProfile = "RELEASE",
    $sln = "..\src\Probel.Mvvm.sln",
    #=======#
    # Nuget #
    #=======#
    $nuget = ".\nuget.exe",
    [Parameter(Mandatory=$true)]
    $project    
)
<# ===========================================================
 # Definition of the functions
 =========================================================== #>

function Replace-Version
{
    $version = Build-Version  
    echo "Version: $version" 
    $content = Get-Content $file
    $content = $content.Replace($pattern, $version)
    $content | Set-Content $destination -Encoding UTF8
}

function Compile-Solution
{
    $cmdargs = @("$sln", "/p:Configuration=$buildProfile")
    & $msbuild $cmdargs
}

function Build-NugetPackage
{
    if($project -eq "toolkit") 
    {
        echo "Bulding TOOLKIT nuget package"
        $prj = "..\src\Probel.Mvvm.Toolkit\Probel.Mvvm.Toolkit.csproj"
    }
    elseif($project -eq "gui")
    {
        echo "Building the GUI nuget package"
        $prj = "..\src\Probel.Mvvm.Gui\Probel.Mvvm.Gui.csproj"
    }
    else
    {
        "Unknown profile: $profile"
        return 
    }
   
    & $nuget pack $prj -Build -Properties Configuration=Release
}

function Push-NugetPackage
{
    $key = Get-ApiKey
    echo "ApiKey: $key"
        
    & $nuget push "*.nupkg" $key
}

function Clear-Build
{
    echo "removing all '.nupkg' files..."
    Remove-Item *.nupkg
}

<# ===========================================================
 # Helpers and tools
 ===========================================================#>
function Get-ApiKey
{
    [Xml]$fileContent = Get-Content $configFile  
    return $fileContent.configuration.apikey
}
function Build-Version
{	
    $date = Get-Date    

    $day = $date.Day + 10	
    $month = $date.Month + 10
    $v = "$v.{0}.{1:00}{2:00}" -f $date.Year, $month, $day
    return [String] $v
}
function Echo-Title([string] $message)
{
    Write-Host
    Write-Host "===========================================" -ForegroundColor Yellow
    Write-Host $message                                      -ForegroundColor Yellow
    Write-Host "===========================================" -ForegroundColor Yellow
    Write-Host
}
<# ===========================================================
 # Main entry point
 =========================================================== #>
clear


Echo-Title "Updating the version of the package"        
Replace-Version

#Echo-Title "Compiling the solution"                     
#Compile-Solution

Echo-Title "Bulding Nuget package"                      
Build-NugetPackage

Echo-Title "Pushing the Nuget package"                  
Push-NugetPackage

Echo-Title "Clearing..."
Clear-Build

Echo-Title "Build done..."