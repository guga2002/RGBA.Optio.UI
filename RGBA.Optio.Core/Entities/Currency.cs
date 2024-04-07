using Microsoft.EntityFrameworkCore;
using Optio.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBA.Optio.Core.Entities
{
    [Table("Curencies")]
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Column("Name_Of_Valute")]
        [MaxLength(30)]
        [Unicode(false)]
        public required string NameOfValute { get; set; }

        [Column("Currency_Code")]
        [MaxLength(15)]
        [Unicode(false)]
        public required string CurrencyCode {  get; set; }

        public virtual IEnumerable<Transaction> Transactions { get; set; }

        public virtual IEnumerable<ValuteCourse> Courses { get; set; }

    }
}
