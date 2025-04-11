# Entity Framework


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