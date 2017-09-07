#!/bin/bash

PACKAGE_FILE=`find . -type f -name mangopay2-sdk.*.nupkg | head -n 1`
nuget push $PACKAGE_FILE -ApiKey $NUGET_API_KEY -Source $NUGET_SOURCE
