using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared.DTOs
{
    public class DishDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] DishImage { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }

        public DishDTO() { IsDeleted = false; }
        public DishDTO(string name, string description, byte[] image, int category)
        {
            Name = name;
            Description = description;
            DishImage = image;
            IsDeleted = false;
            CategoryId = category;
        }
    }
}
