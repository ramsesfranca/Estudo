using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Enums;
using System;

namespace RF.Estudo.Domain.Entities
{
    public class Telefone
    {
        public string Numero { get; private set; }
        public TipoTelefone TipoTelefone { get; set; }
        public Guid? ClienteId { get; set; }

        public virtual Cliente Cliente { get; private set; }

        public Telefone(string numero, TipoTelefone tipoTelefone)
        {
            this.Numero = numero;
            this.TipoTelefone = tipoTelefone;
        }

        public void AlterarNome(string numero)
        {
            Validacoes.ValidarSeVazio(numero, "O campo Numero do cliente não pode estar vazio");

            this.Numero = numero;
        }

        public void AlterarNome(Cliente cliente)
        {
            this.Cliente = cliente;
            this.ClienteId = cliente.Id;
        }
    }
}
