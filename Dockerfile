FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine.3.11 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EasyBar/EasyBar.csproj", "EasyBar/"]
RUN dotnet restore "EasyBar/EasyBar.csproj"
COPY . ./
WORKDIR /src/EasyBar
RUN dotnet build "EasyBar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyBar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyBar.dll"]