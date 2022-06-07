using Inventory.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess.Context
{
    public class SqlServerContext: DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Movement> Movement { get; set; }

        private readonly string _connectionString = string.Empty;

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public SqlServerContext()
        {
            _connectionString = @"Data Source = DESKTOP-R4U1A54\SQLEXPRESS; Initial Catalog = Inventory; Integrated Security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => new { p.IdProduct });
            modelBuilder.Entity<Product>().Property(p => p.IdProduct).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Movement>().HasKey(m => new { m.IdMovement });
            modelBuilder.Entity<Movement>().Property(m => m.IdMovement).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
