using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Entities
{

    [Table("TypeOfTransactions")]
    [Index(nameof(TransactionName),IsUnique =true)]
    public class TypeOfTransaction:AbstractClass
    {
        public string? TransactionName { get; set; }

        public IEnumerable<Transaction>? Transactions { get; set; }

    }
}
