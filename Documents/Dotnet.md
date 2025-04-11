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