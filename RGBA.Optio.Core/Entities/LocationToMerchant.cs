using Optio.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBA.Optio.Core.Entities
{
    [Table("LocationToMerchants")]
    public class LocationToMerchant:AbstractClass
    {
        [ForeignKey("location")]
        public Guid LocatrionId { get; set; }

        [ForeignKey("merchant")]
        public Guid merchantId { get; set; }
        public Location location { get; set; }

        public Merchant merchant { get; set; }
    }
}
