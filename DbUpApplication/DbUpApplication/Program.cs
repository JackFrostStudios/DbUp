using System;
using DbUpApplication.DbUp;
using DbUpApplication.Model;
using DbUpApplication.UI;

namespace DbUpApplication
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            //Run DbUp
            Console.WriteLine("Running DbUp, would you like to seed data? (Y/N)");
            var seedData = Console.ReadLine() == "Y";

            var dbManager = new DatabaseManager("FilmDb", seedData);
            dbManager.CreateDatabase();
            var upgradeResult = dbManager.Upgrade();

            if (!upgradeResult.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DbUp did not complete successfully.");
                Console.WriteLine(upgradeResult.Error);
                Console.WriteLine("Please press any key to exit");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.WriteLine("DbUp ran successfully");
#endif

            using (var dbContext = new FilmDbContext("FilmDb"))
            {
                try
                {
                    dbContext.Database.CompatibleWithModel(true);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Database does not match model, press any key to exit...");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("Success! Database matches EF model.");
            }

            //Main App
            var controller = new Controller("FilmDb");

            controller.Start();
        }
    }
}
