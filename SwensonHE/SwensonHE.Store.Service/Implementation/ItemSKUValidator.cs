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
        /// <summary>
        /// Validate if Flavor Enum is Exist of not
        /// </summary>
        /// <param name="flavorType"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validate If Product Type is Exist or Not
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Validate If Item Size is Exist or not
        /// </summary>
        /// <param name="itemSizeEnum"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateItemSize(ItemSizeEnum? itemSizeEnum)
        {
            if (itemSizeEnum.HasValue)
            {
                if (!Enum.IsDefined(typeof(ProductTypeEnum), itemSizeEnum))
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

        /// <summary>
        /// Validate Model Type Exist or not
        /// </summary>
        /// <param name="modeltypeEnum"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateModelType(ModeltypeEnum? modeltypeEnum)
        {
            if (modeltypeEnum.HasValue)
            {
                if (!Enum.IsDefined(typeof(ProductTypeEnum), modeltypeEnum))
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
