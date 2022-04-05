using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace Kustodya.Medicos.Services
{
    //public class MedicosOutputModelService : IMedicosOutputModelService
    //{
    //    public MedicosOutputModelService(IMapper mapper, IMedicoService service)
    //    {
    //        _mapper = mapper;
    //        _medicoService = service;
    //    }

    //    private readonly IMapper _mapper;
    //    private readonly IMedicoService _medicoService;

    //    //public async Task<MedicoOutputModel> GetMedicoOutputModel(InputModel medicosInputModel, string peticion)
    //    //{
    //    //    // Servicio que consulta medico
    //    //    Medico medico = await _medicoService.GetMedicoAsync(medicosInputModel.NumeroIdentificacion, medicosInputModel.TipoIdentificacion, Guid.NewGuid());

    //    //    // Convertir Medico en MedicoOutputModel
    //    //    var medicosOutpuModel = (MedicoOutputModel)_mapper.Map(medico, typeof(Medico), typeof(MedicoOutputModel));

    //    //    return medicosOutpuModel;
    //    //}

    //    //public async Task<MedicoOutputModel[]> GetMedicosOutputModel(List<InputModel> medicosInputModel, Guid peticionId)
    //    //{
    //    //    // Servicio que pagina y consulta medicos
    //    //    List<Medico> medicos = await _medicoService.GetMedicosAsync(medicosInputModel, peticionId);

    //    //    // Convertir Medico en MedicoOutputModel
    //    //    var medicosOutpuModel = (List<MedicoOutputModel>)_mapper.Map(medicos,typeof(List<Medico>), typeof(List<MedicoOutputModel>));

    //    //    return medicosOutpuModel.ToArray();
    //    //}

    //}
}
