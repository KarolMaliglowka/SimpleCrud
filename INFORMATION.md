# INFORMATION

```cmd
dotnet ef migrations add "migration2" --project ..\SimpleCrud.Infrastructure.csproj --context SimpleCrudDbContext --startup-project ..\..\SimpleCrud.Api\SimpleCrud.Api.csproj
```
```text
dotnet ef database update --project ..\SimpleCrud.Infrastructure.csproj --context SimpleCrudDbContext --startup-project ..\..\SimpleCrud.Api\SimpleCrud.Api.csproj
```