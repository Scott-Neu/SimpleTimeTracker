using MigSharp;
using System;
using System.Configuration;
using System.Reflection;

namespace SimpleTimeTracker.DataMigrations
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eventArgs) => {
                eventArgs.Cancel = true;
                Environment.Exit(1);
            };

            string connectionString = string.Empty;
            try
            {
                if (args.Length == 1) // expand this later if needed for named params - could add bypass for prompt, etc.
                {
                    connectionString = args[0].ToString();
                }
                else
                {
                    connectionString = ConfigurationManager.ConnectionStrings["SimpleTimeTracker"].ToString();
                }

                var migrator = new Migrator(connectionString, DbPlatform.SqlServer2014);
                var migrations = migrator.FetchMigrations(Assembly.GetExecutingAssembly());

                Console.WriteLine($"Executing migrations for {connectionString}.");
                Console.WriteLine($"{migrations.Steps.Count} are pending.");
                Console.WriteLine("Press any key to continue or Ctl-C to abort.");
                Console.ReadKey();
                
                migrations.Execute();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown trying to migrate the database with connection {connectionString}.");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return 1;
            }
        }
    }
}
