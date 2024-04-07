using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Column("Name")]
        [MaxLength(50)]
        public required string Name { get; set; }
        public required IEnumerable<Transaction> Transactions { get; set; }
    }
}
