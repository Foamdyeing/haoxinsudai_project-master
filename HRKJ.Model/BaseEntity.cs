using System;

namespace HRKJ.Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int DeleteId { get; set; } = 1;

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}