# Define the path to the base folder relative to the script's location.
$baseFolderPath = Resolve-Path "$PSScriptRoot\.."

# Arrays of directories and files to remove.
$directoriesToRemove = @('bin', 'obj', '.vs', '.angular', '.dist', 'node_modules')
$filesToRemove = @('package-lock.json')

# Remove directories, including hidden ones
foreach ($dir in $directoriesToRemove) {
    Get-ChildItem -Path $baseFolderPath -Directory -Force -Recurse | Where-Object { $_.Name -in $directoriesToRemove } | ForEach-Object {
        $dirPath = $_.FullName
        Write-Host "Removing directory: $dirPath"
        Remove-Item -Path $dirPath -Recurse -Force -ErrorAction SilentlyContinue
    }
}

# Remove files.
foreach ($file in $filesToRemove) {
    Get-ChildItem -Path $baseFolderPath -File -Name $file -Recurse | ForEach-Object {
        $filePath = Join-Path -Path $baseFolderPath -ChildPath $_
        Write-Host "Removing file: $filePath"
        Remove-Item -Path $filePath -Force -ErrorAction SilentlyContinue
    }
}
