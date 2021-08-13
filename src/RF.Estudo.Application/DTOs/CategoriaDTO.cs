using System;

namespace RF.Estudo.Application.DTOs
{
    public class CategoriaDTO : BaseDTO<Guid>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}
