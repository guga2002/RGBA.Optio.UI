using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class TransactionTypeModel
    {
        [Required]
        public string TransactionName { get; set; }
    }
}
