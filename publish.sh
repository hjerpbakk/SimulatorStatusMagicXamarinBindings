#!/usr/bin/env bash
set -e

: ${NuGetApiKey?NuGetApiKey must be set}
nuget pack SimulatorStatusMagic.nuspec
nuget push *.nupkg -Source nuget.org -ApiKey $NuGetApiKey