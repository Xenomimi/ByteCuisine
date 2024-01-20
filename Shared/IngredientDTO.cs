using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class IngredientDTO
    {
        public int Ingredient_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Category { get; set; }
        public double Callories { get; set; }

        public IngredientDTO(int id, string name, string description, string image, string category, double calories)
        {
            Ingredient_Id = id;
            Name = name;
            Description = description;
            Image = Convert.FromBase64String(image);
            Category = category;
            Callories = calories;
        }
        public IngredientDTO(string name, string description, byte[] image, string category, double calories)
        {
            Name = name;
            Description = description;
            Image = image;
            Category = category;
            Callories = calories;
        }
    }
}