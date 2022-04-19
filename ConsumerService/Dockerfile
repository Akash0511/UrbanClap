#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConsumerService/ConsumerService.csproj", "ConsumerService/"]
RUN dotnet restore "ConsumerService/ConsumerService.csproj"
COPY . .
WORKDIR "/src/ConsumerService"
RUN dotnet build "ConsumerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsumerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsumerService.dll"]