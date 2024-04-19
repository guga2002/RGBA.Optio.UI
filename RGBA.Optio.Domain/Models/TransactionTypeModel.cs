using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class TransactionTypeModel
    {
        [Required(ErrorMessage ="Trabsaction Type Name Is Required")]
        [StringLength(30,ErrorMessage ="Name is not valid",MinimumLength =3)]
        [Display(Name ="Transaction Type")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Transaction Type should contain only letters and spaces.")]
        public required string TransactionName { get; set; }
   
    }
}
