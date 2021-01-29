using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SwensonHE.Store.Data.Entities;
using System;
using System.Data;

namespace SwensonHE.Store.Service.Interfaces
{
    public interface IStoreDBEntities : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        IDbConnection GetDbContextConnection();
        DatabaseFacade Database { get; }

        DbSet<ItemSKU> itemSKU { get; set; }
        DbSet<ModelType> ModelType { get; set; }
        DbSet<Flavor> Flavor { get; set; }
        DbSet<ItemSize> IetmSize { get; set; }
        DbSet<Item> Item { get; set; }
        DbSet<Pack> Pack { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductType> ProductType { get; set; }

    }
}
