using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteCuisine.Shared.DTOs
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] PictureData { get; set; }

        public AccountDTO()
        {
            Role = "User";
            IsDeleted = false;
        }

        public AccountDTO(string name, string password)
        {
            Username = name;
            Password = password;
        }

        public AccountDTO(string email,string name, string password)
        {
            Email = email;
            Username = name;
            Password = password;         
        }

        public AccountDTO(string email, string name, string password, string role, string image)
        {
            Email = email;
            Username = name;
            Password = password;
            Role = role;
            IsDeleted = false;
            PictureData = Convert.FromBase64String(image);
        }

        public AccountDTO(string email,string name, string password, string role, byte[] image)
        {
            Email = email;
            Username = name;
            Password = password;
            Role = role;
            IsDeleted = false;
            PictureData = image;
        }

        

    }
}