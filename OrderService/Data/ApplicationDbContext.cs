using OrderService.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MarketingArea> MarketingAreas { get; set; } = null!;
        public virtual DbSet<ProductSparepart> ProductSpareparts { get; set; } = null!;
        public virtual DbSet<SalesOrder> SalesOrders { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

			modelBuilder.Entity<ProductSparepart>(entity =>
			{
				entity.HasOne(e => e.Stores)
					.WithMany(e => e.ProductSpareparts)
					.HasForeignKey(e => e.StoreId)
					.IsRequired(true)
                    .OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Store>(entity =>
			{
				entity.HasOne(e => e.MarketingArea)
					.WithMany(e => e.Stores)
					.HasForeignKey(e => e.MarketingAreaId)
					.IsRequired(true)
					.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<SalesOrder>(entity =>
			{
				entity.HasOne(e => e.ProductSparepart)
					.WithMany(e => e.SalesOrders)
					.HasForeignKey(e => e.ProductSparepartId)
					.IsRequired(true)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(e => e.Customer)
					.WithMany(e => e.SalesOrders)
					.HasForeignKey(e => e.CustomerId)
					.IsRequired(true)
					.OnDelete(DeleteBehavior.Restrict);
			});

			base.OnModelCreating(modelBuilder);

        }

    }
}
