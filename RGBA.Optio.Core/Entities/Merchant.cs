using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("Merchants")]
    [Index(nameof(Name),IsUnique =true,IsDescending =new bool[] { true })]
    public class Merchant:AbstractClass
    {
        [Column("Name")]
        [StringLength(50,ErrorMessage ="Mercvhant name is not valid!",MinimumLength =3)]
        public required string Name { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
