#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Api/DSRNetSchool.Api/DSRNetSchool.Api.csproj", "Systems/Api/DSRNetSchool.Api/"]
COPY ["Data/DSRNetSchool.Context/DSRNetSchool.Context.csproj", "Data/DSRNetSchool.Context/"]
COPY ["Shared/DSRNetSchool.Settings/DSRNetSchool.Settings.csproj", "Shared/DSRNetSchool.Settings/"]
COPY ["Data/DSRNetSchool.Context.Entities/DSRNetSchool.Context.Entities.csproj", "Data/DSRNetSchool.Context.Entities/"]
COPY ["Data/Migrations/DSRNetSchool.Context.MigrationsMSSQL/DSRNetSchool.Context.MigrationsMSSQL.csproj", "Data/Migrations/DSRNetSchool.Context.MigrationsMSSQL/"]
COPY ["Data/Migrations/DSRNetSchool.Context.MigrationsPostgreSQL/DSRNetSchool.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/DSRNetSchool.Context.MigrationsPostgreSQL/"]
COPY ["Services/DSRNetSchool.Services.Actions/DSRNetSchool.Services.Actions.csproj", "Services/DSRNetSchool.Services.Actions/"]
COPY ["Shared/DSRNetSchool.Consts/DSRNetSchool.Consts.csproj", "Shared/DSRNetSchool.Consts/"]
COPY ["Services/DSRNetSchool.Services.EmailSender/DSRNetSchool.Services.EmailSender.csproj", "Services/DSRNetSchool.Services.EmailSender/"]
COPY ["Services/DSRNetSchool.Services.RabbitMq/DSRNetSchool.Services.RabbitMq.csproj", "Services/DSRNetSchool.Services.RabbitMq/"]
COPY ["Services/DSRNetSchool.Services.Authors/DSRNetSchool.Services.Authors.csproj", "Services/DSRNetSchool.Services.Authors/"]
COPY ["Services/DSRNetSchool.Services.Books/DSRNetSchool.Services.Books.csproj", "Services/DSRNetSchool.Services.Books/"]
COPY ["Shared/DSRNetSchool.Common/DSRNetSchool.Common.csproj", "Shared/DSRNetSchool.Common/"]
COPY ["Services/DSRNetSchool.Services.Cache/DSRNetSchool.Services.Cache.csproj", "Services/DSRNetSchool.Services.Cache/"]
COPY ["Services/DSRNetSchool.Services.Settings/DSRNetSchool.Services.Settings.csproj", "Services/DSRNetSchool.Services.Settings/"]
COPY ["Services/DSRNetSchool.Services.UserAccount/DSRNetSchool.Services.UserAccount.csproj", "Services/DSRNetSchool.Services.UserAccount/"]
COPY ["Systems/Api/DSRNetSchool.Api.Settings/DSRNetSchool.Api.Settings.csproj", "Systems/Api/DSRNetSchool.Api.Settings/"]
RUN dotnet restore "Systems/Api/DSRNetSchool.Api/DSRNetSchool.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/DSRNetSchool.Api"
RUN dotnet build "DSRNetSchool.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSRNetSchool.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSRNetSchool.Api.dll"]