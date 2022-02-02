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
        public DbSet<ModifierGroup> ModifierGroups { get; set; }
        public DbSet<ProductModifier> ProductModifiers { get; set; }
        public DbSet<ProductModifierGroup> ProductModifierGroups { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(500);
                b.Property(p => p.Image).HasMaxLength(1000);

                b.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });


            builder.Entity<Photo>(b =>
            {
                b.Property(p => p.Url).HasMaxLength(1000);

                b.HasOne(i => i.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(i => i.ProductId);
            });

            builder.Entity<Variant>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(500);
                b.Property(p => p.Price).HasColumnType("decimal(18,2)");

                b.HasOne(o => o.Product)
                .WithMany(c => c.Variants)
                .HasForeignKey(c => c.ProductId);

            });

            builder.Entity<Product>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(500);
                b.Property(p => p.Price).HasColumnType("decimal(18,2)");

                b.HasOne(o => o.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<ProductModifier>(b =>
            {
                b.HasKey(p => new { p.ProductId, p.ModifierId });

                b.HasOne(p => p.Product)
                .WithMany(m => m.Modifiers);

                b.HasOne(p => p.Modifier)
                .WithMany(m => m.Products);
            });

            builder.Entity<ProductModifierGroup>(b =>
            {
                b.HasKey(p => new { p.ProductId, p.ModifierGroupId });

                b.HasOne(p => p.Product)
                .WithMany(m => m.ModifierGroups);

                b.HasOne(p => p.ModifierGroup)
                .WithMany(m => m.Products);
            });

            builder.Entity<ModifierGroup>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(500);
            });

            builder.Entity<Modifier>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(500);
                b.Property(p => p.Price).HasColumnType("decimal(18,2)");

                b.HasOne(o => o.ModifierGroup)
                .WithMany(c => c.Modifiers)
                .HasForeignKey(p => p.ModifierGroupId)
                .OnDelete(DeleteBehavior.NoAction);
            });
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
