$databaseServer = $args[0]
$databaseName = $args[1]
$databaseUser = $args[2]
$databasePassword = $args[3]
$scriptPath = $args[4]

Add-Type -Path (Join-Path $PSScriptRoot 'DbUp.dll')

$dbUp = [DbUp.DeployChanges]::To
$dbUp = [SqlServerExtensions]::SqlDatabase($dbUp, "Data Source=$databaseServer;Initial Catalog=$databaseName;User id=$databaseUser;Password=$databasePassword")
$dbUp = [StandardExtensions]::WithScriptsFromFileSystem($dbUp, $scriptPath)
$dbUp = [StandardExtensions]::LogToConsole($dbUp)
$upgradeResult = $dbUp.Build().PerformUpgrade()