using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optio.Core.Entities
{
    [Table("Merchants")]
    [Index(nameof(Name),IsUnique =true)]
    public class Merchant:AbstractClass
    {
        public string? Name { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
