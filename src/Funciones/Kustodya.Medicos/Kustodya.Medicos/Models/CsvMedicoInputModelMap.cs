using Kustodya.Medicos.Services.Input;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;
using Kustodya.Medicos.Data.Medicos;

namespace Kustodya.Medicos.Models
{
    public class CsvMedicoInputModelMap : CsvMapping<Registro>
    {
        public CsvMedicoInputModelMap()
            : base()
        {
            MapProperty(0, x => x.TipoIdentificacion, new EnumConverter<TiposDeDocumentoDeIdentificacion>());
            MapProperty(1, x => x.NumeroIdentificacion);
        }
    }

}