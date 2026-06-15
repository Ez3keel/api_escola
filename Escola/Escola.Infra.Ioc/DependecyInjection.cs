using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configuração do Entity Framework Core com SQL Server
            //habilita as migrações e o acesso ao banco de dados usando o ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // futuramente: services.AddEmailService(configuration);
            // Adicione as dependências da camada de infraestrutura aqui
            // Por exemplo:
            // services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            // services.AddScoped<ITurmaRepository, TurmaRepository>();
            // services.AddScoped<INotaRepository, NotaRepository>();
            return services;
        }

    }
}
