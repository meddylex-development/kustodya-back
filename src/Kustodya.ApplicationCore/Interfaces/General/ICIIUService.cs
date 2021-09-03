using Kustodya.ApplicationCore.Dtos.General;
using System.Threading.Tasks;

namespace Kustodya.ApplicationCore.Interfaces.General
{
    public interface ICIIUService
    {
        Task<ActividadEconomicaModel> GetCIIUById(short? idactividadEconomica1);
    }
}