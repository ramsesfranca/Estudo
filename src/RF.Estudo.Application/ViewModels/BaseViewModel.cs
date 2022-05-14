using System;
using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        public Guid Id { get; }

        protected BaseViewModel()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
