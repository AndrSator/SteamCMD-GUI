<#
.SYNOPSIS
    Builds SteamCMD GUI and packages releases.

.DESCRIPTION
    Needs nothing installed: it uses the MSBuild and VB compiler that ship with
    Windows (.NET Framework 4.x) plus Microsoft's reference assemblies, which are
    downloaded once from nuget.org into .tools\ and checked against a pinned hash.

.PARAMETER Task
    Build       Incremental build (default).
    Rebuild     Clean build.
    Clean       Remove build output, dist\ included. Keeps the .tools\ cache.
    Run         Build and start the program.
    Package     Release rebuild, then create dist\SteamCMD.GUI.zip for publishing.
    SetVersion  Write -Version into AssemblyInfo.vb.

.EXAMPLE
    .\build.ps1
    .\build.ps1 Build -Configuration Release
    .\build.ps1 Run
    .\build.ps1 SetVersion -Version 3.2.0.0
    .\build.ps1 Package
#>
[CmdletBinding()]
param(
    [Parameter(Position = 0)]
    [ValidateSet('Build', 'Rebuild', 'Clean', 'Run', 'Package', 'SetVersion')]
    [string]$Task = 'Build',

    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Debug',

    [ValidatePattern('^\d+\.\d+\.\d+\.\d+$')]
    [string]$Version
)

Set-StrictMode -Version 2
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'

$Root         = $PSScriptRoot
$ProjectDir   = Join-Path $Root 'Source\SteamCMD GUI'
$Project      = Join-Path $ProjectDir 'SteamCMD GUI.vbproj'
$AssemblyInfo = Join-Path $ProjectDir 'My Project\AssemblyInfo.vb'
$Changelog    = Join-Path $Root 'Documentation\Changelog.md'
$ToolsDir     = Join-Path $Root '.tools'
$DistDir      = Join-Path $Root 'dist'
$MSBuild      = Join-Path $env:WINDIR 'Microsoft.NET\Framework\v4.0.30319\MSBuild.exe'

# SHA512 values come from the nuget.org catalog entry of each package (version 1.0.3).
$ReferencePackages = @{
    'v4.0' = @{
        Id     = 'microsoft.netframework.referenceassemblies.net40'
        Sha512 = 'BD45E6C0FC62EE56350C49B19EB9EF7BF6B826037F6755C4E916A8CDC9A5AAB7F6399C6CF6C99705BDD0F72D9D6769423ED54CC990513388D03C15F3D38227A5'
    }
    'v4.8' = @{
        Id     = 'microsoft.netframework.referenceassemblies.net48'
        Sha512 = '5D62A0C9E35A74D71341A215BD007C06B74236B11AAFA7E8FDD7B539D41167D1C5CB48DC05268CF08579ABAE196A6A6C4A70BC0254EC002686654BA8170E3544'
    }
}

function Get-ProjectProperty([string]$Name) {
    $xml = [xml](Get-Content -LiteralPath $Project -Raw -Encoding UTF8)
    $node = $xml.GetElementsByTagName($Name) | Select-Object -First 1
    if ($node) { $node.InnerText.Trim() } else { '' }
}

# Returns the folder to use as TargetFrameworkRootPath, downloading it on first use.
function Get-ReferenceAssemblies([string]$Framework) {
    $package = $ReferencePackages[$Framework]
    if (-not $package) {
        throw "No reference assemblies configured for .NET Framework $Framework; add its package to `$ReferencePackages in build.ps1."
    }

    $target = Join-Path $ToolsDir $package.Id
    if (Test-Path -LiteralPath $target) { return Join-Path $target 'build' }

    New-Item -ItemType Directory -Force $ToolsDir | Out-Null
    $archive = "$target.nupkg"
    $partial = "$target.partial"
    Write-Host "Downloading $($package.Id)..."
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    Invoke-WebRequest -UseBasicParsing -OutFile $archive `
        -Uri "https://api.nuget.org/v3-flatcontainer/$($package.Id)/1.0.3/$($package.Id).1.0.3.nupkg"

    $hash = (Get-FileHash -LiteralPath $archive -Algorithm SHA512).Hash
    if ($hash -ne $package.Sha512) {
        Remove-Item -LiteralPath $archive
        throw "Hash mismatch for $($package.Id): got $hash."
    }

    if (Test-Path -LiteralPath $partial) { Remove-Item -LiteralPath $partial -Recurse -Force }
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $zip = [IO.Compression.ZipFile]::OpenRead($archive)
    try {
        foreach ($entry in $zip.Entries) {
            # Skip the IntelliSense docs (most of the package); the RedistList is required.
            $wanted = $entry.FullName -like 'build/*.dll' -or $entry.FullName -like 'build/*/RedistList/*.xml'
            if (-not $wanted) { continue }
            $file = Join-Path $partial $entry.FullName
            New-Item -ItemType Directory -Force (Split-Path $file) | Out-Null
            [IO.Compression.ZipFileExtensions]::ExtractToFile($entry, $file)
        }
    } finally {
        $zip.Dispose()
    }
    # Renamed last, so an interrupted extraction is never mistaken for a complete one.
    Move-Item -LiteralPath $partial -Destination $target
    Remove-Item -LiteralPath $archive
    Join-Path $target 'build'
}

function Invoke-MSBuild([string]$Target, [string]$Config) {
    if (-not (Test-Path -LiteralPath $MSBuild)) { throw "MSBuild not found at $MSBuild." }

    $framework = Get-ProjectProperty 'TargetFrameworkVersion'
    $profileName = Get-ProjectProperty 'TargetFrameworkProfile'
    $references = Get-ReferenceAssemblies $framework
    $sdkPath = Join-Path $references ".NETFramework\$framework"
    if ($profileName) { $sdkPath = Join-Path $sdkPath "Profile\$profileName" }

    # vbc takes mscorlib from FrameworkPathOverride, not from TargetFrameworkRootPath.
    # Without it the 4.8 runtime mscorlib is used and the build fails with BC30002/BC30560.
    & $MSBuild $Project /nologo /verbosity:minimal "/target:$Target" `
        "/property:Configuration=$Config" '/property:Platform=x86' `
        "/property:TargetFrameworkRootPath=$references" `
        "/property:FrameworkPathOverride=$sdkPath" | Out-Host
    if ($LASTEXITCODE -ne 0) { throw "MSBuild failed (exit code $LASTEXITCODE)." }
}

function Get-OutputExe([string]$Config) {
    Join-Path $ProjectDir "bin\$Config\SteamCMD GUI.exe"
}

function Get-AssemblyVersion {
    $text = [IO.File]::ReadAllText($AssemblyInfo)
    $match = [regex]::Match($text, 'AssemblyFileVersion\("([\d.]+)"\)')
    if (-not $match.Success) { throw "AssemblyFileVersion not found in $AssemblyInfo." }
    $match.Groups[1].Value
}

function Set-AssemblyVersion([string]$NewVersion) {
    $text = [IO.File]::ReadAllText($AssemblyInfo)
    $text = [regex]::Replace($text, '(Assembly(?:File)?Version\(")[\d.]+("\))', "`${1}$NewVersion`${2}")
    [IO.File]::WriteAllText($AssemblyInfo, $text, (New-Object Text.UTF8Encoding $true))
}

function New-Package {
    $current = Get-AssemblyVersion
    $notes = [IO.File]::ReadAllText($Changelog)
    if ($notes -notmatch "(?m)^## $([regex]::Escape($current))\s*$") {
        throw "Documentation\Changelog.md has no '## $current' section."
    }

    Invoke-MSBuild 'Rebuild' 'Release'
    $exe = Get-OutputExe 'Release'
    $built = (Get-Item -LiteralPath $exe).VersionInfo.FileVersion
    if ($built -ne $current) { throw "Built exe is $built but AssemblyInfo.vb says $current." }

    # Names the About window looks for next to the exe; Packaging\ is copied as is.
    $files = @(
        @{ Source = $exe; Entry = 'SteamCMD GUI.exe' }
        @{ Source = $Changelog; Entry = 'Changelog.txt' }
        @{ Source = (Join-Path $Root 'LICENSE'); Entry = 'License.txt' }
    )
    $packaging = Join-Path $Root 'Packaging'
    foreach ($file in Get-ChildItem -LiteralPath $packaging -Recurse -File) {
        $files += @{ Source = $file.FullName; Entry = $file.FullName.Substring($packaging.Length + 1).Replace('\', '/') }
    }

    New-Item -ItemType Directory -Force $DistDir | Out-Null
    # Same asset name as every previous GitHub release, so direct links keep working.
    $zipPath = Join-Path $DistDir 'SteamCMD.GUI.zip'
    if (Test-Path -LiteralPath $zipPath) { Remove-Item -LiteralPath $zipPath }
    Add-Type -AssemblyName System.IO.Compression
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $zip = [IO.Compression.ZipFile]::Open($zipPath, [IO.Compression.ZipArchiveMode]::Create)
    try {
        foreach ($file in $files) {
            [void][IO.Compression.ZipFileExtensions]::CreateEntryFromFile($zip, $file.Source, $file.Entry)
        }
    } finally {
        $zip.Dispose()
    }

    Write-Host "Packaged $current -> $zipPath"
    Write-Host "SHA256  $((Get-FileHash -LiteralPath $zipPath -Algorithm SHA256).Hash)"
}

switch ($Task) {
    'Build'   { Invoke-MSBuild 'Build' $Configuration }
    'Rebuild' { Invoke-MSBuild 'Rebuild' $Configuration }
    'Clean' {
        foreach ($dir in (Join-Path $ProjectDir 'bin'), (Join-Path $ProjectDir 'obj'), $DistDir) {
            if (Test-Path -LiteralPath $dir) { Remove-Item -LiteralPath $dir -Recurse -Force }
        }
    }
    'Run' {
        Invoke-MSBuild 'Build' $Configuration
        # The program resolves Settings\ and Logs\ from its working directory.
        $exe = Get-OutputExe $Configuration
        Start-Process -FilePath $exe -WorkingDirectory (Split-Path $exe)
    }
    'Package' { New-Package }
    'SetVersion' {
        if (-not $Version) { throw 'SetVersion needs -Version, e.g. -Version 3.2.0.0.' }
        Set-AssemblyVersion $Version
        Write-Host "Version set to $Version. Add a '## $Version' section to Documentation\Changelog.md before packaging."
    }
}
