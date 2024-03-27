using Microsoft.EntityFrameworkCore;
using RGBA.Optio.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("Transactions")]
    public class Transaction:AbstractClass
    {
        [ForeignKey("curency")]
        public Guid CurencyId { get; set; }

        [ForeignKey("Curency")]
        public Guid CurencyNameId { get; set; }
        public Curency? Curency { get; set; }
        public float Amount { get; set; }

        public float EquvalentInGel { get; set; }

        [Column("Date_Of_Transaction")]
        public DateTime Date { get; set; }


        [ForeignKey("TypeOfTransaction")]
        public Guid TypeId { get; set; }
        public TypeOfTransaction? TypeOfTransaction { get; set; }


        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }


        [ForeignKey("Merchant")]
        public Guid MerchantId { get; set; }
        public Merchant? Merchant {  get; set; }


        [ForeignKey("Channel")]
        public Guid ChannelId { get; set; }
        public Channels? Channel { get; set; }


        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public Location? Location { get; set; }

    }
}
