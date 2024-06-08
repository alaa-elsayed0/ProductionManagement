using System.ComponentModel.DataAnnotations.Schema;

namespace Production.Core.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
