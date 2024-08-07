using Application.Common.Interfaces;

namespace Infrastructure.Persistence
{
    public class NoSQLDatabaseSettings : INoSQLDatabaseSettings
    {
        public NoSQLDatabaseSettings(string databaseName, string connectionString)
        {
            DatabaseName = databaseName;
            ConnectionString = connectionString;
        }

        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
