using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("CategoryOfTransactions")]
    [Index(nameof(TransactionCategory),IsUnique = true)]
    public class Category:AbstractClass
    {
        [Column("Transaction_Category")]
        [MaxLength(50)]
        public required string TransactionCategory { get; set; }

        public required IEnumerable<Transaction> Transactions { get; set; }
    }
}
