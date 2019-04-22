#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 59161
EXPOSE 44323

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["VehicleTracking.Web/VehicleTracking.Web.csproj", "VehicleTracking.Web/"]
RUN dotnet restore "VehicleTracking.Web/VehicleTracking.Web.csproj"
COPY . .
WORKDIR "/src/VehicleTracking.Web"
RUN dotnet build "VehicleTracking.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VehicleTracking.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VehicleTracking.Web.dll"]