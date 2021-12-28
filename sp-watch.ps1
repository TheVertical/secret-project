$path = get-location;

$dotnetAppPath = ".\SecretProject.Web";
$reactAppPath = ".\SecretProject.React";

function run-project {
    param (
        [string]
        $ProjectName
    )
    
}

function build-and-run-dotnet-app {
    cd ([string]::Concat($path, "\", $dotnetAppPath));
    start-process -filepath "powershell.exe" -WindowStyle minimized -argumentlist  @("-Command", "dotnet run");
}

function run-dotnet-app {
    cd ([string]::Concat($path, "\", $dotnetAppPath));
    start-process -filepath "powershell.exe" -WindowStyle minimized -argumentlist  @("-Command", "dotnet run");
}

function run-react-app {
    cd ([string]::Concat($path, "\", $reactAppPath));
    ./sp-watch.ps1;
}

# .NET | SecretEstimate
build-and-run-dotnet-app;

# React | SecretEstimate.React
run-react-app;