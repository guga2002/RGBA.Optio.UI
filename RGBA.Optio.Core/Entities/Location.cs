using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public string? LocationName {  get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
