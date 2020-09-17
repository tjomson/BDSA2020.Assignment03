using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BDSA2020.Assignment03.Entities
{
    public class User
    {
        public int Id {get; set;}
        [Required]
        [StringLength(100)]
        public string Title {get; set; }
        [Required]
        [StringLength(100)]
        public string Email {get; set; }
        public ICollection<Task> Tasks {get; set; }

    }
}
