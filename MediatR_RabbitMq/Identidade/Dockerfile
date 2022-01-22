#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MediatR_RabbitMq/Identidade/Identidade.csproj", "MediatR_RabbitMq/Identidade/"]
COPY ["MediatR_RabbitMq/Core/Core.csproj", "MediatR_RabbitMq/Core/"]
RUN dotnet restore "MediatR_RabbitMq/Identidade/Identidade.csproj"
COPY . .
WORKDIR "/src/MediatR_RabbitMq/Identidade"
RUN dotnet build "Identidade.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identidade.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identidade.dll"]