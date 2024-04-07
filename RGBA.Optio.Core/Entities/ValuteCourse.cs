using Optio.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBA.Optio.Core.Entities
{
    [Table("ValutesCourses")]
    public class ValuteCourse:AbstractClass
    {
        [Column("Exchange_Rate")]
        public float ExchangeRate { get; set; }

        [Column("Last_Updated")]
        public DateTime DateOfValuteCourse { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyID {  get; set; }

        public Currency Currency { get; set; }
    }
}
