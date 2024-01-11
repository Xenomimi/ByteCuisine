using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class VirtualFridge
    {
        public int VirtualFridge_Id { get; set; }
        public List<IngredientsInFridge> IngredientsInFridge { get; set; }
        public Account Account { get; set; }
        public int Theme_Id { get; set; }
        public Theme Theme { get; set; }
    }
}
