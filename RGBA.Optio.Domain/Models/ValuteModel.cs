using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Models
{
    public class ValuteModel
    {
        public decimal ExchangeRate { get; set; }

        public DateTime DateOfValuteCourse { get; set; }

        public int CurrencyID { get; set; }
    }
}
