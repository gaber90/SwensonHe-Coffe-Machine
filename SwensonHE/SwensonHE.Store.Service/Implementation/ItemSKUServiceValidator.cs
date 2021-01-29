using SwensonHE.Store.DTO;
using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Service.Interfaces;
using SwensonHE.Store.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Implementation
{
    public class ItemSKUServiceValidator : IItemSKUServiceValidator
    {
        private readonly Lazy<IItemSKUValidator> _itemSKUValidator;

        public ItemSKUServiceValidator(Lazy<IItemSKUValidator> itemSKUValidator)
        {
            _itemSKUValidator = itemSKUValidator;
        }

        private IItemSKUValidator ItemSKUValidator => _itemSKUValidator.Value;
        public async Task<ValidatorResult> GetSKUListValidator(FlavorTypeEnum? flavorType, ProductTypeEnum? productType)
        {
            var tasks = new List<Task<ValidatorResult>>()
            {
                ItemSKUValidator.ValidateFlavorType(flavorType),
                ItemSKUValidator.ValidateProductType(productType)
            };
            await Task.WhenAll(tasks);
            var result = tasks.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (result != null)
                return result;
            return new ValidatorResult();
        }
    }
}
