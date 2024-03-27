using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class locationModel
    {
        [Required]
        public string LocationName { get; set; }
    }
}
