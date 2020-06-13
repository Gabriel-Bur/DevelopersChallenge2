using Microsoft.EntityFrameworkCore;
using Xayah.Domain.Entities;

namespace Xayah.Data
{
    public class SqlServerContext : DbContext
    {
        public DbSet<Transaction> Transactions{ get; set; }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo

            base.OnModelCreating(modelBuilder);
        }

    }
}
