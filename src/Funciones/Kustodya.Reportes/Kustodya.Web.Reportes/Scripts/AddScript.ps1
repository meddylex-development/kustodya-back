﻿dotnet ef migrations script --context ContabilidadContext --project '../../Kustodya.Infrastructure/Kustodya.Infrastructure.csproj' --output ../../Kustodya.Infrastructure/Data/Scripts/ContabilidadEntidad.sql --verbose -i --startup-project '../Kustodya.WebApi.csproj'