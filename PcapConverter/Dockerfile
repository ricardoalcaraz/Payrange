FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PcapConverter/PcapConverter.csproj", "PcapConverter/"]
RUN dotnet restore "PcapConverter/PcapConverter.csproj"
COPY . .
WORKDIR "/src/PcapConverter"
RUN dotnet build "PcapConverter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PcapConverter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PcapConverter.dll"]
