using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            //Primary key
            builder.HasKey(m => m.Id);

            //2. Properties
            builder.Property(m => m.UsuarioId)
                .IsRequired();
            builder.Property(m => m.TurmaId)
                .IsRequired();

            //3. Relationships
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.TurmaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
