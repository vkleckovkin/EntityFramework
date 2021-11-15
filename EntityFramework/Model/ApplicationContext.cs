using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Model
{
    class ApplicationContext:DbContext
    {
        public DbSet<Incident> incidents { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=incidentsDBNew;Trusted_Connection=True;");
        }
    }
}
