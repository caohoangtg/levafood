using Catalog.Domain.Common;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Photo>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Product>()
                .HasOne(o => o.Variant)
                .WithOne(c => c.Product)
                .HasForeignKey<Variant>(c => c.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Product>()
                .HasOne(o => o.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Product>()
                .HasMany(p => p.Modifiers)
                .WithMany(m => m.Products)
                .UsingEntity(x => x.ToTable("ProductModifier"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UpdateCreated("HoangTC");
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateLastModified("HoangTC");
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
