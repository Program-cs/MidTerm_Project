using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<LoginUser> users = new List<LoginUser>

            { new LoginUser("Admin", "admin123"),
              new LoginUser("Vatta", "vatta123")
            };

            Console.WriteLine("————————Log In System———————-");
            Console.Write("User Name : ");
            string username = Console.ReadLine();
            Console.Write("Password  : ");
            string password = Console.ReadLine();

            bool isLoggedIn = false;
            string loggedInUser = "";

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].UserName.ToLower() == username.ToLower() && users[i].Password == password)
                {
                    isLoggedIn = true;
                    loggedInUser = users[i].UserName;
                    break;
                }
            }

            if (isLoggedIn)
            {
                Console.WriteLine("\nLogin Successful!\n");
                ShowMainMenu(loggedInUser);
            }
            else
            {
                Console.WriteLine("\nInvalid Username or Password.");
            }
        }

        static void ShowMainMenu(string currentUser)
        {
            int option = 0;
            do
            {
                Console.WriteLine("——————POS System—————————");

                if (currentUser.ToLower() == "admin")
                {
                    Console.WriteLine("1. User Management");
                    Console.WriteLine("2. Role Management");
                    Console.WriteLine("3. Product Management");
                    Console.WriteLine("4. Category Management");
                    Console.WriteLine("5. Supplier Management");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("—————————————————————");
                    Console.Write("Please choose option: ");

                    option = int.Parse(Console.ReadLine());
                }


                if (currentUser.ToLower() == "vatta")
                {
                    Console.WriteLine("1. Product Management");
                    Console.WriteLine("2. Category Management");
                    Console.WriteLine("3. Supplier Management");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("—————————————————————");
                    Console.Write("Please choose option: ");

                    option = int.Parse(Console.ReadLine());
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n[User Management module]\n");
                        break;
                    case 2:
                        Console.WriteLine("\n[Role Management module]\n");
                        break;
                    case 3:
                        Console.WriteLine("\n[Product Management module]\n");
                        break;
                    case 4:
                        Console.WriteLine("\n[Category Management module]\n");
                        break;
                    case 5:
                        Console.WriteLine("\n[Supplier Management module]\n");
                        break;
                    case 6:
                        Console.WriteLine("\nExiting POS System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option! Please try again.\n");
                        break;
                }
            } while (option != 6);
        }


        }
    }
