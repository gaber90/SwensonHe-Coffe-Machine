using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class ProductType : IEntity
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
