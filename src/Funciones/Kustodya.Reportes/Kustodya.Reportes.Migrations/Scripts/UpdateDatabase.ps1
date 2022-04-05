# cd src\Kustodya.WebApi\Scripts

dotnet-ef database update --context ReportesContext --project '../../Kustodya.Infrastructure.Reportes/Kustodya.Infrastructure.Reportes.csproj' --startup-project '../Kustodya.Reportes.Migrations.csproj' --verbose

# dotnet-ef migrations add Plantillas --context ReportesContext --project '../../Kustodya.Infrastructure.Reportes/Kustodya.Infrastructure.Reportes.csproj' --output-dir Data/Migrations/Contabilidades  -v --startup-project '../Kustodya.Reportes.Migrations.csproj'