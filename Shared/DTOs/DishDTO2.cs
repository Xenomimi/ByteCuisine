using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared.DTOs
{
    public class DishDTO2
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] DishImage { get; set; }
        public string Category { get; set; }

        // Konstruktor bezparametrowy
        public DishDTO2() { }

        // Możesz również mieć konstruktory parametryczne
        public DishDTO2(string name, string description, byte[] dishImage, string category)
        {
            Name = name;
            Description = description;
            DishImage = dishImage;
            Category = category;
        }
    }
}
