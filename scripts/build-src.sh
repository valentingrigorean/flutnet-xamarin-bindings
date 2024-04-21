#!/usr/bin/env bash

# Define paths
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
SOLUTION_PATH=$SCRIPT_DIR/../Flutnet.Interop.sln

# Restore NuGet packages
dotnet restore "$SOLUTION_PATH"

# Clean and build the solution for all specified configurations
configurations=("Debug" "ReleaseWithDebugNativeRef" "Release")

for config in "${configurations[@]}"
do
    # Clean each configuration
    dotnet clean "$SOLUTION_PATH" --configuration $config

    # Build each configuration
    dotnet build "$SOLUTION_PATH" --configuration $config --no-restore
done