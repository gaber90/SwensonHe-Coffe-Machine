using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int ID { get; set; }
        public virtual ProductType ProductType { get; set; }

        public virtual Item Item { get; set; }
        public  ICollection<ItemSKU> itemSKUs  { get; set; }
    }
}
