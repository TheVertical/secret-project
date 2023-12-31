﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Common;
using SecretProject.BusinessProject.Models.Order;
using SecretProject.BusinessProject.Models.UserData;
using SecretProject.VisualElements.Elements;
using SecretProject.VisualElements.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using SecretProject.BusinessProject.Models.Measurements;
using SecretProject.BusinessProject.Models.Nomenclature;
using SecretProject.BusinessProject.Models.Other;
using SecretProject.BusinessProject.Models.Vendor;

namespace SecretProject.DAL.Contexts
{
    public class MainContext : DbContext
    {
        #region BaseSettings
        internal DbSet<Company> Companies { get; set; }
        #endregion

        #region Nomenclature
        internal DbSet<Nomenclature> Nomenclatures { get; set; } 
        internal DbSet<NomenclatureGroup> NomenclatureGroups { get; set; }
        internal DbSet<NomenclatureProperty> NomenclatureProperties { get; set; }
        internal DbSet<Promotion> Promotions { get; set; }
        internal DbSet<Manufacturer> Manufacturers { get; set; }
        internal DbSet<Measurement> Measurements { get; set; }
        #endregion

        #region Order
        internal DbSet<Order> Orders { get; set; } 
        internal DbSet<OrderDetails> OrderDetails{ get; set; }
        internal DbSet<OrderItem> OrderItems { get; set; }
        #endregion

        #region User
        internal DbSet<Adress> Adresses { get; set; }
        #endregion

        #region Design elements
        public DbSet<Page> Pages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        #endregion

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                throw new Exception("Context is not configured!");
            }
        }


    }
}
