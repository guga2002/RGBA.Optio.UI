using RGBA.Optio.Domain.Validation.VallidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Models
{
    public class ValuteModel
    {
        [Required(ErrorMessage = "Exchange rate is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Exchange rate must be a positive number.")]
        public decimal ExchangeRate { get; set; }

        [Required(ErrorMessage = "Date of valute course is required.")]
        [DataType(DataType.Date)]
        [DatatimeValidate]
        public DateTime DateOfValuteCourse { get; set; }

        [Required(ErrorMessage = "Currency ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Currency ID must be a positive integer.")]
        public int CurrencyID { get; set; }
    }
}
