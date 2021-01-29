using SwensonHE.Store.Ground.Enums;
using System;

namespace SwensonHE.Store.DTO
{
    /// <summary>
    /// Item SkU Request
    /// </summary>
    public class ItemSKUDTORequest
    {
        /// <summary>
        /// HasWaterLine
        /// </summary>
        public bool? HasWaterLine { get; set; } = false;


        /// <summary>
        /// FlavorType
        /// </summary>
        public FlavorTypeEnum? FlavorType { get;  set; }

        /// <summary>
        /// ProductType
        /// </summary>
        public ProductTypeEnum? ProductType { get; private  set; }

        /// <summary>
        /// ItemSize
        /// </summary>
        public ItemSizeEnum? ItemSize { get; set; }

        /// <summary>
        /// Modeltype
        /// </summary>
        public ModeltypeEnum? Modeltype { get; set; }

        /// <summary>
        /// PackSize
        /// </summary>
        public int? PackSize { get; set; }

        /// <summary>
        /// Set Type Value
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public ItemSKUDTORequest SetProductType(ProductTypeEnum productType)
        {
            this.ProductType = productType;
            return this;
        }

    }
}
