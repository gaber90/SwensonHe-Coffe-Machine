using SwensonHE.Store.DTO;
using SwensonHE.Store.Service.Model;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Interfaces
{
    public interface IItemSKUServices
    {
        Task<ServiceResultList<ItemSKUDTOResponse>> GetSKUList(ItemSKUDTORequest itemSKUDTORequest);
    }
}
