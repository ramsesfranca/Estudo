using System;
using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels
{
    public class BaseViewModel<TId>
        where TId : IEquatable<TId>
    {
        [Key]
        public TId Id { get; set; }
    }
}
