using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class Pack : IEntity
    {
        [Key]
        public int ID { get; set; }

        public int Dozen { get; set; }

        public int Qty { get; set; }

        public ICollection<ItemSKU> itemSKUs { get; set; }
    }
}
