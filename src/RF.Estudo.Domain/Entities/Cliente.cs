using System;
using RF.Estudo.Domain.Core.Entities;

namespace RF.Estudo.Domain.Entities
{
    public class Cliente  : BaseEntity<Guid>
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public bool Situacao { get; private set; }

        protected Cliente()
        {
        }

        public Cliente(string nome, string sobrenome, string email, bool situacao)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Situacao = situacao;
        }
    }
}
