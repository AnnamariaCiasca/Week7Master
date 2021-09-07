using Microsoft.EntityFrameworkCore;
using System;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF
{
    public class MasterContext : DbContext
    {
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }
        public DbSet<Docente> Docenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		                                  Database = CorsiMaster;
                                          Trusted_Connection = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
