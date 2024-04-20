using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace RGBA.Optio.Domain.Models
{
    public class CategoryModel
    {
        [Required(ErrorMessage = "Category  Name is required.")]
        [StringLength(50, ErrorMessage = "Category Name is not valid", MinimumLength = 3)]
        [Display(Name = "Transaction category name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Transaction Type Name should contain only letters and spaces.")]
        public required string TransactionCategory { get; set; }
        public required BigInteger TransactionTypeID { get; set; }
    }
}
