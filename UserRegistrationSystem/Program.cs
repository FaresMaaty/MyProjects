namespace _1Challenge
{
    internal class Program
    {
        static Dictionary<string, User> users = new Dictionary<string, User>();

        static void Main(string[] args)
        {
           
            Console.WriteLine("Please Choice:");
            Console.WriteLine("**************");
            while (true)
            {
                Console.WriteLine("1.Register");
                Console.WriteLine("2.Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choice is  ");

                string choice = Console.ReadLine();
                Console.WriteLine("**************");
                switch (choice)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        LoginUser();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("invalid choice.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter UserName: ");
            string username = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // التحقق إذا كان المستخدم موجودًا بالفعل
            if (users.ContainsKey(email))
            {
                Console.WriteLine("This email is already registered❌");
                return;
            }

            // إضافة المستخدم إلى القاموس
            users[email] = new User { Username = username, Password = password };

            Console.WriteLine("The account has been registered successfully!");
        }

        static void LoginUser()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            // التحقق من وجود المستخدم وكلمة السر
            if (users.ContainsKey(email) && users[email].Password == password)
            {
                Console.WriteLine($"{users[email].Username}");
            }
            else
            {
                Console.WriteLine("The email or password is incorrect.");
            }
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
