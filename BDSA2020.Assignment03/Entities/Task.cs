using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2020.Assignment03.Entities
{
    public class Task
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [StringLength(100)]
        public string Title {get; set;}
        public User? AssignedTo {get; set;}
        [StringLength(100)]
        public string? Description {get; set;}
        [Required]
        public State State {get; set;}
        public ICollection<Tag> Tags {get; set;}
    }

    public enum State{
        NEW,ACTIVE,RESOLVED,CLOSED,REMOVED
    }
}
