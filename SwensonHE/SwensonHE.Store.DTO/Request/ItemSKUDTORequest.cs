using SwensonHE.Store.Ground.Enums;
using System;

namespace SwensonHE.Store.DTO
{
    public class ItemSKUDTORequest
    {
        public bool? HasWaterLine { get; set; } = false;

        public FlavorTypeEnum? FlavorType { get; set; }

        public ProductTypeEnum? ProductType { get; set; }

        public int PackSize { get; set; } = 0;
    }
}
