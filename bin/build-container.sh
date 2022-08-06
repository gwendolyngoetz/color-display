#!/bin/bash

pushd "$(git rev-parse --show-toplevel)"

source bin/lib.sh

docker build --build-arg VERSION=${version} --tag ${container}:${tag} ColorDisplay.Web 
docker tag ${container}:${tag} ${container}:${version}

popd > /dev/null
