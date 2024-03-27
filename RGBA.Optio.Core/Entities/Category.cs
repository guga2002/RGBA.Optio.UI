using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("CategoryOfTransactions")]
    [Index(nameof(TransactionCategory),IsUnique = true)]
    public class Category:AbstractClass
    {
        public string? TransactionCategory { get; set; }

        public IEnumerable<Transaction>?Transactions { get; set; }
    }
}
