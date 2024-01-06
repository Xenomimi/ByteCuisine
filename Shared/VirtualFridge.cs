using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class VirtualFridge
    {
        public int VirtualFridge_id { get; set; }
        public int User_id { get; set; }
        public int Ingridient_id { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
