namespace TaskTrackerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    enum Priority
    {
        LOW,
        MEDIUM,
        HIGH
    }

    public enum Status
    {
        PENDING,
        INPROGRESS,
        COMPLETED
    }

    class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Task(int id, string title, string description, DateTime dueDate, Priority priority, Status status)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }

        public override string ToString()
        {
            string overdue = (Status != Status.COMPLETED && DueDate < DateTime.Today) ? " (OVERDUE!)" : "";
            return $"[ID: {Id}] {Title}{overdue}\n" +
                   $"  Description: {Description}\n" +
                   $"  Due: {DueDate:yyyy-MM-dd} | Priority: {Priority} | Status: {Status}\n";

        }


    }


    class TaskManager
    {
        List<Task> tasks = new List<Task>();

        public void Add(int id, string title, string description, DateTime dueDate, Priority priority, Status status)
        {
            Task task = new Task(id, title, description, dueDate, priority, status);
            tasks.Add(task);
        }
        public void Delete(int idOfTask)
        {
            if (idOfTask - 1 < 0 | idOfTask - 1 > tasks.Count)
            {
                Console.WriteLine("This Task isn't found.");
                return;
            }
            tasks.RemoveAt(idOfTask - 1);
        }
        public void Update(int idOfTask, Task newTask)
        {
            for (int i=0;i<tasks.Count;i++)
            {
                if (tasks[i].Id == idOfTask)
                {
                    tasks.RemoveAt(i);
                    tasks[i] = newTask;
                    return;
                }
            }
            Console.WriteLine("Id Of Task isn't Found then can't addition new task.");
        }
        public void Veiw()
        {

        }
        public void Exit()
        {

        }

    }


}
