#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Imagem
# docker image rm CONTAINER ID
# docker build -t nomeImagem:tagImagem . 

# Container
# docker container rm CONTAINER ID
# docker container stop CONTAINER ID
# docker container start CONTAINER ID
# docker inspect CONTAINER ID
# docker run -d -p 3000:80 --name nomeContainer nomeImagem:tagImagem
# docker run -d -p 3000:80 --name nomeContainer -v nomeVolume:/data nomeImagem:tagImagem

# docker run -d -p 3000:80 --name nomeContainer -v D:\Estudos\Docker\ApiTest\DockerMaster\src\DockerMaster.API\docs\:/app volumes:test

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /
COPY ["./DockerMaster.API/DockerMaster.API.csproj", "DockerMaster.API/"]
RUN dotnet restore "DockerMaster.API/DockerMaster.API.csproj"
COPY . .
WORKDIR "DockerMaster.API"
RUN dotnet build "DockerMaster.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerMaster.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerMaster.API.dll"]