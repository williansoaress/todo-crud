namespace TodoCrud.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DueDate { get; set; }
        public bool IsComplete { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
