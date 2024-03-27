using System.ComponentModel.DataAnnotations;

namespace RGBA.Optio.Domain.Models
{
    public class ChanellModel
    {
        [Required]
        public string ChannelType { get; set; }
    }
}
