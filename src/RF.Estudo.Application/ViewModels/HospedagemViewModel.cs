using RF.Estudo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels
{
    public class HospedagemViewModel : BaseViewModel<Guid>
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ChaleId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Estado Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtdPessoas { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Desconto { get; set; }

        public List<HospedagemServicoViewModel> Servicos { get; set; }
    }
}
