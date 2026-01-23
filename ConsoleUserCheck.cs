using System;

namespace AbsoluteCinema
{
    class ConsoleUserCheck
    {
        public static User Register()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Admin? (yes/no)");
            string role = Console.ReadLine();

            if (role.ToLower() == "yes")
                return new Admin(name, id);

            return new User(name, id);
        }
    }
}
