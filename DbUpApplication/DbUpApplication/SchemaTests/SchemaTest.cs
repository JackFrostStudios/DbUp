using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUpApplication.DbUp;
using DbUpApplication.Model;
using Ef6SchemaCompare;
using NUnit.Framework;

namespace DbUpApplication.SchemaTests
{
    [TestFixture]
    class SchemaTest
    {
        [SetUp]
        public void RunBeforeAllTests()
        {
            var dbUpManager = new DatabaseManager("dbUpTestDb");
            dbUpManager.CreateDatabase();
            dbUpManager.Upgrade();
        }

        [TearDown]
        public void RunAfterAllTests()
        {
            System.Data.Entity.Database.Delete("dbUpTestDb");
            System.Data.Entity.Database.Delete("efTestDb");
        }

        [Test]
        public void EfToSchemaTest()
        {
            using (var dbContext = new FilmDbContext("dbUpTestDb"))
            {
                var comparer = new CompareEfSql();
                var status = comparer.CompareEfWithDb(dbContext);

                Assert.True(status.IsValid, status.GetAllErrors());
                Assert.False(status.HasWarnings, string.Join("\n", status.Warnings));
            }
        }

        [Test]
        public void SqlToSqlTest()
        {
            using (var dbContext = new FilmDbContext("efTestDb"))
            {
                dbContext.Database.Delete();
                dbContext.Database.CreateIfNotExists();
                var comparer = new CompareSqlSql();
                var status = comparer.CompareSqlToSql("efTestDb", "dbUpTestDb");

                Assert.True(status.IsValid, status.GetAllErrors());
                Assert.False(status.HasWarnings, string.Join("\n", status.Warnings));
            }
        }

        [Test]
        public void EFGeneratedToSqlTest()
        {
            using (var dbContext = new FilmDbContext())
            {
                var comparer = new CompareSqlSql();
                var status = comparer.CompareEfGeneratedSqlToSql(dbContext, "dbUpTestDb");

                Assert.True(status.IsValid, status.GetAllErrors());
                Assert.False(status.HasWarnings, string.Join("\n", status.Warnings));
            }
        }
    }
}
