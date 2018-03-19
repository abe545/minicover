#!/usr/bin/env bash

set -e

export "MiniCover=dotnet run -p src/MiniCover/MiniCover.csproj --"

rm -r artifacts || true

dotnet restore
dotnet build

for project in tests/**/*.csproj; do dotnet test --no-build $project; done

export Version=$(cat version)-local-$(date +%Y%m%d%H%M%S)
dotnet pack -c Release --output $PWD/artifacts/local

echo "### Running sample build"
cd sample
./build.sh
cd ..
