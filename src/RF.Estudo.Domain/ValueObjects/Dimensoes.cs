using RF.Estudo.Domain.Core.DomainObjects;

namespace RF.Estudo.Domain.ValueObjects
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            this.Altura = altura;
            this.Largura = largura;
            this.Profundidade = profundidade;

            this.Validar();
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {this.Largura} x {this.Altura} x {this.Profundidade}";
        }

        private void Validar()
        {
            Validation.ValidarSeMenorQue(this.Altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            Validation.ValidarSeMenorQue(this.Largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            Validation.ValidarSeMenorQue(this.Profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");
        }
    }
}
