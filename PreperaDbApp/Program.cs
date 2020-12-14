using Microsoft.EntityFrameworkCore;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataInitiazation;
using System;

namespace PreperaDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            sBaseContextFactory factory = new sBaseContextFactory();
            using (sBaseContext context = factory.CreateDbContext("server=DESKTOP-P7SS3RO;database=SecretDb;Integrated Security=True;App=EntityFramework"))
            {
                DataInitiazer.RecreateDatabase(context);
                DataInitiazer.InitializeData(context);
            }

        }
    }
}
