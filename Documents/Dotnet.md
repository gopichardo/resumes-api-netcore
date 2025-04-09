## Dotnet

Restore the dependencies
```shell
dotnet restore
```

Build the project:
```shell
dotnet build
```

Run API
```shell
 dotnet watch run -p .\Infrastructure\Api\
```

Add project reference
```shell
dotnet add Infrastructure/Database/Infrastructure.Database.csproj reference Entity/Entity.csproj
```

## Entity Framework


Install EF tool
```shell
dotnet tool install --global dotnet-ef
```

Add MIgration
```shell
dotnet ef migrations add InitialMigration -o Migrations -p .\Infrastructure\Database\ -s .\Infrastructure\Api\
```

Apply MIgrations
```shell
dotnet ef database update --project People.Infrastructure --startup-project People.Api
dotnet ef database update -p .\Infrastructure\Database\ -s .\Infrastructure\Api\
```