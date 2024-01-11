using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class Account
    {
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public byte[] PictureData { get; set; }
        public VirtualFridge VirtualFridge { get; set; }
    }
}