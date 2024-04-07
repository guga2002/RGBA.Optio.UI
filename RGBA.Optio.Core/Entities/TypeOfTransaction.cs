using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("TypeOfTransactions")]
    [Index(nameof(TransactionName),IsUnique =true,IsDescending =new bool[] { true })]
    public class TypeOfTransaction:AbstractClass
    {
        [Column("Transaction_Name")]
        [StringLength(100,ErrorMessage ="Transaction name is not valid!!",MinimumLength =3)]
        public required string TransactionName { get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }

    }
}
