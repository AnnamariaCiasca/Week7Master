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
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> modelBuilder)
        {
            modelBuilder.ToTable("Corso");
            modelBuilder.HasKey(c => c.CodiceCorso);
            modelBuilder.Property(c => c.Nome).IsRequired();
            modelBuilder.Property(c => c.Descrizione).IsRequired();

            //Relazione Corso 1 -> Studenti n (uno a molti)
            modelBuilder.HasMany(c => c.Studenti).WithOne(s => s.Corso).HasForeignKey(s => s.CodiceCorso);

            //Relazione Corso 1 -> Lezioni n (uno a molti)
            modelBuilder.HasMany(c => c.Lezioni).WithOne(l => l.Corso).HasForeignKey(l => l.CodiceCorso);
        }
    }
}