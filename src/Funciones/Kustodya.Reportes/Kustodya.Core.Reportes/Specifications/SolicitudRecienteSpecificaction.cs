using System;
using System.Linq;
using Ardalis.Specification;
using Kustodya.Core.Reportes.Entities;

namespace Kustodya.Core.Reportes.Specifications
{
    public class ReporteConUsoRecienteSpecificaction : Specification<Reporte>
    {
        public ReporteConUsoRecienteSpecificaction(Guid workspaceId)
        {
            var hace30Min = DateTime.Now - TimeSpan.FromMinutes(30);
            Query.Where(r => r.WorkspaceId == workspaceId 
                && r.Solicitudes.Where(s => 
                    s.Solicitado > hace30Min
                    && s.Aprobada
                    ).Any());
            Query.Include(r => r.Solicitudes);
        }
    }
}