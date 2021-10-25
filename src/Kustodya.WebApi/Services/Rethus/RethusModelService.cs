using ClosedXML.Excel;
using Kustodya.ApplicationCore.DTOs.Rethus;
using Kustodya.ApplicationCore.Entities.Rethus;
using Kustodya.ApplicationCore.Interfaces;
using Kustodya.ApplicationCore.Specifications.Rethus;
using Kustodya.WebApi.Models.Rethus;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.WebApi.Services.Rethus
{
    public class RethusModelService : IRethusModelService
    {
        private readonly IAsyncRepository<tblRethusIdentificationTypes> _rethusIdentificationRepo;
        private readonly IAsyncRepository<tblRethusData_Main> _rethusData_Main;
        private readonly IAsyncRepository<tblRethusData_Academic> _rethusData_Academic;
        private readonly IAsyncRepository<tblRethusData_Sanctions> _rethusData_Sanctions;
        private readonly IAsyncRepository<tblRethusData_SSO> _rethusData_SSO;
        private readonly IAsyncRepository<tblRethusTasks> _rethusTasks;
        private readonly IAsyncRepository<tblRethusQuerys> _rethusQuerys;
        public RethusModelService(IAsyncRepository<tblRethusIdentificationTypes> rethusIdentificationRepo,
            IAsyncRepository<tblRethusData_Main> rethusDataMain,
            IAsyncRepository<tblRethusData_Academic> rethusDataAcademic,
            IAsyncRepository<tblRethusData_Sanctions> rethusDataSantions,
            IAsyncRepository<tblRethusData_SSO> rethusDataSso,
            IAsyncRepository<tblRethusTasks> rethusTasks,
            IAsyncRepository<tblRethusQuerys> rethusQuerys) {
            _rethusIdentificationRepo = rethusIdentificationRepo;
            _rethusData_Main = rethusDataMain;
            _rethusData_Academic = rethusDataAcademic;
            _rethusData_Sanctions = rethusDataSantions;
            _rethusData_SSO = rethusDataSso;
            _rethusTasks = rethusTasks;
            _rethusQuerys = rethusQuerys;
        }
        public async Task<IEnumerable<tblRethusIdentificationTypes>> GetIdentificaciones() {
            return await _rethusIdentificationRepo.ListAllAsync();
        }
        public async Task<IEnumerable<tblRethusData_Main>> GetMedicos(string documento, string tipo, string PrimerNombre, string PrimerApellido)
        {
            var spec = new ConsultaRethus(documento, tipo, PrimerNombre, PrimerApellido);
            return await _rethusData_Main.ListAsync(spec);
        }
        public async Task<IEnumerable<tblRethusData_Academic>> GetAcademicos(int iIDRethusQuery)
        {
            var spec = new ConsultarAcademicosporId(iIDRethusQuery);
            return await _rethusData_Academic.ListAsync(spec);
            
        }
        public async Task<IEnumerable<tblRethusData_Sanctions>> GetSanciones(int iIDRethusQuery)
        {
            var spec = new ConsultarSancionesporId(iIDRethusQuery);
            return await _rethusData_Sanctions.ListAsync(spec);
        }
        public async Task<IEnumerable<tblRethusData_SSO>> GetSso(int iIDRethusQuery)
        {
            var spec = new ConsultarSSOporId(iIDRethusQuery);
            return await _rethusData_SSO.ListAsync(spec);
        }
        public async Task AddTask(string typeId, string numberId ) {
            int tipo = 0;
            if (typeId == "CE")
            {
                tipo = 2;
            }
            else
            {
                tipo = 1;
            }

            tblRethusTasks rethusTasks = new tblRethusTasks
            {
                iIDAllocatorUser = 0,
                iIDTaskType = 1,
                iIDPriority = 1,
                iIDTaskState = 1, //TO DO
                dtAllocatedDate = DateTime.Now
            };
            await _rethusTasks.AddAsync(rethusTasks);

            tblRethusQuerys rethusQuerys = new tblRethusQuerys
            {
                iIDTask = rethusTasks.iIDTask,
                iIDSearchType = 1,
                iIDQueryState = 5, // TO DO
                iIDRethusIdentificationType = tipo,
                tIdentificationNumber = numberId
            };
            await _rethusQuerys.AddAsync(rethusQuerys);
        }
        public IReadOnlyList<CargueInputModel> GetInputModel(DataTable dt)
        {
            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }
            //if (dt.Select("[Código Contabilidad] <>''", "[Código Contabilidad] desc").Length == 0)
                //throw new Exception("Debe diligenciar todos los campos de cada fila");

            //Eliminar filas sin código de contabilidad
            //dt = dt.Select("[Tipo I] <>''", "[Código Contabilidad] desc").CopyToDataTable();

            //Validar existencia de registros en el archivo
            if (dt.Rows.Count == 0)
            {
                throw new Exception("El archivo no contiene información");
            }

            //Validar cantidad de columnas
            if (dt.Columns.Count != 2)
            {
                throw new Exception("La cantidad de columnas no corresponde con la estructura requerida " +
                    "(2 columnas: Tipo de identificación, Número de identificación)");
            }

            //Pasar DataTable a Listado de PucInputModel
            List<CargueInputModel> cargueRethus = new List<CargueInputModel>();
            foreach (DataRow item in dt.Rows)
            {
                if (item[0].ToString() == "" || item[1].ToString() == "")
                    throw new Exception("Hay campos sin diligenciar en el archivo cargado");

                CargueInputModel cargue= new CargueInputModel
                {
                    TipoIdentificacion = item[0].ToString(),
                    NumIdentificacion = item[1].ToString()
                };
                cargueRethus.Add(cargue);
            }
            return cargueRethus;
        }
        public async Task CrearTareaRobot(IReadOnlyList<CargueInputModel> cargueInputModels, int entidadId)
        {
            //Crear registro en la tabla de tarea de rethus
            if (cargueInputModels.Count == 0)
                return;
            var tarea = new tblRethusTasks
            {
                iIDAllocatorUser = 0,
                iIDTaskType = 2,
                iIDPriority = 1,
                iIDTaskState = 1,
                dtAllocatedDate = DateTime.Now
            };
            await _rethusTasks.AddAsync(tarea);

            foreach (var item in cargueInputModels)
            {
                await _rethusQuerys.AddAsync(new tblRethusQuerys {
                    iIDTask = tarea.iIDTask,
                    iIDSearchType = 1,
                    iIDQueryState = 5,
                    iIDRethusIdentificationType = Convert.ToInt32(item.TipoIdentificacion),
                    tIdentificationNumber = item.NumIdentificacion,
                    iIDEntidad = entidadId
                });
            }
        }
        public async Task<List<CargueOutputModel>> GetCargues(int entidadId, int? skip = 10, int? take = 10) {
            var spec = new TareasporCargue(skip, take);
            var tareas = await _rethusTasks.ListAsync(spec);
            var specqueries = new QueriesporTask(1);

            List<CargueOutputModel> cargueOutputModels = new List<CargueOutputModel>();
            foreach (var item in tareas)
            {
                var cargueOutput = new CargueOutputModel
                {
                    taskId = item.iIDTask,
                    fecha = item.dtAllocatedDate
                };
                switch (item.iIDTaskState)
                {
                    case 1:
                        cargueOutput.estado = "To Do";
                        break;
                    case 2:
                        cargueOutput.estado = "In Progress";
                        break;
                    case 3:
                        cargueOutput.estado = "Succesful";
                        break;
                    case 4:
                        cargueOutput.estado = "Pause";
                        break;
                    default:
                        break;
                }
                var queryspec = new QueriesporTask(cargueOutput.taskId);
                var queries = await _rethusQuerys.ListAsync(queryspec);
                cargueOutput.cantidadregistros = queries.Count;
                cargueOutputModels.Add(cargueOutput);
            }
            return cargueOutputModels;
        }
        public async Task<byte[]> ExportarCargue(int taskId) {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("Cargue rethus");
                worksheet.Cell(1, 1).Value = "Tipo identificación";
                worksheet.Cell(1, 2).Value = "Número identificación";
                worksheet.Cell(1, 3).Value = "Primer nombre";
                worksheet.Cell(1, 4).Value = "Segundo nombre";
                worksheet.Cell(1, 5).Value = "Primer apellido";
                worksheet.Cell(1, 6).Value = "Segundo apellido";

                int index = 2;
                var spec = new QueriesporTask(taskId);
                var queries = await _rethusQuerys.ListAsync(spec);
                
                List<MedicoOutputModel> medicoOutputModels = new List<MedicoOutputModel>();
                foreach (var item in queries)
                {
                    var tipo = "";
                    if(item.iIDRethusIdentificationType == 1)
                        tipo = "CC";
                    var specMain = new RethusMainporTipoidyNumId(tipo, item.tIdentificationNumber);
                    var medico = (await _rethusData_Main.ListAsync(specMain)).FirstOrDefault();
                    if (medico != null)
                    {
                        medicoOutputModels.Add(new MedicoOutputModel
                        {
                            TipoIdentificacion = medico.tTipoIdentificacion,
                            NumeroIdentificacion = medico.tNrodentificacion,
                            PrimerNombre = medico.tPrimerNombre,
                            SegundoNombre = medico.tSegundoNombre,
                            PrimerApellido = medico.tPrimerApellido,
                            SegundoApellido = medico.tSegundoApellido
                        });
                    }
                    else {
                        medicoOutputModels.Add(new MedicoOutputModel
                        {
                            TipoIdentificacion = item.iIDRethusIdentificationType.ToString(),
                            NumeroIdentificacion = item.tIdentificationNumber
                        }); ;
                    }
                }

                foreach (var item in medicoOutputModels)
                {
                    worksheet.Cell(index, 1).Value = item.TipoIdentificacion;
                    worksheet.Cell(index, 2).Value = item.NumeroIdentificacion;
                    worksheet.Cell(index, 3).Value = item.PrimerNombre;
                    worksheet.Cell(index, 4).Value = item.SegundoNombre;
                    worksheet.Cell(index, 5).Value = item.PrimerApellido;
                    worksheet.Cell(index, 6).Value = item.SegundoApellido;
                    index++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
        public async Task<int> TotalCargues(int entidadId)
        {
            var spec = new TareasporCargue(0, int.MaxValue);
            var total = await _rethusTasks.CountAsync(spec);
            return total;
        }
    }
}
