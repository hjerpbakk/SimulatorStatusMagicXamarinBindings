#!/usr/bin/env bash
set -e

wget -c $(curl -ksL "https://api.github.com/repos/shinydevelopment/SimulatorStatusMagic/releases/latest" | jq -r ".assets[0].browser_download_url")