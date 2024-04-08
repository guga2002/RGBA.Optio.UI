using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBA.Optio.Domain.Models
{
    public class CurrencyModel
    {
        public required string NameOfValute { get; set; }

        public required string CurrencyCode { get; set; }
    }
}
