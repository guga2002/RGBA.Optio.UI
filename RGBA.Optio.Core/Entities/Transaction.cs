using Microsoft.EntityFrameworkCore;
using RGBA.Optio.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("Transactions")]
    public class Transaction:AbstractClass
    {
        [Column("Date_Of_Transaction")]
        public DateTime Date { get; set; }

        [Column("Amount")]
        public float Amount { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }

        [Column("Amount_Equivalent")]
        public decimal AmountEquivalent { get; set; }


        [ForeignKey("TypeOfTransaction")]
        public Guid TypeId { get; set; }

        public TypeOfTransaction TypeOfTransaction { get; set; }


        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Merchant")]
        public Guid MerchantId { get; set; }

        public Merchant Merchant {  get; set; }

        [ForeignKey("Channel")]
        public Guid ChannelId { get; set; }

        public Channels Channel { get; set; }

        [ForeignKey("Location")]
        public Guid LocationId { get; set; }

        public Location Location { get; set; }

    }
}
