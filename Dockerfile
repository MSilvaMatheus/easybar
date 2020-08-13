FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

# copy csproj and restore as distinct layers
COPY *.sln .
COPY EasyBar/*.csproj ./EasyBar/
RUN dotnet restore "EasyBar/EasyBar.csproj"

# copy everything else and build app
COPY EasyBar/. ./EasyBar/
WORKDIR /app/EasyBar
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine.3.11 AS runtime
WORKDIR /app
COPY --from=build /app/EasyBar/out ./
ENTRYPOINT ["dotnet", "EasyBar.dll"]