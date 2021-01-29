using SwensonHE.Store.Data.Entities;
using SwensonHE.Store.DTO;
using SwensonHE.Store.Ground.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Interfaces
{
    public interface IItemSKURepository : IBaseRepository<ItemSKU>
    {
        Task<IQueryable<ItemSKU>> GetIetmSKU(ItemSKUDTORequest itemSKU);
    }
}
