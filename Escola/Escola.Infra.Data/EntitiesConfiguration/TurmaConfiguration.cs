using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>   
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            //1. Chavé primária
            builder.HasKey(t => t.Id);

            //2. propriedades obrigatórias, com tamanho máximo de 50 caracteres para o nome e 150 para a descrição
            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.Descricao)
                .HasMaxLength(150);
            builder.Property(t => t.CursoId).IsRequired();

            //3. Relacionamento com a entidade Curso (uma turma pertence a um curso)
            builder.HasOne(x => x.Curso)
                .WithMany(x => x.Turma)
                .HasForeignKey(x => x.CursoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
