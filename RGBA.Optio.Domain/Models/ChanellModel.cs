using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class ChanellModel
    {
        [Required(ErrorMessage = "Channel Name is required.")]
        [StringLength(50, ErrorMessage = "Channel Name is not valid", MinimumLength = 3)]
        [Display(Name = "Transaction Channel Type")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Chanell Type Name should contain only letters and spaces.")]
        public required string ChannelType { get; set; }
    }
}
