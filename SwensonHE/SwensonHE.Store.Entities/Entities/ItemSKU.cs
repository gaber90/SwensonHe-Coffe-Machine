

using SwensonHE.Store.Ground.Enums;
using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class ItemSKU : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public int Qty { get; set; }
        public bool HasWaterCompatibality { get; set; }
        public virtual Product Product { get; set; }
        public virtual Pack Pack { get; set; }
        public virtual Flavor Flavor { get; set; }
        public virtual ModelType ModelType { get; set; }
        public virtual ItemSize ItemSize { get; set; }
    }


}
