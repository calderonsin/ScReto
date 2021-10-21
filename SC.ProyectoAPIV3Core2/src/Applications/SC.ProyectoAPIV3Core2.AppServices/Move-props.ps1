Move-Item "Build" -Destination "..\..\..\..\Build"
Move-Item "Directory.Build.props" -Destination "..\..\..\..\Directory.Build.props"

Write-Host 'Copiado terminado'.ToUpper() -ForegroundColor Yellow -BackgroundColor DarkCyan


Pause