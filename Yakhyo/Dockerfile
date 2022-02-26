#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:6001
EXPOSE 6001
EXPOSE 6000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Yakhyo/Yakhyo.csproj", "Yakhyo/"]
RUN dotnet restore "Yakhyo/Yakhyo.csproj"
COPY . .
WORKDIR "/src/Yakhyo"
RUN dotnet build "Yakhyo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yakhyo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yakhyo.dll"]