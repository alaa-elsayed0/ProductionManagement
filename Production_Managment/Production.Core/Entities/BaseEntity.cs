using System.ComponentModel.DataAnnotations.Schema;

namespace Production.Core.Entities
{
    public class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }
}
