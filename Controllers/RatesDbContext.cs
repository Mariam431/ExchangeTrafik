using ExchangeTrafik.Models.CurrencyModels;
using Microsoft.EntityFrameworkCore;

namespace ExchangeTrafik.Controllers
{
    public class RatesDbContext : DbContext
    {
        public DbSet<Option> Options { get; set; }
        public object TransactionLogs { get; internal set; }
        public RatesDbContext(DbContextOptions<RatesDbContext> options) : base(options)
        {
        }
    }

}