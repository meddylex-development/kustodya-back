using System;
using Kustodya.Core.Entities;
using Kustodya.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kustodya.Infrastructure.Data
{
    public static class EfSsqlRepositoryExtensions
    {
        public static void AgregarEfSqlRepository<TAggregate, TContext>(this IServiceCollection servicios, Action<EfSqlRepositoryOptions> opciones)
            where TAggregate : BaseEntity, IAggregateRoot
            where TContext : DbContext
        {
            servicios.Configure(opciones);
            var opcionesSql = servicios.BuildServiceProvider().GetService<IOptionsMonitor<EfSqlRepositoryOptions>>().CurrentValue;
            servicios.AddDbContext<TContext>(o =>
            {
                o.UseSqlServer(opcionesSql.ConnectionString);
            });
            servicios.AddScoped(typeof(IAsyncRepository<TAggregate>), typeof(EfSqlRepository<TAggregate, TContext>));
        }
    }
}