namespace BDSA2020.Assignment03.Entities
{
    public class Task
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public User? AssignedTo {get; set;}
        public string? Description {get; set;}
        public State State {get; set;}
    }

    public enum State{
        NEW,ACTIVE,RESOLVED,CLOSED,REMOVED
    }
}
