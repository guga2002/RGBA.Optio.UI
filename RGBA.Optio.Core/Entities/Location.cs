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
    [Table("Locations")]
    [Index(nameof(LocationName),IsUnique =true)]
    public class Location:AbstractClass
    {
        [Column("Location_Name")]
        [MaxLength(50)]
        public required string LocationName {  get; set; }

        public required IEnumerable<Transaction> Transactions { get; set; }
    }
}
