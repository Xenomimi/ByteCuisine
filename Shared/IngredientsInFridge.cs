using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class IngredientsInFridge
    {
        public int IngredientsInFridge_Id { get; set; }
        public int Ingredient_Id { get; set; }
        public Ingredient Ingredient { get; set; }

        public int VirtualFridge_Id { get; set; }
        public VirtualFridge VirtualFridge { get; set; }
    }
}
