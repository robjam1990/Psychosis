# File: robjam1990/Psychosis/Scripts/Setup.ps1
# Description: PowerShell script to set up the "Psychosis" game.

# Function to log messages to a file
function Write-Log {
    param(
        [string]$Message,
        [string]$LogFile
    )

    $TimeStamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    $LogMessage = "$TimeStamp - $Message"
    Add-content -Path $LogFile -Value $LogMessage
}

# Function to handle errors
function Handle-Error {
    param(
        [string]$ErrorMessage
    )

    Write-Host $ErrorMessage -ForegroundColor "Red"
    Write-Log -Message $ErrorMessage -LogFile "Setup.log"
    exit 1
}

# Initializing setup process
Write-Host "Initializing Psychosis Setup Process" -ForegroundColor "Yellow"
Write-Log -Message "Initializing Psychosis Setup Process" -LogFile "Setup.log"

# Setting up request parameters for game template
$RequestUri = "https://robjam1990.ca/api/psychosis"
$RequestBody = '{"type":"text-based","platform":"pc","sortBy":"popularity","pageSize":"1"}'
$RequestHeaders = @{
    'Accept' = 'application/json'
}

try {
    # Sending request and retrieving results
    $Results = Invoke-RestMethod -Uri $RequestUri -Method POST -Headers $RequestHeaders -Body $RequestBody

    if ($Results) {
        $TemplateUrl = $Results[0].url

        # Downloading the game template file
        $TemplateFileName = Split-Path -Leaf $TemplateUrl
        $TemplateFullPath = Join-Path -Path $env:USERPROFILE -ChildPath $TemplateFileName
        Invoke-WebRequest -Uri $TemplateUrl -OutFile $TemplateFullPath

        # Setting up game directory
        $GameDirectory = "C:\robjam1990\Psychosis"
        if (!(Test-Path $GameDirectory)) {
            New-Item -Path $GameDirectory -ItemType Directory | Out-Null
        }

        # Extracting game template to game directory
        Expand-Archive -Path $TemplateFullPath -DestinationPath $GameDirectory -Force

        # Removing downloaded template file after extraction
        Remove-Item $TemplateFullPath -Force

        # Logging success message
        $SuccessMessage = "Game setup completed successfully. Template extracted to: $GameDirectory"
        Write-Host $SuccessMessage -ForegroundColor "Green"
        Write-Log -Message $SuccessMessage -LogFile "Setup.log"
    }
    else {
        Handle-Error "Failed to retrieve the game template. Please try again later."
    }
}
catch {
    Handle-Error "An error occurred during the setup process: $_"
}
