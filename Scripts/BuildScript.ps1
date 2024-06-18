# Define the path to the base folder relative to the script's location.
$baseFolderPath = "$PSScriptRoot\.."

# Define the relative paths to the projects that need to be built, relative to the base folder.
$projectsToBuild = @(
	# 1st stage projects.
	# Build projects that do not depend on other projects.
	"Attributes\Net8\CyberFab.Attributes.Net8\CyberFab.Attributes.Net8.csproj",
	"Images\Net8\CyberFab.Images.Net8\CyberFab.Images.Net8.csproj",
	"Utils\Console\Net8\CyberFab.Utils.Console.Net8\CyberFab.Utils.Console.Net8.csproj",
	"Utils\Enumerators\Net8\CyberFab.Utils.Enumerators.Net8\CyberFab.Utils.Enumerators.Net8.csproj",
	"Utils\Structures\Net8\CyberFab.Utils.Structures.Net8\CyberFab.Utils.Structures.Net8.csproj",
	
	# 2nd stage projects.
	# Build projects that depend on the 1st stage projects.
	"Database\Production\Models\Net8\CyberFab.Database.Production.Models.Net8\CyberFab.Database.Production.Models.Net8.csproj",
	"Utils\Graph\Net8\CyberFab.Utils.Graph.Net8\CyberFab.Utils.Graph.Net8.csproj",
	
	# 3rd stage projects.
	# Build projects that depend on the 2nd stage projects.
	"Automation\Scheduler\Net8\CyberFab.Automation.Scheduler.Net8\CyberFab.Automation.Scheduler.Net8.csproj",
	"Database\Production\Context\Net8\CyberFab.Database.Production.Context.Net8\CyberFab.Database.Production.Context.Net8.csproj",
	"Mock\Data\Net8\CyberFab.Mock.Data.Net8\CyberFab.Mock.Data.Net8.csproj",

	# 4th stage projects.
	# Build projects that depend on the 3rd stage projects.
	"Database\Production\Repository\Net8\CyberFab.Database.Production.Repository.Net8\CyberFab.Database.Production.Repository.Net8.csproj"
	
	# 5th stage projects.
	# Build projects that depend on the 4th stage projects.

	# 6th stage projects.
	# Build projects that depend on the 5th stage projects.
)

# Function to build a project.
function Build-Project {
    param (
        [string]$projectPath
    )
	
    # Ensure the path is fully resolved before using it.
    $resolvedProjectPath = Resolve-Path $projectPath
	
    dotnet build $resolvedProjectPath
}

# Iterate over the projects to build and build them.
foreach ($projectPath in $projectsToBuild) {
    # Combine the base folder path with the relative project path.
    # Use Resolve-Path to ensure the full path is correctly resolved, eliminating ".." navigations.
    $fullPath = Resolve-Path (Join-Path -Path $baseFolderPath -ChildPath $projectPath)
	
    Write-Host "Building project: $fullPath"
	
    Build-Project -projectPath $fullPath
}