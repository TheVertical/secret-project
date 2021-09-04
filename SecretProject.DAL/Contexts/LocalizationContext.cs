using System;
using Microsoft.EntityFrameworkCore;
using SecretProject.BusinessProject.Models.Common;
using SecretProject.BusinessProject.Models.Other;

namespace SecretProject.DAL.Contexts
{
    public class LocalizationContext : DbContext
    {
        #region Localize
        internal DbSet<Language> Languages { get; set; }

        internal DbSet<LocalizedString> LocalizedString { get; set; }
        #endregion

        public LocalizationContext(DbContextOptions<LocalizationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Context is not configured!");
            }
        }
    }
}
