using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Defina os DbSets para suas entidades aqui, por exemplo:
        // public DbSet<Curso> Cursos { get; set; }

        // Construtor que recebe as opções de configuração do DbContext aqui ele recebe as opções de configuração do DbContext, que são passadas para a classe base DbContext.
        // Isso permite configurar a conexão com o banco de dados e outras opções relacionadas ao contexto.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Nota> Nota { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        // Configurações adicionais de mapeamento podem ser feitas aqui, por exemplo:
        // O método OnModelCreating é usado para configurar o modelo de dados e as relações entre as entidades.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais de mapeamento podem ser feitas aqui, por exemplo:
            // modelBuilder.Entity<Curso>().HasKey(c => c.Id);
            // modelBuilder.Entity<Curso>().Property(c => c.Nome).IsRequired().HasMaxLength(100);

            // O método ApplyConfigurationsFromAssembly é usado para aplicar todas as configurações
            // de entidade definidas em classes separadas que implementam a interface IEntityTypeConfiguration<T>.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
