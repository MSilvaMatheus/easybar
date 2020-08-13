FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["EasyBar/EasyBar.csproj", "EasyBar/"]
RUN dotnet restore "EasyBar/EasyBar.csproj"
COPY ./EasyBar ./EasyBar
WORKDIR "/src/EasyBar"
RUN dotnet build "EasyBar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyBar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./CounterPage/build ./wwwroot

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet EasyBar.dll