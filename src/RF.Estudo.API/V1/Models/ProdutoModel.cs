using System;

namespace RF.Estudo.API.V1.Models
{
    public class ProdutoModel : BaseModel<Guid>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
