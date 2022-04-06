using System.Threading.Tasks;
using Kustodya.ApplicationCore.Dtos;
using Kustodya.ApplicationCore.DTOs;
using Kustodya.WebApi.Models;

namespace Kustodya.WebApi.Services
{
    public interface IPerfilesOutputModelService
    {
        Task<PerfilesOuputModel> GetPerfilesOutputModelAsync(string nombre, int pagina = 0);
        Task<PerfilConDetalleOutputModel> GetPerfilOutputModelAsync(int id);
    }
}