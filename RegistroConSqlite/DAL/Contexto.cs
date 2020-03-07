using Microsoft.EntityFrameworkCore;
using RegistroConSqlite.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroConSqlite.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Personas.db");
        }
    }
}
