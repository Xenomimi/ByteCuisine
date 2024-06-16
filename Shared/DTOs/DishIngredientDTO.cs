using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared.DTOs
{
    public class DishIngredientDTO
    {
        public int Dish_Id { get; set; }
        public int Ingredient_Id { get; set; }
        public DishIngredientDTO() { }
        public DishIngredientDTO(int dish, int ingredient)
        {
            Dish_Id = dish;
            Ingredient_Id = ingredient;
        }
    }
}