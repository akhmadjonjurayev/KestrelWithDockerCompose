#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:4001
EXPOSE 4001
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Accemo/Accemo.csproj", "Accemo/"]
COPY ["GrpcExtention/GrpcExtention.csproj", "GrpcExtention/"]
RUN dotnet restore "Accemo/Accemo.csproj"
COPY . .
WORKDIR "/src/Accemo"
RUN dotnet build "Accemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Accemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Accemo.dll"]