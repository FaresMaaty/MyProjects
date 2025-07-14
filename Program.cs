namespace TaskTrackerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            int id;
            string title;
            string description;
            DateTime dueDate;
            Priority _Priority = Priority.LOW;
            Status _Status = Status.PENDING;
            string choice = "1-Add\n2-Update\n3-Delete\n4-Veiw\n5-Exit";
            while (true)
            {
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "add":
                        
                        (id, title, description, dueDate) = TaskDetails();
                        _Priority = PriorityDetail();
                        _Status = StatusDetail();
                        Task task = new Task(id, title, description, dueDate, _Priority, _Status);
                        taskManager.Add(task);
                        break;
                    case "delete":
                        int idOfOldTask = int.Parse(Console.ReadLine());
                        taskManager.Delete(idOfOldTask);
                        break;

                    case "update":
                        idOfOldTask = int.Parse(Console.ReadLine());
                        (id, title, description, dueDate) = TaskDetails();
                        _Priority = PriorityDetail();
                        _Status = StatusDetail();
                        Task newTask = new Task(id, title, description, dueDate, _Priority, _Status);
                        taskManager.Update(idOfOldTask, newTask);

                        break;

                    case "veiw":
                        taskManager.Veiw();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("this status not correct.");
                        return;
                }
            }
        }

        static (int id, string title, string description, DateTime dueDate) TaskDetails()
        {
            Console.WriteLine("Enter ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter DueDate(Year-Month-Day):");
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime dueDate = new DateTime(year, month, day);

            return (id, title, description, dueDate);
        }
        static Status StatusDetail()
        {
            Status _Status = Status.PENDING;
            Console.WriteLine("Enter Status (PENDING or INPROGRESS or COMPLETED):");
            string status = Console.ReadLine().ToUpper();
            switch (status)                  
            {
                case "PENDING":
                    _Status = Status.PENDING;
                    break;
                case "INPROGRESS":
                    _Status = Status.INPROGRESS;
                    break;
                case "COMPLETED":
                    _Status = Status.COMPLETED;
                    break;
                default:
                    Console.WriteLine("this status not correct.");
                    break;
            }
            return _Status;
        }
        static Priority PriorityDetail()
        {
            Priority _Priority = Priority.LOW;
            Console.WriteLine("Enter Priority (LOW or MEDIUM or HIGH):");
            string priority = Console.ReadLine().ToUpper();
            switch (priority)
            {
                case "LOW":
                    _Priority = Priority.LOW;
                    break;
                case "MEDIUM":
                    _Priority = Priority.MEDIUM;
                    break;
                case "HIGH":
                    break;
                default:
                    Console.WriteLine("this status not correct.");
                    break;
            }

            return _Priority;
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
                   $"  description: {Description}\n" +
                   $"  Due: {DueDate:yyyy-MM-dd} | _Priority: {Priority} | _Status: {Status}\n";
        }


    }


    class TaskManager
    {
        List<Task> tasks = new List<Task>();

        public void Add(Task task)
        {
            tasks.Add(task);
        }
        public void Delete(int idOfTask)
        {

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == idOfTask)
                {
                    tasks.RemoveAt(i);
                    return;
                }

            }
            Console.WriteLine("This Task isn't found.");
        }
        public void Update(int idOfOldTask, Task newTask)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == idOfOldTask)
                {
                    tasks[i] = newTask;
                    return;
                }
            }
            Console.WriteLine("id Of Task isn't Found then can't addition new task.");
        }
        public void Veiw()
        {
            if (tasks.Count != 0)
            {
                foreach (Task task in tasks)
                {
                    Console.WriteLine(task);
                }
            }
            else
            {
                Console.WriteLine("Not Found Any Tasks...");
            }
        }
        public void Exit()
        {
            return;
        }

    }


}
