using Kustodya.ApplicationCore.DTOs.Contabilidades;
using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Services.Contabilidades
{
    public class CentroDomainService : ICentroService
    {
        private readonly IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> _repoContabilidad;
        private readonly IAsyncContabilidadRepository<Regional> _repoRegional;
        private readonly IAsyncContabilidadRepository<Segmento> _repoSegmento;
        private readonly IAsyncContabilidadRepository<Movimiento> _repoMovimiento;
        private readonly IAsyncContabilidadRepository<CentroCosto> _repoCentroCosto;
        private readonly IContabilidadService _contabilidadService;
        public CentroDomainService(IAsyncContabilidadRepository<Entities.Contabilidades.Contabilidad> repoContabilidad,
            IAsyncContabilidadRepository<Regional> repoRegional, IAsyncContabilidadRepository<Segmento> repoSegmento,
            IContabilidadService contabilidadService, IAsyncContabilidadRepository<Movimiento> repoMovimiento,
            IAsyncContabilidadRepository<CentroCosto> repoCentroCosto) {
            _repoContabilidad = repoContabilidad;
            _repoRegional = repoRegional;
            _repoSegmento = repoSegmento;
            _contabilidadService = contabilidadService;
            _repoMovimiento = repoMovimiento;
            _repoCentroCosto = repoCentroCosto;
        }
        public async Task ActualizarCentros(IReadOnlyList<CentroInputModel> centrosInput, int entidadId)
        {
            //Crear listado de Centros desde el inputModel
            var contabilidades = await _repoContabilidad.ListAllAsync();
            var regionales = await _repoRegional.ListAllAsync();
            var segmentos = await _repoSegmento.ListAllAsync();
            var movimientos = await _repoMovimiento.ListAllAsync();
            var centroscostoActuales = await _repoCentroCosto.ListAllAsync();
            contabilidades = contabilidades.Where(c => c.EntidadId == entidadId).ToList();
            List<CentroCosto> centros = centrosInput.Select(c => new CentroCosto(contabilidades.Where(d => d.Codigo == c.Contabilidad).First().Id, c.Codigo, c.Descripcion,
            regionales.Where(d => d.Descripcion == c.Regional).First().Id, segmentos.Where(d => d.Descripcion == c.Segmento).First().Id)).ToList();

            //Obtener Contabilidades
            var contabilidadesunicas = (from p in centros
                                        select new
                                        {
                                            Contabilidad = p.ContabilidadId
                                        }).Distinct();

            //Eliminar centros de costo que actualmente no es están usando en ningun movimiento
            centroscostoActuales = centroscostoActuales.Where(d => !movimientos.Select(c => c.CentroCostoId).Contains(d.Id)).ToList();
            await _repoCentroCosto.DeleteRangeAsync(centroscostoActuales);

            centroscostoActuales = await _repoCentroCosto.ListAllAsync();
            foreach (var item in contabilidadesunicas)
            {
                var contabilidad = await _contabilidadService.ObtenerContabilidadConPUCyCentrosporId(item.Contabilidad);
                foreach (CentroCosto cc in centros.Where(c => c.ContabilidadId == contabilidad.Id))
                {
                    //Validar si el centro de costo ya existe por contabilidad y codigo
                    var centroCostoActual = centroscostoActuales
                        .Where(c => c.ContabilidadId == cc.ContabilidadId && c.Codigo.ToLower() == cc.Codigo.ToLower()).FirstOrDefault();

                    //Si no existe se crea el centro de costo
                    if (centroCostoActual == null)
                    {
                        await _repoCentroCosto.AddAsync(cc);
                    }
                    else
                    { //Si existe, se actualiza
                        centroCostoActual.RegionalId = cc.RegionalId;
                        centroCostoActual.SegmentoId = cc.SegmentoId;
                        centroCostoActual.Descripcion = cc.Descripcion;
                        await _repoCentroCosto.UpdateAsync(centroCostoActual);
                    }
                }

                //contabilidad.ActualizarCentros(centros.Where(c => c.ContabilidadId == item.Contabilidad).ToList());
                await _repoContabilidad.UpdateAsync(contabilidad);
            }
        }
    }
}
