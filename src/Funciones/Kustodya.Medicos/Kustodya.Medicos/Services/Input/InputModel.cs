using System.Collections.Generic;
using System.Linq;
using TinyCsvParser.Mapping;
using Kustodya.Medicos.Models;
using Kustodya.Medicos.Services.Input;
using System.Text.RegularExpressions;

namespace Kustodya.Medicos.Input
{
    public sealed class InputModel
    {
        public InputModel(ICollection<ResultadoDeMapeo> csvConvertido)
        {
            CsvConvertido = csvConvertido;
        }

        public ICollection<ResultadoDeMapeo> CsvConvertido { get; private set; }
        public ICollection<Registro> Validos { get => CalcularValidos(); }
        public ICollection<Registro> Convertibles { get => CalcularConvertibles(); } // Procesados en Cosmos
        public ICollection<Registro> Unicos { get => CalcularUnicos(); }
        public int TotalSubido { get => CsvConvertido.Count(); }
        public ICollection<Registro> DuplicadosValidosDistintos { get => CalcularValidosDuplicados(); }
        public int TotalDuplicados { get => Validos.Count() - Unicos.Count(); }

        public static class Fabrica
        {
            public static InputModel CrearDesdeCsvConvertido(ICollection<ResultadoDeMapeo> csvConvertido) => new InputModel(csvConvertido);
        }

        private ICollection<Registro> CalcularValidosDuplicados()
        {
            return Validos
                .GroupBy(v => v)
                .Where(g => g.Count() > 1)
                .SelectMany(w => w)
                .Distinct()
                .ToList();
        }
        private ICollection<Registro> CalcularUnicos()
        {
            return Validos.Distinct()
                .ToList();
        }
        private ICollection<Registro> CalcularValidos()
        {
            return Convertibles
                .Where(r => Regex.IsMatch(r.NumeroIdentificacion, @"^\d+$"))
                .ToList();
        }
        private ICollection<Registro> CalcularConvertibles()
        {
            return CsvConvertido
                .Where(c => c.EsValido)
                .Select(v => v.Registro)
                .ToList();
        }
    }
}
