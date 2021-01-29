using SwensonHE.Store.Ground.Enums;
using System;

namespace SwensonHE.Store.DTO
{
    public class ItemSKUDTORequest
    {
        public bool? HasWaterLine { get; set; } = false;

        public FlavorTypeEnum? FlavorType { get;  set; }

        public ProductTypeEnum? ProductType { get; private  set; }

        public ItemSizeEnum? ItemSize { get; set; }

        public int? PackSize { get; set; }

        public ItemSKUDTORequest SetProductType(ProductTypeEnum productType)
        {
            this.ProductType = productType;
            return this;
        }

    }
}
