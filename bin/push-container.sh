#!/bin/bash

pushd "$(git rev-parse --show-toplevel)"

source bin/lib.sh

if [[ "$(docker images -q ${container}:${tag} 2> /dev/null)" == "" ]]; then
    echo "Could not find local container: ${container}:${tag}"
    exit 1
fi

docker login https://${registry} --username $USER
docker push ${container}:${tag}

popd > /dev/null
