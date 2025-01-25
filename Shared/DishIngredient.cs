using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("DishIngredient", Schema = "ByteCuisine")]
    public class DishIngredient
    {
        public int DishIngredient_Id { get; set; }

        public int Dish_Id { get; set; }
        public virtual Dish Dish { get; set; }

        public int Ingredient_Id { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public DishIngredient(int dishId, int ingredientId)
        {
            Dish_Id = dishId;
            Ingredient_Id = ingredientId;
        }
        public DishIngredient() { }
    }
}
