using System;
using DbUpApplication.DbUp;
using DbUpApplication.UI;

namespace DbUpApplication
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            //Run DbUp
            var dbManager = new DatabaseManager("FilmDb");
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

            //Main App
            var controller = new Controller();

            controller.Start();
        }
    }
}
