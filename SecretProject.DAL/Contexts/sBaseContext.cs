﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.DAL.Contexts
{
    public class sBaseContext : DbContext
    {
        internal DbSet<Nomenclature> Nomenclatures { get; set; } 
        internal DbSet<NomenclatureGroup> NomenclatureGroups { get; set; }
        internal DbSet<NomenclatureProperty> GetNomenclatureProperties { get; set; }
        internal DbSet<Manufacturer> Manufacturers { get; set; } 

        public sBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var connectionString = @"server=DESKTOP-P7SS3RO;database=SecretDb;User Id = root;Password = 123;App=EntityFramework";
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
                    //.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.Query));
            }
        }


    }
}