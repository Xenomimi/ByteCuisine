using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared
{
    public class AccountDTO
    {
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public byte[] PictureData { get; set; }

        public AccountDTO(int id, string name, string password, string role, string image)
        {
            User_Id = id;
            Username = name;
            Password = password;
            Role = role;
            PictureData = Convert.FromBase64String(image);
        }

        public AccountDTO(string name, string password, string role, byte[] image)
        {
            Username = name;
            Password = password;
            Role = role;
            PictureData = image;
        }
    }
}