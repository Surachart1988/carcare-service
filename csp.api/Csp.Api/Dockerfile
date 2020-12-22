#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Csp.Api/Csp.Api.csproj", "Csp.Api/"]
COPY ["Csp.DAL/Csp.DAL.csproj", "Csp.DAL/"]
COPY ["Csp.Services/Csp.Services.csproj", "Csp.Services/"]
RUN dotnet restore "Csp.Api/Csp.Api.csproj"
COPY . .
WORKDIR "/src/Csp.Api"
RUN dotnet build "Csp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Csp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN echo "Asia/Bangkok" > /etc/timezone
RUN dpkg-reconfigure -f noninteractive tzdata
RUN date
ENTRYPOINT ["dotnet", "Csp.Api.dll"]