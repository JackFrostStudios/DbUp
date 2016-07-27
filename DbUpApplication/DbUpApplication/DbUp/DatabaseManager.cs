using DbUp;
using System.Reflection;
using DbUp.Engine;

namespace DbUpApplication.DbUp
{
    public class DatabaseManager
    {
        private string _connectionString;
        private UpgradeEngine _upgradeEngine;

        public DatabaseManager(string connectionName)
        {
            _connectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            _upgradeEngine = DeployChanges.To
                .SqlDatabase(_connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();
        }

        public DatabaseUpgradeResult Upgrade()
        {
            return _upgradeEngine.PerformUpgrade();
        }

        public void CreateDatabase()
        {
            EnsureDatabase.For.SqlDatabase(_connectionString);
        }
    }
}