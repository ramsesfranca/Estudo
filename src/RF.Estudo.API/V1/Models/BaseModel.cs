using System;

namespace RF.Estudo.API.V1.Models
{
    public abstract class BaseModel<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
