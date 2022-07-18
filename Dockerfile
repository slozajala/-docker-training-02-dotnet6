FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-amd64 AS build

EXPOSE 80

WORKDIR /source
RUN mkdir /dist

COPY . ./

RUN dotnet restore
RUN dotnet build --configuration Release -o /dist --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /dist
COPY --from=build /dist ./
ENTRYPOINT ["dotnet", "api.dll"]
