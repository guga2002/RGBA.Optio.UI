using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class CategoryModel
    {
        [Required]
        public string TransactionCategory { get; set; }
    }
}
