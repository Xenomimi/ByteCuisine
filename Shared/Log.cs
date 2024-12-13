using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ByteCuisine.Shared
{
    [Table("Log", Schema = "ByteCuisine")]
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ActivityTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string ActivityName { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
