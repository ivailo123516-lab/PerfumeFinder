$out = "PerfumeFinder.zip"
if (Test-Path $out) { Remove-Item $out }
Compress-Archive -Path * -DestinationPath $out -Force
Write-Host "Created $out"
