using System.Collections.Generic;
using AutoMapper;
using Kustodya.Medicos.Data;

namespace Roojo.Rethus
{
    public partial class Consulta
    {
        public class ConsultasFabric : IConsultasFabric
        {
            private IMapper _mapper;

            public ConsultasFabric(IMapper mapper)
            {
                _mapper = mapper;
            }

            public Consulta NuevaDesdeMedicoPorTipoDeIdentificacion(Medico medico)
            {
                TipoIdentificacionRethus tipoIdentificacion = TipoIdentificacionRethus.Cédule_de_Ciudadanía;
                switch(medico.TipoIdentificacion){
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Ciudadanía:
                        tipoIdentificacion = TipoIdentificacionRethus.Cédule_de_Ciudadanía;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Cédula_de_Extranjería:
                        tipoIdentificacion = TipoIdentificacionRethus.Cédula_de_Extranjería;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.CN_Certificado_de_Nacido_Vivo:
                        tipoIdentificacion = TipoIdentificacionRethus.CN_Certificado_de_Nacido_Vivo;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Nit:
                        tipoIdentificacion = TipoIdentificacionRethus.Nit;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Pasaporte:
                        tipoIdentificacion = TipoIdentificacionRethus.Pasaporte;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.PE_Permiso_Especial_de_Permanencia:
                        tipoIdentificacion = TipoIdentificacionRethus.PE_Permiso_Especial_de_Permanencia;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Resgistro_Civil:
                        tipoIdentificacion = TipoIdentificacionRethus.Resgistro_Civil;
                        break;
                    case Kustodya.Medicos.Data.Medicos.TiposDeDocumentoDeIdentificacion.Tarjeta_de_Identidad:
                        tipoIdentificacion = TipoIdentificacionRethus.Tarjeta_de_Identidad;
                        break;
                    default:
                        break;
                }
                 //_mapper.Map<TipoIdentificacionRethus>(medico.TipoIdentificacion);

                return new Consulta
                {
                    NumeroIdentificacion = medico.NumeroIdentifiacion ?? medico.NumeroIdentificacion,
                    TipoIdentificacion = tipoIdentificacion,
                    TipoBusqueda = TipoDeBusqueda.PorDocumentoDeIdentificacion,
                    Estado = Consulta.Estados.PorHacer
                };
            }
        }
    }
}
