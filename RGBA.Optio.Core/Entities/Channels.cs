using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optio.Core.Entities
{
    [Table("Channels")]
    [Index(nameof(ChannelType),IsUnique =true)]
    public class Channels:AbstractClass
    {
        public string? ChannelType { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set;}
    }
}
