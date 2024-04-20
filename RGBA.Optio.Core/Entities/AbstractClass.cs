using System.ComponentModel.DataAnnotations;
using System.Numerics;
namespace Optio.Core.Entities
{
    public abstract class AbstractClass
    {
        [Key]
        public BigInteger Id { get; set; }
     
    }
}
