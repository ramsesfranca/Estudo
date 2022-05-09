using RF.Estudo.Domain.Core.DomainObjects;

namespace RF.Estudo.Domain.ValueObjects
{
    public class Localizacao
    {
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Cep { get; private set; }

        public Localizacao(string endereco, string bairro, string cidade, string cep)
        {
            this.Endereco = endereco;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Cep = cep;

            this.Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(this.Endereco, "O campo Endereço do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(this.Bairro, "O campo Bairro do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(this.Cidade, "O campo Cidade do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(this.Cep, "O campo Cep do produto não pode estar vazio");
        }
    }
}
