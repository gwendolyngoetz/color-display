#!/bin/bash

docker build ColorDisplay.Web
docker build --tag registry.splynes.com/gwendolyngoetz/color-display:1.1 ColorDisplay.Web
