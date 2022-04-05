using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kustodya.ApplicationCore.Entities.Contabilidades.Puc;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public class PUCDomainService : IPUCService
    {
        private IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> _repoContabilidad;
        private IContabilidadService _contabilidadService;
        public PUCDomainService(IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> repoContabilidad,
            IContabilidadService contabilidadService) {
            _repoContabilidad = repoContabilidad;
            _contabilidadService = contabilidadService;
        }
        public async Task ActualizarPUC(IReadOnlyList<PUCInputModel> pucsInput, int entidadId) {
            //Crear listado de Pucs desde el inputModel
            var contabilidades = await _repoContabilidad.ListAllAsync();
            contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
            List<Puc> pucs = pucsInput.Select(c => new Puc(c, contabilidades.Where(d => d.Codigo == c.Contabilidad).First())).ToList();

            //Obtener Contabilidades
            var contabilidadesunicas = (from p in pucs
            select new
            {
                Contabilidad = p.ContabilidadId
            }).Distinct();

            foreach (var item in contabilidadesunicas)
            {
                var contabilidad = await _contabilidadService.ObtenerContabilidadConPUCyCentrosporId(item.Contabilidad);
                contabilidad.ActualizarPucs(pucs.Where(c => c.ContabilidadId == item.Contabilidad).ToList());
                await _repoContabilidad.UpdateAsync(contabilidad);
            }
        }
    }
}
