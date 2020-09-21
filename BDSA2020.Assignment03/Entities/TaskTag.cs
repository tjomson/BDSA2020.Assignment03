using System.ComponentModel.DataAnnotations;

namespace BDSA2020.Assignment03.Entities
{
    // Join entity required for n:n mapping between Task and Tag
    public class TaskTag
    {
        [Required]
        public int TagId {get; set;}
        public int TaskId {get; set;}
    }
}