#!/bin/bash

PACKAGE_FILE=`find . -type f -name MangoPay.SDK.*.nupkg | head -n 1`
nuget push $PACKAGE_FILE -ApiKey $NUGET_API_KEY -Source $NUGET_SOURCE
