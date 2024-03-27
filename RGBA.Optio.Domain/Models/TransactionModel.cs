
namespace RGBA.Optio.Domain.Models
{
    public class TransactionModel
    {
        public DateTime Date { get; set; }
        public Guid CurencyNameId { get; set; }
        public float Amount { get; set; }
        public float EquvalentInGel { get; set; }

        public Guid TypeId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid MerchantId { get; set; }
 
        public Guid ChannelId { get; set; }

        public Guid LocationId { get; set; }
    }
}
