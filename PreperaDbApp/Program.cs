using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataInitiazation;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SecretProject.DevTools
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                var command = Console.ReadLine();
            }

            IdentityContextFactory factory = new IdentityContextFactory();
            IdentityDataInitializer dataInitializer = new IdentityDataInitializer();
            using (var context = factory.CreateDbContext(args))
            {
                    dataInitializer.RecreateDatabase(context,true);
            }

            Console.WriteLine("Ready!");
            Console.ReadLine();
            //MainContextFactory factory = new MainContextFactory();
            //using (sBaseContext context = factory.CreateDbContext("server=DESKTOP-P7SS3RO;database=SecretDb;Integrated Security=True;App=EntityFramework"))
            //{
            //    SBaseDataInitializer.RecreateDatabase(context);
            //    SBaseDataInitializer.InitializeData(context);
            //}
        }
    }

    public class CommandParser
    {
        public void ParseCommand(string commandLine)
        {
        }
    }

}
