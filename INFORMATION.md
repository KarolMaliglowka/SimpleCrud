# INFORMATION

```shell
dotnet ef migrations add newMigration --startup-project ..\..\SimpleCrud.Api\SimpleCrud.Api.csproj --project ..\SimpleCrud.Infrastructure.csproj --context SimpleCrudDbContext
```


```shell
dotnet ef database update --startup-project ..\..\SimpleCrud.Api\SimpleCrud.Api.csproj --project ..\SimpleCrud.Infrastructure.csproj --context SimpleCrudDbContext
```