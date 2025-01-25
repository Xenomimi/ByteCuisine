using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("Category", Schema = "ByteCuisine")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
        
        public Category() { }
        public Category(string name)
        {
            CategoryName = name;
        }
    }
}
