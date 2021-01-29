using Microsoft.EntityFrameworkCore;
using SwensonHE.Store.Data.Entities;
using SwensonHE.Store.Presistance.Extensions;
using SwensonHE.Store.Service.Interfaces;
using System.Data;

namespace SwensonHE.Store.DatabaseContext
{
    public class StoreDBEntities : DbContext, IStoreDBEntities
    {
        public StoreDBEntities(DbContextOptions<StoreDBEntities> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<ItemSKU> itemSKU { get; set; }
        public virtual DbSet<ModelType> ModelType { get; set; }
        public virtual DbSet<Flavor> Flavor { get; set; }
        public virtual DbSet<ItemSize> IetmSize { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Pack> Pack { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.Entity<Product>().HasMany(i => i.itemSKUs).WithOne(p => p.Product);
            modelBuilder.Entity<Pack>().HasMany(i => i.itemSKUs).WithOne(p => p.Pack);
            modelBuilder.Entity<Flavor>().HasMany(i => i.itemSKUs).WithOne(f => f.Flavor);

            modelBuilder.Entity<ModelType>().HasMany(i => i.itemSKUs).WithOne(m => m.ModelType);
            modelBuilder.Entity<ItemSize>().HasMany(i => i.itemSKUs).WithOne(i => i.ItemSize);
            modelBuilder.Entity<ProductType>().HasMany(t => t.products).WithOne(i => i.ProductType);
            modelBuilder.Entity<ItemSKU>().HasIndex(a => a.Code).IsUnique();

            modelBuilder.Entity<Item>().HasMany(p => p.Products).WithOne(p => p.Item);

        }

        public IDbConnection GetDbContextConnection()
        {
            var connection = Database.GetDbConnection();
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            connection.Open();
            return connection;
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        
    }
}
