#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:7001
EXPOSE 7001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Xacton/Xacton.csproj", "Xacton/"]
COPY ["GrpcExtention/GrpcExtention.csproj", "GrpcExtention/"]
RUN dotnet restore "Xacton/Xacton.csproj"
COPY . .
WORKDIR "/src/Xacton"
RUN dotnet build "Xacton.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xacton.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xacton.dll"]