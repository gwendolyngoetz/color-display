#!/bin/bash

pushd "$(git rev-parse --show-toplevel)"

dotnet build
dotnet test

popd > /dev/null
