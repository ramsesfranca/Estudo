using System;

namespace RF.Estudo.Application.DTOs
{
    public class ProdutoDTO : BaseDTO<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
