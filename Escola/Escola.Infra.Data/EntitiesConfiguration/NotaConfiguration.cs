using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class NotaConfiguration : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.HasKey(n => n.Id);

            // Configurações adicionais para as propriedades
            builder.Property(n => n.ValorNota)
                .IsRequired();
            builder.Property(n => n.MatriculaId)
                .IsRequired();

            // Relacionamento entre Nota e Matricula
            builder.HasOne(x => x.Matriculas)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.MatriculaId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
