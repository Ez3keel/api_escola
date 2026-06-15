using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        // O construtor recebe o ApplicationDbContext via injeção de dependência
        // Para acessar o banco de dados e realizar operações relacionadas à entidade Curso
        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            //Adc o curso ao contexto e salva as alterações no banco de dados
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> DeleteAsync(int id)
        {
            //Busca o curso pelo id, verificando se não está marcado como excluído
            var curso = await _context.Curso.Where(x => ! x.Excluido && x.Id == id).FirstOrDefaultAsync();
            if (curso != null)
            {
                //_context.Curso.Remove(curso);
                //await _context.SaveChangesAsync();
                curso.Excluido = true;
                await _context.SaveChangesAsync();
            }
            return curso;
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            //Retorna páginado os cursos que não estão marcados como excluídos
            return await _context.Curso.Where(x => !x.Excluido).ToListAsync();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            //Busca o curso pelo id, verificando se não está marcado como excluído
            return await _context.Curso.Where(x => !x.Excluido && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Curso> UpdateAsync(Curso curso)
        {
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
