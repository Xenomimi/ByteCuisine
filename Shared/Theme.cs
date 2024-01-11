using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class Theme
    {
        public int Theme_Id { get; set; }
        public string Name { get; set; }
        public byte[] ThemeImage { get; set; }
        public List<VirtualFridge> VirtualFridges { get; set; }
    }
}
