using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class DishIngredient
    {
        public int Dish_Id { get; set; }
        public Dish Dish { get; set; }

        public int Ingredient_Id { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
