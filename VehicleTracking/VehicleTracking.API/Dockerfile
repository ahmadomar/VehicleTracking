FROM microsoft/dotnet:2.2.0-aspnetcore-runtime AS base
WORKDIR /app
COPY ./bin/Docker .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT dotnet VehicleTracking.API.dll