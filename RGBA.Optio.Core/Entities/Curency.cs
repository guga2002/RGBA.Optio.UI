using Optio.Core.Entities;

namespace RGBA.Optio.Core.Entities
{
    public class Curency:AbstractClass
    {
        public string? NameOfValute { get; set; }

        public virtual IEnumerable<Transaction> ?Transactions { get; set; }
    }
}
