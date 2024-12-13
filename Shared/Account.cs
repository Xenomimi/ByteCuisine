using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("Account", Schema = "ByteCuisine")]
    public class Account
    {
        [Key]  
        public int User_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] PictureData { get; set; }
        public virtual ICollection<IngredientsInFridge> IngredientsInFridge { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
