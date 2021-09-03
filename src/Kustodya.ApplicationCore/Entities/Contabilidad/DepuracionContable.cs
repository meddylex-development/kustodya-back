using Kustodya.ApplicationCore.Entities.Administracion;
using Kustodya.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Kustodya.ApplicationCore.Entities.Contabilidades
{
    public class DepuracionContable : BaseEntity, IBaseEntity
    {
        public long NumeroFichaTecnica { get; private set; }
        // public Segmento Segmento { get; set; }
        public DateTime FechaElaboracion { get; private set; }
        [NotMapped]
        public string FichaTecnica { get => "FTP - " + NumeroFichaTecnica.ToString().PadLeft(4, '0'); }
        public string DescripcionFicha { get; private set; }
        public int? FichaTecnicaAprobada { get; private set; }
        public int? Subcuenta { get; private set; }
        public Guid? SegmentoId { get; private set; }
        public int? Folios { get; private set; }
        public string SituacionEncontrada { get; private set; }
        public string DisposicionesLegales { get; private set; }
        public string AccionesRealizadas { get; private set; }
        public string Recomendaciones { get; private set; }
        public string Anexos { get; private set; }
        public int? ElaboradoporId { get; private set; }
        public int? CoordinadorId { get; private set; }
        public EstadoRevisor? EstadoAprobacionCoordinador { get; set; }
        public int? GerenteId { get; private set; }
        public EstadoRevisor? EstadoAprobacionGerente { get; set; }
        public int? InterventorId { get; private set; }
        public EstadoRevisor? EstadoAprobacionInterventor { get; set; }
        public EstadoRevisor? EstadoAprobacionContador_1_Id { get; set; }
        public EstadoRevisor? EstadoAprobacionContador_2_Id { get; set; }
        public EstadoRevisor? EstadoAprobacionOperativo_1_Id { get; set; }
        public EstadoRevisor? EstadoAprobacionOperativo_2_Id { get; set; }
        public int? AprobadorId { get; private set; }
        public ClaseDocumento ClaseDocumento { get; private set; }
        public Segmento Segmento { get; private set; }
        public EstadoDepuracion Estado { get; set; }
        public int UsuarioCreacionId { get; private set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<Movimiento> Movimientos { get; private set; }
        public ICollection<DepuracionFolio> DepuracionesFolios { get; private set; }
        public Contabilidad Contabilidad { get; private set; }
        public Guid ContabilidadId { get; private set; }

        public Guid ClaseDocumentoId { get; private set; }
        public string NotaCoordinador { get; set; }
        public string NotaGerente { get; set; }
        public string NotaInterventor { get; set; }
        public string NotaAprobador { get; set; }
        public int? Contador_1_Id { get; set; }
        public string NotaContador_1 { get; set; }
        public int? Contador_2_Id { get; set; }
        public string NotaContador_2 { get; set; }
        public int? Operativo_1_Id { get; set; }
        public string NotaOpertaivo_1 { get; set; }
        public int? Operativo_2_Id { get; set; }
        public string NotaOpertaivo_2 { get; set; }
        public CausaDepuracion? Causadepuracion { get; set; }
        public EstadoPago? Estadopago { get; set; }
        public string CentroUtilidad { get; set; }
        public string NroIncapacidad { get; set; }
        public string TarjetaProfessionalContador1 { get; set; }
        public string TarjetaProfessionalContador2 { get; set; }
        public static class Nueva
        {
            public static DepuracionContable Basica(int usuarioCreacionId, Contabilidad contabilidad, ClaseDocumento? claseDocumento = null, string? descripcionFicha = null, int? folios = 0, string situacionEncontrada = null, string anexos = null, string disposicionesLegales = null, string accionesRealizadas = null, string recomendaciones = null)
            {

                if (!contabilidad.Entidad.TieneAprobadoresPorDefecto())
                    throw new Exception("Debe asignar aprobadores por defecto a la entidad para poder crear una depuración contable");

                return new DepuracionContable
                {
                    // 🍊 Mandatory
                    FechaElaboracion = DateTime.Now,
                    FechaCreacion = DateTime.Now,
                    Estado = EstadoDepuracion.Borrador,
                    UsuarioCreacionId = usuarioCreacionId,
                    Contabilidad = contabilidad, // Balance a depurar
                    Eliminado = false,

                    ClaseDocumento = claseDocumento ?? contabilidad.ClaseDocumentoPorDefecto,
                    DescripcionFicha = descripcionFicha,
                    Folios = folios,
                    SituacionEncontrada = situacionEncontrada,
                    Anexos = anexos,
                    DisposicionesLegales = disposicionesLegales,
                    AccionesRealizadas = accionesRealizadas,
                    Recomendaciones = recomendaciones,
                    GerenteId = contabilidad.Entidad.GerentePorDefectoId,
                    CoordinadorId = contabilidad.Entidad.CoordinadorPorDefectoId,
                    InterventorId = contabilidad.Entidad.InterventorPorDefectoId,
                    AprobadorId = contabilidad.Entidad.AprobadorPorDefectoId,
                    Contador_1_Id = contabilidad.Entidad.AprobadorContabilidad_1,
                    Contador_2_Id = contabilidad.Entidad.AprobadorContabilidad_2,
                    Operativo_1_Id = contabilidad.Entidad.AprobadorOperativo_1,
                    Operativo_2_Id = contabilidad.Entidad.AprobadorOperativo_2
                };
            }
        }

        public void Actualizar(Guid contabilidadId, Guid claseDocumentoId, string descripcionFicha, int? folios, string situacionEncontrada, string anexos, string disposicionesLegales, string accionesRealizadas,
        string recomendaciones)
        {
            ContabilidadId = contabilidadId;
            ClaseDocumentoId = claseDocumentoId;
            DescripcionFicha = descripcionFicha;
            Folios = folios;
            SituacionEncontrada = ReemplazarComodines(situacionEncontrada);
            Anexos = ReemplazarComodines(anexos);
            DisposicionesLegales = ReemplazarComodines(disposicionesLegales);
            AccionesRealizadas = ReemplazarComodines(accionesRealizadas);
            Recomendaciones = ReemplazarComodines(recomendaciones);
        }

        public int TotalCreditos() {
            return Movimientos.Sum(c => c.Credito == null ?  0 : Convert.ToInt32(c.Credito));
        }
        public int TotalDebitos()
        {
            return Movimientos.Sum(c => c.Debito == null ? 0 : Convert.ToInt32(c.Debito));
        }

        public void EliminarMovimientosInactivos() {
            Movimientos = Movimientos.Where(c => c.Eliminado == false).ToList();
        }

        //{{NIT}}", "{{Fecha_doc}}", "{{Valor_ter}}", "{{Nombre}}", "{{Fecha_hoy}}
        public string ReemplazarComodines(string texto) {
            texto = texto.Replace("{{NIT}}", Movimientos.FirstOrDefault()?.NitTercero);
            texto = texto.Replace("{{Fecha_doc}}", FechaElaboracion.ToShortDateString());
            texto = texto.Replace("{{Valor_ter}}", Movimientos.FirstOrDefault()?.Debito.ToString());
            texto = texto.Replace("{{Nombre}}", Movimientos.FirstOrDefault()?.NitTercero);
            texto = texto.Replace("{{Fecha_hoy}}", DateTime.Now.ToShortDateString());
            texto = texto.Replace("{{Valor}}", DateTime.Now.ToShortDateString());
            texto = texto.Replace("{{NombreTercero}}", "");
            texto = texto.Replace("{{FechaIncapacidad}}", "");
            texto = texto.Replace("{{NroIncapacidad}}", NroIncapacidad);
            texto = texto.Replace("{{FechaRadicacion}}", "");
            texto = texto.Replace("{{NivelEscolaridadEnfermero}}", "");
            texto = texto.Replace("{{NombreMedico}}", "");
            texto = texto.Replace("{{RegistroMedico}}", "");
            return texto;
        }
        public bool Eliminable(int userId) {
            if (Estado == EstadoDepuracion.Borrador && UsuarioCreacionId == userId)
                return true;

            if (Estado == EstadoDepuracion.PorPreaprobar && (GerenteId == userId || CoordinadorId == userId || InterventorId == userId))
                return true;

            return false;
        }

        public bool xEditableEstado(int userId)
        {
            if (Estado == EstadoDepuracion.Borrador && UsuarioCreacionId == userId)
                return true;
            if (Estado == EstadoDepuracion.PorPreaprobar && (GerenteId == userId || CoordinadorId == userId || InterventorId == userId))
                return true;
            if (Estado == EstadoDepuracion.Preaprobada && (Contador_1_Id == userId || Contador_2_Id == userId || Operativo_1_Id == userId || Operativo_2_Id == userId))
                return true;
            if (Estado == EstadoDepuracion.Aprobada_Contador && (Operativo_1_Id == userId || Operativo_2_Id == userId))
                return true;
            if (Estado == EstadoDepuracion.Aprobada_Operativo && (Contador_1_Id == userId || Contador_2_Id == userId))
                return true;

            return false;
        }

        public bool xEditableDetalle(int userId)
        {
            if (Estado == EstadoDepuracion.Borrador && UsuarioCreacionId == userId)
                return true;
            return false;
        }

        public enum EstadoDepuracion : int
        {
            Borrador = 1,
            PorPreaprobar = 2,
            Preaprobada = 3,
            Aprobada_Contador = 4,
            Aprobada_Operativo = 5,
            Aprobada = 6,
            Rechazada = 7
        }
        
        public enum EstadoRevisor : int
        {
            Terminada = 2,
            Aprobada = 4,
            Rechazada = 5
        }
        public enum CausaDepuracion : int
        {
            No_Rethus = 1,
            No_Autorizado = 2,
            Sancionado = 3
        }
        public enum EstadoPago : int
        {
            Pagadas = 1,
            No_Pagadas = 2
        }
    }
}
