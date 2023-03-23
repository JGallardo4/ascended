# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY src/*.csproj ./Ascended/
RUN cd Ascended && dotnet restore

# copy everything else and build app
COPY src/. ./Ascended/
WORKDIR /source/Ascended
RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "AscendedGuild.dll"]
