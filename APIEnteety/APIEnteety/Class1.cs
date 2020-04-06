using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIEnteety
{
    class Class1
    {
        public class ApplicationContext : DbContext
        {
            public DbSet<Passengers> Passengers { get; set; }
            public DbSet<Flinghts> Flinghts { get; set; }

            public ApplicationContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Flightsdb;Trusted_Connection=True;");
            }
        }
    }
}
