using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; }
    }
}
