#!/bin/bash

if [[ -z "${PRIVATE_DOCKER_REGISTRY}" ]]; then
    echo "Did not find environment variable: PRIVATE_DOCKER_REGISTRY"
    exit 1
fi

if [[ -z "${PRIVATE_REGISTRY_USERNAME}" ]]; then
    echo "Did not find environment variable: PRIVATE_REGISTRY_USERNAME"
    exit 1
fi

if [[ -z "${PRIVATE_REGISTRY_PASSWORD}" ]]; then
    echo "Did not find environment variable: PRIVATE_REGISTRY_PASSWORD"
    exit 1
fi

export version="$(date +"%Y%m%d%H%M%S")"
export registry="${PRIVATE_DOCKER_REGISTRY}"
export username="${PRIVATE_REGISTRY_USERNAME}"
export password="${PRIVATE_REGISTRY_PASSWORD}"
export container="${registry}/gwendolyngoetz/color-display"
export tag="latest"

