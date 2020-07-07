#!/bin/bash

nuget setApiKey $NUGET_API_KEY -Source $NUGET_URL
dotnet nuget push ./MangoPay.SDK/bin/Release/mangopay2-sdk.*.nupkg -k $NUGET_API_KEY
