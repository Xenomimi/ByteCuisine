using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class Ingredient
    {
        public int Ingredient_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Category { get; set; }
        public double Callories { get; set; }
        public List<DishIngredient> DishIngredients { get; set; }
        public List<IngredientsInFridge> IngredientsInFridge { get; set; }
    }
}
