using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Master.Core.Entities;

namespace Week7Master.RepositoryEF.Configurations
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> modelBuilder)
        {
            modelBuilder.ToTable("Docente");
            modelBuilder.HasKey(d => d.Id);
            modelBuilder.Property(d => d.Nome).IsRequired();
            modelBuilder.Property(d => d.Cognome).IsRequired();
            modelBuilder.Property(d => d.Email).IsRequired();
            modelBuilder.Property(d => d.Telefono).IsRequired().HasMaxLength(10);

            //Relazione Docente 1 -> Lezione n (uno a molti)
            modelBuilder.HasMany(d => d.Lezioni).WithOne(l => l.Docente).HasForeignKey(d => d.IdDocente);
        }
    }
}
