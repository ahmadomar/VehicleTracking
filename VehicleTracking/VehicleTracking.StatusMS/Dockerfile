#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 59083
EXPOSE 44340

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["VehicleTracking.StatusMS/VehicleTracking.StatusMS.csproj", "VehicleTracking.StatusMS/"]
RUN dotnet restore "VehicleTracking.StatusMS/VehicleTracking.StatusMS.csproj"
COPY . .
WORKDIR "/src/VehicleTracking.StatusMS"
RUN dotnet build "VehicleTracking.StatusMS.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VehicleTracking.StatusMS.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VehicleTracking.StatusMS.dll"]