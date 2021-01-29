using SwensonHE.Store.Data.Entities;
using SwensonHE.Store.DTO;
using SwensonHE.Store.Service.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SwensonHE.Store.Presistance.CoreImplementation.Repositories
{
    public class ItemSKURepository : BaseRepository<ItemSKU>, IItemSKURepository
    {
        protected IStoreDBEntities _storeDBEntities;
        public ItemSKURepository(IStoreDBEntities context) : base(context)
        {
            _storeDBEntities = context;
        }
        protected IStoreDBEntities StoreDBEntities => _storeDBEntities;

        public async Task<IQueryable<ItemSKU>> GetIetmSKU(ItemSKUDTORequest itemSKU)
        {
            var data = StoreDBEntities.itemSKU
                 .Include(p => p.Product)
                 .Include(p => p.Pack)
                 .Include(p => p.ModelType)
                 .Include(p => p.Flavor)
                 .Include(p => p.ItemSize)
                 .Include("Product.ProductType")
                 .Include("Product.Item");

            //Filter By productType
            data = (int)itemSKU.ProductType > 0 ? data.Where(a => a.Product.ProductType.ID == (int)itemSKU.ProductType) : data;

            //Filter By WaterLine
            data = data.Where(i => i.HasWaterCompatibality == itemSKU.HasWaterLine);

            if (itemSKU.FlavorType.HasValue)
                //Filter by Flavor
                data = (int)itemSKU.FlavorType > 0 ? data.Where(f => f.Flavor.ID == (int)itemSKU.FlavorType) : data;
            if (itemSKU.PackSize.HasValue)
                //Filter by PackSize
                data = itemSKU.PackSize > 0 ? data.Where(a => a.Pack.ID == itemSKU.PackSize) : data;

            return data;

        }
    }
}
