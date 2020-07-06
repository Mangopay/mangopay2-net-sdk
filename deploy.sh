#!/bin/bash

nuget setapikey $NUGET_API_KEY -Source $NUGET_SOURCE
dotnet nuget push ./MangoPay.SDK/bin/Release/mangopay2-sdk.*.nupkg $NUGET_API_KEY -s $NUGET_SOURCE
