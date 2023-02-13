#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIREST/APIREST.csproj", "APIREST/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["EF/EF.csproj", "EF/"]
COPY ["DTOs/DTOs.csproj", "DTOs/"]
RUN dotnet restore "APIREST/APIREST.csproj"
COPY . .
WORKDIR "/src/APIREST"
RUN dotnet build "APIREST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIREST.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIREST.dll"]

