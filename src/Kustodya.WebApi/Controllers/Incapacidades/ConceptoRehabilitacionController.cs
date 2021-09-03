using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kustodya.ApplicationCore.Interfaces.Incapacidades;
using Kustodya.ApplicationCore.Interfaces.Rehabilitacion;
using Kustodya.WebApi.Controllers.Incapacidades.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kustodya.ApplicationCore.Entities.Concepto;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Globalization;
using Kustodya.ApplicationCore.Dtos;

namespace Kustodya.WebApi.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoRehabilitacionController : BaseController
    {
        private readonly IConceptoRehabilitacionService _conceptoRehabilitacionService;
        private readonly ICie10Service _cie10Service;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg => {
            cfg.AddProfile<MappingProfiles>();
            cfg.CreateMap<ConceptoRehabilitacionDetalleInputModel, ConceptoRehabilitacion>();
        });

        public ConceptoRehabilitacionController(IConceptoRehabilitacionService conceptoRehabilitacionService,
            ICie10Service cie10Service)
        {
            _conceptoRehabilitacionService = conceptoRehabilitacionService;
            _cie10Service = cie10Service;
            _mapper = _config.CreateMapper();

        }

        [HttpGet("{pacienteporEmitirId:int}")]
        public async Task<IActionResult> ConceptoRehabilitacion(int pacienteporEmitirId)
        {
            var conceptoRehabilitacion = await _conceptoRehabilitacionService.DatosConcepto(pacienteporEmitirId);
            if (conceptoRehabilitacion == null)
                return NotFound();
            var pacientePorEmitir = await _conceptoRehabilitacionService.PacientePorEmitir(pacienteporEmitirId);
            var diasAcumulados = await _conceptoRehabilitacionService.DiasAcumulados(pacientePorEmitir.PacienteId);
            var conceptosEmitidos = await _conceptoRehabilitacionService.ConceptosEmitidos(pacientePorEmitir.PacienteId, "", null, null);
            var diagnosticos = await _cie10Service.GetCie10();
            ConceptoRehabilitacionOutputModel crom = new ConceptoRehabilitacionOutputModel
            {
                diasAcumulados = diasAcumulados == null ? 0 : (int)diasAcumulados,
                conceptosEmitidos = conceptosEmitidos.Count(),
                PCLCalificados = 0, //Calculado: pendiente por crear formulario
                apellidos = pacientePorEmitir.Paciente.TPrimerApellido + (pacientePorEmitir.Paciente.TSegundoApellido == null ? "" : " " + pacientePorEmitir.Paciente.TSegundoApellido),
                nombres = pacientePorEmitir.Paciente.TPrimerNombre + (pacientePorEmitir.Paciente.TSegundoNombre == null ? "" : " " + pacientePorEmitir.Paciente.TSegundoNombre),
                tipoDocumento = pacientePorEmitir.Paciente.IIdtipoDocNavigation.TDescripcion,
                numeroDocumento = pacientePorEmitir.Paciente.TNumeroDocumento,
                fechaNacimiento = pacientePorEmitir.Paciente.DtFechaNacimiento?.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,
                fechaEmision = pacientePorEmitir.FechaEmision?.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,
                edad = pacientePorEmitir.Paciente.IEdad,
                ARL = pacientePorEmitir.Paciente.IIdarlNavigation.TNombre,
                AFP = pacientePorEmitir.Paciente.IIdafpNavigation.TNombre,
                EPS = pacientePorEmitir.Paciente.IIdepsNavigation.TNombre,
                codigoCorto = conceptoRehabilitacion.CodigoCorto,
                historiaClinica = conceptoRehabilitacion.ResumenHistoriaClinica,
                finalidadTratmamiento = Convert.ToInt32(conceptoRehabilitacion.FinalidadTratamientos),
                Farmacologico = conceptoRehabilitacion.EsFarmacologico,
                terapiaOcupacional = conceptoRehabilitacion.EsTerapiaOcupacional,
                fonoAudiologia = conceptoRehabilitacion.EsFonoaudiologia,
                quirurgico = conceptoRehabilitacion.EsQuirurgico,
                terapiaFisica = conceptoRehabilitacion.EsTerapiaFisica,
                otrosTramites = conceptoRehabilitacion.EsOtrosTratamientos,
                otrosTratamientos = conceptoRehabilitacion.DescripcionOtrosTratamientos,
                cortoPlazo = Convert.ToInt32(conceptoRehabilitacion.PlazoCorto),
                medianoPlazo = Convert.ToInt32(conceptoRehabilitacion.PlazoMediano),
                concepto = Convert.ToInt32(conceptoRehabilitacion.Concepto),
                RemisionAdministradoraFondoPension   = conceptoRehabilitacion.RemisionAdministradoraFondoPension
            };

            List<DiagnosticosOutputModel> doms = new List<DiagnosticosOutputModel>();
            foreach (var item in conceptoRehabilitacion.Diagnosticos)
            {
                var diagnostico = diagnosticos.Where(c => c.IIdcie10 == item.Cie10Id).FirstOrDefault();
                DiagnosticosOutputModel dom = new DiagnosticosOutputModel
                {
                    id = item.Id,
                    CIE10Id = diagnostico.IIdcie10,
                    nombreDiagnostico = diagnostico?.TCie10 + "-" + diagnostico?.TDescripcion,
                    Etiologia = Convert.ToInt32(item.Etiologia),
                    nombreEtiologia = item.Etiologia.ToString(),
                    FechaIncapacidad = item.FechaIncapacidad.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds
                };
                doms.Add(dom);
            }
            crom.diagnosticos = doms;

            List<SecuelasOutputModel> soms = new List<SecuelasOutputModel>();
            foreach (var item in conceptoRehabilitacion.Secuelas)
            {
                SecuelasOutputModel som = new SecuelasOutputModel
                {
                    id = item.Id,
                    descripcion = item.Descripcion,
                    pronostico = Convert.ToInt32(item.Pronostico),
                    nombrePronostico = item.Pronostico.ToString(),
                    tipoSecuela = Convert.ToInt32(item.Tipo),
                    nombreTipoSecuela = item.Tipo.ToString()
                };
                soms.Add(som);
            }
            crom.secuelas = soms;
            return Ok(crom);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConceptoRehabilitacionDetalleInputModel conceptoRehabilitacionInputModel)
        {
            GetUserId(out int usuarioId);
            var conceptoRehabilitacion = await _conceptoRehabilitacionService.DatosConcepto(conceptoRehabilitacionInputModel.PacienteporEmitirId);
            if (conceptoRehabilitacion != null)
                return Conflict("Este concepto ya fue generado");

            var pacientePorEmitir = await _conceptoRehabilitacionService.PacientePorEmitir(conceptoRehabilitacionInputModel.PacienteporEmitirId);
            if (pacientePorEmitir == null)
                return Conflict("El id del paciente pendiente por emitir no existe");

            var pronosticosConceptos = await _conceptoRehabilitacionService.Pronosticos();

            ConceptoRehabilitacion concepto = _mapper.Map<ConceptoRehabilitacion>(conceptoRehabilitacionInputModel);
            if(concepto.Concepto != 0)
                concepto.RemisionAdministradoraFondoPension = pronosticosConceptos.Where(c => c.PronosticoConceptoId == concepto.Concepto).First().Texto;

            foreach (var item in concepto.Diagnosticos)
            {
                item.Id = 0;
            }
            foreach (var item in concepto.Secuelas)
            {
                item.Id = 0;
            }

            concepto.CodigoCorto = pacientePorEmitir.CalcularCodigoCorto();

            await _conceptoRehabilitacionService.CrearConcepto(concepto, usuarioId);
            return Ok();
        }

        [HttpPut("{pacienteporEmitirId:int}")]
        public async Task<IActionResult> Put(ConceptoRehabilitacionInputModel inputModel, int pacienteporEmitirId) {
            GetUserId(out int usuarioId);
            var conceptoRehabilitacionRepo = await _conceptoRehabilitacionService.DatosConcepto(pacienteporEmitirId);
            if (conceptoRehabilitacionRepo == null)
                return Conflict("No se encontró un concepto emitido para este paciente");

            _mapper.Map(inputModel, conceptoRehabilitacionRepo, typeof(ConceptoRehabilitacionInputModel), typeof(ConceptoRehabilitacion));
            await _conceptoRehabilitacionService.ActualizarConcepto(conceptoRehabilitacionRepo);
            return Ok();
        }
        
        [HttpPatch("{pacienteporEmitirId:int}")]
        public async Task<IActionResult> Update([FromBody] JsonPatchDocument<ConceptoRehabilitacionDetalleInputModel> registryPatch, int pacienteporEmitirId)
        {
            GetUserId(out int userId);
            ConceptoRehabilitacion conceptoRehabilitacion = await _conceptoRehabilitacionService.DatosConcepto(pacienteporEmitirId);
            var conceptoRehabilitacionDetalleInputModel = new ConceptoRehabilitacionDetalleInputModel();

            conceptoRehabilitacionDetalleInputModel = _mapper.Map(conceptoRehabilitacion, conceptoRehabilitacionDetalleInputModel);

            registryPatch.ApplyTo(conceptoRehabilitacionDetalleInputModel);
            ConceptoRehabilitacion conceptoRehabilitacionActualizado = _mapper.Map(conceptoRehabilitacionDetalleInputModel, conceptoRehabilitacion);
            await _conceptoRehabilitacionService.ActualizarConcepto(conceptoRehabilitacionActualizado);
            return Ok();
        }

        [HttpPost("{pacienteporEmitirId:int}/Anular")]
        public async Task<IActionResult> AnularConcepto(int pacienteporEmitirId, [FromBody] string descripcionAnulacion)
        {
            GetUserId(out int usuarioId);
            var pacientePorEmitir = await _conceptoRehabilitacionService.PacientePorEmitir(pacienteporEmitirId);
            if (pacientePorEmitir == null)
                return Conflict("El id del del concepto no existe");

            if (pacientePorEmitir.Estado == PacientesPorEmitir.EstadoConcepto.Anulado)
                return Conflict("El concepto ya se encuentra anulado");
            
            if (pacientePorEmitir.Estado == PacientesPorEmitir.EstadoConcepto.Por_Emitir)
                return Conflict("Aún no hay un concepto emitido");

            pacientePorEmitir.Estado = PacientesPorEmitir.EstadoConcepto.Anulado;
            pacientePorEmitir.FechaAnulacion = DateTime.Now;
            pacientePorEmitir.CausalAnulacion = descripcionAnulacion;

            //Anular Concepto
            await _conceptoRehabilitacionService.ActualizarPacientePorEmitir(pacientePorEmitir);

            //Crear nuevo pendiente por emitir
            pacientePorEmitir.Id = 0;
            pacientePorEmitir.Estado = PacientesPorEmitir.EstadoConcepto.Por_Emitir;
            pacientePorEmitir.CausalAnulacion = null;
            await _conceptoRehabilitacionService.CrearPendientePorEmitir(pacientePorEmitir);

            return Ok();
        }

        [HttpGet("{pacienteId:int}/Historial")]
        public async Task<IActionResult> ConceptoRehabilitacionPorPaciente(int pacienteId, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1)
        {
            int cantidad = 10;
            var conceptos = await _conceptoRehabilitacionService.ConceptosEmitidos(pacienteId, busqueda, (pagina - 1) * cantidad, cantidad);
            var total = await _conceptoRehabilitacionService.ConceptosEmitidos(pacienteId, busqueda, null, null);
            var diagnosticos = await _cie10Service.GetCie10();
            
            List<HistorialConceptoOutputModel> historialConceptosOutputModels = _mapper.Map<List<HistorialConceptoOutputModel>>(conceptos);

            foreach (HistorialConceptoOutputModel hcom in historialConceptosOutputModels)
            {
                foreach (DiagnosticosOutputModel item in hcom.Diagnosticos)
                {
                    var diagnostico = diagnosticos.Where(c => c.IIdcie10 == Convert.ToInt32(item.CIE10Id)).First();
                    item.CIE10Id = diagnostico.IIdcie10; 
                    item.nombreDiagnostico = diagnostico.TCie10 + "-" + diagnostico.TDescripcion;
                }
            }
            HistorialConceptosOutputModel historialConceptosOutputModel = new HistorialConceptosOutputModel
            {
                historialConceptosOutputModel = historialConceptosOutputModels,
                paginacion = new PaginacionModel(total.Count(), pagina, cantidad)
            };
            return Ok(historialConceptosOutputModel);
        }

        [HttpGet("Dashboard")]
        public async Task<IActionResult> Dashboard(string periodo)
        {
            var dashboard = await _conceptoRehabilitacionService.Dashboard(periodo);
            var totales = await _conceptoRehabilitacionService.Dashboard("");
            List<DashBoardCategoria> categorias = new List<DashBoardCategoria>();
            switch (periodo)
            {
                case "hoy":
                    var respuesta = from d in dashboard
                        group d by new { d.FechaAsignacion.Date, d.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Count(),
                            Categoria = "Hoy"
                        };
                    foreach (var item in respuesta)
                    {
                        DashBoardCategoria DC = new DashBoardCategoria
                        {
                            estado = item.Estado,
                            cantidad = item.Cantidad,
                            categoria = item.Categoria
                        };
                        categorias.Add(DC);
                    }
                    break;
                case "mes":
                    DateTime reference = DateTime.Now;
                    Calendar calendar = CultureInfo.CurrentCulture.Calendar;

                    IEnumerable<int> daysInMonth = Enumerable.Range(1, calendar.GetDaysInMonth(reference.Year, reference.Month));

                    List<Tuple<DateTime, DateTime>> weeks = daysInMonth.Select(day => new DateTime(reference.Year, reference.Month, day))
                        .GroupBy(d => calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday))
                        .Select(g => new Tuple<DateTime, DateTime>(g.First(), g.Last()))
                        .ToList();

                    respuesta = from d in dashboard
                        group d by new { d.FechaAsignacion.Date, d.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Count(),
                            Categoria = "Semana " + ObtenerSemana(G.First().FechaAsignacion, weeks).ToString()
                        };
                    var agrupar = from r in respuesta
                        group r by new { r.Categoria, r.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Sum(c=>c.Cantidad),
                            G.First().Categoria
                        };
                    foreach (var item in agrupar)
                    {
                        DashBoardCategoria DC = new DashBoardCategoria
                        {
                            estado = item.Estado,
                            cantidad = item.Cantidad,
                            categoria = item.Categoria
                        };
                        categorias.Add(DC);
                    }
                    categorias = categorias.OrderBy(c => c.estado).OrderBy(c => c.categoria).ToList();
                    break;
                case "semana":
                    respuesta = from d in dashboard
                        group d by new { d.FechaAsignacion.Date, d.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Count(),
                            Categoria = G.First().FechaAsignacion.ToString("dddd", CultureInfo.CreateSpecificCulture("es")) //G.First().FechaAsignacion.DayOfWeek.ToString()
                        };
                    foreach (var item in respuesta)
                    {
                        DashBoardCategoria DC = new DashBoardCategoria
                        {
                            estado = item.Estado,
                            cantidad = item.Cantidad,
                            categoria = item.Categoria
                        };
                        categorias.Add(DC);
                    }
                    categorias = categorias.OrderBy(c => c.estado).OrderBy(c => c.categoria).ToList();
                    break;
                case "año":
                    respuesta = from d in dashboard
                        group d by new { d.FechaAsignacion.Date, d.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Count(),
                            Categoria = G.First().FechaAsignacion.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"))
                        };
                    agrupar = from r in respuesta
                        group r by new { r.Categoria, r.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Sum(c => c.Cantidad),
                            G.First().Categoria
                        };
                    foreach (var item in agrupar)
                    {
                        DashBoardCategoria DC = new DashBoardCategoria
                        {
                            estado = item.Estado,
                            cantidad = item.Cantidad,
                            categoria = item.Categoria
                        };
                        categorias.Add(DC);
                    }
                    categorias = categorias.OrderBy(c => c.estado).OrderBy(c => c.categoria).ToList();
                    break;
                default:
                    respuesta = from d in dashboard
                        group d by new { d.FechaAsignacion.Date, d.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Count(),
                            Categoria = G.First().FechaAsignacion.Year.ToString()
                        };
                    agrupar = from r in respuesta
                        group r by new { r.Categoria, r.Estado } into G
                        select new
                        {
                            Estado = (int)G.First().Estado,
                            Cantidad = G.Sum(c => c.Cantidad),
                            G.First().Categoria
                        };
                    foreach (var item in agrupar)
                    {
                        DashBoardCategoria DC = new DashBoardCategoria
                        {
                            estado = item.Estado,
                            cantidad = item.Cantidad,
                            categoria = item.Categoria
                        };
                        categorias.Add(DC);
                    }
                    categorias = categorias.OrderBy(c => c.estado).OrderBy(c => c.categoria).ToList();
                    break;
            }
            
            var dashoard = new DashboardOutputModel();
            string scategorias = "[";
            //Convertir listado de categorias 
            foreach (var item in categorias)
            {
                if (!scategorias.Contains(item.categoria)){ 
                    int pendientes = categorias.Where(c => c.categoria == item.categoria && c.estado == 1).Sum(c=>c.cantidad);
                    int  emitidos = categorias.Where(c => c.categoria == item.categoria && c.estado == 2).Sum(c => c.cantidad);
                    scategorias += "['" + item.categoria + "'," + emitidos.ToString() + "," + pendientes.ToString() + "," + 
                        Math.Round((emitidos + (decimal)pendientes)/2,1).ToString() + "],";
                }
            }
            if (categorias.Count() == 0)
            {
                switch (periodo)
                {
                    case "hoy":
                        scategorias += "]";
                        break;
                    case "semana":
                        scategorias += "]";
                        break;
                    case "mes":
                        scategorias += "]";
                        break;
                    case "año":
                        scategorias += "]";
                        break;
                    default:
                        scategorias += "]";
                        break;
                }
            }
            else {
                scategorias = scategorias.Substring(0, scategorias.Length - 1);
                scategorias = scategorias + "]";
            }

            dashoard.categorias = scategorias;

            DateTime hoy = DateTime.Now.Date;
            DateTime fechaLunes = hoy.AddDays(-(int)DateTime.Now.DayOfWeek);
            DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dashoard.dashBoardGlobales = new DashBoardGlobales
            {
                Hoy = totales.Where(c=>c.FechaAsignacion >= hoy).Count(),
                TotalPendientes = totales.Where(c => c.Estado == PacientesPorEmitir.EstadoConcepto.Por_Emitir).Count(),
                UltimaSemana = totales.Where(c => c.FechaAsignacion >= fechaLunes && c.Estado != PacientesPorEmitir.EstadoConcepto.Anulado).Count(),
                UltimoMes = totales.Where(c => c.FechaAsignacion >= inicioMes && c.Estado != PacientesPorEmitir.EstadoConcepto.Anulado).Count()
            };
            return Ok(dashoard);
        }

        [HttpGet("{pacienteId:int}/Incapacidades")]
        public async Task<IActionResult> IncapacidadesPorPaciente(int pacienteId, [FromQuery] string busqueda = "", [FromQuery] int pagina = 1)
        {
            int cantidad = 10;
            var diagnosticosIncapacidades = await _conceptoRehabilitacionService.Incapacidades(pacienteId, busqueda, (pagina - 1) * cantidad, cantidad);
            var total = await _conceptoRehabilitacionService.Incapacidades(pacienteId, busqueda, null, null);
            //var diagnosticos = await _cie10Service.GetCie10();

            List<DiagnosticoIncapacidadOutputModel> diagnosticoIncapacidadOutputModels = _mapper.Map<List<DiagnosticoIncapacidadOutputModel>>(diagnosticosIncapacidades);

            foreach (DiagnosticoIncapacidadOutputModel diom in diagnosticoIncapacidadOutputModels)
            {
                var cie10List = diagnosticosIncapacidades.Where(c => c.IIddiagnosticoIncapacidad == diom.id).First().TblCie10DiagnosticoIncapacidad;
                var cie10 = cie10List.Select(c => c.IIdcie10Navigation).Where(c => c.TCaracter != "R").FirstOrDefault();
                diom.CIE10 = cie10.TCie10;
                diom.DescripcionSintomatologica = cie10.TDescripcion;
            }
            DiagnosticosIncapacidadesOutputModel diagnosticosIncapacidadesOutputModels = new DiagnosticosIncapacidadesOutputModel
            {
                diagnosticoIncapacidadOutputModels = diagnosticoIncapacidadOutputModels,
                paginacion = new PaginacionModel(total.Count(), pagina, cantidad)
            };
            return Ok(diagnosticosIncapacidadesOutputModels);
        }


        /*public int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }*/

        private int ObtenerSemana(DateTime fecha, List<Tuple<DateTime, DateTime>> weeks) {
            int semana = 1;
            foreach (var item in weeks)
            {
                if (fecha >= item.Item1 && fecha <= item.Item2.AddHours(23))
                    return semana;
                semana++;
            }
            return semana;
        }

    }
}