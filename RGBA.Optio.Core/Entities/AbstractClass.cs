using System.ComponentModel.DataAnnotations;
namespace Optio.Core.Entities
{
    public abstract class AbstractClass
    {
        [Key]
        public Guid Id { get; set; }
        protected AbstractClass()
        {  
            Id = Guid.NewGuid();
        }
    }
}
