namespace Kustodya.Infrastructure.Data
{
    public class EfSqlRepositoryOptions
    {
        public const string Area = "SqlServer";
        public string ConnectionString { get; set; }
    }
}