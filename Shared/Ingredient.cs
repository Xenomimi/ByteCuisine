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

        public virtual ICollection<IngredientsInFridge> IngredientsInFridge { get; set; }
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }

        public Ingredient(string name, string description, byte[] image, double callories)
        {
            Name = name;
            Description = description;
            Image = image;
            Callories = callories;
        }
        public Ingredient() 
        {
        }
    }
}
