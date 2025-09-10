#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . "ColorDisplay.Web/"
RUN dotnet restore "ColorDisplay.Web/ColorDisplay.Web.csproj"
COPY . .
WORKDIR "/src/ColorDisplay.Web"
RUN dotnet build "ColorDisplay.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ColorDisplay.Web.csproj" -c Release -o /app/publish

FROM base AS final
ARG version
ENV VERSION=$version
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ColorDisplay.Web.dll"]
