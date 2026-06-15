using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfiguration
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            //1. Chavé primária
            builder.HasKey(c => c.Id);

            //2. propriedades obrigatórias, com tamanho máximo de 50 caracteres para o nome e 150 para a descrição
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Descricao)
                .HasMaxLength(150);

            ////3. Relacionamento com a entidade Turma (um curso pode ter várias turmas)
            //builder.HasMany(x => x.Turma)
            //    .WithOne(t => t.Curso)
            //    .HasForeignKey(t => t.CursoId);

        }
    }
}
