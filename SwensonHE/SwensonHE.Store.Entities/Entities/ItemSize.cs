using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class ItemSize : IEntity
    {
        [Key]
        public int ID { get; set; }
        public int itemID { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public ICollection<ItemSKU> itemSKUs { get; set; }
    }
}
