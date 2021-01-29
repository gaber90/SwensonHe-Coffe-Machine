using SwensonHE.Store.Ground.Enums;
using SwensonHE.Store.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwensonHE.Store.Service.Interfaces
{
    public interface IItemSKUValidator
    {
        Task<ValidatorResult> ValidateProductType(ProductTypeEnum? productType);

        Task<ValidatorResult> ValidateFlavorType(FlavorTypeEnum? flavorType);
    }
}
