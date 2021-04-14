using System;
using SixBDigital.CarValeting.Core.Interfaces;

namespace SixBDigital.CarValeting.Core.Entities
{
    public abstract class BaseEntity<T> : IEntity where T : BaseEntity<T>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
