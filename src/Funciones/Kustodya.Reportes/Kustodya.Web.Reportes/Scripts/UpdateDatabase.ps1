cd src\Kustodya.WebApi\Scripts

# dotnet-ef database update EntidadClaseDocumentoDefecto --context dbProtektoV1Context --project '../../Kustodya.Infrastructure/Kustodya.Infrastructure.csproj'  --startup-project '../Kustodya.WebApi.csproj'  --verbose

dotnet-ef database update --context ContabilidadContext --project '../../Kustodya.Infrastructure/Kustodya.Infrastructure.csproj'   --startup-project '../Kustodya.WebApi.csproj' --verbose

# dotnet-ef database update --context ContabilidadContext --project '../../Kustodya.Infrastructure/Kustodya.Infrastructure.csproj'   --startup-project '../Kustodya.WebApi.csproj' --verbose