#!/usr/bin/env bash

# Define paths
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
ARTIFACTS_DIR=$SCRIPT_DIR/../artifacts
SRC_DIR=$SCRIPT_DIR/../src

# Create NuGet packages for binding libraries
dotnet pack "$SRC_DIR/Flutnet.Interop.Android/Flutnet.Interop.Android.csproj" -o "$ARTIFACTS_DIR/nuget-packages"
dotnet pack "$SRC_DIR/Flutnet.Interop.iOS/Flutnet.Interop.iOS.csproj" -o "$ARTIFACTS_DIR/nuget-packages"
#dotnet pack "$SRC_DIR/Flutnet.Interop.Java8/Flutnet.Interop.Java8.csproj" -o "$ARTIFACTS_DIR/nuget-packages"
