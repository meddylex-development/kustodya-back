using System;
using System.Collections.Generic;
using System.Text;
using Kustodya.ApplicationCore.DTOs.Contabilidades;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class Movimiento : BaseEntity
    {
        #region Propiedades
        public Guid DepuracionContableId { get; private set; }
        public long CodigoContable { get; private set; }
        public string DescripcionMovimiento { get; private set; }
        public Guid CentroCostoId { get; private set; }
        public string NitTercero { get; private set; }
        public int? Debito { get; private set; }
        public int? Credito { get; private set; }
        public string Referencia { get; private set; }
        public long NumComprobanteCierre { get; private set; }
        public string ReferenciacionSoportes { get; private set; }
        public int UsuarioCreacion { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public int EntidadId { get; private set; }
        public Guid TipoAjusteId { get; private set; }
        public TipoAjuste TipoAjuste { get; private set; }
        public DepuracionContable DepuracionContable { get; private set; }
        #endregion

        public void Actualizar(long codigoContable, string descripcionMovimiento, int? debito, int? credito, string referencia, long numComprobanteCierre, string referenciacionSoportes, Guid tipoAjusteId)
        {
            FechaCreacion = DateTime.Now;
            CodigoContable = codigoContable;
            DescripcionMovimiento = descripcionMovimiento;
            Debito = debito;
            Credito = credito;
            Referencia = referencia;
            NumComprobanteCierre = numComprobanteCierre;
            ReferenciacionSoportes = referenciacionSoportes;
            TipoAjusteId = tipoAjusteId;
        }

        public void Actualizar(MovimientoInputModel inputModel)
        {
            Actualizar(
                inputModel.CodigoContable,
                inputModel.DescripcionMovimiento,
                inputModel.Debito,
                inputModel.Credito,
                inputModel.Referencia,
                inputModel.NumComprobanteCierre,
                inputModel.ReferenciacionSoportes,
                inputModel.TipoAjusteId
            );
        }

        public static class Nuevo
        {
            public static Movimiento Basico(DepuracionContable depuracionContable, long codigoContable, string descripcionMovimiento, Guid centroCostoId, string nitTercero, int? debito, int? credito, string referencia, long numComprobanteCierre, string referenciacionSoportes, int usuarioCreacion, int entidadId, Guid tipoAjusteId)
            {
                if ((debito is null || debito is 0) && (credito is null || credito is 0))
                    throw new MovimientoSinCreditoODebitoException();
                    
                return new Movimiento
                {
                    FechaCreacion = DateTime.Now,
                    DepuracionContable = depuracionContable,
                    CodigoContable = codigoContable,
                    DescripcionMovimiento = descripcionMovimiento,
                    CentroCostoId = centroCostoId,
                    NitTercero = nitTercero,
                    Debito = debito,
                    Credito = credito,
                    Referencia = referencia,
                    NumComprobanteCierre = numComprobanteCierre,
                    ReferenciacionSoportes = referenciacionSoportes,
                    UsuarioCreacion = usuarioCreacion,
                    EntidadId = entidadId,
                    TipoAjusteId = tipoAjusteId
                };
            }

            public static Movimiento DesdeInputModel(MovimientoInputModel inputModel, DepuracionContable depuracionContable)
            {
                return Basico(
                    depuracionContable,
                    inputModel.CodigoContable,
                    inputModel.DescripcionMovimiento,
                    inputModel.CentroCostoId,
                    inputModel.NitTercero,
                    inputModel.Debito,
                    inputModel.Credito,
                    inputModel.Referencia,
                    inputModel.NumComprobanteCierre,
                    inputModel.ReferenciacionSoportes,
                    inputModel.UsuarioCreacion,
                    inputModel.EntidadId,
                    inputModel.TipoAjusteId
                );
            }
        }
    }
}

