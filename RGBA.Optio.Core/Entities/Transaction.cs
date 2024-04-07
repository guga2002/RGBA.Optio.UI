using Microsoft.EntityFrameworkCore;
using RGBA.Optio.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("Transactions")]
    [Index(nameof(Amount),IsDescending =new bool[] { true })]
    [Index(nameof(AmountEquivalent), IsDescending = new bool[] { true })]
    [Index(nameof(Date), IsDescending = new bool[] { true })]
    public class Transaction:AbstractClass
    {
        [Column("Date_Of_Transaction")]
        public DateTime Date { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("Amount_Equivalent")]
        public decimal AmountEquivalent { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }


        [ForeignKey("TypeOfTransaction")]
        public Guid TypeId { get; set; }

        public virtual TypeOfTransaction TypeOfTransaction { get; set; }


        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Merchant")]
        public Guid MerchantId { get; set; }

        public virtual Merchant Merchant {  get; set; }

        [ForeignKey("Channel")]
        public Guid ChannelId { get; set; }

        public virtual Channels Channel { get; set; }

        [ForeignKey("Location")]
        public Guid LocationId { get; set; }

        public virtual Location Location { get; set; }

    }
}
