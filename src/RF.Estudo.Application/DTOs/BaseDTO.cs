using System;

namespace RF.Estudo.Application.DTOs
{
    public abstract class BaseDTO<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
