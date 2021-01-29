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

        /// <summary>
        /// Fetch All Item Sku Either Machines or Pods
        /// </summary>
        /// <param name="itemSKU"></param>
        /// <returns></returns>
        public async Task<IQueryable<ItemSKU>> GetIetmSKU(ItemSKUDTORequest itemSKU)
        {
            //Fetch all SKU by product type
            var data = StoreDBEntities.itemSKU.Where(a => a.Product.ProductType.ID == (int)itemSKU.ProductType);

            //Filter By WaterLine
            data = data.Where(i => i.HasWaterCompatibality == itemSKU.HasWaterLine);

            //Filter by Flavor
            if (itemSKU.FlavorType.HasValue)
                data = (int)itemSKU.FlavorType > 0 ? data.Where(f => f.Flavor.ID == (int)itemSKU.FlavorType) : data;

            //Filter by Item Size
            if (itemSKU.ItemSize.HasValue)
                data = (int)itemSKU.ItemSize > 0 ? data.Where(f => f.ItemSize.ID == (int)itemSKU.ItemSize) : data;

            //Filter by Model Type
            if (itemSKU.Modeltype.HasValue)
                data = (int)itemSKU.Modeltype > 0 ? data.Where(a => a.Pack.ID == (int)itemSKU.Modeltype) : data;

            //Filter by PackSize
            if (itemSKU.PackSize.HasValue)
                data = itemSKU.PackSize > 0 ? data.Where(a => a.Pack.ID == itemSKU.PackSize) : data;
            
            return data;
        }
    }
}
