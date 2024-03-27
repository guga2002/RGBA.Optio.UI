using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Optio.Core.Entities;
using RGBA.Optio.Core.Entities;

namespace Optio.Core.Data
{
    public class OptioDB:IdentityDbContext<User>
    { 
        public OptioDB(DbContextOptions<OptioDB> bs) : base(bs) { }

        public DbSet<Category> CategoryOfTransactions { get; set; }
        public DbSet<Channels>Channels { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TypeOfTransaction> Types { get; set; }
    }
}
