using DbUp;
using System.Reflection;
using DbUp.Engine;

namespace DbUpApplication.DbUp
{
    public class DatabaseManager
    {
        private string _connectionString;
        private UpgradeEngine _upgradeEngine;

        public DatabaseManager(string connectionName, bool seedData)
        {
            _connectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            if (seedData)
            {
                _upgradeEngine = DeployChanges.To
                    .SqlDatabase(_connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith("DbUpApplication.DbUp.UpgradeScripts"))
                    .LogToConsole()
                    .Build();
            }
            else
            {
                _upgradeEngine = DeployChanges.To
                    .SqlDatabase(_connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), s => s.StartsWith("DbUpApplication.DbUp.UpgradeScripts") && s.Contains("Seed_Data") == false)
                    .LogToConsole()
                    .Build();
            }

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