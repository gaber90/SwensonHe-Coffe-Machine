using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class ModelType : IEntity
    {
        [Key]
        public int ID { set; get; }

        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<ItemSKU> itemSKUs { get; set; }
    }
}
