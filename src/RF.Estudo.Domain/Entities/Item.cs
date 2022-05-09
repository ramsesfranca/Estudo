using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Item
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual ICollection<Chale> Chales { get; private set; }

        protected Item()
        {
        }

        public Item(string nome, string descricao)
        {
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}
