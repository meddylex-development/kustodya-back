dotnet-ef migrations add Inicial --context ReportesContext --project '../../Kustodya.Infrastructure.Reportes/Kustodya.Infrastructure.Reportes.csproj' --output-dir Data/Migrations/Contabilidades -v --startup-project '../../Kustodya.Web.Reportes/Kustodya.WebApi.csproj'

# dotnet-ef migrations add Primera --context ReportesContext --project '../Kustodya.Infrastructure.Reportes.csproj' --output-dir Data/Migrations  -v

# dotnet-ef migrations add Primera --context ReportesContext --output-dir Data/Migrations/ -v --startup-project '../Kustodya.Web.Reportes/Kustodya.Web.Reportes.csproj'