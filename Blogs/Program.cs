using Blogs.Models;
using Blogs.Services;
using System.Threading.Channels;

namespace Blogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Name, Surname, Username, Password: ");
                        User user = new User()
                        {
                            Name = Console.ReadLine(),
                            Surname = Console.ReadLine(),
                            Username = Console.ReadLine(),
                            Password = Console.ReadLine()
                        };
                        UserServices.Register(user);
                        break;
                    case 2:
                        bool answer = UserServices.Login();
                        if (answer == true)
                        {
                            Console.WriteLine("1. Users");
                            Console.WriteLine("2. Blogs");
                            int choice1 = Convert.ToInt32(Console.ReadLine());
                            switch (choice1)
                            {
                                case 1:
                                    Console.WriteLine("1. Edit Users");
                                    Console.WriteLine("2. Delete Users");
                                    int choice2 = Convert.ToInt32(Console.ReadLine());
                                    switch (choice2)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter the id of the user you want to edit: ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            User user1 = new User()
                                            {
                                                Name = Console.ReadLine(),
                                                Surname = Console.ReadLine(),
                                                Username = Console.ReadLine(),
                                                Password = Console.ReadLine()
                                            };
                                            UserServices.Edit(id, user1);
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter the id of the user you want to delete: ");
                                            int id1 = Convert.ToInt32(Console.ReadLine());
                                            UserServices.Delete(id1);
                                            break;
                                        default:
                                            Console.WriteLine("Wrong Input!");
                                            break;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("1. Create Blog");
                                    Console.WriteLine("2. Delete Blog");
                                    Console.WriteLine("3. Update Blog");
                                    Console.WriteLine("4. Get all blogs");
                                    Console.WriteLine("5. Get blog by id");
                                    Console.WriteLine("6. Get blog by where");
                                    int choice3 = Convert.ToInt32(Console.ReadLine());
                                    switch (choice3)
                                    {
                                        case 1:
                                            BlogServices blogServices1 = new BlogServices();
                                            Blog blog = new Blog()
                                            {
                                                Title = Console.ReadLine(),
                                                Description = Console.ReadLine(),
                                                UserId = Convert.ToInt32(Console.ReadLine())
                                            };
                                            blogServices1.Create(blog);
                                            break;
                                        case 2:
                                            BlogServices blogServices2 = new BlogServices();
                                            Console.WriteLine("Enter the id of the blog you want to delete: ");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            blogServices2.Delete(id);
                                            break;
                                        case 3:
                                            BlogServices blogServices3 = new BlogServices();
                                            Console.WriteLine("Enter the id of the blog you want to update: ");
                                            int id1 = Convert.ToInt32(Console.ReadLine());
                                            Blog blog1 = new Blog()
                                            {
                                                Title = Console.ReadLine(),
                                                Description = Console.ReadLine(),
                                                UserId = Convert.ToInt32(Console.ReadLine())
                                            };
                                            blogServices3.Update(id1, blog1);
                                            break;
                                        case 4:
                                            BlogServices blogServices4 = new BlogServices();
                                            blogServices4.GetAll();
                                            break;
                                        case 5:
                                            BlogServices blogServices5 = new BlogServices();
                                            Console.WriteLine("Enter the id of the blog you want to get: ");
                                            int id3 = Convert.ToInt32(Console.ReadLine());
                                            blogServices5.GetById(id3);
                                            break;
                                        case 6:
                                            Console.WriteLine("Get blog by where nece yazim bilmedimmm");
                                            break;
                                        default:
                                            Console.WriteLine("Wrong Input!");
                                            break;
                                    }
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong Input!");
                        break;
                }
            }
        }
    }
}