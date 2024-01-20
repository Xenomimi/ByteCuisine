using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class DishDTO
    {
        public int Dish_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] DishImage { get; set; }
        public string Category { get; set; }

        public DishDTO(int id, string name, string description, string image, string category)
        {
            Dish_Id = id;
            Name = name;
            Description = description;
            DishImage = Convert.FromBase64String(image);
            Category = category;
        }
        public DishDTO(string name, string description, byte[] image, string category)
        {
            Name = name;
            Description = description;
            DishImage = image;
            Category = category;
        }
    }
}
