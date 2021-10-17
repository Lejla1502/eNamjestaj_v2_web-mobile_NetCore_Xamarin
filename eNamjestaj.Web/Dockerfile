#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:2.2 AS build
WORKDIR /src
COPY ["eNamjestaj.Web/eNamjestaj.Web.csproj", "eNamjestaj.Web/"]
COPY ["eNamjestaj.Data/eNamjestaj.Data.csproj", "eNamjestaj.Data/"]
RUN dotnet restore "eNamjestaj.Web/eNamjestaj.Web.csproj"
COPY . .
WORKDIR "/src/eNamjestaj.Web"
RUN dotnet build "eNamjestaj.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eNamjestaj.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eNamjestaj.Web.dll"]
