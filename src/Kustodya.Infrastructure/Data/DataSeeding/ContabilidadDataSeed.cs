using Kustodya.ApplicationCore.Entities.Contabilidades;
using Kustodya.Infrastructure.Data.Contabilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kustodya.Infrastructure.Data
{
    public class ContabilidadContextSeed
    {
        public static async Task SeedAsync(ContabilidadContext ContabilidadContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!ContabilidadContext.Contabilidades.Any())
                {
                    ContabilidadContext.Contabilidades.AddRange(
                        GetPreconfiguredCondabilidades());

                    await ContabilidadContext.SaveChangesAsync();
                }

                if (!ContabilidadContext.Pucs.Any())
                {
                    ContabilidadContext.Pucs.AddRange(
                        GetPreconfiguredPucs(ContabilidadContext.Contabilidades.Select(c => c.Id).ToList()));

                    await ContabilidadContext.SaveChangesAsync();
                }

                await Sembrador<ClaseDocumento>
                    .SembrarAsync(
                        ContabilidadContext, 
                        GetPreconfiguredClasesDocumento(
                            ContabilidadContext.Contabilidades.Select(c => c.Id).ToList()));

                await Sembrador<TipoAjuste>
                    .SembrarAsync(ContabilidadContext, GetPreconfiguredTiposAjuste());
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ContabilidadContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(ContabilidadContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<Contabilidad> GetPreconfiguredCondabilidades()
        {
            return new List<Contabilidad>()
                {
                    new Contabilidad(1, "1231", "Roojo Australia"),
                    new Contabilidad(1, "1233", "Roojo Colombia"),
                    new Contabilidad(1, "1234", "Famisanar zona norte"),
                    new Contabilidad(1, "1235", "Sanitas EPS")
                };
        }

        static IEnumerable<Puc> GetPreconfiguredPucs(IEnumerable<Guid> contabilidadesId)
        {
            return new List<Puc>()
                {
                    new Puc("410505","Cultivo de cereales", contabilidadesId.First(), Puc.TiposContabilidad.Kustodya, 1),
                    new Puc("410510","Cultivos de hortalizas, legumbres y plantas ornamentales", contabilidadesId.First(), Puc.TiposContabilidad.Kustodya, 1),
                    new Puc("410515","Cultivos de frutas, nueces y plantas aromáticas", contabilidadesId.ElementAt(2), Puc.TiposContabilidad.Kustodya, 1),
                    new Puc("410520","Cultivo de café", contabilidadesId.ElementAt(2), Puc.TiposContabilidad.Kustodya, 1),
                    new Puc("410525","Cultivo de flores", contabilidadesId.First(), Puc.TiposContabilidad.Otro, 1),
                    new Puc("410530","Cultivo de caña de azúcar", contabilidadesId.First(), Puc.TiposContabilidad.Otro, 1)
                };
        }

        static IEnumerable<ClaseDocumento> GetPreconfiguredClasesDocumento(IList<Guid> contabilidadesId)
        {
            return new List<ClaseDocumento>()
                {
                    new ClaseDocumento(contabilidadesId.First(), "Ficha General"),
                    new ClaseDocumento(contabilidadesId.First(), "Ficha Minuciosa"),
                    new ClaseDocumento(contabilidadesId.First(), "Ficha Minuciosa"),
                    new ClaseDocumento(contabilidadesId.First(), "Ficha Minuciosa"),
                    new ClaseDocumento(contabilidadesId.ElementAt(2), "Ficha Positiva"),
                    new ClaseDocumento(contabilidadesId.ElementAt(2), "Ficha Negativa"),
                };
        }

        static IEnumerable<TipoAjuste> GetPreconfiguredTiposAjuste()
        {
            return new List<TipoAjuste>()
                {
                    new TipoAjuste("Por fecha", new Guid()),
                    new TipoAjuste("A la medida", new Guid()),
                    new TipoAjuste("Al cero", new Guid()),
                    new TipoAjuste("Por corte", new Guid()),
                };
        }
    }

    public static class Sembrador<TEntity> where TEntity : class
    {
        public static async Task SembrarAsync(DbContext context, IEnumerable<TEntity> set)
        {
            if (!context.Set<TEntity>().Any())
                {
                    context.Set<TEntity>().AddRange(set);

                    await context.SaveChangesAsync();
                }
        }
    }
}
