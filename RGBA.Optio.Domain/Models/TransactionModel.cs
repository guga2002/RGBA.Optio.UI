using RGBA.Optio.Domain.Validation.VallidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class TransactionModel
    {
        [Required(ErrorMessage = "Date is required.")]
        [DatatimeValidate]
        [Display(Name ="Date of transaction")]
        public required DateTime Date { get; set; }

        [Required(ErrorMessage = "Currency ID is required.")]
        public required int CurencyNameId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        [Display(Name = "Amount transacted")]
        public required float Amount { get; set; }

        [Required(ErrorMessage = "Equivalent in GEL is required.")]
        [Range(0.01,double.MaxValue, ErrorMessage = "Equivalent in GEL must be greater than 0.")]
        [Display(Name = "Equvalent in GEL")]
        public required double EquivalentInGel { get; set; }

        [Required(ErrorMessage = "Type ID is required.")]
        public required Guid TypeId { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public required Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Merchant ID is required.")]
        public required Guid MerchantId { get; set; }

        [Required(ErrorMessage = "Channel ID is required.")]
        public required Guid ChannelId { get; set; }

        [Required(ErrorMessage = "Location ID is required.")]
        public required Guid LocationId { get; set; }
    }
}
