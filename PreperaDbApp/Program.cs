using Microsoft.EntityFrameworkCore;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataInitiazation;
using System;
using System.Runtime.InteropServices;

namespace PreperaDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppIdentityContextFactory factory = new AppIdentityContextFactory();
            IdentityDataInitializer dataInitializer = new IdentityDataInitializer();
            using (var context = factory.CreateDbContext(args))
            {
                    dataInitializer.RecreateDatabase(context,true);
            }

            Console.WriteLine("Ready!");
            Console.ReadLine();
            //sBaseContextFactory factory = new sBaseContextFactory();
            //using (sBaseContext context = factory.CreateDbContext("server=DESKTOP-P7SS3RO;database=SecretDb;Integrated Security=True;App=EntityFramework"))
            //{
            //    SBaseDataInitializer.RecreateDatabase(context);
            //    SBaseDataInitializer.InitializeData(context);
            //}
        }
    }
}
