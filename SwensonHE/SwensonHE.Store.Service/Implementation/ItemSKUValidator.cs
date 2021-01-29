using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Language.Resources;
using SwensonHE.Store.Service.Interfaces;
using SwensonHE.Store.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Implementation
{
    public class ItemSKUValidator : IItemSKUValidator
    {
        public async Task<ValidatorResult> ValidateFlavorType(FlavorTypeEnum? flavorType)
        {
            if (flavorType.HasValue)
            {
                if (!Enum.IsDefined(typeof(FlavorTypeEnum), flavorType))
                {
                    return new ValidatorResult()
                    {
                        IsValid = false,
                        Message = Resource.Invalidflavor
                    };
                }

            }

            return new ValidatorResult();
        }

        public async Task<ValidatorResult> ValidateProductType(ProductTypeEnum? productType)
        {
            if (productType.HasValue)
            {
                if (!Enum.IsDefined(typeof(ProductTypeEnum), productType))
                {
                    return new ValidatorResult()
                    {
                        IsValid = false,
                        Message = Resource.InvalideProductType
                    };
                }

            }

            return new ValidatorResult();
        }
    }
}
