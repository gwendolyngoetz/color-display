#!/bin/bash

if [[ -z "${PRIVATE_DOCKER_REGISTRY}" ]]; then
    echo "Did not find environment variable: PRIVATE_DOCKER_REGISTRY"
    exit 1
fi

export version="$(date +"%Y%m%d%H%M%S")"
export registry="${PRIVATE_DOCKER_REGISTRY}"
export container="${registry}/gwendolyngoetz/color-display"
export tag="latest"

