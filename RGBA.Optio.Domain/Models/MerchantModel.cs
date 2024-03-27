using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class MerchantModel
    {
        [Required]
        public string Name { get; set; }
    }
}
