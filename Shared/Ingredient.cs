using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("Ingredient", Schema = "ByteCuisine")]
    public class Ingredient
    {
        [Key]
        public int Ingredient_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public double Callories { get; set; }

        public ICollection<IngredientsInFridge> IngredientsInFridge { get; set; }
        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
