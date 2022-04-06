using Kustodya.ApplicationCore.Constants;
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
    public class TerceroDomainService : ITerceroService
    {
        private IAsyncContabilidadRepository<Tercero> _repoTercero;
        public TerceroDomainService(IAsyncContabilidadRepository<Tercero> repoTercero) {
            _repoTercero = repoTercero;
        }
        public async Task ActualizarTerceros(IReadOnlyList<TerceroInputModel> tercerosInput, int entidadId) {
            var terceros = await _repoTercero.ListAllAsync();
            var tercerosEliminar = terceros.Where(c => c.EntidadId == entidadId).ToList();
            List<Tercero> tercerosNuevosPN = tercerosInput.Where(c => c.TipoPersona.Trim() == "PN")
                .Select(c => new Tercero(entidadId, c.NumeroId, (TipoIdentificacion)Enum.Parse(typeof(TipoIdentificacion), c.TipoId.Replace(" ", "_")), c.PrimerNombre, c.PrimerApellido)
                {
                    SegundoNombre = c.SegundoNombre, 
                    SegundoApellido = c.SegundoApellido,
                    NumeroComprobante = c.NumeroComprobante,
                    FechaComprobante = c.FechaComprobante,
                    CodigoContable = c.CodigoContable,
                    ValorCredito = c.ValorCredito,
                    ValorDebito = c.ValorDebito,
                    CodigoContabilidad = c.CodigoContabilidad,
                    CentroCosto = c.CentroCosto,
                    FechaCorte = c.FechaCorte
                }).ToList();
            
            List<Tercero> tercerosNuevosPJ = tercerosInput.Where(c=>c.TipoPersona.Trim() == "PJ")
                .Select(c => new Tercero(entidadId, c.NumeroId, (TipoIdentificacion)Enum.Parse(typeof(TipoIdentificacion), c.TipoId.Replace(" ", "_")), c.RazonSocial)
                {
                    NumeroComprobante = c.NumeroComprobante,
                    FechaComprobante = c.FechaComprobante,
                    CodigoContable = c.CodigoContable,
                    ValorCredito = c.ValorCredito,
                    ValorDebito = c.ValorDebito,
                    CodigoContabilidad = c.CodigoContabilidad,
                    CentroCosto = c.CentroCosto,
                    FechaCorte = c.FechaCorte
                }).ToList();

            await _repoTercero.DeleteRangeAsync(tercerosEliminar);
            await _repoTercero.AddRangeAsync(tercerosNuevosPN);
            await _repoTercero.AddRangeAsync(tercerosNuevosPJ);

        }
        public async Task EliminarTerceros(int entidadId) {
            var terceros = await _repoTercero.ListAllAsync();
            var tercerosEliminar = terceros.Where(c => c.EntidadId == entidadId).ToList();
            await _repoTercero.DeleteRangeAsync(tercerosEliminar);
        }
    }
}
