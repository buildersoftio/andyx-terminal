FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Buildersoft.Andy.X.Terminal/Buildersoft.Andy.X.Terminal.csproj", "src/Buildersoft.Andy.X.Terminal/"]
RUN dotnet restore "src/Buildersoft.Andy.X.Terminal/Buildersoft.Andy.X.Terminal.csproj"
COPY . .
WORKDIR "/src/src/Buildersoft.Andy.X.Terminal"
RUN dotnet build "Buildersoft.Andy.X.Terminal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Buildersoft.Andy.X.Terminal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD echo "Buildersoft Andy X Terminal"
CMD echo "(c) 2020 Buildersoft. All rights reserved."
CMD echo "To run terminal execute command 'dotnet Buildersoft.Andy.X.Terminal.dll'"
#ENTRYPOINT ["dotnet", "Buildersoft.Andy.X.Terminal.dll"]