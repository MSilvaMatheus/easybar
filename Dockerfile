FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine.3.11 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

# copy csproj and restore as distinct layers
COPY *.sln .
COPY EasyBar/*.csproj ./EasyBar/
RUN dotnet restore

# copy everything else and build app
COPY EasyBar/. ./EasyBar/
WORKDIR /app/EasyBar
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY --from=build /app/aspnetapp/out ./
ENTRYPOINT ["dotnet", "EasyBar.dll"]