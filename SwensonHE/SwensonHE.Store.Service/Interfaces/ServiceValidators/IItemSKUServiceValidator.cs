using SwensonHE.Store.DTO;
using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Service.Model;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Interfaces
{
    public interface IItemSKUServiceValidator
    {
        Task<ValidatorResult> GetSKUListValidator(FlavorTypeEnum? flavorType, ProductTypeEnum? productType
            , ItemSizeEnum? itemSize, ModeltypeEnum? modeltype);
    }
}
