using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("Dish", Schema = "ByteCuisine")]
    public class Dish
    {
        [Key]
        public int Dish_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] DishImage { get; set; }

        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
