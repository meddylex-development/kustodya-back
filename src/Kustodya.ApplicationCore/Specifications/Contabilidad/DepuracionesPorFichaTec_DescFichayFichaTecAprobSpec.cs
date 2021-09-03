using Kustodya.ApplicationCore.Entities.Contabilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kustodya.ApplicationCore.Specifications.Contabilidades
{
    public class DepuracionesPorFichaTec_DescFichayFichaTecAprobSpec : BaseSpec<DepuracionContable>
    {
        public DepuracionesPorFichaTec_DescFichayFichaTecAprobSpec(Expression<Func<DepuracionContable, bool>> criteria, int? skip, int? take) : base(criteria)
        {
            if (skip.HasValue && take.HasValue)
                ApplyPaging(skip.Value, take.Value);
        }
        public DepuracionesPorFichaTec_DescFichayFichaTecAprobSpec(int entidadId, string busqueda, DepuracionContable.CausaDepuracion? causaDepuracion, 
            DepuracionContable.EstadoPago? estadoPago, int? skip, int? take, int userId, DepuracionContable.EstadoDepuracion? estadoDepuracion)
                : this(u => estadoDepuracion == null ?
                ((causaDepuracion != null ? u.Causadepuracion == causaDepuracion : true) &&
                (estadoPago != null ? u.Estadopago == estadoPago : true) &&
                u.Contabilidad.EntidadId == entidadId && u.Eliminado == false &&
                (u.Estado == DepuracionContable.EstadoDepuracion.Borrador ? u.UsuarioCreacionId == userId : true) &&
                (u.Estado == DepuracionContable.EstadoDepuracion.PorPreaprobar ? ((u.GerenteId == userId && u.EstadoAprobacionGerente == null) || (u.CoordinadorId == userId && u.EstadoAprobacionCoordinador == null) || (u.InterventorId == userId && u.EstadoAprobacionInterventor == null)) : true) &&
                (u.Estado == DepuracionContable.EstadoDepuracion.Preaprobada ? (u.Contador_1_Id == userId || u.Contador_2_Id == userId || u.Operativo_1_Id == userId || u.Operativo_2_Id == userId) : true) &&
                (u.Estado == DepuracionContable.EstadoDepuracion.Aprobada_Operativo ? (u.Contador_1_Id == userId || u.Contador_2_Id == userId) : true) &&
                (u.Estado == DepuracionContable.EstadoDepuracion.Aprobada_Contador ? (u.Operativo_1_Id == userId || u.Operativo_2_Id == userId) : true) &&
                (u.Estado == DepuracionContable.EstadoDepuracion.Aprobada ? (u.Contador_1_Id == userId || u.Contador_2_Id == userId || u.Operativo_1_Id == userId || u.Operativo_2_Id == userId) : true) &&
                (u.Estado == DepuracionContable.EstadoDepuracion.Rechazada ? (u.Contador_1_Id == userId || u.Contador_2_Id == userId || u.Operativo_1_Id == userId || u.Operativo_2_Id == userId) : true) &&
                (busqueda == null ? true : 
                (u.DescripcionFicha.ToLower().Contains(busqueda.ToLower()) || u.FichaTecnicaAprobada == null ? false : u.FichaTecnicaAprobada.ToString().Contains(busqueda.ToLower())
                || u.Movimientos.Select(c=>c.NitTercero.ToLower()).Contains(busqueda) || u.Movimientos.Select(c => c.CodigoContable.ToString()).Contains(busqueda)
                || u.NumeroFichaTecnica.ToString().Contains(busqueda)))) : 
                u.Estado == estadoDepuracion
                , skip, take)
        {
            AddInclude(c => c.Contabilidad);
            AddInclude(c => c.Movimientos);
        }
    }
}
