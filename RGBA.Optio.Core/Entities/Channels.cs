using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("Channels")]
    [Index(nameof(ChannelType),IsUnique =true)]
    public class Channels:AbstractClass
    {
        [Column("Channel_Type")]
        [MaxLength(50)]
        public required string ChannelType { get; set; }
        public required IEnumerable<Transaction> Transactions { get; set;}
    }
}
