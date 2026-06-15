using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } //Hash da senha
        public byte[] PasswordSalt { get; set; } // Verifica a senha
        public string Perfil { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }
    }
}
