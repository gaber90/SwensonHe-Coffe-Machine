using System.ComponentModel.DataAnnotations;

namespace SwensonHE.Store.Data.Entities
{
    public class Item : IEntity
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }
    }
}
