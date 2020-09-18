using System.ComponentModel.DataAnnotations;

namespace BDSA2020.Assignment03.Entities
{
    public class Tag
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [StringLength(100)]
        public string Title {get; set;}
        
    }
}
