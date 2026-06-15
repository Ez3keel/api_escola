using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> GetByIdAsync(int id);
        Task<List<Turma>> GetAllAsync();
        Task<Turma> AddAsync(Turma turma);
        Task<Turma> UpdateAsync(Turma turma);
        Task<Turma> DeleteAsync(int id);
        // Define os métodos para manipulação de Turma
        // Por exemplo:
        // Implemente os métodos conforme necessário
        // Exemplo de métodos:
        // Aqui estão os métodos definidos para a interface ITurmaRepository
        // Esses métodos são assíncronos e retornam Task para permitir operações assíncronas
        // O método GetByIdAsync recebe um ID e retorna a Turma correspondente
        // O método GetAllAsync retorna uma lista de todas as Turmas
        // O método AddAsync recebe uma Turma e a adiciona ao repositório, retornando a Turma adicionada
        // O método UpdateAsync recebe uma Turma e a atualiza no repositório, retornando a Turma atualizada
        // O método DeleteAsync recebe um ID e remove a Turma correspondente do repositório, retornando a Turma removida
        // Esses métodos são apenas exemplos e podem ser ajustados conforme as necessidades específicas do seu projeto
        // Lembre-se de implementar esses métodos na classe que implementa a interface ITurmaRepository
        // Essa interface é uma parte fundamental para a manipulação de dados relacionados às Turmas no seu sistema
        // Certifique-se de que a implementação desses métodos seja consistente com as regras de negócio do seu sistema
        // A interface ITurmaRepository é uma abstração que define as operações de CRUD (Create, Read, Update, Delete) para a entidade Turma

    }
}
